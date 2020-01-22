using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.OleDb;
using System.IO;

namespace NotasProyecto
{
    public partial class Form1 : Form
    {

        OleDbCommand sCommand;
        OleDbDataAdapter sAdapter;
        OleDbCommandBuilder sBuilder;
        DataSet sDs;
        DataTable sTable;

        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            string connectionString = "Provider=Microsoft.ACE.OLEDB.12.0;Data Source=|DataDirectory|\\evalua.accdb;";
            string consulta;
            if (checkBox1.Checked)
            {
                consulta = "SELECT * FROM Notas WHERE periodo='" + comboBox1.SelectedItem + "'";
            }
            else
            {
                consulta = "SELECT * FROM Notas WHERE nifAlumno='" + listBox1.SelectedValue + "' AND periodo='" + comboBox1.SelectedItem + "'";
            }
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();

            sCommand = new OleDbCommand(consulta, connection);
            sAdapter = new OleDbDataAdapter(sCommand);
            sBuilder = new OleDbCommandBuilder(sAdapter);
            sDs = new DataSet();
            sAdapter.Fill(sDs, "nifAlumno");
            sTable = sDs.Tables["nifAlumno"];
            connection.Close();

            dataGridView1.DataSource = sDs.Tables["nifalumno"];
            dataGridView1.ReadOnly = true;
            botonGuardar.Enabled = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            panel1.Visible = true;
            panel2.Visible = false;

        }

        private void Form1_Load(object sender, EventArgs e)
        {

            // TODO: esta línea de código carga datos en la tabla 'evaluaDataSet5.Notas' Puede moverla o quitarla según sea necesario.
            this.notasTableAdapter.Fill(this.evaluaDataSet5.Notas);
            //TODO: esta línea de código carga datos en la tabla 'evaluaDataSet4.Alumnos' Puede moverla o quitarla según sea necesario.
            this.alumnosTableAdapter2.Fill(this.evaluaDataSet4.Alumnos);
            // TODO: esta línea de código carga datos en la tabla 'evaluaDataSet3.Alumnos' Puede moverla o quitarla según sea necesario.
            this.alumnosTableAdapter1.Fill(this.evaluaDataSet3.Alumnos);
            // TODO: esta línea de código carga datos en la tabla 'evaluaDataSet1.Alumnos' Puede moverla o quitarla según sea necesario.
            this.alumnosTableAdapter.Fill(this.evaluaDataSet1.Alumnos);


            panel1.Visible = false;
            panel2.Visible = true;

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void botonAñadir_Click(object sender, EventArgs e)
        {
            dataGridView1.ReadOnly = false;
            botonGuardar.Enabled = true;
            botonAñadir.Enabled = false;
            botonEliminar.Enabled = false;
        }

        private void botonEliminar_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que quieres eliminar?", "Delete", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                dataGridView1.Rows.RemoveAt(dataGridView1.SelectedRows[0].Index);
                sAdapter.Update(sTable);
            }
        }

        private void botonGuardar_Click(object sender, EventArgs e)
        {
            sAdapter.Update(sTable);
            dataGridView1.ReadOnly = true;
            botonGuardar.Enabled = false;
            botonAñadir.Enabled = true;
            botonEliminar.Enabled = true;
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox1.SetSelected(i, true);
                }
            }
            else {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox1.SetSelected(i, false);
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            mostrarAyuda();
        }

        private void mostrarAyuda() {
            String path = Path.GetDirectoryName(Application.ExecutablePath);
            path = "file://" + Path.Combine(path, "help.chm");
            Help.ShowHelp(this, path);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData) {
            if (keyData == Keys.F1) {
                mostrarAyuda();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
