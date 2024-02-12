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
    }
}
