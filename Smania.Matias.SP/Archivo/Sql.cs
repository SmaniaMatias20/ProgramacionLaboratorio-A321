using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Archivo
{
    public class Sql : IArchivo
    {
        // Atributos
        private SqlCommand _comando;
        private SqlConnection _conexion;

        /// <summary>
        /// Inicializa una nueva instancia de la clase Sql.
        /// </summary>
        public Sql()
        {
            _conexion = new SqlConnection("Data Source=DESKTOP-HEJ5SS0\\SQLEXPRESS;Initial Catalog=lab_sp;Integrated Security=True;");
            _comando = new SqlCommand();
            _comando.CommandType = CommandType.Text;
            _comando.Connection = _conexion;
        }

        /// <summary>
        /// Guarda la lista de patentes en la base de datos.
        /// </summary>
        /// <param name="datos">Lista de objetos Patente a guardar.</param>
        /// <returns>True si se guardaron correctamente las patentes, False en caso contrario.</returns>
        public bool Guardar(List<Patente> datos) 
        {
            try
            {
                using (_conexion)
                {
                    _conexion.Open();
                    foreach (var patente in datos)
                    {
                        _comando.CommandText = $"INSERT INTO patentes (patente, tipo) VALUES ('{patente.CodigoPatente}', '{patente.TipoCodigo.ToString()}')";
                        _comando.ExecuteNonQuery();
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
        /// Lee todas las patentes almacenadas en la base de datos.
        /// </summary>
        /// <returns>Lista de objetos Patente leídos desde la base de datos.</returns>
        public List<Patente> Leer() 
        {
            List<Patente> patentes = new List<Patente>();
            try
            {
                using (_conexion)
                {
                    _conexion.Open();
                    _comando.CommandText = "SELECT * FROM patentes";
                    using (SqlDataReader reader = _comando.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            Patente patente = new Patente
                            {
                                CodigoPatente = Convert.ToString(reader["patente"]),
                                TipoCodigo = (ETipo)Enum.Parse(typeof(ETipo), reader["tipo"].ToString())
                            };
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
