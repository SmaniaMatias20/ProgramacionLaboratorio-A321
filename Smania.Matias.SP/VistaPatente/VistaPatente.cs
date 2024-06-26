using System;
using System.Windows.Forms;
using System.Threading;
using Entidades;
using System.Threading.Tasks;

namespace Patentes
{
    // Definición de los delegados
    public delegate void FinExposicionPatente(VistaPatente vistaPatente);
    public delegate void MostrarPatente(object patente);

    public partial class VistaPatente : UserControl
    {
        public event FinExposicionPatente finExposicion;

        public VistaPatente()
        {
            InitializeComponent();
            picPatente.Image = fondosPatente.Images[(int)ETipo.Mercosur];
        }

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
                    // Manejar excepción
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
