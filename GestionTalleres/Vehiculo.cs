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

    }
}
