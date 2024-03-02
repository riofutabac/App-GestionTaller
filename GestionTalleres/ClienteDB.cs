using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GestionTalleres
{
    class ClienteDB
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString;

        public string Cedula { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Ciudad { get; set; }
        public string ID_Taller { get; set; }

        public List<ClienteDB> GetAllClientes()
        {
            List<ClienteDB> clientes = new List<ClienteDB>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM Cliente_01";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            ClienteDB cliente = new ClienteDB()
                            {
                                Cedula = reader["Cedula"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Ciudad = reader["Ciudad"].ToString(),
                                ID_Taller = reader["ID_Taller"].ToString(),
                            };
                            clientes.Add(cliente);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener clientes: " + ex.Message);
                    }
                }
            }

            return clientes;
        }
    }
}
