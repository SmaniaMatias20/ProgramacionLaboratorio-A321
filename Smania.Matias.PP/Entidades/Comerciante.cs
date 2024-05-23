using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Entidades
{
    public class Comerciante
    {
        // Atributos
        private string _apellido;
        private string _nombre;

        //Propiedades
        public string Apellido
        {
            get { return _apellido; }
            set { _apellido = value; }
        }
        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }

        /// <summary>
        /// Constructor por defecto de la clase Comerciante.
        /// </summary>
        public Comerciante()
        {
        }

        /// <summary>
        /// Constructor de la clase Comerciante que inicializa el nombre y el apellido del comerciante.
        /// </summary>
        /// <param name="nombre">El nombre del comerciante.</param>
        /// <param name="apellido">El apellido del comerciante.</param>
        public Comerciante(string nombre, string apellido)
        {
            _nombre = nombre;   
            _apellido = apellido;
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad para comparar dos objetos de tipo Comerciante.
        /// </summary>
        /// <param name="c1">El primer Comerciante a comparar.</param>
        /// <param name="c2">El segundo Comerciante a comparar.</param>
        /// <returns>True si los nombres y apellidos de los comerciantes son iguales, de lo contrario False.</returns>
        public static bool operator ==(Comerciante c1, Comerciante c2)
        {
            return c1.Nombre == c2.Nombre && c1.Apellido == c2.Apellido;
        }

        /// <summary>
        /// Sobrecarga del operador de desigualdad para comparar dos objetos de tipo Comerciante.
        /// </summary>
        /// <param name="c1">El primer Comerciante a comparar.</param>
        /// <param name="c2">El segundo Comerciante a comparar.</param>
        /// <returns>True si los nombres o apellidos de los comerciantes son diferentes, de lo contrario False.</returns>
        public static bool operator !=(Comerciante c1, Comerciante c2)
        {
            return !(c1 == c2);
        }

        /// <summary>
        /// Sobrecarga del operador de conversión implícita a string para obtener una representación en cadena del objeto Comerciante.
        /// </summary>
        /// <param name="comerciante">El objeto Comerciante a convertir.</param>
        /// <returns>Una cadena que representa el nombre y el apellido del comerciante.</returns>
        public static implicit operator string(Comerciante comerciante)
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Nombre: {comerciante.Nombre}");
            stringBuilder.AppendLine($"Apellido: {comerciante.Apellido}");

            return stringBuilder.ToString();    
        }

    }
}
