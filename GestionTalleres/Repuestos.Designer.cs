namespace GestionTalleres
{
    partial class Repuestos
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Repuestos));
            datosRepuestosDataGridView = new DataGridView();
            adminAddUsers_imageView = new PictureBox();
            marcaTextBox = new TextBox();
            nombreTextBox = new TextBox();
            adminAddProducts_clearBtn = new Button();
            adminAddProducts_deleteBtn = new Button();
            adminAddProducts_updateBtn = new Button();
            adminAddProducts_addBtn = new Button();
            label4 = new Label();
            cantidadTextBox = new TextBox();
            panel1 = new Panel();
            label1 = new Label();
            label6 = new Label();
            label7 = new Label();
            label5 = new Label();
            idTextBox = new TextBox();
            label2 = new Label();
            precioTextBox = new TextBox();
            panel2 = new Panel();
            ((System.ComponentModel.ISupportInitialize)datosRepuestosDataGridView).BeginInit();
            ((System.ComponentModel.ISupportInitialize)adminAddUsers_imageView).BeginInit();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            SuspendLayout();
            // 
            // datosRepuestosDataGridView
            // 
            datosRepuestosDataGridView.AllowUserToAddRows = false;
            datosRepuestosDataGridView.AllowUserToDeleteRows = false;
            datosRepuestosDataGridView.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            datosRepuestosDataGridView.BorderStyle = BorderStyle.None;
            dataGridViewCellStyle1.Alignment = DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle1.BackColor = Color.FromArgb(7, 99, 102);
            dataGridViewCellStyle1.Font = new Font("Arial Rounded MT Bold", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            dataGridViewCellStyle1.ForeColor = Color.White;
            dataGridViewCellStyle1.SelectionBackColor = SystemColors.Highlight;
            dataGridViewCellStyle1.SelectionForeColor = SystemColors.HighlightText;
            dataGridViewCellStyle1.WrapMode = DataGridViewTriState.False;
            datosRepuestosDataGridView.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle1;
            datosRepuestosDataGridView.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            datosRepuestosDataGridView.EnableHeadersVisualStyles = false;
            datosRepuestosDataGridView.Location = new Point(22, 62);
            datosRepuestosDataGridView.Margin = new Padding(4);
            datosRepuestosDataGridView.Name = "datosRepuestosDataGridView";
            datosRepuestosDataGridView.ReadOnly = true;
            datosRepuestosDataGridView.RowHeadersVisible = false;
            datosRepuestosDataGridView.RowHeadersWidth = 51;
            datosRepuestosDataGridView.Size = new Size(1317, 284);
            datosRepuestosDataGridView.TabIndex = 2;
            // 
            // adminAddUsers_imageView
            // 
            adminAddUsers_imageView.Image = (Image)resources.GetObject("adminAddUsers_imageView.Image");
            adminAddUsers_imageView.Location = new Point(1166, 83);
            adminAddUsers_imageView.Margin = new Padding(4);
            adminAddUsers_imageView.Name = "adminAddUsers_imageView";
            adminAddUsers_imageView.Size = new Size(120, 124);
            adminAddUsers_imageView.SizeMode = PictureBoxSizeMode.Zoom;
            adminAddUsers_imageView.TabIndex = 26;
            adminAddUsers_imageView.TabStop = false;
            // 
            // marcaTextBox
            // 
            marcaTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            marcaTextBox.Location = new Point(735, 148);
            marcaTextBox.Margin = new Padding(4);
            marcaTextBox.Name = "marcaTextBox";
            marcaTextBox.Size = new Size(246, 26);
            marcaTextBox.TabIndex = 25;
            // 
            // nombreTextBox
            // 
            nombreTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            nombreTextBox.Location = new Point(192, 142);
            nombreTextBox.Margin = new Padding(4);
            nombreTextBox.Name = "nombreTextBox";
            nombreTextBox.Size = new Size(246, 26);
            nombreTextBox.TabIndex = 24;
            // 
            // adminAddProducts_clearBtn
            // 
            adminAddProducts_clearBtn.BackColor = Color.Maroon;
            adminAddProducts_clearBtn.FlatStyle = FlatStyle.Flat;
            adminAddProducts_clearBtn.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            adminAddProducts_clearBtn.ForeColor = Color.White;
            adminAddProducts_clearBtn.Location = new Point(837, 240);
            adminAddProducts_clearBtn.Margin = new Padding(4);
            adminAddProducts_clearBtn.Name = "adminAddProducts_clearBtn";
            adminAddProducts_clearBtn.Size = new Size(144, 56);
            adminAddProducts_clearBtn.TabIndex = 23;
            adminAddProducts_clearBtn.Text = "LIMPIAR";
            adminAddProducts_clearBtn.UseVisualStyleBackColor = false;
            adminAddProducts_clearBtn.Click += adminAddProducts_clearBtn_Click;
            // 
            // adminAddProducts_deleteBtn
            // 
            adminAddProducts_deleteBtn.BackColor = Color.Maroon;
            adminAddProducts_deleteBtn.FlatStyle = FlatStyle.Flat;
            adminAddProducts_deleteBtn.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            adminAddProducts_deleteBtn.ForeColor = Color.White;
            adminAddProducts_deleteBtn.Location = new Point(633, 240);
            adminAddProducts_deleteBtn.Margin = new Padding(4);
            adminAddProducts_deleteBtn.Name = "adminAddProducts_deleteBtn";
            adminAddProducts_deleteBtn.Size = new Size(144, 56);
            adminAddProducts_deleteBtn.TabIndex = 22;
            adminAddProducts_deleteBtn.Text = "ELIMINAR";
            adminAddProducts_deleteBtn.UseVisualStyleBackColor = false;
            adminAddProducts_deleteBtn.Click += adminAddProducts_deleteBtn_Click;
            // 
            // adminAddProducts_updateBtn
            // 
            adminAddProducts_updateBtn.BackColor = Color.Maroon;
            adminAddProducts_updateBtn.FlatStyle = FlatStyle.Flat;
            adminAddProducts_updateBtn.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            adminAddProducts_updateBtn.ForeColor = Color.White;
            adminAddProducts_updateBtn.Location = new Point(404, 240);
            adminAddProducts_updateBtn.Margin = new Padding(4);
            adminAddProducts_updateBtn.Name = "adminAddProducts_updateBtn";
            adminAddProducts_updateBtn.Size = new Size(144, 56);
            adminAddProducts_updateBtn.TabIndex = 21;
            adminAddProducts_updateBtn.Text = "EDITAR";
            adminAddProducts_updateBtn.UseVisualStyleBackColor = false;
            adminAddProducts_updateBtn.Click += adminAddProducts_updateBtn_Click;
            // 
            // adminAddProducts_addBtn
            // 
            adminAddProducts_addBtn.BackColor = Color.Maroon;
            adminAddProducts_addBtn.FlatStyle = FlatStyle.Flat;
            adminAddProducts_addBtn.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            adminAddProducts_addBtn.ForeColor = Color.White;
            adminAddProducts_addBtn.Location = new Point(200, 240);
            adminAddProducts_addBtn.Margin = new Padding(4);
            adminAddProducts_addBtn.Name = "adminAddProducts_addBtn";
            adminAddProducts_addBtn.Size = new Size(144, 56);
            adminAddProducts_addBtn.TabIndex = 20;
            adminAddProducts_addBtn.Text = "AGREGAR";
            adminAddProducts_addBtn.UseVisualStyleBackColor = false;
            adminAddProducts_addBtn.Click += adminAddProducts_addBtn_Click;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(626, 152);
            label4.Margin = new Padding(4, 0, 4, 0);
            label4.Name = "label4";
            label4.Size = new Size(59, 17);
            label4.TabIndex = 17;
            label4.Text = "Marca:";
            // 
            // cantidadTextBox
            // 
            cantidadTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cantidadTextBox.Location = new Point(735, 92);
            cantidadTextBox.Margin = new Padding(4);
            cantidadTextBox.Name = "cantidadTextBox";
            cantidadTextBox.Size = new Size(246, 26);
            cantidadTextBox.TabIndex = 16;
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label1);
            panel1.Controls.Add(datosRepuestosDataGridView);
            panel1.Location = new Point(23, 382);
            panel1.Margin = new Padding(4);
            panel1.Name = "panel1";
            panel1.Size = new Size(1363, 374);
            panel1.TabIndex = 6;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial Rounded MT Bold", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 15);
            label1.Margin = new Padding(4, 0, 4, 0);
            label1.Name = "label1";
            label1.Size = new Size(107, 22);
            label1.TabIndex = 3;
            label1.Text = "Repuestos";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(626, 98);
            label6.Margin = new Padding(4, 0, 4, 0);
            label6.Name = "label6";
            label6.Size = new Size(78, 17);
            label6.TabIndex = 15;
            label6.Text = "Cantidad:";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(626, 44);
            label7.Margin = new Padding(4, 0, 4, 0);
            label7.Name = "label7";
            label7.Size = new Size(61, 17);
            label7.TabIndex = 13;
            label7.Text = "Precio:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(48, 148);
            label5.Margin = new Padding(4, 0, 4, 0);
            label5.Name = "label5";
            label5.Size = new Size(71, 17);
            label5.TabIndex = 11;
            label5.Text = "Nombre:";
            // 
            // idTextBox
            // 
            idTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            idTextBox.Location = new Point(192, 38);
            idTextBox.Margin = new Padding(4);
            idTextBox.Name = "idTextBox";
            idTextBox.Size = new Size(246, 26);
            idTextBox.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial Rounded MT Bold", 11.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(48, 44);
            label2.Margin = new Padding(4, 0, 4, 0);
            label2.Name = "label2";
            label2.Size = new Size(29, 17);
            label2.TabIndex = 4;
            label2.Text = "ID:";
            // 
            // precioTextBox
            // 
            precioTextBox.Font = new Font("Microsoft Sans Serif", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            precioTextBox.Location = new Point(735, 38);
            precioTextBox.Margin = new Padding(4);
            precioTextBox.Name = "precioTextBox";
            precioTextBox.Size = new Size(246, 26);
            precioTextBox.TabIndex = 14;
            // 
            // panel2
            // 
            panel2.BackColor = Color.White;
            panel2.Controls.Add(adminAddUsers_imageView);
            panel2.Controls.Add(marcaTextBox);
            panel2.Controls.Add(nombreTextBox);
            panel2.Controls.Add(adminAddProducts_clearBtn);
            panel2.Controls.Add(adminAddProducts_deleteBtn);
            panel2.Controls.Add(adminAddProducts_updateBtn);
            panel2.Controls.Add(adminAddProducts_addBtn);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(cantidadTextBox);
            panel2.Controls.Add(label6);
            panel2.Controls.Add(precioTextBox);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label5);
            panel2.Controls.Add(idTextBox);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(23, 24);
            panel2.Margin = new Padding(4);
            panel2.Name = "panel2";
            panel2.Size = new Size(1363, 324);
            panel2.TabIndex = 5;
            // 
            // Repuestos
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            Controls.Add(panel1);
            Controls.Add(panel2);
            Name = "Repuestos";
            Size = new Size(1409, 780);
            Load += Repuestos_Load;
            ((System.ComponentModel.ISupportInitialize)datosRepuestosDataGridView).EndInit();
            ((System.ComponentModel.ISupportInitialize)adminAddUsers_imageView).EndInit();
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView datosRepuestosDataGridView;
        private PictureBox adminAddUsers_imageView;
        private TextBox marcaTextBox;
        private TextBox nombreTextBox;
        private Button adminAddProducts_clearBtn;
        private Button adminAddProducts_deleteBtn;
        private Button adminAddProducts_updateBtn;
        private Button adminAddProducts_addBtn;
        private Label label4;
        private TextBox cantidadTextBox;
        private Panel panel1;
        private Label label1;
        private Label label6;
        private Label label7;
        private Label label5;
        private TextBox idTextBox;
        private Label label2;
        private TextBox precioTextBox;
        private Panel panel2;
    }
}
