
namespace GestionTalleres
{
    partial class Admin
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Admin));
            panel1 = new Panel();
            closeBttn = new Label();
            label1 = new Label();
            close = new Label();
            panel2 = new Panel();
            salirButton = new Button();
            inicioButton = new Button();
            repuestoBttn = new Button();
            empleadoButton = new Button();
            logout_btn = new Button();
            reparacionButton = new Button();
            clienteButton = new Button();
            vehiculoButton = new Button();
            nombreUsuarioLabel = new Label();
            label3 = new Label();
            label2 = new Label();
            pictureBox1 = new PictureBox();
            panel3 = new Panel();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(closeBttn);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(close);
            panel1.Dock = DockStyle.Top;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1698, 52);
            panel1.TabIndex = 0;
            // 
            // closeBttn
            // 
            closeBttn.AutoSize = true;
            closeBttn.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            closeBttn.Location = new Point(1669, 16);
            closeBttn.Margin = new Padding(4, 0, 4, 0);
            closeBttn.Name = "closeBttn";
            closeBttn.Size = new Size(18, 18);
            closeBttn.TabIndex = 11;
            closeBttn.Text = "X";
            closeBttn.Click += closeBttn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 17);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(98, 17);
            label1.TabIndex = 3;
            label1.Text = "ReparaTodo";
            // 
            // close
            // 
            close.AutoSize = true;
            close.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            close.Location = new Point(1719, 11);
            close.Margin = new Padding(4, 0, 4, 0);
            close.Name = "close";
            close.Size = new Size(18, 18);
            close.TabIndex = 2;
            close.Text = "X";
            // 
            // panel2
            // 
            panel2.BackColor = Color.FromArgb(192, 0, 0);
            panel2.Controls.Add(salirButton);
            panel2.Controls.Add(inicioButton);
            panel2.Controls.Add(repuestoBttn);
            panel2.Controls.Add(empleadoButton);
            panel2.Controls.Add(logout_btn);
            panel2.Controls.Add(reparacionButton);
            panel2.Controls.Add(clienteButton);
            panel2.Controls.Add(vehiculoButton);
            panel2.Controls.Add(nombreUsuarioLabel);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label2);
            panel2.Controls.Add(pictureBox1);
            panel2.Dock = DockStyle.Left;
            panel2.Location = new Point(0, 52);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(290, 773);
            panel2.TabIndex = 1;
            // 
            // salirButton
            // 
            salirButton.BackColor = Color.Maroon;
            salirButton.FlatStyle = FlatStyle.Flat;
            salirButton.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            salirButton.ForeColor = Color.White;
            salirButton.Location = new Point(14, 692);
            salirButton.Margin = new Padding(4);
            salirButton.Name = "salirButton";
            salirButton.Size = new Size(262, 53);
            salirButton.TabIndex = 20;
            salirButton.Text = "Salir";
            salirButton.UseVisualStyleBackColor = false;
            salirButton.Click += closeBttn_Click;
            // 
            // inicioButton
            // 
            inicioButton.BackColor = Color.Maroon;
            inicioButton.FlatStyle = FlatStyle.Flat;
            inicioButton.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            inicioButton.ForeColor = Color.White;
            inicioButton.Location = new Point(14, 255);
            inicioButton.Margin = new Padding(4);
            inicioButton.Name = "inicioButton";
            inicioButton.Size = new Size(262, 53);
            inicioButton.TabIndex = 19;
            inicioButton.Text = "Inicio";
            inicioButton.UseVisualStyleBackColor = false;
            inicioButton.Click += inicionButton_Click;
            // 
            // repuestoBttn
            // 
            repuestoBttn.BackColor = Color.Maroon;
            repuestoBttn.FlatStyle = FlatStyle.Flat;
            repuestoBttn.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            repuestoBttn.ForeColor = Color.White;
            repuestoBttn.Location = new Point(14, 549);
            repuestoBttn.Margin = new Padding(4);
            repuestoBttn.Name = "repuestoBttn";
            repuestoBttn.Size = new Size(262, 53);
            repuestoBttn.TabIndex = 18;
            repuestoBttn.Text = "Repuestos";
            repuestoBttn.UseVisualStyleBackColor = false;
            repuestoBttn.Click += repuestoBttn_Click;
            // 
            // empleadoButton
            // 
            empleadoButton.BackColor = Color.Maroon;
            empleadoButton.FlatStyle = FlatStyle.Flat;
            empleadoButton.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            empleadoButton.ForeColor = Color.White;
            empleadoButton.Location = new Point(14, 619);
            empleadoButton.Margin = new Padding(4);
            empleadoButton.Name = "empleadoButton";
            empleadoButton.Size = new Size(262, 53);
            empleadoButton.TabIndex = 18;
            empleadoButton.Text = "Empleados";
            empleadoButton.UseVisualStyleBackColor = false;
            empleadoButton.Click += empleadoButton_Click;
            // 
            // logout_btn
            // 
            logout_btn.BackColor = Color.FromArgb(7, 99, 102);
            logout_btn.FlatStyle = FlatStyle.Flat;
            logout_btn.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            logout_btn.ForeColor = Color.White;
            logout_btn.Location = new Point(14, 793);
            logout_btn.Margin = new Padding(4);
            logout_btn.Name = "logout_btn";
            logout_btn.Size = new Size(262, 53);
            logout_btn.TabIndex = 17;
            logout_btn.Text = "Logout";
            logout_btn.UseVisualStyleBackColor = false;
            // 
            // reparacionButton
            // 
            reparacionButton.BackColor = Color.Maroon;
            reparacionButton.FlatStyle = FlatStyle.Flat;
            reparacionButton.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reparacionButton.ForeColor = Color.White;
            reparacionButton.Location = new Point(14, 479);
            reparacionButton.Margin = new Padding(4);
            reparacionButton.Name = "reparacionButton";
            reparacionButton.Size = new Size(262, 53);
            reparacionButton.TabIndex = 16;
            reparacionButton.Text = "Reparaciones";
            reparacionButton.UseVisualStyleBackColor = false;
            reparacionButton.Click += reparacionButton_Click;
            // 
            // clienteButton
            // 
            clienteButton.BackColor = Color.Maroon;
            clienteButton.FlatStyle = FlatStyle.Flat;
            clienteButton.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            clienteButton.ForeColor = Color.White;
            clienteButton.Location = new Point(14, 401);
            clienteButton.Margin = new Padding(4);
            clienteButton.Name = "clienteButton";
            clienteButton.Size = new Size(262, 53);
            clienteButton.TabIndex = 14;
            clienteButton.Text = "Clientes";
            clienteButton.UseVisualStyleBackColor = false;
            clienteButton.Click += clienteButton_Click;
            // 
            // vehiculoButton
            // 
            vehiculoButton.BackColor = Color.Maroon;
            vehiculoButton.FlatStyle = FlatStyle.Flat;
            vehiculoButton.Font = new Font("Arial Rounded MT Bold", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            vehiculoButton.ForeColor = Color.White;
            vehiculoButton.Location = new Point(14, 330);
            vehiculoButton.Margin = new Padding(4);
            vehiculoButton.Name = "vehiculoButton";
            vehiculoButton.Size = new Size(262, 53);
            vehiculoButton.TabIndex = 13;
            vehiculoButton.Text = "Vehiculos";
            vehiculoButton.UseVisualStyleBackColor = false;
            vehiculoButton.Click += vehiculoButton_Click;
            // 
            // nombreUsuarioLabel
            // 
            nombreUsuarioLabel.AutoSize = true;
            nombreUsuarioLabel.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nombreUsuarioLabel.ForeColor = Color.White;
            nombreUsuarioLabel.Location = new Point(108, 224);
            nombreUsuarioLabel.Margin = new Padding(4, 0, 4, 0);
            nombreUsuarioLabel.Name = "nombreUsuarioLabel";
            nombreUsuarioLabel.Size = new Size(48, 15);
            nombreUsuarioLabel.TabIndex = 12;
            nombreUsuarioLabel.Text = "Admin";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.ForeColor = Color.White;
            label3.Location = new Point(14, 224);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(58, 15);
            label3.TabIndex = 4;
            label3.Text = "Usuario";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.ForeColor = Color.White;
            label2.Location = new Point(66, 182);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(129, 22);
            label2.TabIndex = 4;
            label2.Text = "Admin Portal";
            // 
            // pictureBox1
            // 
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(83, 62);
            pictureBox1.Margin = new Padding(4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(116, 116);
            pictureBox1.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox1.TabIndex = 11;
            pictureBox1.TabStop = false;
            // 
            // panel3
            // 
            panel3.Dock = DockStyle.Fill;
            panel3.Location = new Point(290, 52);
            panel3.Margin = new Padding(3, 2, 3, 2);
            panel3.Name = "panel3";
            panel3.Size = new Size(1408, 773);
            panel3.TabIndex = 2;
            // 
            // Admin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1698, 825);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Margin = new Padding(4);
            Name = "Admin";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Admin";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label close;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label nombreUsuarioLabel;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button reparacionButton;
        private System.Windows.Forms.Button clienteButton;
        private System.Windows.Forms.Button vehiculoButton;
        private System.Windows.Forms.Button logout_btn;
        private Button inicioButton;
        private Button empleadoButton;
        private Button salirButton;
        private Label closeBttn;
        private Panel panel3;
        private Button repuestoBttn;
    }
}