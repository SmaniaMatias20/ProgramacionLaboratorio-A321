using Entidades;
using System;
using System.Collections.Generic;
using System.IO;

namespace Archivo
{
    public class Texto : IArchivo
    {
        /// <summary>
        /// Guarda la lista de patentes en un archivo de texto en el escritorio.
        /// </summary>
        /// <param name="datos">Lista de objetos Patente a guardar.</param>
        /// <returns>true si se guardaron correctamente las patentes; false, si ocurrió un error.</returns>
        public bool Guardar(List<Patente> datos) 
        {
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "patentes.txt");

                using (StreamWriter writer = new StreamWriter(filePath, false))
                {
                    foreach (var patente in datos)
                    {
                        writer.WriteLine($"{patente.CodigoPatente},{patente.TipoCodigo}");
                    }
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
        /// Lee las patentes almacenadas en un archivo de texto en el escritorio.
        /// </summary>
        /// <returns>Lista de objetos Patente leídos desde el archivo.</returns>
        public List<Patente> Leer() 
        {
            List<Patente> patentes = new List<Patente>();
            try
            {
                string desktopPath = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
                string filePath = Path.Combine(desktopPath, "patentes.txt");

                using (StreamReader reader = new StreamReader(filePath))
                {
                    string line;
                    while ((line = reader.ReadLine()) != null)
                    {
                        string codigoPatente = line.Split(',')[0];

                        Patente patente = PatenteStringExtension.ValidarPatente(codigoPatente);
                        if (patente != null)
                        {
                            patentes.Add(patente);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            return patentes;

        }

    }
}
