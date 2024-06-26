﻿using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Numerics;
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
            CargarPropietarios();

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

        private void CargarPropietarios()
        {
            List<String> propietarios = vehiculoDB.GetAllPropietarios();

            propietarioComboBox.DataSource = propietarios;
        }

        private void Limpiar()
        {
            // Restablece el contenido de los TextBoxes a cadenas vacías
            placaTextBox.Text = "";
            colorTextBox.Text = "";
            propietarioComboBox.SelectedIndex = -1; // Selecciona ningún ítem
            chasisTextBox.Text = "";
            matriculaTextBox.Text = "";
            cilindrajeBox1.Text = "";

            // Asegura que todos los campos estén habilitados
            placaTextBox.Enabled = true;
            chasisTextBox.Enabled = true;
            matriculaTextBox.Enabled = true;
            propietarioComboBox.Enabled = true;
            fechaCompra.Enabled = true;

            // Configura el botón para agregar, oculta el de guardar cambios
            adminAddProducts_addBtn.Visible = true;
            guardarCambiosBtn.Visible = false;
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
                string matriculaSeleccionada = datosVehiculosDataGridView.CurrentRow.Cells["Matricula"].Value.ToString();
                EliminarVehiculo(matriculaSeleccionada);
            }
            Limpiar();
        }
        private void EliminarVehiculo(string Matricula)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(vehiculoDB.connectionString))
                {
                    string query = "DELETE FROM VistaVehiculo WHERE Matricula = @Matricula AND ID_Taller = @ID_Taller";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Matricula", Matricula);
                        command.Parameters.AddWithValue("@ID_Taller", Globals.SelectedNode);

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
            CargarVehiculos();
            Limpiar();
        }
        private void AgregarVehiculo()
        {


            // Realizar las validaciones necesarias
            if (!Regex.IsMatch(placaTextBox.Text, @"^[a-zA-Z0-9]+$") ||
                !Regex.IsMatch(matriculaTextBox.Text, @"^[a-zA-Z0-9]+$") ||
                !Regex.IsMatch(cilindrajeBox1.Text, @"^[a-zA-Z0-9]+$") ||
                !Regex.IsMatch(chasisTextBox.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("Matrícula, Placa, Chasis y Cilindraje deben contener solo caracteres alfanuméricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(colorTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Color debe contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (ExisteMatricula(matriculaTextBox.Text))
            {
                MessageBox.Show("La matrícula ya existe en la base de datos.", "Error de duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            if (ExistePlaca(placaTextBox.Text))
            {
                MessageBox.Show("La placa ya existe en la base de datos.", "Error de duplicado", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Continúa con la inserción en la base de datos si pasa las validaciones
            string Matricula = matriculaTextBox.Text;
            string Placa = placaTextBox.Text;
            string Chasis = chasisTextBox.Text;
            string Color = colorTextBox.Text;

            string[] propietarioParts = propietarioComboBox.Text.Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);
            string Nombre = propietarioParts[0];
            string Apellido = propietarioParts.Length > 1 ? propietarioParts[1] : "";

            DateTime Fecha_Compra = fechaCompra.Value;
            string Cilindraje = cilindrajeBox1.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(vehiculoDB.connectionString))
                {
                    string query = @"
            INSERT INTO VistaVehiculo (Matricula, ID_Taller, Placa, Color, Cilindraje, Fecha_Compra, Chasis, Nombre, Apellido) 
            VALUES (@Matricula, @ID_Taller, @Placa, @Color, @Cilindraje, @Fecha_Compra, @Chasis, @Nombre, @Apellido)";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Matricula", Matricula);
                        command.Parameters.AddWithValue("@ID_Taller", Globals.SelectedNode);
                        command.Parameters.AddWithValue("@Placa", Placa);
                        command.Parameters.AddWithValue("@Color", Color);
                        command.Parameters.AddWithValue("@Cilindraje", Cilindraje);
                        command.Parameters.AddWithValue("@Fecha_Compra", Fecha_Compra);
                        command.Parameters.AddWithValue("@Chasis", Chasis);
                        command.Parameters.AddWithValue("@Nombre", Nombre);
                        command.Parameters.AddWithValue("@Apellido", Apellido);

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

            CargarDatosVehiculoParaEdicion();

            // Deshabilitar campos que no deben editarse
            placaTextBox.Enabled = false;
            chasisTextBox.Enabled = false;
            matriculaTextBox.Enabled = false;
            propietarioComboBox.Enabled = false;
            fechaCompra.Enabled = false;

            guardarCambiosBtn.Visible = true;
            adminAddProducts_addBtn.Visible = false;
        }
        private void CargarDatosVehiculoParaEdicion()
        {
            // Suponiendo que tu DataGridView tiene nombres de columna como se muestra
            matriculaTextBox.Text = datosVehiculosDataGridView.CurrentRow.Cells["Matricula"].Value.ToString();
            placaTextBox.Text = datosVehiculosDataGridView.CurrentRow.Cells["Placa"].Value.ToString();
            colorTextBox.Text = datosVehiculosDataGridView.CurrentRow.Cells["Color"].Value.ToString();
            chasisTextBox.Text = datosVehiculosDataGridView.CurrentRow.Cells["Chasis"].Value.ToString();

            // Concatenar el nombre y apellido recuperados de la fila actual
            string nombreCompleto = datosVehiculosDataGridView.CurrentRow.Cells["Nombre"].Value.ToString() + " " + datosVehiculosDataGridView.CurrentRow.Cells["Apellido"].Value.ToString();

            // Buscar el ítem en el ComboBox que coincida con el nombre completo y seleccionarlo
            propietarioComboBox.SelectedIndex = propietarioComboBox.FindStringExact(nombreCompleto);


            cilindrajeBox1.Text = datosVehiculosDataGridView.CurrentRow.Cells["Cilindraje"].Value.ToString();
        }


        private void guardarCambiosBtn_Click(object sender, EventArgs e)
        {
            // Realiza las validaciones de los campos editables
            if (!Regex.IsMatch(colorTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("El color debe contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!Regex.IsMatch(cilindrajeBox1.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("El cilindraje debe ser alfanumerico.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Continúa con la actualización en la base de datos
            ActualizarVehiculo();


            // Habilitar nuevamente los campos bloqueados para la próxima operación de agregar
            placaTextBox.Enabled = true;
            chasisTextBox.Enabled = true;
            matriculaTextBox.Enabled = true;
            guardarCambiosBtn.Visible = false;
            adminAddProducts_addBtn.Visible = true;

            Limpiar(); // Asegúrate de implementar este método para limpiar los campos después de guardar
            CargarVehiculos();
        }

        private bool ExisteMatricula(string matricula)
        {
            using (SqlConnection connection = new SqlConnection(vehiculoDB.connectionString))
            {
                string query = "SELECT COUNT(*) FROM VistaVehiculo WHERE Matricula = @Matricula AND ID_Taller = @ID_Taller";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Matricula", matricula);
                    command.Parameters.AddWithValue("@ID_Taller", Globals.SelectedNode);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }

        private bool ExistePlaca(string placa)
        {
            using (SqlConnection connection = new SqlConnection(vehiculoDB.connectionString))
            {
                string query = "SELECT COUNT(*) FROM VistaVehiculo WHERE Placa = @Placa AND ID_Taller = @ID_Taller";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Placa", placa);
                    command.Parameters.AddWithValue("@ID_Taller", Globals.SelectedNode);

                    connection.Open();
                    int count = (int)command.ExecuteScalar();
                    return count > 0;
                }
            }
        }


        private void ActualizarVehiculo()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(vehiculoDB.connectionString))
                {
                    string tablaNombre = Globals.SelectedNode == 1 ? "Vehiculo_01" : "Vehiculo_02";

                    string query = $@"
                UPDATE {tablaNombre}
                SET Color = @Color,  
                    Cilindraje = @Cilindraje
                WHERE Matricula = @Matricula";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Color", colorTextBox.Text);
                        command.Parameters.AddWithValue("@Nombre", propietarioComboBox.Text);
                        command.Parameters.AddWithValue("@Apellido", propietarioComboBox.Text);
                        command.Parameters.AddWithValue("@ID_Taller", Globals.SelectedNode);
                        command.Parameters.AddWithValue("@Cilindraje", cilindrajeBox1.Text);
                        command.Parameters.AddWithValue("@Matricula", matriculaTextBox.Text);

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
            Limpiar();
            CargarVehiculos();
        }


    }
}
