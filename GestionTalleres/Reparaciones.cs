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
    public partial class Reparaciones : UserControl
    {
        private ReparacionDB reparacionDB;
        public Reparaciones()
        {
            InitializeComponent();
            reparacionDB = new ReparacionDB();
        }

        private void Reparaciones_Load(object sender, EventArgs e)
        {
            CargarReparaciones();

        }

        private void CargarReparaciones()
        {
            List<ReparacionDB> repuestos = reparacionDB.GetAllReparaciones();


            datosReparacionDataGridView.DataSource = repuestos;


            datosReparacionDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }

        private void Limpiar()
        {
            // Suponiendo que tienes campos de texto para id_reparacion, numero_matricula, observaciones, etc.
            idTextBox.Text = "";
            matriculaTextBox.Text = "";
            observacionesTextBox.Text = "";
            precioTextBox.Text = "";
            tipoTextBox.Text = "";
            fechaTextBox.Text = "";
        }


        private void adminAddProducts_addBtn_Click(object sender, EventArgs e)
        {
            AñadirReparacion();
        }

        private void AñadirReparacion()
        {
            // Validar que matrícula e ID sean alfanuméricos
            if (!Regex.IsMatch(matriculaTextBox.Text, @"^[a-zA-Z0-9]+$") || !Regex.IsMatch(idTextBox.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("La matrícula y el ID deben ser alfanuméricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que observaciones y tipo sean alfabéticos
            if (!Regex.IsMatch(observacionesTextBox.Text, @"^[a-zA-Z\s]+$") || !Regex.IsMatch(tipoTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Las observaciones y el tipo deben contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar que precio sea numérico
            if (!decimal.TryParse(precioTextBox.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un número positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Validar el formato de fecha
            if (!DateTime.TryParseExact(fechaTextBox.Text, "MM/dd/yy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateTime fecha))
            {
                MessageBox.Show("La fecha debe estar en el formato MM/dd/yy, por ejemplo, 12/31/20 para el 31 de diciembre de 2020.", "Formato de Fecha Inválido", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ExisteReparacion(idTextBox.Text))
            {
                MessageBox.Show("Ya existe una reparación con el mismo ID o número de matrícula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Si todas las validaciones son correctas, procede a añadir la reparación
            string query = @"INSERT INTO reparacion_N01 (id_reparacion, numero_matricula, observaciones, precio, tipo, fecha_reparacion) 
                     VALUES (@idReparacion, @numeroMatricula, @observaciones, @precio, @tipo, @fechaReparacion)";

            using (SqlConnection connection = new SqlConnection(reparacionDB.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idReparacion", idTextBox.Text);
                    command.Parameters.AddWithValue("@numeroMatricula", matriculaTextBox.Text);
                    command.Parameters.AddWithValue("@observaciones", observacionesTextBox.Text);
                    command.Parameters.AddWithValue("@precio", precio); // Se asume que ya se validó que es decimal
                    command.Parameters.AddWithValue("@tipo", tipoTextBox.Text);
                    command.Parameters.AddWithValue("@fechaReparacion", fecha); // Se asume que ya se validó el formato

                    try
                    {
                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Reparación añadida exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        Limpiar();
                        CargarReparaciones();
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Error de base de datos al añadir la reparación: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al añadir la reparación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private bool ExisteReparacion(string idReparacion)
        {
            string connectionString = "tu_cadena_de_conexion_aqui"; // Asegúrate de reemplazar esto con tu cadena de conexión real
            string query = "SELECT COUNT(*) FROM reparacion_N01 WHERE id_reparacion = @idReparacion";

            using (SqlConnection connection = new SqlConnection(reparacionDB.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@idReparacion", idReparacion);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al verificar la existencia de la reparación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true; // En caso de error, asume que existe para evitar duplicaciones.
                    }
                }
            }
        }




        private void adminAddProducts_updateBtn_Click(object sender, EventArgs e)
        {
            // Verificar si hay alguna fila actualmente seleccionada en el DataGridView de reparaciones
            if (datosReparacionDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione una reparación para editar.", "Seleccionar reparación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Cargar la información de la reparación seleccionada en los TextBoxes
            CargarDatosReparacionParaEdicion();

            // Deshabilitar la edición de id, matricula y fecha
            idTextBox.Enabled = false;
            matriculaTextBox.Enabled = false;
            fechaTextBox.Enabled = false;

            // Cambiar el botón de agregar a "Guardar Cambios"
            adminAddProducts_addBtn.Text = "GUARDAR CAMBIOS";
            adminAddProducts_addBtn.Click -= adminAddProducts_addBtn_Click; // Eliminar el evento de clic de agregar
            adminAddProducts_addBtn.Click += guardarCambiosBtn_Click; // Agregar el evento de clic de guardar cambios
        }
        private void CargarDatosReparacionParaEdicion()
        {
            // Asume que las columnas tienen estos nombres en tu DataGridView
            idTextBox.Text = datosReparacionDataGridView.CurrentRow.Cells["IdReparacion"].Value.ToString();
            matriculaTextBox.Text = datosReparacionDataGridView.CurrentRow.Cells["NumeroMatricula"].Value.ToString();
            observacionesTextBox.Text = datosReparacionDataGridView.CurrentRow.Cells["Observaciones"].Value.ToString();
            precioTextBox.Text = datosReparacionDataGridView.CurrentRow.Cells["Precio"].Value.ToString();
            tipoTextBox.Text = datosReparacionDataGridView.CurrentRow.Cells["Tipo"].Value.ToString();
            fechaTextBox.Text = ((DateTime)datosReparacionDataGridView.CurrentRow.Cells["FechaReparacion"].Value).ToString("MM/dd/yy");
        }

        private void guardarCambiosBtn_Click(object sender, EventArgs e)
        {
            // Realizar las validaciones necesarias para los campos editables
            if (!Regex.IsMatch(observacionesTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Las observaciones deben contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(tipoTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("El tipo debe contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(precioTextBox.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un número válido y positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Llamada al método para actualizar la reparación en la base de datos
            ActualizarReparacion();

            // Restablecer la UI
            adminAddProducts_addBtn.Text = "AGREGAR";
            adminAddProducts_addBtn.Click -= guardarCambiosBtn_Click;
            adminAddProducts_addBtn.Click += adminAddProducts_addBtn_Click;
            Limpiar();
            idTextBox.Enabled = true;
            matriculaTextBox.Enabled = true;
            fechaTextBox.Enabled = true;

            // Actualizar la lista de reparaciones
            CargarReparaciones();
        }

        private void ActualizarReparacion()
        {

            // Realizar las validaciones necesarias para los campos editables
            if (!Regex.IsMatch(observacionesTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Las observaciones deben contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!Regex.IsMatch(tipoTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("El tipo debe contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(precioTextBox.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un número válido y positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Utilizar el ID de la reparación para identificar el registro a actualizar
            string idReparacion = idTextBox.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(reparacionDB.connectionString))
                {
                    string query = @"UPDATE reparacion_N01 SET 
                             observaciones = @observaciones, 
                             precio = @precio, 
                             tipo = @tipo
                             WHERE id_reparacion = @idReparacion";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@observaciones", observacionesTextBox.Text);
                        command.Parameters.AddWithValue("@precio", precio);
                        command.Parameters.AddWithValue("@tipo", tipoTextBox.Text);
                        command.Parameters.AddWithValue("@idReparacion", idReparacion); // El ID ya viene definido y no se edita

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Reparación actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            // Aquí podrías llamar a métodos para actualizar la lista de reparaciones y limpiar los campos si es necesario
                        }
                        else
                        {
                            MessageBox.Show("No se encontró la reparación especificada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de base de datos al actualizar la reparación: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar la reparación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void adminAddProducts_deleteBtn_Click(object sender, EventArgs e)
        {
            if (datosReparacionDataGridView.SelectedRows.Count == null)
            {
                MessageBox.Show("Por favor, seleccione una reparación para eliminar.");

            }
            // Obtiene el ID de reparación seleccionado

            // Confirmación de eliminación
            var confirmResult = MessageBox.Show("¿Está seguro de que quiere eliminar la reparación seleccionada?",
                                                 "Confirmar eliminación", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string idReparacion = datosReparacionDataGridView.CurrentRow.Cells["IdReparacion"].Value.ToString();
                EliminarReparacion(idReparacion);
                CargarReparaciones();
            }

        }

        private void EliminarReparacion(string idReparacion)
        {
            string query = "DELETE FROM reparacion_N01 WHERE id_reparacion = @idReparacion";

            using (SqlConnection connection = new SqlConnection(reparacionDB.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    // Usar parámetros para prevenir inyecciones SQL
                    command.Parameters.AddWithValue("@idReparacion", idReparacion);

                    try
                    {
                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Reparación eliminada exitosamente.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarReparaciones();
                            Limpiar();
                        }
                        else
                        {
                            MessageBox.Show("La reparación no fue encontrada.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                    catch (SqlException ex)
                    {
                        MessageBox.Show($"Error de base de datos al eliminar la reparación: {ex.Message}", "Error de Base de Datos", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al eliminar la reparación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }


        private void adminAddProducts_clearBtn_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

    }
}
