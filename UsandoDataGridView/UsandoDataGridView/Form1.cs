using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UsandoDataGridView
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
            string connectionString = "Provider = Microsoft.ACE.OLEDB.12.0; Data Source = |DataDirectory|\\usuario.accdb";
            string ole = "SELECT * FROM usuario";
            OleDbConnection connection = new OleDbConnection(connectionString);
            connection.Open();

            sCommand = new OleDbCommand(ole, connection);
            sAdapter = new OleDbDataAdapter(sCommand);
            sBuilder = new OleDbCommandBuilder(sAdapter);

            sDs = new DataSet();
            sAdapter.Fill(sDs, "Stores");
            sTable = sDs.Tables["Stores"];
            connection.Close();

            dataGridView1.DataSource = sDs.Tables["Stores"];
            dataGridView1.ReadOnly = true;
            save_btn.Enabled = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }
    }
}
