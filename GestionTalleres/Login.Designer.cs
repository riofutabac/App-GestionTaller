namespace GestionTalleres
{
    partial class Login
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Login));
            panel1 = new Panel();
            label6 = new Label();
            pictureBox1 = new PictureBox();
            login_btn = new Button();
            login_showPass = new CheckBox();
            contraseniaLogin = new TextBox();
            label4 = new Label();
            cedulaLogin = new TextBox();
            label3 = new Label();
            label2 = new Label();
            closeBttn = new Label();
            NodocomboBox = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(192, 0, 0);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(393, 559);
            panel1.TabIndex = 9;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.ForeColor = Color.White;
            label6.Location = new Point(104, 236);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(148, 22);
            label6.TabIndex = 9;
            label6.Text = "REPARATODO";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(126, 97);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(116, 116);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 10;
            pictureBox1.TabStop = false;
            // 
            // login_btn
            // 
            login_btn.BackColor = Color.FromArgb(64, 0, 0);
            login_btn.FlatStyle = FlatStyle.Flat;
            login_btn.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_btn.ForeColor = Color.White;
            login_btn.Location = new Point(441, 400);
            login_btn.Margin = new Padding(4);
            login_btn.Name = "login_btn";
            login_btn.Size = new Size(134, 43);
            login_btn.TabIndex = 17;
            login_btn.Text = "Ingresar";
            login_btn.UseVisualStyleBackColor = false;
            login_btn.Click += Login_btn_Click;
            // 
            // login_showPass
            // 
            login_showPass.AutoSize = true;
            login_showPass.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            login_showPass.Location = new Point(439, 309);
            login_showPass.Margin = new Padding(4);
            login_showPass.Name = "login_showPass";
            login_showPass.Size = new Size(171, 21);
            login_showPass.TabIndex = 16;
            login_showPass.Text = "Mostrar contraseña";
            login_showPass.UseVisualStyleBackColor = true;
            login_showPass.CheckedChanged += Login_showPass_CheckedChanged;
            // 
            // contraseniaLogin
            // 
            contraseniaLogin.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            contraseniaLogin.Location = new Point(441, 267);
            contraseniaLogin.Margin = new Padding(4);
            contraseniaLogin.Name = "contraseniaLogin";
            contraseniaLogin.PasswordChar = '*';
            contraseniaLogin.Size = new Size(320, 26);
            contraseniaLogin.TabIndex = 15;
            contraseniaLogin.KeyDown += ContraseniaLogin_KeyDown;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(438, 247);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(93, 17);
            label4.TabIndex = 14;
            label4.Text = "Contraseña";
            // 
            // cedulaLogin
            // 
            cedulaLogin.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cedulaLogin.Location = new Point(439, 201);
            cedulaLogin.Margin = new Padding(4);
            cedulaLogin.Name = "cedulaLogin";
            cedulaLogin.Size = new Size(320, 26);
            cedulaLogin.TabIndex = 13;
            cedulaLogin.KeyDown += CedulaLogin_KeyDown;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(436, 176);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(59, 17);
            label3.TabIndex = 12;
            label3.Text = "Cédula";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(436, 111);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(79, 22);
            label2.TabIndex = 11;
            label2.Text = "Ingreso";
            // 
            // closeBttn
            // 
            closeBttn.AutoSize = true;
            closeBttn.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            closeBttn.Location = new Point(775, 11);
            closeBttn.Margin = new Padding(4, 0, 4, 0);
            closeBttn.Name = "closeBttn";
            closeBttn.Size = new Size(18, 18);
            closeBttn.TabIndex = 10;
            closeBttn.Text = "X";
            closeBttn.Click += CloseBttn_Click;
            // 
            // NodocomboBox
            // 
            NodocomboBox.FormattingEnabled = true;
            NodocomboBox.Items.AddRange(new object[] { "N01_QUITO", "N02_GUAYAQUIL" });
            NodocomboBox.Location = new Point(441, 351);
            NodocomboBox.Name = "NodocomboBox";
            NodocomboBox.Size = new Size(121, 23);
            NodocomboBox.TabIndex = 18;
            NodocomboBox.SelectedIndexChanged += NodocomboBox_SelectedIndexChanged;
            // 
            // Login
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(799, 559);
            Controls.Add(NodocomboBox);
            Controls.Add(panel1);
            Controls.Add(login_btn);
            Controls.Add(login_showPass);
            Controls.Add(contraseniaLogin);
            Controls.Add(label4);
            Controls.Add(cedulaLogin);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(closeBttn);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(3, 2, 3, 2);
            Name = "Login";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Login";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Panel panel1;
        private Label label6;
        private PictureBox pictureBox1;
        private Button login_btn;
        private CheckBox login_showPass;
        private TextBox contraseniaLogin;
        private Label label4;
        private TextBox cedulaLogin;
        private Label label3;
        private Label label2;
        private Label closeBttn;
        private ComboBox NodocomboBox;
    }
}