using Entidades;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;

namespace Archivo
{
    public class Sql : IArchivo
    {
        private SqlCommand _comando;
        private SqlConnection _conexion;

        public Sql()
        {
            _conexion = new SqlConnection("Data Source=DESKTOP-HEJ5SS0\\SQLEXPRESS;Initial Catalog=lab_sp;Integrated Security=True;");
            _comando = new SqlCommand();
            _comando.CommandType = System.Data.CommandType.Text;
            _comando.Connection = _conexion;
        }

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
