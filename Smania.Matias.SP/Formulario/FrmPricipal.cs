using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using Entidades;
using Archivo;
using System.Threading;
using Patentes;
using System.IO;
using System.Xml.Serialization;

namespace Formulario
{
    /// <summary>
    /// Formulario principal para la gestión de patentes.
    /// </summary>
    public partial class FrmPricipal : Form
    {
        List<Patente> patentes;
        List<Thread> listaThreads;

        /// <summary>
        /// Inicializa una nueva instancia de la clase <see cref="FrmPricipal"/>.
        /// </summary>
        public FrmPricipal()
        {
            InitializeComponent();
            patentes = new List<Patente>();
            listaThreads = new List<Thread>();
        }

        /// <summary>
        /// Manejador del evento Load del formulario.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FrmPricipal_Load(object sender, EventArgs e)
        {
            // Crear una instancia de VistaPatente
            VistaPatente vistaPatente = new VistaPatente();

            // Asociar el evento finExposicion con ProximaPatente
            vistaPatente.finExposicion += ProximaPatente;

            // Agregar vistaPatente al formulario (suponiendo que es un UserControl)
            Controls.Add(vistaPatente);

        }

        /// <summary>
        /// Manejador del evento FormClosing del formulario.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void FrmPricipal_FormClosing(object sender, FormClosingEventArgs e)
        {
            FinalizarSimulacion();
        }

        /// <summary>
        /// Manejador del evento Click del botón para agregar más patentes.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnMas_Click(object sender, EventArgs e)
        {
            try
            {
                List<Patente> listPatente = new List<Patente>
                {
                    new Patente("CP709WA", ETipo.Mercosur),
                    new Patente("DIB009", ETipo.Vieja),
                    new Patente("FD010GC", ETipo.Mercosur)
                };

                // Guardar en la base de datos SQL
                Sql sqlArchivo = new Sql(); 
                bool guardadoSql = sqlArchivo.Guardar(listPatente);

                if (guardadoSql)
                {
                    MessageBox.Show("¡Patentes guardadas en la base de datos!");
                }
                else
                {
                    MessageBox.Show("¡Error al guardar en la base de datos!");
                }

                // Guardar en archivo XML
                Xml xmlArchivo = new Xml();
                bool guardadoXml = xmlArchivo.Guardar(listPatente);

                if (guardadoXml)
                {
                    MessageBox.Show("¡Patentes guardadas en el archivo XML!");
                }
                else
                {
                    MessageBox.Show("¡Error al guardar en el archivo XML!");
                }

                // Guardar en archivo de texto
                Texto textoArchivo = new Texto();
                bool guardadoTexto = textoArchivo.Guardar(listPatente);

                if (guardadoTexto)
                {
                    MessageBox.Show("¡Patentes guardadas en el archivo de texto!");
                }
                else
                {
                    MessageBox.Show("¡Error al guardar en el archivo de texto!");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        /// <summary>
        /// Manejador del evento Click del botón para leer patentes desde la base de datos SQL.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnSql_Click(object sender, EventArgs e)
        {
            try
            {
                // Instanciar la clase Sql que implementa la interfaz IArchivo
                IArchivo sqlArchivo = new Sql();

                // Leer patentes desde la base de datos SQL
                List<Patente> patentesDesdeSql = sqlArchivo.Leer();

                // Verificar si se han leído patentes correctamente
                if (patentesDesdeSql.Count > 0)
                {
                    // Agregar las patentes leídas desde SQL a la lista principal
                    patentes.AddRange(patentesDesdeSql);

                    // Iniciar la simulación
                    IniciarSimulacion();
                }
                else
                {
                    MessageBox.Show("No se encontraron patentes en la base de datos SQL.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer las patentes desde la base de datos SQL: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

    

        /// <summary>
        /// Manejador del evento Click del botón para leer patentes desde un archivo XML.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnXml_Click(object sender, EventArgs e)
        {
            try
            {
                // Instanciar la clase Xml que implementa la interfaz IArchivo
                IArchivo xmlArchivo = new Xml();

                // Leer patentes desde el archivo XML
                List<Patente> patentesDesdeXml = xmlArchivo.Leer();

                // Verificar si se han leído patentes correctamente
                if (patentesDesdeXml.Count > 0)
                {
                    // Agregar las patentes leídas desde XML a la lista principal
                    patentes.AddRange(patentesDesdeXml);

                    // Iniciar la simulación
                    IniciarSimulacion();
                }
                else
                {
                    MessageBox.Show("No se encontraron patentes en el archivo XML.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer las patentes desde el archivo XML: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Manejador del evento Click del botón para leer patentes desde un archivo de texto.
        /// </summary>
        /// <param name="sender">El origen del evento.</param>
        /// <param name="e">Los datos del evento.</param>
        private void btnTxt_Click(object sender, EventArgs e)
        {
            try
            {
                // Instanciar la clase Texto que implementa la interfaz IArchivo
                IArchivo txtArchivo = new Texto();

                // Leer patentes desde el archivo de texto
                List<Patente> patentesDesdeTxt = txtArchivo.Leer();

                // Verificar si se han leído patentes correctamente
                if (patentesDesdeTxt.Count > 0)
                {
                    // Agregar las patentes leídas desde el archivo de texto a la lista principal
                    patentes.AddRange(patentesDesdeTxt);

                    // Iniciar la simulación
                    IniciarSimulacion();

                }
                else
                {
                    MessageBox.Show("No se encontraron patentes válidas en el archivo de texto.",
                                    "Advertencia", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error al leer las patentes desde el archivo de texto: " + ex.Message,
                                "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        /// <summary>
        /// Inicia la simulación de visualización de patentes.
        /// </summary>
        private void IniciarSimulacion()
        {
            // Implementar el método FinalizarSimulación
            // que se encarga de finalizar todos los hilos activos
            FinalizarSimulacion();
            ProximaPatente(vistaPatente);
        }

        /// <summary>
        /// Muestra la próxima patente en la vista.
        /// </summary>
        /// <param name="vistaPatente">La vista de la patente.</param>
        private void ProximaPatente(VistaPatente vistaPatente)
        {
            // Inicializará un hilo parametrizado para el método MostrarPatente del objeto VistaPatente recibido.
            Thread thread = new Thread(new ParameterizedThreadStart(vistaPatente.MostrarPatente));

            // Verificar si hay elementos en la lista de patentes
            if (patentes.Count > 0)
            {
                // Tomar el primer elemento de la lista de patentes
                Patente proximaPatente = patentes[0];

                // Eliminar la patente de la lista después de agregarla al hilo
                patentes.RemoveAt(0);

                // Inicializar el hilo con la próxima patente como parámetro
                thread.Start(proximaPatente);

                // Agregar el hilo a la lista de hilos
                listaThreads.Add(thread);
            }
            else
            {
                // Si no hay elementos en la lista de patentes, hacer algo según tu lógica (opcional)
                Console.WriteLine("No hay más patentes para mostrar.");
            }
        }

        /// <summary>
        /// Método para finalizar todos los hilos activos.
        /// </summary>
        private void FinalizarSimulacion()
        {
            foreach (Thread thread in listaThreads)
            {
                if (thread.IsAlive)
                {
                    thread.Abort(); // Aborta el hilo si aún está activo
                }
            }
        }
    }
}
