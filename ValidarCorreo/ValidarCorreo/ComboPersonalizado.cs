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

namespace ValidarCorreo
{
    public partial class ComboPersonalizado : Form
    {
        public ComboPersonalizado()
        {
            InitializeComponent();
        }

        private void ComboPersonalizado_Load(object sender, EventArgs e)
        {
            string conexion = "Provider=Microsoft.ACE.OLEDB.12.0; Data Source=|DataDirectory|Users\\.accdb";
            string sentencia = "select Id, usuario & \",\" & clave as nombre from usuarios";
            OleDbConnection miCnx = new OleDbConnection(conexion);
            OleDbCommand miCmd = new OleDbCommand(sentencia, miCnx);


            OleDbDataAdapter adapter = new OleDbDataAdapter();
            DataSet ds = new DataSet();

            miCnx.Open();

            //Hacer la conexion a la bbdd
           while (miLector.Read()) {
                ComboboxItem item = new ComboboxItem();
                item.texto = miLector.GetString(1) + " " + miLector.GestString(2);
                item.value = miLector.GetInt32(0);
                comboBox1.Items.Add(item);
                miLector.getString(1);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            MessageBox.Show( ((ComboboxItem)(comboBox1.SelectedItem)).id + " " + ((ComboboxItem)(comboBox1.SelectedItem)).ToString);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            foreach (DataRowView d in listBox1.SelectedItems)
            {
                
            }

        }
    }
}
