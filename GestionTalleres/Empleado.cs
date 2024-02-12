using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
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
    }
}
