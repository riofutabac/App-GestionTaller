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
            ciudadTextBox.Text = "";


            // Habilitar todos los campos y revertir el botón
            cedulaClienteTextBox.Enabled = true;
            nombreClienteTextBox.Enabled = true;
            apellidoClienteTextBox.Enabled = true;

            guardarCambiosBtn.Visible = false;
            agregarBtn.Visible = true;
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
                !Regex.IsMatch(ciudadTextBox.Text, @"^[a-zA-Z\s]+$") ||
                !Regex.IsMatch(apellidoClienteTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Nombre, Apellido y Ciudad deben contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(cedulaClienteTextBox.Text, @"^\d+$"))
            {
                MessageBox.Show("Cédula debe contener solo números.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ExisteCedula(cedulaClienteTextBox.Text))
            {
                MessageBox.Show("La cédula ya está registrada en la base de datos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Continúa con la inserción en la base de datos si pasa las validaciones
            string Cedula = cedulaClienteTextBox.Text;
            string Nombre = nombreClienteTextBox.Text;
            string Apellido = apellidoClienteTextBox.Text;
            string Ciudad = ciudadTextBox.Text;

            Guid rowguid = Guid.NewGuid(); // Generar un nuevo GUID para el rowguid

            try
            {
                using (SqlConnection connection = new SqlConnection(clienteDB.connectionString))
                {
                    string query = "INSERT INTO VistaCliente (Cedula, Nombre, Apellido, Ciudad, ID_Taller) VALUES (@Cedula, @Nombre, @Apellido, @Ciudad, @ID_Taller)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombreClienteTextBox.Text);
                        command.Parameters.AddWithValue("@Apellido", apellidoClienteTextBox.Text);
                        command.Parameters.AddWithValue("@Ciudad", ciudadTextBox.Text);
                        command.Parameters.AddWithValue("@ID_Taller", Globals.SelectedNode);
                        command.Parameters.AddWithValue("@Cedula", cedulaClienteTextBox.Text);

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


        private bool ExisteCedula(string cedula)
        {
            using (SqlConnection connection = new SqlConnection(clienteDB.connectionString))
            {
                string query = "SELECT COUNT(*) FROM VistaCliente WHERE Cedula = @Cedula";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Cedula", cedula);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
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
                string ciClienteSeleccionado = datosClienteDataGridView.CurrentRow.Cells["Cedula"].Value.ToString();
                EliminarCliente(ciClienteSeleccionado);
            }
            limpiar();
        }


        private void EliminarCliente(string ciCliente)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(clienteDB.connectionString))
                {

                    string nombreCliente = datosClienteDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
                    string apellidoCliente = datosClienteDataGridView.CurrentRow.Cells["Apellido"].Value.ToString();
                    string query = "DELETE FROM VistaCliente WHERE Cedula = @Cedula AND Nombre = @Nombre AND Apellido = @Apellido AND ID_Taller = @ID_Taller";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {

                        command.Parameters.AddWithValue("@Cedula", ciCliente);
                        command.Parameters.AddWithValue("@Nombre", nombreCliente);
                        command.Parameters.AddWithValue("@Apellido", apellidoCliente);
                        command.Parameters.AddWithValue("@ID_Taller", Globals.SelectedNode);

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

            // Deshabilitar la edición de la cédula y el taller
            cedulaClienteTextBox.Enabled = false;
            nombreClienteTextBox.Enabled = false;
            apellidoClienteTextBox.Enabled = false;

            guardarCambiosBtn.Visible = true;
            agregarBtn.Visible = false;
        }


        private void CargarDatosClienteParaEdicion()
        {
            cedulaClienteTextBox.Text = datosClienteDataGridView.CurrentRow.Cells["Cedula"].Value.ToString();
            nombreClienteTextBox.Text = datosClienteDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
            apellidoClienteTextBox.Text = datosClienteDataGridView.CurrentRow.Cells["Apellido"].Value.ToString();
            ciudadTextBox.Text = datosClienteDataGridView.CurrentRow.Cells["Ciudad"].Value.ToString();


        }

        private void guardarCambiosBtn_Click_1(object sender, EventArgs e)
        {
            // Realizar las validaciones necesarias
            if (!Regex.IsMatch(nombreClienteTextBox.Text, @"^[a-zA-Z\s]+$") ||
                !Regex.IsMatch(ciudadTextBox.Text, @"^[a-zA-Z\s]+$") ||
                !Regex.IsMatch(apellidoClienteTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Nombre, Apellido y Ciudad deben contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ActualizarCliente();
            CargarClientes();
            nombreClienteTextBox.Enabled = true;
            apellidoClienteTextBox.Enabled = true;
            cedulaClienteTextBox.Enabled = true;
            limpiar();
        }

        private void ActualizarCliente()
        {
            // Obtener los valores actualizados de los TextBoxes
            // Nota: No actualizamos la cédula porque es la clave primaria y no debe cambiar

            try
            {
                using (SqlConnection connection = new SqlConnection(clienteDB.connectionString))
                {
                    string tablaNombre = Globals.SelectedNode == 1 ? "Cliente_01" : "Cliente_02";

                    string query = $@"
                UPDATE {tablaNombre} SET 
                Nombre = @Nombre, 
                Apellido = @Apellido, 
                ID_Taller = @ID_Taller, 
                Ciudad = @Ciudad 
                WHERE Cedula = @Cedula";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", nombreClienteTextBox.Text);
                        command.Parameters.AddWithValue("@Apellido", apellidoClienteTextBox.Text);
                        command.Parameters.AddWithValue("@Ciudad", ciudadTextBox.Text);
                        command.Parameters.AddWithValue("@ID_Taller", Globals.SelectedNode);
                        command.Parameters.AddWithValue("@Cedula", cedulaClienteTextBox.Text);

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
