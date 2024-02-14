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

        public string CiCliente { get; set; }
        public string NombreCliente { get; set; }
        public string ApellidoCliente { get; set; }
        public string Ciudad { get; set; }
        public string CodigoTaller { get; set; }
        public Guid Rowguid { get; set; }

        public List<ClienteDB> GetAllClientes()
        {
            List<ClienteDB> clientes = new List<ClienteDB>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM cliente_N01";

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
                                CiCliente = reader["ci_cliente"].ToString(),
                                NombreCliente = reader["nombre_cliente"].ToString(),
                                ApellidoCliente = reader["apellido_cliente"].ToString(),
                                Ciudad = reader["ciudad"].ToString(),
                                CodigoTaller = reader["codigo_taller"].ToString(),
                                Rowguid = (Guid)reader["rowguid"]
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
