using System;
using System.Configuration;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace GestionTalleres
{
    public partial class DashboardAdmin : UserControl
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["myconstring"].ConnectionString;
        public DashboardAdmin()
        {
            InitializeComponent();
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            this.VisibleChanged += DashboardAdmin_VisibleChanged;
        }

        private void DashboardAdmin_VisibleChanged(object sender, EventArgs e)
        {
            // Verifica si el control es visible
            if (this.Visible)
            {
                CargarDashboard();
            }
        }

        private void CargarDashboard()
        {
            // Actualiza cada contador en el dashboard
            ActualizarContador("SELECT COUNT(*) FROM Empleado_01", dashboard_TC);
            ActualizarContador("SELECT COUNT(*) FROM Cliente_01", dashboard_TCust);
            ActualizarContador("SELECT COUNT(*) FROM Vehiculo_01", dashboard_TI);
        }

        private void ActualizarContador(string query, Label labelToUpdate)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    SqlCommand command = new SqlCommand(query, connection);
                    connection.Open();
                    int total = (int)command.ExecuteScalar();
                    labelToUpdate.Text = total.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error al cargar datos: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
