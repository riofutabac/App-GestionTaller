using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GestionTalleres
{
    class ReparacionDB
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString;

        public string ID_Reparacion { get; set; }
        public string Matricula { get; set; }
        public string Descripcion { get; set; }
        public decimal Precio { get; set; }
        public string Tipo { get; set; }
        public DateTime FechaReparacion { get; set; }

        public List<ReparacionDB> GetAllReparaciones()
        {
            List<ReparacionDB> reparaciones = new List<ReparacionDB>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM VistaReparacion WHERE ID_Taller = @ID_Taller";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Taller", Globals.SelectedNode);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            ReparacionDB reparacion = new ReparacionDB()
                            {
                                ID_Reparacion = reader["ID_Reparacion"].ToString(),
                                Matricula = reader["Matricula"].ToString(),
                                Descripcion = reader["Descripcion"].ToString(),
                                Precio = (decimal)reader["Precio"],
                                Tipo = reader["Tipo"].ToString(),
                                FechaReparacion = (DateTime)reader["FechaReparacion"]
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

        public List<string> GetAllTiposDeReparaciones()
        {
            List<string> tiposReparaciones = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Asegúrate de que el nombre de tu columna en la base de datos sea 'tipo'
                string query = "SELECT DISTINCT Tipo FROM VistaReparacion WHERE ID_Taller = @ID_Taller";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Taller", Globals.SelectedNode);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            tiposReparaciones.Add(reader["Tipo"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejar adecuadamente la excepción
                        Console.WriteLine("Error al obtener tipos de reparaciones: " + ex.Message);
                    }
                }
            }
            return tiposReparaciones;
        }

        public List<string> GetAllMatriculas()
        {
            List<string> matriculas = new List<string>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT DISTINCT Matricula FROM VistaReparacion WHERE ID_Taller = @ID_Taller";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Taller", Globals.SelectedNode);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            matriculas.Add(reader["Matricula"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener las matrículas: " + ex.Message);
                    }
                }
            }

            return matriculas;
        }

    }
}
