using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GestionTalleres
{
    class VehiculoDB
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString;
        public string Matricula { get; set; }
        public string Placa { get; set; }
        public string Color { get; set; }
        public string Chasis { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public DateTime Fecha_Compra { get; set; }
        public string Cilindraje { get; set; }
        public string ID_Taller { get; set; }

        public List<VehiculoDB> GetAllVehiculos()
        {
            List<VehiculoDB> vehiculos = new List<VehiculoDB>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM VistaVehiculo WHERE ID_Taller = @ID_Taller";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Taller", Globals.SelectedNode);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            VehiculoDB vehiculo = new VehiculoDB()
                            {
                                Matricula = reader["Matricula"].ToString(),
                                ID_Taller = reader["ID_Taller"].ToString(),
                                Placa = reader["Placa"].ToString(),
                                Color = reader["Color"].ToString(),
                                Cilindraje = reader["Cilindraje"].ToString(),
                                Fecha_Compra = (DateTime)reader["Fecha_Compra"],
                                Chasis = reader["Chasis"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString()
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

        public List<string> GetAllPropietarios()
        {
            List<string> propietarios = new List<string>();
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                // Utiliza la vista VistaCliente en lugar de la tabla Cliente_01 directamente
                // y filtra los resultados por el ID_Taller utilizando la variable global SelectedNode
                string query = $"SELECT Nombre + ' ' + Apellido AS Nombre_Completo FROM VistaCliente WHERE ID_Taller = @ID_Taller";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Asigna el valor de SelectedNode a @ID_Taller
                    command.Parameters.AddWithValue("@ID_Taller", Globals.SelectedNode);

                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();
                        while (reader.Read())
                        {
                            propietarios.Add(reader["Nombre_Completo"].ToString());
                        }
                    }
                    catch (Exception ex)
                    {
                        // Manejar adecuadamente la excepción
                        Console.WriteLine("Error al obtener propietarios: " + ex.Message);
                    }
                }
            }
            return propietarios;
        }
    }

    }
