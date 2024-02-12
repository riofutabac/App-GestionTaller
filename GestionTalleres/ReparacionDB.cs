using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GestionTalleres
{
    internal class ReparacionDB
    {
        string connectionString = ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString;

        public string IdReparacion { get; set; }
        public string NumeroMatricula { get; set; }
        public string Observaciones { get; set; }
        public decimal Precio { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaReparacion { get; set; }

        public List<ReparacionDB> GetAllReparaciones()
        {
            List<ReparacionDB> reparaciones = new List<ReparacionDB>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM reparacion_N01";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            ReparacionDB reparacion = new ReparacionDB()
                            {
                                IdReparacion = reader["id_reparacion"].ToString(),
                                NumeroMatricula = reader["numero_matricula"].ToString(),
                                Observaciones = reader["observaciones"].ToString(),
                                Precio = (decimal)reader["precio"],
                                Tipo = reader["tipo"].ToString(),
                                FechaReparacion = (DateTime)reader["fecha_reparacion"]
                            };
                            reparaciones.Add(reparacion);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener reparaciones: " + ex.Message);
                    }
                }
            }

            return reparaciones;
        }
    }
}
