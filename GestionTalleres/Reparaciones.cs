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
    }
}
