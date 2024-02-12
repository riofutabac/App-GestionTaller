using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GestionTalleres
{
    internal class RepuestoDB
    {
        string connectionString = ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString;

        public string IdRepuesto { get; set; }
        public string CodigoTaller { get; set; }
        public string NombreRepuesto { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public int Stock { get; set; }
        public string Marca { get; set; }

        public List<RepuestoDB> GetAllRepuestos()
        {
            List<RepuestoDB> repuestos = new List<RepuestoDB>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM repuesto_N01";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            RepuestoDB repuesto = new RepuestoDB()
                            {
                                IdRepuesto = reader["id_repuesto"].ToString(),
                                CodigoTaller = reader["codigo_taller"].ToString(),
                                NombreRepuesto = reader["nombre_repuesto"].ToString(),
                                Precio = (decimal)reader["precio"],
                                Cantidad = (int)reader["cantidad"],
                                Stock = (int)reader["stock"],
                                Marca = reader["marca"].ToString()
                            };
                            repuestos.Add(repuesto);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener repuestos: " + ex.Message);
                    }
                }
            }

            return repuestos;
        }
    }
}
