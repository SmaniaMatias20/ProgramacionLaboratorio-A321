using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public class Exportador : Comercio
    {
        // Atributos 
        private ETipoProducto _tipo;

        /// <summary>
        /// Constructor por defecto de la clase Exportador.
        /// </summary>
        public Exportador() { }

        /// <summary>
        /// Constructor de la clase Exportador que inicializa una nueva instancia con el nombre del comercio, el precio de alquiler, el comerciante y el tipo de producto.
        /// </summary>
        /// <param name="nombreComercio">El nombre del comercio.</param>
        /// <param name="precioAlquiler">El precio de alquiler del comercio.</param>
        /// <param name="comerciante">El comerciante asociado al comercio.</param>
        /// <param name="tipo">El tipo de producto del exportador.</param>
        public Exportador(string nombreComercio, float precioAlquiler, Comerciante comerciante, ETipoProducto tipo) : base (nombreComercio, comerciante, precioAlquiler) 
        { 
            _tipo = tipo;
        }

        /// <summary>
        /// Devuelve una cadena con los detalles del exportador, incluyendo los detalles del comercio y el tipo de producto.
        /// </summary>
        /// <returns>Una cadena que representa los detalles del exportador.</returns>
        public string Mostrar() 
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.Append((string)this);  
            stringBuilder.AppendLine($"Tipo: {_tipo}");

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad para comparar dos objetos de tipo Exportador.
        /// </summary>
        /// <param name="e1">El primer objeto Exportador a comparar.</param>
        /// <param name="e2">El segundo objeto Exportador a comparar.</param>
        /// <returns>True si los tipos de producto y los detalles del comercio de los dos exportadores son iguales, de lo contrario False.</returns>
        public static bool operator ==(Exportador e1, Exportador e2)
        {
            return e1._tipo == e2._tipo && (Comercio)e1 == (Comercio)e2;
        }

        /// <summary>
        /// Sobrecarga del operador de desigualdad para comparar dos objetos de tipo Exportador.
        /// </summary>
        /// <param name="e1">El primer objeto Exportador a comparar.</param>
        /// <param name="e2">El segundo objeto Exportador a comparar.</param>
        /// <returns>True si los tipos de producto o los detalles del comercio de los dos exportadores son diferentes, de lo contrario False.</returns>
        public static bool operator !=(Exportador e1, Exportador e2)
        {
            return !(e1 == e2);
        }

        /// <summary>
        /// Sobrecarga del operador de conversión implícita para convertir un objeto Exportador a su tipo de producto ETipoProducto.
        /// </summary>
        /// <param name="exportador">El objeto Exportador a convertir.</param>
        /// <returns>El tipo de producto del exportador.</returns>
        public static implicit operator ETipoProducto(Exportador exportador)
        {
            return exportador._tipo;
        }
    }
}
