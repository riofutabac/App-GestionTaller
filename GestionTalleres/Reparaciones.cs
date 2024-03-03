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
            CargarTiposDeReparaciones();
            CargarMatriculas();
        }

        private void Reparaciones_Load(object sender, EventArgs e)
        {
            CargarReparaciones();
        }

        private void CargarReparaciones()
        {
            List<ReparacionDB> reparaciones = reparacionDB.GetAllReparaciones();
            datosReparacionDataGridView.DataSource = reparaciones;
        }
        private void CargarMatriculas()
        {
            //List<string> matriculas = reparacionDB.GetAllMatriculas();
            //matriculaComboBox.DataSource = matriculas;
        }


        private void Limpiar()
        {
            idTextBox.Text = "";
            matriculaComboBox.Text = "";
            descripcionTextBox.Text = "";
            precioTextBox.Text = "";
            fecha.Text = "";

            idTextBox.Enabled = true;
            matriculaComboBox.Enabled = true;
            fecha.Enabled = true;

            adminAddProducts_addBtn.Text = "Agregar";
            adminAddProducts_addBtn.Click -= guardarCambiosBtn_Click;
            adminAddProducts_addBtn.Click += adminAddProducts_addBtn_Click;
        }

        private void adminAddProducts_addBtn_Click(object sender, EventArgs e)
        {
            AñadirReparacion();
        }

        private void AñadirReparacion()
        {
            if (!Regex.IsMatch(idTextBox.Text, @"^[a-zA-Z0-9]+$"))
            {
                MessageBox.Show("El ID deben ser alfanuméricos.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(precioTextBox.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un número positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (ExisteReparacion(idTextBox.Text))
            {
                MessageBox.Show("Ya existe una reparación con el mismo ID o número de matrícula.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            string query = @"INSERT INTO VistaReparacion (ID_Reparacion, Matricula, Descripcion, Precio, Tipo, FechaReparacion) 
                 VALUES (@ID_Reparacion, @Matricula, @Descripcion, @Precio, @Tipo, @FechaReparacion)";


            using (SqlConnection connection = new SqlConnection(reparacionDB.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Reparacion", idTextBox.Text);
                    command.Parameters.AddWithValue("@Matricula", matriculaComboBox.Text);
                    command.Parameters.AddWithValue("@Descripcion", descripcionTextBox.Text);
                    command.Parameters.AddWithValue("@Precio", precio);
                    command.Parameters.AddWithValue("@Tipo", tipoTextBox.Text);
                    command.Parameters.AddWithValue("@FechaReparacion", fecha.Value);

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

        private bool ExisteReparacion(string ID_Reparacion)
        {
            string query = "SELECT COUNT(*) FROM Reparacion_02 WHERE ID_Reparacion = @ID_Reparacion";

            using (SqlConnection connection = new SqlConnection(reparacionDB.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Reparacion", ID_Reparacion);

                    try
                    {
                        connection.Open();
                        int count = (int)command.ExecuteScalar();
                        return count > 0;
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error al verificar la existencia de la reparación: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        return true;
                    }
                }
            }
        }

        private void CargarTiposDeReparaciones()
        {
            List<string> tiposReparaciones = reparacionDB.GetAllTiposDeReparaciones();

        }

        private void adminAddProducts_updateBtn_Click(object sender, EventArgs e)
        {
            if (datosReparacionDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione una reparación para editar.", "Seleccionar reparación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarDatosReparacionParaEdicion();

            idTextBox.Enabled = false;
            matriculaComboBox.Enabled = false;
            fecha.Enabled = false;

            adminAddProducts_addBtn.Text = "GUARDAR CAMBIOS";
            adminAddProducts_addBtn.Click -= adminAddProducts_addBtn_Click;
            adminAddProducts_addBtn.Click += guardarCambiosBtn_Click;
        }

        private void CargarDatosReparacionParaEdicion()
        {
            idTextBox.Text = datosReparacionDataGridView.CurrentRow.Cells["ID_Reparacion"].Value.ToString();
            matriculaComboBox.Text = datosReparacionDataGridView.CurrentRow.Cells["Matricula"].Value.ToString();
            descripcionTextBox.Text = datosReparacionDataGridView.CurrentRow.Cells["Descripcion"].Value.ToString();
            precioTextBox.Text = datosReparacionDataGridView.CurrentRow.Cells["Precio"].Value.ToString();
            tipoTextBox.Text = datosReparacionDataGridView.CurrentRow.Cells["Tipo"].Value.ToString();
            fecha.Text = ((DateTime)datosReparacionDataGridView.CurrentRow.Cells["FechaReparacion"].Value).ToString("MM/dd/yy");
        }

        private void guardarCambiosBtn_Click(object sender, EventArgs e)
        {
            if (!Regex.IsMatch(descripcionTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("Las descripcion debe contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!decimal.TryParse(precioTextBox.Text, out decimal precio) || precio <= 0)
            {
                MessageBox.Show("El precio debe ser un número válido y positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            ActualizarReparacion();

            adminAddProducts_addBtn.Text = "AGREGAR";
            adminAddProducts_addBtn.Click -= guardarCambiosBtn_Click;
            adminAddProducts_addBtn.Click += adminAddProducts_addBtn_Click;
            Limpiar();
            idTextBox.Enabled = true;
            matriculaComboBox.Enabled = true;
            fecha.Enabled = true;

            CargarReparaciones();
            Limpiar();
        }

        private void ActualizarReparacion()
        {
            string idReparacion = idTextBox.Text;

            try
            {
                using (SqlConnection connection = new SqlConnection(reparacionDB.connectionString))
                {
                    string query = @"UPDATE Reparacion_01 SET 
                         Descripcion = @Descripcion, 
                         Precio = @Precio, 
                         Tipo = @Tipo
                         WHERE ID_Reparacion = @ID_Reparacion";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Descripcion", descripcionTextBox.Text);
                        command.Parameters.AddWithValue("@Precio", precioTextBox.Text);
                        command.Parameters.AddWithValue("@Tipo", tipoTextBox.Text);
                        command.Parameters.AddWithValue("@ID_Reparacion", idReparacion);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Reparación actualizada con éxito.", "Éxito", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

            var confirmResult = MessageBox.Show("¿Está seguro de que quiere eliminar la reparación seleccionada?",
                                                 "Confirmar eliminación", MessageBoxButtons.YesNo);
            if (confirmResult == DialogResult.Yes)
            {
                string idReparacion = datosReparacionDataGridView.CurrentRow.Cells["ID_Reparacion"].Value.ToString();
                EliminarReparacion(idReparacion);
                CargarReparaciones();
            }
        }

        private void EliminarReparacion(string idReparacion)
        {
            string query = "DELETE FROM VistaReparacion WHERE ID_Reparacion = @ID_Reparacion";


            using (SqlConnection connection = new SqlConnection(reparacionDB.connectionString))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ID_Reparacion", idReparacion);

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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
