using System;
using System.Windows.Forms;

namespace GestionTalleres
{
    public partial class Login : Form
    {
        public Login()
        {
            InitializeComponent();

            NodocomboBox.SelectedIndex = 0;
        }
        private void CloseBttn_Click(object sender, EventArgs e)
        {

            DialogResult result = MessageBox.Show("¿Está seguro que desea salir?", "Confirmar salida", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
 
                Application.Exit();
            }
        }

        private void Login_btn_Click(object sender, EventArgs e)
        {
      
            string usuario = cedulaLogin.Text.Trim();
            string contraseña = contraseniaLogin.Text.Trim();


            if (string.IsNullOrEmpty(usuario) || string.IsNullOrEmpty(contraseña))
            {
                MessageBox.Show("Por favor, ingrese usuario y contraseña.", "Campos vacíos", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (usuario == "admin" && contraseña == "admin")
            {
                MessageBox.Show("Bienvenido, admin!", "Inicio de sesión exitoso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                Admin adminForm = new Admin();
                adminForm.Show();

                this.Hide();
            }
            else
            {
                MessageBox.Show("Usuario o contraseña incorrectos. Por favor, inténtelo de nuevo.", "Error de inicio de sesión", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void Login_showPass_CheckedChanged(object sender, EventArgs e)
        {
            contraseniaLogin.PasswordChar = login_showPass.Checked ? '\0' : '*';
        }

        private void CedulaLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                contraseniaLogin.Focus();
            }
        }

        private void ContraseniaLogin_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Login_btn_Click(sender, e);
            }
        }

        private void NodocomboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (NodocomboBox.SelectedItem.ToString() == "N01_QUITO")
            {
                Globals.SelectedNode = 1;

            }
            else if (NodocomboBox.SelectedItem.ToString() == "N02_GUAYAQUIL")
            {
                Globals.SelectedNode = 2;
            }
        }

    }
}
