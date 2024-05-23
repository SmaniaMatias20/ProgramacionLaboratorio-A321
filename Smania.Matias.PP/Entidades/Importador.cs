using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public class Importador : Comercio
    {
        // Atributos 
        private EPaises _paisOrigen;

        /// <summary>
        /// Constructor por defecto de la clase Importador.
        /// </summary>
        public Importador() 
        { 
        }

        /// <summary>
        /// Constructor de la clase Importador que inicializa una nueva instancia con el nombre del comercio, el precio de alquiler, el comerciante y el país de origen.
        /// </summary>
        /// <param name="nombreComercio">El nombre del comercio.</param>
        /// <param name="precioAlquiler">El precio de alquiler del comercio.</param>
        /// <param name="comerciante">El comerciante asociado al comercio.</param>
        /// <param name="paisOrigen">El país de origen de los productos importados.</param>
        public Importador(string nombreComercio, float precioAlquiler, Comerciante comerciante, EPaises paisOrigen) : base(nombreComercio, comerciante, precioAlquiler) 
        { 
            _paisOrigen = paisOrigen;
        }

        /// <summary>
        /// Devuelve una cadena con los detalles del importador, incluyendo los detalles del comercio y el país de origen.
        /// </summary>
        /// <returns>Una cadena que representa los detalles del importador.</returns>
        public string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append((string)this);  //
            stringBuilder.AppendLine($"Pais: {_paisOrigen}");

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad para comparar dos objetos de tipo Importador.
        /// </summary>
        /// <param name="i1">El primer objeto Importador a comparar.</param>
        /// <param name="i2">El segundo objeto Importador a comparar.</param>
        /// <returns>True si los países de origen y los detalles del comercio de los dos importadores son iguales, de lo contrario False.</returns>
        public static bool operator ==(Importador i1, Importador i2)
        {
            return i1._paisOrigen == i2._paisOrigen && (Comercio)i1 == (Comercio)i2;
        }

        /// <summary>
        /// Sobrecarga del operador de desigualdad para comparar dos objetos de tipo Importador.
        /// </summary>
        /// <param name="i1">El primer objeto Importador a comparar.</param>
        /// <param name="i2">El segundo objeto Importador a comparar.</param>
        /// <returns>True si los países de origen o los detalles del comercio de los dos importadores son diferentes, de lo contrario False.</returns>
        public static bool operator !=(Importador i1, Importador i2)
        {
            return !(i1 == i2);
        }

        /// <summary>
        /// Sobrecarga del operador de conversión implícita para convertir un objeto Importador a su país de origen EPaises.
        /// </summary>
        /// <param name="importador">El objeto Importador a convertir.</param>
        /// <returns>El país de origen del importador.</returns>
        public static implicit operator EPaises(Importador importador)
        {
            return importador._paisOrigen;
        }

    }
}
