using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionTalleres
{
    public partial class Empleado : UserControl
    {
        private EmpleadoDB empleadoDB;
        public Empleado()
        {
            InitializeComponent();
            empleadoDB = new EmpleadoDB();
        }

        private void Empleado_Load(object sender, EventArgs e)
        {
            CargarEmpleados();
        }
        private void CargarEmpleados()
        {
            List<EmpleadoDB> empleados = empleadoDB.GetAllEmpleados();


            datosEmpleadosDataGridView.DataSource = empleados;


            datosEmpleadosDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Limpiar()
        {
            // Restablecer el contenido de los TextBoxes a cadenas vacías
            codigoTextBox.Text = "";
            cedulaTextBox.Text = "";
            nombreTextBox.Text = "";
            tallerTextBox.Text = "";
            salarioTextBox.Text = "";
            fechaTextBox.Text = "";

        }

        private void limpiarBtn_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void eliminarBtn_Click(object sender, EventArgs e)
        {
            // Verificar si hay alguna fila actualmente seleccionada en el DataGridView de empleados
            if (datosEmpleadosDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un empleado para eliminar.", "Seleccionar empleado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación de eliminación
            var confirmResult = MessageBox.Show("¿Está seguro de que quiere eliminar el empleado seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                // Obtener el código del empleado seleccionado, asumiendo que la columna se llama 'codigo_empleado'
                string codigoEmpleadoSeleccionado = datosEmpleadosDataGridView.CurrentRow.Cells["CodigoEmpleado"].Value.ToString();
                EliminarEmpleado(codigoEmpleadoSeleccionado);
            }
        }

        private void EliminarEmpleado(string codigoEmpleado)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(empleadoDB.connectionString)) // Asegúrate de tener la cadena de conexión correcta aquí
                {
                    string query = "DELETE FROM empleado_01 WHERE codigo_empleado = @codigoEmpleado";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codigoEmpleado", codigoEmpleado);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Verificar si la eliminación fue exitosa
                        if (result > 0)
                        {
                            MessageBox.Show("Empleado eliminado exitosamente.", "Empleado Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarEmpleados(); // Recargar la lista de empleados
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el empleado especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void agregarBtn_Click(object sender, EventArgs e)
        {
            AgregarEmpleado();
            CargarEmpleados();
        }

        private bool EmpleadoExiste(string codigoEmpleado, string ciEmpleado)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(empleadoDB.connectionString))
                {
                    connection.Open();

                    // Consulta para verificar la existencia de un empleado con el mismo código o cédula
                    string query = @"
                SELECT COUNT(1) 
                FROM empleado_01 
                WHERE codigo_empleado = @codigoEmpleado 
                   OR ci_empleado = @ciEmpleado";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codigoEmpleado", codigoEmpleado);
                        command.Parameters.AddWithValue("@ciEmpleado", ciEmpleado);

                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al verificar la existencia del empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return false;
        }

        private void AgregarEmpleado()
        {
            // Realizar las validaciones necesarias
            if (!Regex.IsMatch(nombreTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("El nombre debe contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(cedulaTextBox.Text, @"^\d+$"))
            {
                MessageBox.Show("La cédula debe contener solo números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(codigoTextBox.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("El código debe contener solo letras y números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tallerTextBox.Text != "1" && tallerTextBox.Text != "2")
            {
                MessageBox.Show("El código de taller debe ser '1' o '2'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(salarioTextBox.Text, out decimal salario))
            {
                MessageBox.Show("El salario debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Continúa con la inserción en la base de datos si pasa las validaciones
            string codigoEmpleado = codigoTextBox.Text;
            string codigoTaller = tallerTextBox.Text;
            string nombreEmpleado = nombreTextBox.Text;
            string ciEmpleado = cedulaTextBox.Text;
            DateTime fechaContrato;

            // Intenta parsear la fecha del formato MM/dd/yy. Asegúrate de que el usuario haya ingresado la fecha en este formato.
            if (!DateTime.TryParseExact(fechaTextBox.Text, "MM/dd/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out fechaContrato))
            {
                MessageBox.Show("La fecha debe estar en el formato MM/dd/yy, por ejemplo, 12/31/20 para el 31 de diciembre de 2020.", "Formato de Fecha Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Primero, verifica si ya existe un empleado con el mismo código o cédula
            if (EmpleadoExiste(codigoEmpleado, ciEmpleado))
            {
                MessageBox.Show("Ya existe un empleado con el mismo código o cédula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(empleadoDB.connectionString))
                {
                    string query = "INSERT INTO empleado_01 (codigo_empleado, codigo_taller, nombre_empleado, ci_empleado, fecha_contrato, salario) VALUES (@codigoEmpleado, @codigoTaller, @nombreEmpleado, @ciEmpleado, @fechaContrato, @salario)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@codigoEmpleado", codigoEmpleado);
                        command.Parameters.AddWithValue("@codigoTaller", codigoTaller);
                        command.Parameters.AddWithValue("@nombreEmpleado", nombreEmpleado);
                        command.Parameters.AddWithValue("@ciEmpleado", ciEmpleado);
                        command.Parameters.AddWithValue("@fechaContrato", fechaContrato);
                        command.Parameters.AddWithValue("@salario", salario);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Empleado registrado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarEmpleados(); // Actualizar el DataGridView para mostrar el nuevo empleado
                        Limpiar();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Capturar errores específicos de SQL
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    // Si es una violación de clave primaria, mostrar este mensaje
                    MessageBox.Show("El código del empleado ya existe en la base de datos.", "Error de duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                else
                {
                    // Para otros errores de SQL
                    MessageBox.Show($"Error de base de datos: {ex.Message}", "Error de base de datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            catch (Exception ex)
            {
                // Capturar otros errores no relacionados con SQL
                MessageBox.Show($"Error al agregar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editarBtn_Click(object sender, EventArgs e)
        {
            // Verificar si hay alguna fila actualmente seleccionada en el DataGridView de empleados
            if (datosEmpleadosDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un empleado para editar.", "Seleccionar empleado", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cargar la información del empleado seleccionado en los TextBoxes
            CargarDatosEmpleadoParaEdicion();

            // Deshabilitar la edición del código de empleado, cédula y fecha de contrato
            codigoTextBox.Enabled = false;
            cedulaTextBox.Enabled = false;
            fechaTextBox.Enabled = false;

            // Cambiar el botón de agregar a "Guardar Cambios"
            agregarBtn.Text = "GUARDAR CAMBIOS";
            agregarBtn.Click -= agregarBtn_Click; // Eliminar el evento de clic de agregar
            agregarBtn.Click += guardarCambiosBtn_Click; // Agregar el evento de clic de guardar cambios
        }

        private void CargarDatosEmpleadoParaEdicion()
        {
            // Asumiendo que las columnas tienen estos nombres en tu DataGridView
            codigoTextBox.Text = datosEmpleadosDataGridView.CurrentRow.Cells["CodigoEmpleado"].Value.ToString();
            cedulaTextBox.Text = datosEmpleadosDataGridView.CurrentRow.Cells["CiEmpleado"].Value.ToString();
            nombreTextBox.Text = datosEmpleadosDataGridView.CurrentRow.Cells["NombreEmpleado"].Value.ToString();
            tallerTextBox.Text = datosEmpleadosDataGridView.CurrentRow.Cells["CodigoTaller"].Value.ToString();
            fechaTextBox.Text = ((DateTime)datosEmpleadosDataGridView.CurrentRow.Cells["FechaContrato"].Value).ToString("MM/dd/yy");
            salarioTextBox.Text = datosEmpleadosDataGridView.CurrentRow.Cells["Salario"].Value.ToString();
        }

        private void guardarCambiosBtn_Click(object sender, EventArgs e)
        {
            // Realizar las validaciones necesarias
            if (!Regex.IsMatch(nombreTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("El nombre debe contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tallerTextBox.Text != "1" && tallerTextBox.Text != "2")
            {
                MessageBox.Show("El código de taller debe ser '1' o '2'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // No necesitamos validar el código y cédula ya que no se pueden cambiar
            // No validamos la fecha porque no se puede editar

            ActualizarEmpleado();
            
            CargarEmpleados();
            
            agregarBtn.Text = "AGREGAR";
            agregarBtn.Click -= guardarCambiosBtn_Click;
            agregarBtn.Click += agregarBtn_Click;
            Limpiar();
            codigoTextBox.Enabled = true;
            cedulaTextBox.Enabled = true;
            fechaTextBox.Enabled = true;
        }

        private void ActualizarEmpleado()
        {
            // Obtener los valores actualizados de los TextBoxes
            string codigoEmpleado = codigoTextBox.Text; // No se actualiza, pero se usa para identificar el registro
            string nombreEmpleado = nombreTextBox.Text;
            string codigoTaller = tallerTextBox.Text;
            decimal salario;
            if (!decimal.TryParse(salarioTextBox.Text, out salario))
            {
                MessageBox.Show("El salario debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // La cédula y la fecha de contrato no se actualizan, asumimos que están deshabilitadas y no cambian

            try
            {
                using (SqlConnection connection = new SqlConnection(empleadoDB.connectionString))
                {
                    string query = @"
                UPDATE empleado_01 
                SET nombre_empleado = @nombreEmpleado, 
                    codigo_taller = @codigoTaller, 
                    salario = @salario
                WHERE codigo_empleado = @codigoEmpleado";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreEmpleado", nombreEmpleado);
                        command.Parameters.AddWithValue("@codigoTaller", codigoTaller);
                        command.Parameters.AddWithValue("@salario", salario);
                        command.Parameters.AddWithValue("@codigoEmpleado", codigoEmpleado);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Empleado actualizado exitosamente.", "Empleado Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el empleado. Asegúrese de que el empleado exista y de que el código de empleado sea correcto.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                // Aquí podrías manejar errores específicos de SQL si es necesario
                MessageBox.Show($"Error al actualizar el empleado: {ex.Message}", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Capturar otros errores no relacionados con SQL
                MessageBox.Show($"Error al actualizar el empleado: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
