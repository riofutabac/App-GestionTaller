namespace GestionTalleres
{
    partial class Empleado
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Empleado));
            label1 = new Label();
            panel2 = new Panel();
            datosEmpleadosDataGridView = new DataGridView();
            limpiarBtn = new Button();
            eliminarBtn = new Button();
            editarBtn = new Button();
            agregarBtn = new Button();
            cedulaTextBox = new TextBox();
            label3 = new Label();
            nombreTextBox = new TextBox();
            label2 = new Label();
            adminAddUsers_imageView = new PictureBox();
            codigoTextBox = new TextBox();
            label7 = new Label();
            salarioTextBox = new TextBox();
            label4 = new Label();
            label5 = new Label();
            panel3 = new Panel();
            panel1 = new Panel();
            apellidoTextBox = new TextBox();
            label8 = new Label();
            fechaContrato = new DateTimePicker();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)datosEmpleadosDataGridView).BeginInit();
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
            label1.Size = new Size(112, 22);
            label1.TabIndex = 0;
            label1.Text = "Empleados";
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(datosEmpleadosDataGridView);
            panel2.Controls.Add(label1);
            panel2.Location = new Point(480, 27);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(908, 721);
            panel2.TabIndex = 3;
            // 
            // datosEmpleadosDataGridView
            // 
            datosEmpleadosDataGridView.AllowUserToAddRows = false;
            datosEmpleadosDataGridView.AllowUserToDeleteRows = false;
            datosEmpleadosDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datosEmpleadosDataGridView.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(7, 99, 102);
            dataGridViewCellStyle1.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            datosEmpleadosDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            datosEmpleadosDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datosEmpleadosDataGridView.EnableHeadersVisualStyles = false;
            datosEmpleadosDataGridView.Location = new Point(25, 75);
            datosEmpleadosDataGridView.Margin = new Padding(4);
            datosEmpleadosDataGridView.Name = "datosEmpleadosDataGridView";
            datosEmpleadosDataGridView.ReadOnly = true;
            datosEmpleadosDataGridView.RowHeadersVisible = false;
            datosEmpleadosDataGridView.RowHeadersWidth = 51;
            datosEmpleadosDataGridView.Size = new Size(859, 620);
            datosEmpleadosDataGridView.TabIndex = 1;
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
            // cedulaTextBox
            // 
            cedulaTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cedulaTextBox.Location = new Point(142, 336);
            cedulaTextBox.Margin = new Padding(4);
            cedulaTextBox.Name = "cedulaTextBox";
            cedulaTextBox.Size = new Size(246, 26);
            cedulaTextBox.TabIndex = 5;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(20, 339);
            label3.Margin = new Padding(4, 0, 4, 0);
            label3.Name = "label3";
            label3.Size = new Size(64, 17);
            label3.TabIndex = 4;
            label3.Text = "Cedula:";
            // 
            // nombreTextBox
            // 
            nombreTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nombreTextBox.Location = new Point(142, 239);
            nombreTextBox.Margin = new Padding(4);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(246, 26);
            nombreTextBox.TabIndex = 3;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(20, 242);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(71, 17);
            label2.TabIndex = 2;
            label2.Text = "Nombre:";
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
            // codigoTextBox
            // 
            codigoTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            codigoTextBox.Location = new Point(142, 187);
            codigoTextBox.Margin = new Padding(4);
            codigoTextBox.Name = "codigoTextBox";
            codigoTextBox.Size = new Size(246, 26);
            codigoTextBox.TabIndex = 22;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(20, 190);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(51, 17);
            label7.TabIndex = 21;
            label7.Text = "Code:";
            // 
            // salarioTextBox
            // 
            salarioTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            salarioTextBox.Location = new Point(142, 445);
            salarioTextBox.Margin = new Padding(4);
            salarioTextBox.Name = "salarioTextBox";
            salarioTextBox.Size = new Size(246, 26);
            salarioTextBox.TabIndex = 20;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(20, 448);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(65, 17);
            label4.TabIndex = 19;
            label4.Text = "Salario:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(20, 394);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(73, 17);
            label5.TabIndex = 17;
            label5.Text = "Fecha C:";
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
            panel1.Controls.Add(apellidoTextBox);
            panel1.Controls.Add(label8);
            panel1.Controls.Add(fechaContrato);
            panel1.Controls.Add(codigoTextBox);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(salarioTextBox);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(panel3);
            panel1.Controls.Add(limpiarBtn);
            panel1.Controls.Add(eliminarBtn);
            panel1.Controls.Add(editarBtn);
            panel1.Controls.Add(agregarBtn);
            panel1.Controls.Add(cedulaTextBox);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(nombreTextBox);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(20, 30);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(435, 718);
            panel1.TabIndex = 2;
            // 
            // apellidoTextBox
            // 
            apellidoTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            apellidoTextBox.Location = new Point(142, 287);
            apellidoTextBox.Margin = new Padding(4);
            apellidoTextBox.Name = "apellidoTextBox";
            apellidoTextBox.Size = new Size(246, 26);
            apellidoTextBox.TabIndex = 31;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(20, 290);
            label8.Margin = new Padding(4, 0, 4, 0);
            label8.Name = "label8";
            label8.Size = new Size(72, 17);
            label8.TabIndex = 30;
            label8.Text = "Apellido:";
            // 
            // fechaContrato
            // 
            fechaContrato.Location = new Point(142, 394);
            fechaContrato.Name = "fechaContrato";
            fechaContrato.Size = new Size(246, 23);
            fechaContrato.TabIndex = 29;
            // 
            // Empleado
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoSize = true;
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 2, 3, 2);
            Name = "Empleado";
            Size = new Size(1409, 784);
            Load += Empleado_Load;
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)datosEmpleadosDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)adminAddUsers_imageView).EndInit();
            panel3.ResumeLayout(false);
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private Label label1;
        private Panel panel2;
        private DataGridView datosEmpleadosDataGridView;
        private Button limpiarBtn;
        private Button eliminarBtn;
        private Button editarBtn;
        private Button agregarBtn;
        private TextBox cedulaTextBox;
        private Label label3;
        private TextBox nombreTextBox;
        private Label label2;
        private PictureBox adminAddUsers_imageView;
        private TextBox codigoTextBox;
        private Label label7;
        private TextBox salarioTextBox;
        private Label label4;
        private Label label5;
        private Panel panel3;
        private Panel panel1;
        private DateTimePicker fechaContrato;
        private TextBox apellidoTextBox;
        private Label label8;
    }
}
