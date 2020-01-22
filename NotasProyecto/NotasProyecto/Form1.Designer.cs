namespace NotasProyecto
{
    partial class Form1
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

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.panel1 = new System.Windows.Forms.Panel();
            this.botonGuardar = new System.Windows.Forms.Button();
            this.botonEliminar = new System.Windows.Forms.Button();
            this.botonAñadir = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.panel2 = new System.Windows.Forms.Panel();
            this.comboBox1 = new System.Windows.Forms.ComboBox();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.alumnosBindingSource2 = new System.Windows.Forms.BindingSource(this.components);
            this.evaluaDataSet4 = new NotasProyecto.evaluaDataSet4();
            this.evaluaDataSet1 = new NotasProyecto.evaluaDataSet1();
            this.alumnosBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.alumnosTableAdapter = new NotasProyecto.evaluaDataSet1TableAdapters.AlumnosTableAdapter();
            this.evaluaDataSet = new NotasProyecto.evaluaDataSet();
            this.evaluaDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.evaluaDataSet3 = new NotasProyecto.evaluaDataSet3();
            this.alumnosBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.alumnosTableAdapter1 = new NotasProyecto.evaluaDataSet3TableAdapters.AlumnosTableAdapter();
            this.evaluaDataSet3BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.alumnosTableAdapter2 = new NotasProyecto.evaluaDataSet4TableAdapters.AlumnosTableAdapter();
            this.evaluaDataSet5 = new NotasProyecto.evaluaDataSet5();
            this.notasBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.notasTableAdapter = new NotasProyecto.evaluaDataSet5TableAdapters.NotasTableAdapter();
            this.button2 = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alumnosBindingSource2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluaDataSet4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluaDataSet1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alumnosBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluaDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluaDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluaDataSet3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.alumnosBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluaDataSet3BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluaDataSet5)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.notasBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.botonGuardar);
            this.panel1.Controls.Add(this.botonEliminar);
            this.panel1.Controls.Add(this.botonAñadir);
            this.panel1.Controls.Add(this.dataGridView1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(417, 345);
            this.panel1.TabIndex = 0;
            this.panel1.Paint += new System.Windows.Forms.PaintEventHandler(this.panel1_Paint);
            // 
            // botonGuardar
            // 
            this.botonGuardar.Location = new System.Drawing.Point(247, 227);
            this.botonGuardar.Margin = new System.Windows.Forms.Padding(2);
            this.botonGuardar.Name = "botonGuardar";
            this.botonGuardar.Size = new System.Drawing.Size(65, 32);
            this.botonGuardar.TabIndex = 3;
            this.botonGuardar.Text = "Guardar";
            this.botonGuardar.UseVisualStyleBackColor = true;
            this.botonGuardar.Click += new System.EventHandler(this.botonGuardar_Click);
            // 
            // botonEliminar
            // 
            this.botonEliminar.Location = new System.Drawing.Point(155, 227);
            this.botonEliminar.Margin = new System.Windows.Forms.Padding(2);
            this.botonEliminar.Name = "botonEliminar";
            this.botonEliminar.Size = new System.Drawing.Size(54, 32);
            this.botonEliminar.TabIndex = 2;
            this.botonEliminar.Text = "Eliminar";
            this.botonEliminar.UseVisualStyleBackColor = true;
            this.botonEliminar.Click += new System.EventHandler(this.botonEliminar_Click);
            // 
            // botonAñadir
            // 
            this.botonAñadir.Location = new System.Drawing.Point(56, 227);
            this.botonAñadir.Margin = new System.Windows.Forms.Padding(2);
            this.botonAñadir.Name = "botonAñadir";
            this.botonAñadir.Size = new System.Drawing.Size(61, 32);
            this.botonAñadir.TabIndex = 1;
            this.botonAñadir.Text = "Añadir";
            this.botonAñadir.UseVisualStyleBackColor = true;
            this.botonAñadir.Click += new System.EventHandler(this.botonAñadir_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(39, 29);
            this.dataGridView1.Margin = new System.Windows.Forms.Padding(2);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.RowHeadersWidth = 62;
            this.dataGridView1.RowTemplate.Height = 28;
            this.dataGridView1.Size = new System.Drawing.Size(309, 169);
            this.dataGridView1.TabIndex = 0;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(21, 298);
            this.checkBox1.Margin = new System.Windows.Forms.Padding(2);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(56, 17);
            this.checkBox1.TabIndex = 2;
            this.checkBox1.Text = "Todos";
            this.checkBox1.UseVisualStyleBackColor = true;
            this.checkBox1.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(220, 240);
            this.button1.Margin = new System.Windows.Forms.Padding(2);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 42);
            this.button1.TabIndex = 4;
            this.button1.Text = "Notas";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(217, 70);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(63, 13);
            this.label1.TabIndex = 5;
            this.label1.Text = "Evaluación:";
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.button2);
            this.panel2.Controls.Add(this.button1);
            this.panel2.Controls.Add(this.comboBox1);
            this.panel2.Controls.Add(this.listBox1);
            this.panel2.Controls.Add(this.label1);
            this.panel2.Controls.Add(this.checkBox1);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Margin = new System.Windows.Forms.Padding(2);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(417, 345);
            this.panel2.TabIndex = 6;
            this.panel2.Paint += new System.Windows.Forms.PaintEventHandler(this.panel2_Paint);
            // 
            // comboBox1
            // 
            this.comboBox1.FormattingEnabled = true;
            this.comboBox1.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "J",
            "S"});
            this.comboBox1.Location = new System.Drawing.Point(220, 101);
            this.comboBox1.Margin = new System.Windows.Forms.Padding(2);
            this.comboBox1.Name = "comboBox1";
            this.comboBox1.Size = new System.Drawing.Size(100, 21);
            this.comboBox1.TabIndex = 7;
            this.comboBox1.SelectedIndexChanged += new System.EventHandler(this.comboBox1_SelectedIndexChanged);
            // 
            // listBox1
            // 
            this.listBox1.DataSource = this.alumnosBindingSource2;
            this.listBox1.DisplayMember = "nombre";
            this.listBox1.FormattingEnabled = true;
            this.listBox1.Location = new System.Drawing.Point(21, 32);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2);
            this.listBox1.Name = "listBox1";
            this.listBox1.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.listBox1.Size = new System.Drawing.Size(155, 251);
            this.listBox1.TabIndex = 6;
            this.listBox1.ValueMember = "nif";
            // 
            // alumnosBindingSource2
            // 
            this.alumnosBindingSource2.DataMember = "Alumnos";
            this.alumnosBindingSource2.DataSource = this.evaluaDataSet4;
            // 
            // evaluaDataSet4
            // 
            this.evaluaDataSet4.DataSetName = "evaluaDataSet4";
            this.evaluaDataSet4.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // evaluaDataSet1
            // 
            this.evaluaDataSet1.DataSetName = "evaluaDataSet1";
            this.evaluaDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // alumnosBindingSource
            // 
            this.alumnosBindingSource.DataMember = "Alumnos";
            this.alumnosBindingSource.DataSource = this.evaluaDataSet1;
            // 
            // alumnosTableAdapter
            // 
            this.alumnosTableAdapter.ClearBeforeFill = true;
            // 
            // evaluaDataSet
            // 
            this.evaluaDataSet.DataSetName = "evaluaDataSet";
            this.evaluaDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // evaluaDataSetBindingSource
            // 
            this.evaluaDataSetBindingSource.DataSource = this.evaluaDataSet;
            this.evaluaDataSetBindingSource.Position = 0;
            // 
            // evaluaDataSet3
            // 
            this.evaluaDataSet3.DataSetName = "evaluaDataSet3";
            this.evaluaDataSet3.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // alumnosBindingSource1
            // 
            this.alumnosBindingSource1.DataMember = "Alumnos";
            this.alumnosBindingSource1.DataSource = this.evaluaDataSet3;
            // 
            // alumnosTableAdapter1
            // 
            this.alumnosTableAdapter1.ClearBeforeFill = true;
            // 
            // evaluaDataSet3BindingSource
            // 
            this.evaluaDataSet3BindingSource.DataSource = this.evaluaDataSet3;
            this.evaluaDataSet3BindingSource.Position = 0;
            // 
            // alumnosTableAdapter2
            // 
            this.alumnosTableAdapter2.ClearBeforeFill = true;
            // 
            // evaluaDataSet5
            // 
            this.evaluaDataSet5.DataSetName = "evaluaDataSet5";
            this.evaluaDataSet5.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // notasBindingSource
            // 
            this.notasBindingSource.DataMember = "Notas";
            this.notasBindingSource.DataSource = this.evaluaDataSet5;
            // 
            // notasTableAdapter
            // 
            this.notasTableAdapter.ClearBeforeFill = true;
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(327, 248);
            this.button2.Margin = new System.Windows.Forms.Padding(2);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(63, 26);
            this.button2.TabIndex = 8;
            this.button2.Text = "AYUDA";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(417, 345);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.panel2.ResumeLayout(false);
            this.panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.alumnosBindingSource2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluaDataSet4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluaDataSet1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alumnosBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluaDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluaDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluaDataSet3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.alumnosBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluaDataSet3BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.evaluaDataSet5)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.notasBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel2;
        private evaluaDataSet1 evaluaDataSet1;
        private System.Windows.Forms.BindingSource alumnosBindingSource;
        private evaluaDataSet1TableAdapters.AlumnosTableAdapter alumnosTableAdapter;
        private System.Windows.Forms.ListBox listBox1;
        private evaluaDataSet evaluaDataSet;
        private System.Windows.Forms.BindingSource evaluaDataSetBindingSource;
        private evaluaDataSet3 evaluaDataSet3;
        private System.Windows.Forms.BindingSource alumnosBindingSource1;
        private evaluaDataSet3TableAdapters.AlumnosTableAdapter alumnosTableAdapter1;
        private System.Windows.Forms.BindingSource evaluaDataSet3BindingSource;
        private evaluaDataSet4 evaluaDataSet4;
        private System.Windows.Forms.BindingSource alumnosBindingSource2;
        private evaluaDataSet4TableAdapters.AlumnosTableAdapter alumnosTableAdapter2;
        private evaluaDataSet5 evaluaDataSet5;
        private System.Windows.Forms.BindingSource notasBindingSource;
        private evaluaDataSet5TableAdapters.NotasTableAdapter notasTableAdapter;
        private System.Windows.Forms.ComboBox comboBox1;
        private System.Windows.Forms.Button botonGuardar;
        private System.Windows.Forms.Button botonEliminar;
        private System.Windows.Forms.Button botonAñadir;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Button button2;
    }
}

