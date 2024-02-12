using System;
using System.Collections.Generic;
using System.Windows.Forms;

namespace GestionTalleres
{
    public partial class Cliente : UserControl
    {
        private ClienteDB clienteDB; 

        public Cliente()
        {
            InitializeComponent();
            clienteDB = new ClienteDB(); 
        }

        private void Cliente_Load(object sender, EventArgs e)
        {
            CargarClientes(); 
        }

        private void CargarClientes()
        {
            List<ClienteDB> clientes = clienteDB.GetAllClientes(); 

  
            datosClienteDataGridView.DataSource = clientes;

 
            datosClienteDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
        }
    }
}
