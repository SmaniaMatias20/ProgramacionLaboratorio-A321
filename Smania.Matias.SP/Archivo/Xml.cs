using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Archivo
{
    public class Xml : IArchivo
    {
        /// <summary>
        /// Guarda la lista de objetos Patente en un archivo XML en el escritorio del usuario.
        /// </summary>
        /// <param name="datos">Lista de objetos Patente a ser guardados.</param>
        /// <returns>true si se guardaron correctamente los datos; de lo contrario, false.</returns>
        public bool Guardar(List<Patente> datos)
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "patentes.xml");

                using (StreamWriter writer = new StreamWriter(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Patente>));
                    serializer.Serialize(writer, datos);
                }

                return true;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        /// <summary>
        /// Lee los datos de un archivo XML que contiene una lista de objetos Patente desde el escritorio del usuario.
        /// </summary>
        /// <returns>Lista de objetos Patente leídos desde el archivo XML.</returns>
        public List<Patente> Leer()
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "patentes.xml");

                using (StreamReader reader = new StreamReader(filePath))
                {
                    XmlSerializer serializer = new XmlSerializer(typeof(List<Patente>));
                    return (List<Patente>)serializer.Deserialize(reader);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                return new List<Patente>();
            }
        }
    }
}
