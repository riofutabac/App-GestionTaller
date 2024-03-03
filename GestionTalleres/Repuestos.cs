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
    public partial class Repuestos : UserControl
    {
        private RepuestoDB repuestoDB;
        public Repuestos()
        {
            InitializeComponent();
            repuestoDB = new RepuestoDB();

        }

        private void Repuestos_Load(object sender, EventArgs e)
        {
            CargarRepuestos();
        }

        private void CargarRepuestos()
        {
            List<RepuestoDB> repuestos = repuestoDB.GetAllRepuestos();


            datosRepuestosDataGridView.DataSource = repuestos;


            datosRepuestosDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
        private void Limpiar()
        {
            idTextBox.Text = "";
            marcaTextBox.Text = "";
            nombreTextBox.Text = "";
            precioTextBox.Text = "";
            cantidadTextBox.Text = "";


            idTextBox.Enabled = true; // Desbloquear el ID por si estaba bloqueado
            adminAddProducts_addBtn.Text = "Agregar";
            adminAddProducts_addBtn.Click -= GuardarCambiosRepuesto_Click; // Remover el evento de clic de guardar cambios
            adminAddProducts_addBtn.Click += adminAddProducts_addBtn_Click; // Reasignar el evento de clic de agregar
        }


        private void adminAddProducts_clearBtn_Click(object sender, EventArgs e)
        {
            Limpiar();
        }

        private void EliminarRepuesto(string ID_Repuesto)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(repuestoDB.connectionString))
                {
                    string query = "DELETE FROM VistaRepuestos WHERE ID_Repuesto = @ID_Repuesto AND ID_Taller = @ID_Taller";


                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ID_Repuesto", ID_Repuesto);
                        command.Parameters.AddWithValue("@ID_Taller", Globals.SelectedNode); // Usando la variable global para determinar el taller actual


                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        // Verificar si la eliminación fue exitosa
                        if (result > 0)
                        {
                            MessageBox.Show("Repuesto eliminado exitosamente.", "Repuesto Eliminado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            CargarRepuestos();
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el repuesto especificado.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al eliminar el repuesto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void AgregarRepuesto()
        {

            if (!Regex.IsMatch(nombreTextBox.Text, @"^[a-zA-Z\s]+$") ||
                !Regex.IsMatch(marcaTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("La Marca y el Nombre deben contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!int.TryParse(cantidadTextBox.Text, out int Cantidad) || Cantidad < 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }


            // Continúa con la inserción en la base de datos si pasa las validaciones
            string ID_Repuesto = idTextBox.Text;
            string ID_Taller = Globals.SelectedNode.ToString();
            string Nombre = nombreTextBox.Text;
            string Marca = marcaTextBox.Text;
            decimal Precio;
            if (!decimal.TryParse(precioTextBox.Text, out Precio) || Precio < 0)
            {
                MessageBox.Show("El precio debe ser un número válido.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (RepuestoExiste(ID_Repuesto))
            {
                MessageBox.Show("Ya existe un repuesto con el mismo ID.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            bool RepuestoExiste(string idRepuesto)
            {
                try
                {
                    using (SqlConnection connection = new SqlConnection(repuestoDB.connectionString))
                    {
                        connection.Open();

                        // Consulta para verificar la existencia de un repuesto con el mismo ID
                        string query = "SELECT COUNT(1) FROM Repuestos_01 WHERE ID_Repuesto = @ID_Repuesto";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@ID_Repuesto", idRepuesto);

                            int count = (int)command.ExecuteScalar();
                            return count > 0;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error al verificar la existencia del repuesto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return false; // Si ocurre una excepción, asume que el repuesto no existe
            }

            try
            {
                using (SqlConnection connection = new SqlConnection(repuestoDB.connectionString))
                {
                    string query = @"
            INSERT INTO VistaRepuestos (ID_Repuesto, ID_Taller, Nombre, Precio, Cantidad, Marca) 
            VALUES (@ID_Repuesto, @ID_Taller, @Nombre, @Precio, @Cantidad, @Marca)";

                    using (SqlCommand command = new SqlCommand(query, connection))

                    {
                        command.Parameters.AddWithValue("@ID_Repuesto", ID_Repuesto);
                        command.Parameters.AddWithValue("@ID_Taller", ID_Taller);
                        command.Parameters.AddWithValue("@Nombre", Nombre);
                        command.Parameters.AddWithValue("@Precio", Precio);
                        command.Parameters.AddWithValue("@Cantidad", Cantidad);
                        command.Parameters.AddWithValue("@Marca", Marca);

                        connection.Open();
                        command.ExecuteNonQuery();
                        MessageBox.Show("Repuesto agregado con éxito.", "Repuesto Agregado", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        CargarRepuestos();
                        Limpiar();
                    }
                }
            }
            catch (SqlException ex)
            {
                // Aquí podrías manejar errores específicos de SQL
                MessageBox.Show($"Error al agregar el repuesto: {ex.Message}", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                // Capturar otros errores no relacionados con SQL
                MessageBox.Show($"Error al agregar el repuesto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adminAddProducts_addBtn_Click(object sender, EventArgs e)
        {
            AgregarRepuesto();
        }

        private void adminAddProducts_deleteBtn_Click(object sender, EventArgs e)
        {
            // Verificar si hay alguna fila actualmente seleccionada en el DataGridView de repuestos
            if (datosRepuestosDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un repuesto para eliminar.", "Seleccionar repuesto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Confirmación de eliminación
            var confirmResult = MessageBox.Show("¿Está seguro de que quiere eliminar el repuesto seleccionado?", "Confirmar eliminación", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirmResult == DialogResult.Yes)
            {
                // Obtener el id del repuesto seleccionado
                string idRepuestoSeleccionado = datosRepuestosDataGridView.CurrentRow.Cells["ID_Repuesto"].Value.ToString();
                EliminarRepuesto(idRepuestoSeleccionado);
            }
        }



        private void CargarDatosRepuestoParaEdicion()
        {
            // Asumiendo que las columnas tienen estos nombres en tu DataGridView
            idTextBox.Text = datosRepuestosDataGridView.CurrentRow.Cells["ID_Repuesto"].Value.ToString();
            nombreTextBox.Text = datosRepuestosDataGridView.CurrentRow.Cells["Nombre"].Value.ToString();
            precioTextBox.Text = datosRepuestosDataGridView.CurrentRow.Cells["Precio"].Value.ToString();
            cantidadTextBox.Text = datosRepuestosDataGridView.CurrentRow.Cells["Cantidad"].Value.ToString();
            marcaTextBox.Text = datosRepuestosDataGridView.CurrentRow.Cells["Marca"].Value.ToString();
        }

        private void GuardarCambiosRepuesto_Click(object sender, EventArgs e)
        {
            // Validaciones de los campos editables
            if (!Regex.IsMatch(nombreTextBox.Text, @"^[a-zA-Z\s]+$") ||
                !Regex.IsMatch(marcaTextBox.Text, @"^[a-zA-Z\s]+$"))
            {
                MessageBox.Show("La Marca y Nombre deben contener solo letras.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            if (!int.TryParse(cantidadTextBox.Text, out int cantidad) || cantidad < 0)
            {
                MessageBox.Show("La cantidad debe ser un número entero positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }
            decimal precio;
            if (!decimal.TryParse(precioTextBox.Text, out precio) || precio < 0)
            {
                MessageBox.Show("El precio debe ser un número válido y positivo.", "Validación", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Llamada al método para actualizar el repuesto en la base de datos
            ActualizarRepuesto();

            // Restablecer UI
            adminAddProducts_addBtn.Text = "AGREGAR";
            adminAddProducts_addBtn.Click -= GuardarCambiosRepuesto_Click;
            adminAddProducts_addBtn.Click += adminAddProducts_addBtn_Click;
            Limpiar();
            CargarRepuestos();
            // Habilitar ID TextBox si estaba deshabilitado
            idTextBox.Enabled = true;
        }

        private void ActualizarRepuesto()
        {
            string ID_Repuesto = idTextBox.Text;
            string Nombre = nombreTextBox.Text;
            string Marca = marcaTextBox.Text;
            decimal Precio = decimal.Parse(precioTextBox.Text);
            int Cantidad = int.Parse(cantidadTextBox.Text);
            string ID_Taller = Globals.SelectedNode.ToString();

            try
            {
                using (SqlConnection connection = new SqlConnection(repuestoDB.connectionString))
                {
                    string query = @"UPDATE Repuestos_01 
                             SET Nombre = @Nombre, Marca = @Marca, Precio = @Precio, 
                                 Cantidad = @Cantidad, 
                                 ID_Taller = @ID_Taller
                             WHERE ID_Repuesto = @ID_Repuesto";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nombre", Nombre);
                        command.Parameters.AddWithValue("@Marca", Marca);
                        command.Parameters.AddWithValue("@Precio", Precio);
                        command.Parameters.AddWithValue("@Cantidad", Cantidad);
                        command.Parameters.AddWithValue("@ID_Taller", ID_Taller);
                        command.Parameters.AddWithValue("@ID_Repuesto", ID_Repuesto);

                        connection.Open();
                        int result = command.ExecuteNonQuery();

                        if (result > 0)
                        {
                            MessageBox.Show("Repuesto actualizado exitosamente.", "Actualización Exitosa", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        }
                        else
                        {
                            MessageBox.Show("No se encontró el repuesto o no se realizaron cambios.", "Actualización Fallida", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                MessageBox.Show($"Error de base de datos al actualizar el repuesto: {ex.Message}", "Error SQL", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al actualizar el repuesto: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void adminAddProducts_updateBtn_Click(object sender, EventArgs e)
        {
            if (datosRepuestosDataGridView.CurrentRow == null)
            {
                MessageBox.Show("Por favor, seleccione un repuesto para editar.", "Seleccionar repuesto", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            CargarDatosRepuestoParaEdicion();

            idTextBox.Enabled = false;


            adminAddProducts_addBtn.Text = "Guardar Cambios";
            adminAddProducts_addBtn.Click -= adminAddProducts_addBtn_Click;
            adminAddProducts_addBtn.Click += GuardarCambiosRepuesto_Click;
        }
    }
}
