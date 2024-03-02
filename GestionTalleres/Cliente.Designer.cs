namespace GestionTalleres
{
    partial class Cliente
    {
        /// <summary> 
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de componentes

        /// <summary> 
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            DataGridViewCellStyle dataGridViewCellStyle1 = new DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Cliente));
            label1 = new Label();
            panel2 = new Panel();
            datosClienteDataGridView = new DataGridView();
            limpiarBtn = new Button();
            eliminarBtn = new Button();
            editarBtn = new Button();
            agregarBtn = new Button();
            apellidoClienteTextBox = new TextBox();
            label2 = new Label();
            adminAddUsers_imageView = new PictureBox();
            nombreClienteTextBox = new TextBox();
            label6 = new Label();
            cedulaClienteTextBox = new TextBox();
            label7 = new Label();
            label5 = new Label();
            panel3 = new Panel();
            panel1 = new Panel();
            ciudadTextBox = new TextBox();
            label3 = new Label();
            tallerComboBox = new ComboBox();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)datosClienteDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)adminAddUsers_imageView).BeginInit();
            panel3.SuspendLayout();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(21, 28);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(84, 22);
            label1.TabIndex = 0;
            label1.Text = "Clientes";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(datosClienteDataGridView);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(480, 27);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(904, 724);
            panel2.TabIndex = 3;
            // 
            // datosClienteDataGridView
            // 
            datosClienteDataGridView.AllowUserToAddRows = false;
            datosClienteDataGridView.AllowUserToDeleteRows = false;
            datosClienteDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datosClienteDataGridView.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(7, 99, 102);
            dataGridViewCellStyle1.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            datosClienteDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            datosClienteDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datosClienteDataGridView.EnableHeadersVisualStyles = false;
            datosClienteDataGridView.Location = new Point(25, 75);
            datosClienteDataGridView.Margin = new Padding(4);
            datosClienteDataGridView.Name = "datosClienteDataGridView";
            datosClienteDataGridView.ReadOnly = true;
            datosClienteDataGridView.RowHeadersVisible = false;
            datosClienteDataGridView.RowHeadersWidth = 51;
            datosClienteDataGridView.Size = new Size(855, 628);
            datosClienteDataGridView.TabIndex = 1;
            // 
            // limpiarBtn
            // 
            limpiarBtn.BackColor = Color.Maroon;
            limpiarBtn.FlatStyle = FlatStyle.Flat;
            limpiarBtn.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            limpiarBtn.ForeColor = Color.White;
            limpiarBtn.Location = new Point(248, 628);
            limpiarBtn.Margin = new Padding(4);
            limpiarBtn.Name = "limpiarBtn";
            limpiarBtn.Size = new Size(144, 56);
            limpiarBtn.TabIndex = 15;
            limpiarBtn.Text = "LIMPIAR";
            limpiarBtn.UseVisualStyleBackColor = false;
            limpiarBtn.Click += limpiarBtn_Click;
            // 
            // eliminarBtn
            // 
            eliminarBtn.BackColor = Color.Maroon;
            eliminarBtn.FlatStyle = FlatStyle.Flat;
            eliminarBtn.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            eliminarBtn.ForeColor = Color.White;
            eliminarBtn.Location = new Point(43, 628);
            eliminarBtn.Margin = new Padding(4);
            eliminarBtn.Name = "eliminarBtn";
            eliminarBtn.Size = new Size(144, 56);
            eliminarBtn.TabIndex = 14;
            eliminarBtn.Text = "ELIMINAR";
            eliminarBtn.UseVisualStyleBackColor = false;
            eliminarBtn.Click += eliminarBtn_Click;
            // 
            // editarBtn
            // 
            editarBtn.BackColor = Color.Maroon;
            editarBtn.FlatStyle = FlatStyle.Flat;
            editarBtn.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editarBtn.ForeColor = Color.White;
            editarBtn.Location = new Point(248, 536);
            editarBtn.Margin = new Padding(4);
            editarBtn.Name = "editarBtn";
            editarBtn.Size = new Size(144, 56);
            editarBtn.TabIndex = 13;
            editarBtn.Text = "EDITAR";
            editarBtn.UseVisualStyleBackColor = false;
            editarBtn.Click += editarBtn_Click;
            // 
            // agregarBtn
            // 
            agregarBtn.BackColor = Color.Maroon;
            agregarBtn.FlatStyle = FlatStyle.Flat;
            agregarBtn.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            agregarBtn.ForeColor = Color.White;
            agregarBtn.Location = new Point(43, 536);
            agregarBtn.Margin = new Padding(4);
            agregarBtn.Name = "agregarBtn";
            agregarBtn.Size = new Size(144, 56);
            agregarBtn.TabIndex = 12;
            agregarBtn.Text = "AGREGAR";
            agregarBtn.UseVisualStyleBackColor = false;
            agregarBtn.Click += agregarBtn_Click;
            // 
            // apellidoClienteTextBox
            // 
            apellidoClienteTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            apellidoClienteTextBox.Location = new Point(142, 324);
            apellidoClienteTextBox.Margin = new Padding(4);
            apellidoClienteTextBox.Name = "apellidoClienteTextBox";
            apellidoClienteTextBox.Size = new Size(246, 26);
            apellidoClienteTextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 327);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(72, 17);
            label2.TabIndex = 2;
            label2.Text = "Apellido:";
            // 
            // adminAddUsers_imageView
            // 
            adminAddUsers_imageView.Image = (Image)resources.GetObject("adminAddUsers_imageView.Image");
            adminAddUsers_imageView.Location = new Point(0, 4);
            adminAddUsers_imageView.Margin = new Padding(4);
            adminAddUsers_imageView.Name = "adminAddUsers_imageView";
            adminAddUsers_imageView.Size = new Size(120, 124);
            adminAddUsers_imageView.SizeMode = PictureBoxSizeMode.Zoom;
            adminAddUsers_imageView.TabIndex = 0;
            adminAddUsers_imageView.TabStop = false;
            // 
            // nombreClienteTextBox
            // 
            nombreClienteTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nombreClienteTextBox.Location = new Point(142, 275);
            nombreClienteTextBox.Margin = new Padding(4);
            nombreClienteTextBox.Name = "nombreClienteTextBox";
            nombreClienteTextBox.Size = new Size(246, 26);
            nombreClienteTextBox.TabIndex = 24;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(20, 278);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(71, 17);
            label6.TabIndex = 23;
            label6.Text = "Nombre:";
            // 
            // cedulaClienteTextBox
            // 
            cedulaClienteTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cedulaClienteTextBox.Location = new Point(142, 222);
            cedulaClienteTextBox.Margin = new Padding(4);
            cedulaClienteTextBox.Name = "cedulaClienteTextBox";
            cedulaClienteTextBox.Size = new Size(246, 26);
            cedulaClienteTextBox.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(20, 225);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(64, 17);
            label7.TabIndex = 21;
            label7.Text = "Cédula:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(20, 429);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(55, 17);
            label5.TabIndex = 17;
            label5.Text = "Taller:";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Silver;
            panel3.Controls.Add(adminAddUsers_imageView);
            panel3.Location = new Point(148, 28);
            panel3.Margin = new Padding(4);
            panel3.Name = "panel3";
            panel3.Size = new Size(120, 128);
            panel3.TabIndex = 16;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(ciudadTextBox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(tallerComboBox);
            panel1.Controls.Add(nombreClienteTextBox);
            panel1.Controls.Add(label6);
            panel1.Controls.Add(cedulaClienteTextBox);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(limpiarBtn);
            panel1.Controls.Add(eliminarBtn);
            panel1.Controls.Add(editarBtn);
            panel1.Controls.Add(agregarBtn);
            panel1.Controls.Add(apellidoClienteTextBox);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(20, 30);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(435, 721);
            panel1.TabIndex = 2;
            // 
            // ciudadTextBox
            // 
            ciudadTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            ciudadTextBox.Location = new Point(142, 375);
            ciudadTextBox.Margin = new Padding(4);
            ciudadTextBox.Name = "ciudadTextBox";
            ciudadTextBox.Size = new Size(246, 26);
            ciudadTextBox.TabIndex = 30;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(20, 378);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(64, 17);
            label3.TabIndex = 29;
            label3.Text = "Ciudad:";
            // 
            // tallerComboBox
            // 
            tallerComboBox.DropDownStyle = ComboBoxStyle.DropDownList;
            tallerComboBox.FormattingEnabled = true;
            tallerComboBox.Items.AddRange(new object[] { "1", "2" });
            tallerComboBox.Location = new Point(142, 429);
            tallerComboBox.Name = "tallerComboBox";
            tallerComboBox.Size = new Size(246, 23);
            tallerComboBox.Sorted = true;
            tallerComboBox.TabIndex = 28;
            // 
            // Cliente
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Cliente";
            Size = new Size(1416, 771);
            Load += Cliente_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)datosClienteDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)adminAddUsers_imageView).EndInit();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel2;
        private DataGridView datosClienteDataGridView;
        private Button limpiarBtn;
        private Button eliminarBtn;
        private Button editarBtn;
        private Button agregarBtn;
        private TextBox apellidoClienteTextBox;
        private Label label2;
        private PictureBox adminAddUsers_imageView;
        private TextBox nombreClienteTextBox;
        private Label label6;
        private TextBox cedulaClienteTextBox;
        private Label label7;
        private Label label5;
        private Panel panel3;
        private Panel panel1;
        private ComboBox tallerComboBox;
        private TextBox ciudadTextBox;
        private Label label3;
    }
}
