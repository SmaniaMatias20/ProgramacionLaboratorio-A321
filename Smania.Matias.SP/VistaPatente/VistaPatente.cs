using System;
using System.Windows.Forms;
using System.Threading;
using Entidades;
using System.Threading.Tasks;
using System.Collections.Generic;

namespace Patentes
{
    /// <summary>
    /// Delegado para el evento que indica la finalización de la exposición de una patente en la vista.
    /// </summary>
    /// <param name="vistaPatente">La vista de la patente que ha finalizado la exposición.</param>
    public delegate void FinExposicionPatente(VistaPatente vistaPatente);

    /// <summary>
    /// Delegado para el método que muestra una patente.
    /// </summary>
    /// <param name="patente">El objeto que representa la patente a mostrar.</param>
    public delegate void MostrarPatente(object patente);

    public partial class VistaPatente : UserControl
    {
        /// <summary>
        /// Evento que se dispara al finalizar la exposición de una patente en la vista.
        /// </summary>
        public event FinExposicionPatente finExposicion;

        /// <summary>
        /// Inicializa una nueva instancia de la clase VistaPatente.
        /// </summary>
        public VistaPatente()
        {
            InitializeComponent();
            picPatente.Image = fondosPatente.Images[(int)ETipo.Mercosur];
        }

        /// <summary>
        /// Muestra la patente en la interfaz de usuario.
        /// </summary>
        /// <param name="patente">La patente a mostrar.</param>
        public void MostrarPatente(object patente)
        {
            if (lblPatenteNro.InvokeRequired)
            {
                try
                {
                    // Llama al hilo principal para actualizar la interfaz de usuario.
                    this.Invoke(new MostrarPatente(MostrarPatente), new object[] { patente });

                    // Simula un tiempo de exposición de la patente
                    Thread.Sleep(1500);

                    // Dispara el evento de que finalizó la exposición de la patente.
                    if (finExposicion != null)
                    {
                        finExposicion(this);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
            else
            {
                picPatente.Image = fondosPatente.Images[(int)((Patente)patente).TipoCodigo];
                lblPatenteNro.Text = patente.ToString();

                // Simula un tiempo de exposición de la patente
                Task.Run(() =>
                {
                    Thread.Sleep(1500);

                    // Dispara el evento de que finalizó la exposición de la patente.
                    if (finExposicion != null)
                    {
                        finExposicion(this);
                    }
                });
            }



        }
    }
}
