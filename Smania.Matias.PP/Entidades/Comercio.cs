using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entidades
{
    public abstract class Comercio
    {
        // Atributos
        protected int _cantidadDeEmpleados;
        protected float _precioAlquiler;
        protected string _nombre;
        protected Comerciante _comerciante;
        protected static Random _generadorDeEmpleados;

        // Propiedades
        public int CantidadDeEmpleados
        {
            get
            {
                if (_cantidadDeEmpleados == 0)
                {
                    _cantidadDeEmpleados = _generadorDeEmpleados.Next(1, 100);
                   
                }
                return _cantidadDeEmpleados;
            }
            set
            {
                _cantidadDeEmpleados = value;
            }
        }

        public string Nombre
        {
            get { return _nombre; }
            set { _nombre = value; }
        }
        public float PrecioAlquiler
        {
            get { return _precioAlquiler; }
            set { _precioAlquiler = value; }
        }

        public Comerciante Comerciante
        {
            get { return _comerciante; }
            set { _comerciante = value; }
        }


        /// <summary>
        /// Constructor estático de la clase Comercio que inicializa el generador de empleados.
        /// </summary>
        static Comercio() 
        {
            _generadorDeEmpleados = new Random();
        }

        /// <summary>
        /// Constructor por defecto de la clase Comercio.
        /// </summary>
        public Comercio() { }

        /// <summary>
        /// Constructor de la clase Comercio que acepta un nombre, un comerciante y un precio de alquiler, y reutiliza otro constructor de la clase.
        /// </summary>
        /// <param name="nombre">El nombre del comercio.</param>
        /// <param name="comerciante">El comerciante asociado al comercio.</param>
        /// <param name="precioAlquiler">El precio de alquiler del comercio.</param>
        public Comercio(string nombre, Comerciante comerciante, float precioAlquiler)
        : this(precioAlquiler, nombre, comerciante.Nombre, comerciante.Apellido)
        {
            _comerciante = comerciante;
        }

        /// <summary>
        /// Constructor de la clase Comercio que acepta un precio de alquiler, un nombre de comercio, y el nombre y apellido del comerciante, inicializando las propiedades correspondientes.
        /// </summary>
        /// <param name="precioAlquiler">El precio de alquiler del comercio.</param>
        /// <param name="nombreComercio">El nombre del comercio.</param>
        /// <param name="nombre">El nombre del comerciante asociado al comercio.</param>
        /// <param name="apellido">El apellido del comerciante asociado al comercio.</param>
        public Comercio(float precioAlquiler, string nombreComercio, string nombre, string apellido) 
        {
            _nombre = nombreComercio;
            _comerciante = new Comerciante { Nombre = nombre, Apellido = apellido };
            _precioAlquiler = precioAlquiler;
        }

        /// <summary>
        /// Método privado que devuelve una cadena con los detalles del comercio.
        /// </summary>
        /// <returns>Una cadena que contiene el nombre del comercio, el nombre y apellido del comerciante, y la cantidad de empleados.</returns>
        private string Mostrar()
        {
            StringBuilder stringBuilder = new StringBuilder();
            stringBuilder.AppendLine($"Nombre: {_nombre}");
            stringBuilder.AppendLine($"Comerciante: {_comerciante.Nombre}, {_comerciante.Apellido}");
            stringBuilder.AppendLine($"Cantidad Empleados: {_cantidadDeEmpleados}");

            return stringBuilder.ToString();
        }

        /// <summary>
        /// Sobrecarga del operador de conversión explícita a string para obtener una representación en cadena del objeto Comercio.
        /// </summary>
        /// <param name="comercio">El objeto Comercio a convertir.</param>
        /// <returns>Una cadena que representa los detalles del comercio.</returns>
        public static explicit operator string(Comercio comercio)
        {
            return comercio.Mostrar();
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad para comparar dos objetos de tipo Comercio.
        /// </summary>
        /// <param name="c1">El primer objeto Comercio a comparar.</param>
        /// <param name="c2">El segundo objeto Comercio a comparar.</param>
        /// <returns>True si los nombres y los comerciantes de los dos comercios son iguales, de lo contrario False.</returns>
        public static bool operator ==(Comercio c1, Comercio c2)
        {
            return c1._nombre == c2._nombre && c1._comerciante == c2._comerciante;
        }


        /// <summary>
        /// Sobrecarga del operador de desigualdad para comparar dos objetos de tipo Comercio.
        /// </summary>
        /// <param name="c1">El primer objeto Comercio a comparar.</param>
        /// <param name="c2">El segundo objeto Comercio a comparar.</param>
        /// <returns>True si los nombres o los comerciantes de los dos comercios son diferentes, de lo contrario False.</returns>
        public static bool operator !=(Comercio c1, Comercio c2)
        {
            return !(c1 == c2);
        }

        /// <summary>
        /// Determina si el objeto especificado es igual al objeto actual.
        /// </summary>
        /// <param name="obj">El objeto a comparar con el objeto actual.</param>
        /// <returns>True si el objeto especificado es igual al objeto actual; de lo contrario, False.</returns>
        public override bool Equals(object obj)
        {
            // Reveer
            return obj is Comercio otroComercio && this == (Comercio)otroComercio;
        }






    }
}
