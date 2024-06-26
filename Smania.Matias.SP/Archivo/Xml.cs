using Entidades;
using System;
using System.Collections.Generic;
using System.IO;
using System.Xml.Serialization;

namespace Archivo
{
    public class Xml : IArchivo
    {
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
                // Manejar excepción
                Console.WriteLine(ex.Message);
                return false;
            }
        }

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
                // Manejar excepción
                Console.WriteLine(ex.Message);
                return new List<Patente>();
            }
        }
    }
}
