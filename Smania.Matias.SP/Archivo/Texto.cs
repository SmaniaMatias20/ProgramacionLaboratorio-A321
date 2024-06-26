using Entidades;
using System;
using System.Collections.Generic;
using System.IO;

namespace Archivo
{
    public class Texto : IArchivo
    {
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
                // Manejar excepción
                Console.WriteLine(ex.Message);
                return false;
            }
        }

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
                        Patente patente = PatenteStringExtension.ValidarPatente(line);
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
