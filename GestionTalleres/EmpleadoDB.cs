using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GestionTalleres
{
    internal class EmpleadoDB
    {
        public string connectionString = ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString;

        public string ID_Empleado { get; set; }
        public string ID_Taller { get; set; }
        public string Nombre { get; set; }
        public string Apellido { get; set; }
        public string Cedula { get; set; }
        public DateTime FechaC { get; set; }
        public decimal Salario { get; set; }

        public List<EmpleadoDB> GetAllEmpleados()
        {
            List<EmpleadoDB> empleados = new List<EmpleadoDB>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM VistaEmpleado WHERE ID_Taller = @ID_Taller";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Taller", Globals.SelectedNode);
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            EmpleadoDB empleado = new EmpleadoDB()
                            {
                                ID_Empleado = reader["ID_Empleado"].ToString(),
                                ID_Taller = reader["ID_Taller"].ToString(),
                                Nombre = reader["Nombre"].ToString(),
                                Apellido = reader["Apellido"].ToString(),
                                Cedula = reader["Cedula"].ToString(),
                                FechaC = (DateTime)reader["FechaC"],
                                Salario = (decimal)reader["Salario"]
                            };
                            empleados.Add(empleado);
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine("Error al obtener empleados: " + ex.Message);
                    }
                }
            }

            return empleados;
        }
    }
}
