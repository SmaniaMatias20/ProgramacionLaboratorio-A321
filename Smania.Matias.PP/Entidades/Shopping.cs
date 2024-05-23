using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Entidades

{
    [XmlInclude(typeof(Shopping))]
    [XmlInclude(typeof(Comercio))]
    [XmlInclude(typeof(Importador))]
    [XmlInclude(typeof(Exportador))]
    [XmlInclude(typeof(Comerciante))]
    [XmlInclude(typeof(Enum))]
    public class Shopping
    {
        // Atributos
        private int _capacidadMaxima;
        private List<Comercio> _comercios;

        // Propiedades
        public double PrecioDeExportadores
        {
            get { return ObtenerPrecio(EComercios.Exportador); }
            set {  }
        }

        public double PrecioDeImportadores
        {
            get { return ObtenerPrecio(EComercios.Importador); }
            set { }
        }

        public double PrecioTotal
        {
            get { return PrecioDeExportadores + PrecioDeImportadores; }
            set {}
        }

        public int CapacidadMaxima 
        {
            get { return _capacidadMaxima; }
            set { }
        }

        public List<Comercio> Comercios
        {
            get { return _comercios; }
            set { }
        }

        /// <summary>
        /// Constructor privado de la clase Shopping que inicializa una nueva instancia con una lista de comercios vacía.
        /// </summary>
        private Shopping()
        {
            _comercios = new List<Comercio>();
        }

        /// <summary>
        /// Constructor privado de la clase Shopping que inicializa una nueva instancia con una capacidad máxima especificada y una lista de comercios vacía.
        /// </summary>
        /// <param name="capacidadMaxima">La capacidad máxima del shopping.</param>
        private Shopping(int capacidadMaxima) : this()
        {
            _capacidadMaxima = capacidadMaxima;
        }

        /// <summary>
        /// Genera una representación de texto del shopping, incluyendo su capacidad máxima, los totales por importadores y exportadores, el precio total y una lista de todos los comercios incluidos en el shopping.
        /// </summary>
        /// <param name="shopping">El shopping a mostrar.</param>
        /// <returns>Una cadena que representa los detalles del shopping.</returns>
        public static string Mostrar(Shopping shopping)
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"\nCapacidad del shopping: {shopping._capacidadMaxima}");
            stringBuilder.AppendLine($"Total por Importadores: ${shopping.PrecioDeImportadores}");
            stringBuilder.AppendLine($"Total por Exportadores: ${shopping.PrecioDeExportadores}");
            stringBuilder.AppendLine($"Total: ${shopping.PrecioTotal}");

            stringBuilder.AppendLine("********************");
            stringBuilder.AppendLine("Listado de comercios");
            stringBuilder.AppendLine("********************");


            foreach (Comercio comercio in shopping._comercios)
            {
                if (comercio is Exportador)
                {

                    Exportador exportador = (Exportador)comercio;
                    stringBuilder.AppendLine(exportador.Mostrar());

                }
                else if (comercio is Importador)
                {
 
                    Importador importador = (Importador)comercio;
                    stringBuilder.AppendLine(importador.Mostrar());

                }


            }



            return stringBuilder.ToString();
        }

        /// <summary>
        /// Sobrecarga del operador de conversión implícita para convertir un entero en una instancia de la clase Shopping con la capacidad máxima especificada.
        /// </summary>
        /// <param name="capacidad">La capacidad máxima del shopping.</param>
        /// <returns>Una instancia de la clase Shopping con la capacidad máxima especificada.</returns>
        public static implicit operator Shopping(int capacidad)
        {
            return new Shopping(capacidad);
        }

        /// <summary>
        /// Sobrecarga del operador de igualdad para determinar si un comercio está contenido en la lista de comercios de un shopping.
        /// </summary>
        /// <param name="shopping">El shopping en el que buscar.</param>
        /// <param name="comercio">El comercio a buscar.</param>
        /// <returns>True si el comercio está contenido en la lista de comercios del shopping, de lo contrario False.</returns>
        public static bool operator ==(Shopping shopping, Comercio comercio)
        {
            return shopping._comercios.Contains(comercio);

        }

        /// <summary>
        /// Sobrecarga del operador de desigualdad para determinar si un comercio no está contenido en la lista de comercios de un shopping.
        /// </summary>
        /// <param name="shopping">El shopping en el que buscar.</param>
        /// <param name="comercio">El comercio a buscar.</param>
        /// <returns>True si el comercio no está contenido en la lista de comercios del shopping, de lo contrario False.</returns>
        public static bool operator !=(Shopping shopping, Comercio comercio)
        {
            return !(shopping == comercio);
        }

        /// <summary>
        /// Sobrecarga del operador de adición para agregar un comercio a la lista de comercios de un shopping.
        /// </summary>
        /// <param name="shopping">El shopping al que agregar el comercio.</param>
        /// <param name="comercio">El comercio a agregar.</param>
        /// <returns>El shopping con el comercio agregado, si se pudo agregar, o el shopping original.</returns>
        public static Shopping operator +(Shopping shopping, Comercio comercio)
        {
            if (shopping != comercio)
            {
                if (shopping._capacidadMaxima > shopping._comercios.Count)
                {
                    shopping._comercios.Add(comercio);
                    return shopping;
                }
                else
                {
                    Console.WriteLine("No hay mas lugar en el shopping!!!");
                    return shopping;
                }


            }
            else
            {
                Console.WriteLine("El comercio ya esta en el shopping!!!");
                return shopping;
            }

        }

        /// <summary>
        /// Calcula el precio total de todos los comercios de un determinado tipo en el shopping.
        /// </summary>
        /// <param name="tipo">El tipo de comercio para el cual calcular el precio total.</param>
        /// <returns>El precio total de todos los comercios del tipo especificado en el shopping.</returns>
        private double ObtenerPrecio(EComercios tipo) 
        {
            double valorTotal = 0;

            foreach (Comercio comercio in _comercios)
            {
                if (comercio.GetType().Name == tipo.ToString())
                {
                    valorTotal += comercio.PrecioAlquiler;
                }


            }

            return valorTotal;  
        }

        /// <summary>
        /// Guarda los detalles del shopping en un archivo de texto en la ruta especificada.
        /// </summary>
        /// <param name="rutaArchivo">La ruta del archivo en la que guardar los detalles del shopping.</param>
        public void GuardarShopping(string rutaArchivo)
        {
            if (!File.Exists(rutaArchivo))
            {
                using (FileStream fileStream = File.Create(rutaArchivo))
                {
                    fileStream.Close();
                }
            }

            using (StreamWriter streamWriter = new StreamWriter(rutaArchivo))
            {
                streamWriter.WriteLine(Mostrar(this));
            }

        }

        /// <summary>
        /// Serializa el objeto Shopping en formato XML y lo guarda en un archivo en la ruta especificada.
        /// </summary>
        /// <param name="rutaArchivo">La ruta del archivo en la que guardar la serialización XML del objeto Shopping.</param>
        public void SerializarShopping(string rutaArchivo)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shopping));

            using (StreamWriter streamWriter = new StreamWriter(rutaArchivo))
            {
                xmlSerializer.Serialize(streamWriter, this);
            }
        }

        /// <summary>
        /// Lee un archivo XML que contiene la representación serializada de un objeto Shopping, lo deserializa y devuelve un objeto Shopping reconstruido.
        /// </summary>
        /// <param name="rutaArchivo">La ruta del archivo que contiene la serialización XML del objeto Shopping.</param>
        /// <returns>Un objeto Shopping reconstruido a partir de la serialización XML.</returns>
        public static Shopping DeserializarShopping(string rutaArchivo)
        {
            XmlSerializer xmlSerializer = new XmlSerializer(typeof(Shopping));

            using (StreamReader streamReader = new StreamReader(rutaArchivo))
            {
                return (Shopping)xmlSerializer.Deserialize(streamReader);
            }
        }


    }
}
