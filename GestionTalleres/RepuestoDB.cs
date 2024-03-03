using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GestionTalleres
{
     class RepuestoDB
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString;
        public string ID_Repuesto { get; set; }
        public string ID_Taller { get; set; }
        public string Nombre { get; set; }
        public decimal Precio { get; set; }
        public int Cantidad { get; set; }
        public string Marca { get; set; }

        public List<RepuestoDB> GetAllRepuestos()
        {
            List<RepuestoDB> repuestos = new List<RepuestoDB>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM VistaRepuestos WHERE ID_Taller = @ID_Taller";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Taller", Globals.SelectedNode);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            RepuestoDB repuesto = new RepuestoDB()
                            {
                                ID_Repuesto = reader["ID_Repuesto"].ToString(),
                                ID_Taller = reader["ID_Taller"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Precio = (decimal)reader["Precio"],
                                Cantidad = (int)reader["Cantidad"],
                                Marca = reader["Marca"].ToString()
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
