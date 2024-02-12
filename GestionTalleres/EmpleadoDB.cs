using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Configuration;

namespace GestionTalleres
{
    internal class EmpleadoDB
    {
        string connectionString = ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString;

        public string CodigoEmpleado { get; set; }
        public string CodigoTaller { get; set; }
        public string NombreEmpleado { get; set; }
        public string CiEmpleado { get; set; }
        public DateTime FechaContrato { get; set; }
        public decimal Salario { get; set; }

        public List<EmpleadoDB> GetAllEmpleados()
        {
            List<EmpleadoDB> empleados = new List<EmpleadoDB>();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT * FROM empleado_01";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    try
                    {
                        connection.Open();
                        SqlDataReader reader = command.ExecuteReader();

                        while (reader.Read())
                        {
                            EmpleadoDB empleado = new EmpleadoDB()
                            {
                                CodigoEmpleado = reader["codigo_empleado"].ToString(),
                                CodigoTaller = reader["codigo_taller"].ToString(),
                                NombreEmpleado = reader["nombre_empleado"].ToString(),
                                CiEmpleado = reader["ci_empleado"].ToString(),
                                FechaContrato = (DateTime)reader["fecha_contrato"],
                                Salario = (decimal)reader["salario"]
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
