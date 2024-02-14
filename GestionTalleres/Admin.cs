using System;
using System.Windows.Forms;

namespace GestionTalleres
{
    partial class Admin : Form
    {
        DashboardAdmin dashboardAdmin = new DashboardAdmin();
        Cliente cliente = new Cliente();
        Vehiculo vehiculo = new Vehiculo();
        Reparaciones reparaciones = new Reparaciones();
        Empleado empleados = new Empleado();
        Repuestos repuestos = new Repuestos();

        public Admin()
        {
            InitializeComponent();
            panel3.Controls.Add(dashboardAdmin);
        }

        private void clienteButton_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            panel3.Controls.Add(cliente);
        }
        private void inicionButton_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            panel3.Controls.Add(dashboardAdmin);
        }
        private void vehiculoButton_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            panel3.Controls.Add(vehiculo);
        }

        private void reparacionButton_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            panel3.Controls.Add(reparaciones);
        }

        private void empleadoButton_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            panel3.Controls.Add(empleados);
        }

        private void repuestoBttn_Click(object sender, EventArgs e)
        {
            panel3.Controls.Clear();
            panel3.Controls.Add(repuestos);
        }

        private void closeBttn_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("¿Está seguro que desea salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
