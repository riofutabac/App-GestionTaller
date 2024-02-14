using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace GestionTalleres
{
    public partial class Vehiculo : UserControl
    {
        private VehiculoDB vehiculoDB;
        public Vehiculo()
        {
            InitializeComponent();
            vehiculoDB = new VehiculoDB();

        }

        private void Vehiculo_Load(object sender, EventArgs e)
        {
            CargarVehiculos();
        }
        private void CargarVehiculos()
        {
            List<VehiculoDB> vehiculos = vehiculoDB.GetAllVehiculos();


            datosVehiculosDataGridView.DataSource = vehiculos;


            datosVehiculosDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Limpiar()
        {
            // Restablece el contenido de los TextBoxes a cadenas vacías
            placaTextBox.Text = "";
            ciudadTextBox.Text = "";
            colorTextBox.Text = "";
            propietarioTextBox.Text = "";
            chasisTextBox.Text = "";
            matriculaTextBox.Text = "";
            cilindrajeBox1.Text = "";

        }

        private void adminAddProducts_clearBtn_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void adminAddProducts_deleteBtn_Click(object sender, EventArgs e)
        {
            // Verificar si hay alguna fila actualmente seleccionada en el DataGridView de vehículos
            if (datosVehiculosDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un vehículo para eliminar.", "Seleccionar vehículo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación de eliminación
            var confirmResult = MessageBox.Show("¿Está seguro de que quiere eliminar el vehículo seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                // Obtener la matrícula o ID del vehículo seleccionado
                string matriculaSeleccionada = datosVehiculosDataGridView.CurrentRow.Cells["NumeroMatricula"].Value.ToString();
                EliminarVehiculo(matriculaSeleccionada);
            }
        }
        private void EliminarVehiculo(string matricula)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(vehiculoDB.connectionString))
                {
                    string query = "DELETE FROM vehiculo_N01 WHERE numero_matricula = @matricula";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@matricula", matricula);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Verificar si la eliminación fue exitosa
                        if (result > 0)
                        {
                            MessageBox.Show("Vehículo eliminado exitosamente.", "Vehículo Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarVehiculos();
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el vehículo especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el vehículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adminAddProducts_addBtn_Click(object sender, EventArgs e)
        {
            AgregarVehiculo();
        }
        private void AgregarVehiculo()
        {
            // Realizar las validaciones necesarias
            if (!Regex.IsMatch(placaTextBox.Text, @"^[a-zA-Z0-9]+$") ||
                !Regex.IsMatch(matriculaTextBox.Text, @"^[a-zA-Z0-9]+$") ||
                !Regex.IsMatch(chasisTextBox.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Matrícula, Placa y Chasis deben contener solo caracteres alfanuméricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(colorTextBox.Text, @"^[a-zA-Z\s]+$") ||
                !Regex.IsMatch(propietarioTextBox.Text, @"^[a-zA-Z\s]+$") ||
                !Regex.IsMatch(ciudadTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Color, Nombre del propietario y Ciudad deben contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(cilindrajeBox1.Text, out int cilindraje) || cilindraje <= 0)
            {
                MessageBox.Show("El cilindraje debe ser un número entero positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Continúa con la inserción en la base de datos si pasa las validaciones
            string matricula = matriculaTextBox.Text;
            string placa = placaTextBox.Text;
            string chasis = chasisTextBox.Text;
            string color = colorTextBox.Text;
            string propietario = propietarioTextBox.Text;
            string ciudad = ciudadTextBox.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(vehiculoDB.connectionString))
                {
                    string query = @"
                INSERT INTO vehiculo_N01 (numero_matricula, numero_placa, chasis, color, nombre_propietario, ciudad, cilindraje) 
                VALUES (@matricula, @placa, @chasis, @color, @propietario, @ciudad, @cilindraje)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@matricula", matricula);
                        command.Parameters.AddWithValue("@placa", placa);
                        command.Parameters.AddWithValue("@chasis", chasis);
                        command.Parameters.AddWithValue("@color", color);
                        command.Parameters.AddWithValue("@propietario", propietario);
                        command.Parameters.AddWithValue("@ciudad", ciudad);
                        command.Parameters.AddWithValue("@cilindraje", cilindraje);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Vehículo agregado con éxito.", "Vehículo Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarVehiculos();
                        Limpiar();
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error al agregar el vehículo: {ex.Message}", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al agregar el vehículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adminAddProducts_updateBtn_Click(object sender, EventArgs e)
        {
            // Verificar si hay alguna fila actualmente seleccionada en el DataGridView de vehículos
            if (datosVehiculosDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un vehículo para editar.", "Seleccionar Vehículo", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cargar la información del vehículo seleccionado en los TextBoxes
            CargarDatosVehiculoParaEdicion();

            // Cambiar el botón de "Agregar" a "Guardar Cambios" y ajustar los eventos de clic
            adminAddProducts_addBtn.Text = "Guardar Cambios";
            adminAddProducts_addBtn.Click -= adminAddProducts_addBtn_Click; // Remover el evento de agregar
            adminAddProducts_addBtn.Click += GuardarCambiosVehiculo_Click; // Añadir el evento de guardar cambios

            // Deshabilitar campos que no deben editarse
            placaTextBox.Enabled = false;
            chasisTextBox.Enabled = false;
            matriculaTextBox.Enabled = false;
        }
        private void CargarDatosVehiculoParaEdicion()
        {
            // Suponiendo que tu DataGridView tiene nombres de columna como se muestra
            matriculaTextBox.Text = datosVehiculosDataGridView.CurrentRow.Cells["NumeroMatricula"].Value.ToString();
            placaTextBox.Text = datosVehiculosDataGridView.CurrentRow.Cells["NumeroPlaca"].Value.ToString();
            colorTextBox.Text = datosVehiculosDataGridView.CurrentRow.Cells["Color"].Value.ToString();
            chasisTextBox.Text = datosVehiculosDataGridView.CurrentRow.Cells["Chasis"].Value.ToString();
            propietarioTextBox.Text = datosVehiculosDataGridView.CurrentRow.Cells["NombrePropietario"].Value.ToString();
            ciudadTextBox.Text = datosVehiculosDataGridView.CurrentRow.Cells["Ciudad"].Value.ToString();
            cilindrajeBox1.Text = datosVehiculosDataGridView.CurrentRow.Cells["Cilindraje"].Value.ToString();
        }

        private void GuardarCambiosVehiculo_Click(object sender, EventArgs e)
        {
            // Realiza las validaciones de los campos editables
            if (!Regex.IsMatch(colorTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("El color debe contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(ciudadTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("La ciudad debe contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(propietarioTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("El nombre del propietario debe contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(cilindrajeBox1.Text, out int cilindraje) || cilindraje <= 0)
            {
                MessageBox.Show("El cilindraje debe ser un número entero positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Continúa con la actualización en la base de datos
            ActualizarVehiculo();

            // Restablece la interfaz
            adminAddProducts_addBtn.Text = "Agregar";
            adminAddProducts_addBtn.Click -= GuardarCambiosVehiculo_Click;
            adminAddProducts_addBtn.Click += adminAddProducts_addBtn_Click;

            // Habilitar nuevamente los campos bloqueados para la próxima operación de agregar
            placaTextBox.Enabled = true;
            chasisTextBox.Enabled = true;
            matriculaTextBox.Enabled = true;

            Limpiar(); // Asegúrate de implementar este método para limpiar los campos después de guardar
            CargarVehiculos();
        }
        private void ActualizarVehiculo()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(vehiculoDB.connectionString))
                {
                    string query = @"
                UPDATE Vehiculo_N01
                SET Color = @Color, 
                    Nombre_Propietario = @NombrePropietario, 
                    Ciudad = @Ciudad, 
                    Cilindraje = @Cilindraje
                WHERE Numero_Matricula = @NumeroMatricula";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Color", colorTextBox.Text);
                        command.Parameters.AddWithValue("@NombrePropietario", propietarioTextBox.Text);
                        command.Parameters.AddWithValue("@Ciudad", ciudadTextBox.Text);
                        command.Parameters.AddWithValue("@Cilindraje", cilindrajeBox1.Text);
                        command.Parameters.AddWithValue("@NumeroMatricula", matriculaTextBox.Text);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Vehículo actualizado con éxito.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el vehículo: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            CargarVehiculos();
        }

    }
}
