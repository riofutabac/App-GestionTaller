using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;

namespace GestionTalleres
{
    public partial class Cliente : UserControl
    {
        private ClienteDB clienteDB;

        public Cliente()
        {
            InitializeComponent();
            clienteDB = new ClienteDB();
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            CargarClientes();
        }

        private void CargarClientes()
        {
            List<ClienteDB> clientes = clienteDB.GetAllClientes();


            datosClienteDataGridView.DataSource = clientes;


            datosClienteDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void limpiar()
        {
            // Restablecer el contenido de los TextBoxes a cadenas vacías
            cedulaClienteTextBox.Text = "";
            nombreClienteTextBox.Text = "";
            apellidoClienteTextBox.Text = "";
            ciudadClienteTextBox.Text = "";
            tallerTextBox.Text = "";
        }

        private void limpiarBtn_Click(object sender, EventArgs e)
        {
            limpiar();
        }

        private void agregarBtn_Click(object sender, EventArgs e)
        {
            AgregarCliente();
            CargarClientes();
            limpiar();
        }

        private void AgregarCliente()
        {
            // Realizar las validaciones necesarias
            if (!Regex.IsMatch(nombreClienteTextBox.Text, @"^[a-zA-Z\s]+$") ||
                !Regex.IsMatch(apellidoClienteTextBox.Text, @"^[a-zA-Z\s]+$") ||
                !Regex.IsMatch(ciudadClienteTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Nombre, Apellido y Ciudad deben contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(cedulaClienteTextBox.Text, @"^\d+$"))
            {
                MessageBox.Show("Cédula debe contener solo números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tallerTextBox.Text != "1" && tallerTextBox.Text != "2")
            {
                MessageBox.Show("Código de Taller debe ser '1' o '2'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Continúa con la inserción en la base de datos si pasa las validaciones
            string ciCliente = cedulaClienteTextBox.Text;
            string nombreCliente = nombreClienteTextBox.Text;
            string apellidoCliente = apellidoClienteTextBox.Text;
            string ciudad = ciudadClienteTextBox.Text;
            string codigoTaller = tallerTextBox.Text;
            Guid rowguid = Guid.NewGuid(); // Generar un nuevo GUID para el rowguid

            try
            {
                using (SqlConnection connection = new SqlConnection(clienteDB.connectionString))
                {
                    string query = "INSERT INTO cliente_N01 (ci_cliente, nombre_cliente, apellido_cliente, ciudad, codigo_taller, rowguid) VALUES (@ciCliente, @nombreCliente, @apellidoCliente, @ciudad, @codigoTaller, @rowguid)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ciCliente", ciCliente);
                        command.Parameters.AddWithValue("@nombreCliente", nombreCliente);
                        command.Parameters.AddWithValue("@apellidoCliente", apellidoCliente);
                        command.Parameters.AddWithValue("@ciudad", ciudad);
                        command.Parameters.AddWithValue("@codigoTaller", codigoTaller);
                        command.Parameters.AddWithValue("@rowguid", rowguid);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Cliente registrado con éxito.", "Información", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarClientes(); // Actualizar el DataGridView para mostrar el nuevo cliente
                    }
                }
            }
            catch (SqlException ex)
            {
                // Capturar errores específicos de SQL
                if (ex.Number == 2627 || ex.Number == 2601)
                {
                    // Si es una violación de clave primaria, mostrar este mensaje
                    MessageBox.Show("La cédula del cliente ya existe en la base de datos.", "Error de duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                MessageBox.Show($"Error al agregar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void eliminarBtn_Click(object sender, EventArgs e)
        {
            // Verificar si hay alguna fila actualmente seleccionada
            if (datosClienteDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente para eliminar.", "Seleccionar cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación de eliminación
            var confirmResult = MessageBox.Show("¿Está seguro de que quiere eliminar el cliente seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                // Obtener la cédula del cliente seleccionado
                string ciClienteSeleccionado = datosClienteDataGridView.CurrentRow.Cells["CiCliente"].Value.ToString();
                EliminarCliente(ciClienteSeleccionado);
            }
        }


        private void EliminarCliente(string ciCliente)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clienteDB.connectionString))
                {
                    string query = "DELETE FROM cliente_N01 WHERE ci_cliente = @ciCliente";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ciCliente", ciCliente);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Verificar si la eliminación fue exitosa
                        if (result > 0)
                        {
                            MessageBox.Show("Cliente eliminado exitosamente.", "Cliente Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarClientes(); // Recargar la lista de clientes
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el cliente especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void editarBtn_Click(object sender, EventArgs e)
        {
            // Verificar si hay alguna fila actualmente seleccionada
            if (datosClienteDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un cliente para editar.", "Seleccionar cliente", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cargar la información del cliente seleccionado en los TextBoxes
            CargarDatosClienteParaEdicion();

            // Deshabilitar la edición de la cédula
            cedulaClienteTextBox.Enabled = false;

            // Cambiar el botón de agregar a "Guardar Cambios" o habilitar un nuevo botón para guardar
            // Por ejemplo:
            agregarBtn.Text = "GUARDAR CAMBIOS";
            agregarBtn.Click -= agregarBtn_Click; // Eliminar el evento de clic de agregar
            agregarBtn.Click += guardarCambiosBtn_Click; // Agregar el evento de clic de guardar
        }

        private void CargarDatosClienteParaEdicion()
        {
            // Asumiendo que el nombre de la columna que contiene la cédula del cliente es "ci_cliente"
            cedulaClienteTextBox.Text = datosClienteDataGridView.CurrentRow.Cells["CiCliente"].Value.ToString();
            nombreClienteTextBox.Text = datosClienteDataGridView.CurrentRow.Cells["NombreCliente"].Value.ToString();
            apellidoClienteTextBox.Text = datosClienteDataGridView.CurrentRow.Cells["ApellidoCliente"].Value.ToString();
            ciudadClienteTextBox.Text = datosClienteDataGridView.CurrentRow.Cells["Ciudad"].Value.ToString();
            tallerTextBox.Text = datosClienteDataGridView.CurrentRow.Cells["CodigoTaller"].Value.ToString();

        }


        private void guardarCambiosBtn_Click(object sender, EventArgs e)
        {
            // Realizar las validaciones necesarias
            if (!Regex.IsMatch(nombreClienteTextBox.Text, @"^[a-zA-Z\s]+$") ||
                !Regex.IsMatch(apellidoClienteTextBox.Text, @"^[a-zA-Z\s]+$") ||
                !Regex.IsMatch(ciudadClienteTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Nombre, Apellido y Ciudad deben contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (tallerTextBox.Text != "1" && tallerTextBox.Text != "2")
            {
                MessageBox.Show("El código de taller debe ser '1' o '2'.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Si todas las validaciones son correctas, proceder a actualizar el cliente
            ActualizarCliente();
            // Recargar la lista de clientes en el DataGridView para mostrar los cambios
            CargarClientes();
            // Cambiar el botón de vuelta a "Agregar" y limpiar los controles
            agregarBtn.Text = "AGREGAR";
            agregarBtn.Click -= guardarCambiosBtn_Click;
            agregarBtn.Click += agregarBtn_Click;
            cedulaClienteTextBox.Enabled = true; // Volver a habilitar la edición de la cédula si es necesario
            limpiar(); // Asegúrate de que exista un método llamado limpiar que restablezca los campos
        }

        private void ActualizarCliente()
        {
            // Obtener los valores actualizados de los TextBoxes
            // Nota: No actualizamos la cédula porque es la clave primaria y no debe cambiar

            try
            {
                using (SqlConnection connection = new SqlConnection(clienteDB.connectionString))
                {
                    string query = "UPDATE cliente_N01 SET nombre_cliente = @nombreCliente, apellido_cliente = @apellidoCliente, ciudad = @ciudad, codigo_taller = @codigoTaller WHERE ci_cliente = @ciCliente";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@nombreCliente", nombreClienteTextBox.Text);
                        command.Parameters.AddWithValue("@apellidoCliente", apellidoClienteTextBox.Text);
                        command.Parameters.AddWithValue("@ciudad", ciudadClienteTextBox.Text);
                        command.Parameters.AddWithValue("@codigoTaller", tallerTextBox.Text);
                        command.Parameters.AddWithValue("@ciCliente", cedulaClienteTextBox.Text);

                        connection.Open();
                        int result = command.ExecuteNonQuery();
                        if (result > 0)
                        {
                            MessageBox.Show("Cliente actualizado exitosamente.", "Cliente Actualizado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se pudo actualizar el cliente.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el cliente: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

    }
}
