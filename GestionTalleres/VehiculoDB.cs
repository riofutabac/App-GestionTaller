using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GestionTalleres
{
    class VehiculoDB
    {
        string connectionString = ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString;

        public string NumeroMatricula { get; set; }
        public string NumeroPlaca { get; set; }
        public string Color { get; set; }
        public string Chasis { get; set; }
        public string NombrePropietario { get; set; }
        public string Ciudad { get; set; }
        public string Cilindraje { get; set; }

        public List<VehiculoDB> GetAllVehiculos()
        {
            List<VehiculoDB> vehiculos = new List<VehiculoDB>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM vehiculo_N01";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            VehiculoDB vehiculo = new VehiculoDB()
                            {
                                NumeroMatricula = reader["numero_matricula"].ToString(),
                                NumeroPlaca = reader["numero_placa"].ToString(),
                                Color = reader["color"].ToString(),
                                Chasis = reader["chasis"].ToString(),
                                NombrePropietario = reader["nombre_propietario"].ToString(),
                                Ciudad = reader["ciudad"].ToString(),
                                Cilindraje = reader["cilindraje"].ToString()
                            };
                            vehiculos.Add(vehiculo);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener vehículos: " + ex.Message);
                    }
                }
            }

            return vehiculos;
        }
    }
}
