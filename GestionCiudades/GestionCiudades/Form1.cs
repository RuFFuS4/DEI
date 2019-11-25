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

namespace GestionCiudades
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        void eliminarPaneles()
        {
            panel1.Visible = false;
            panel2.Visible = false;
            panel3.Visible = false;
            panel4.Visible = false;
            panel5.Visible = false;
            panel6.Visible = false;
            panel7.Visible = false;
            panel8.Visible = false;
            panel9.Visible = false;
            panel10.Visible = false;
            panel11.Visible = false;
            panel12.Visible = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String nombre = textBox1.Text;
            string conexion = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|\\gestionciudades.mdb";
            string consulta = "select pais from paises where pais='" + nombre + "'";
            string sentencia = "insert into paises (pais) values('" + nombre + "')";

            OleDbConnection miCnx = new OleDbConnection(conexion);

            OleDbCommand miCmdConsulta = new OleDbCommand(consulta, miCnx);
            OleDbDataReader milector;

            //Abrimos la conexion
            miCnx.Open();
            milector = miCmdConsulta.ExecuteReader();
            milector.Read();

            //Comprobamos si la consulta devuelva alguna fila.
            if (milector.HasRows)
            {

                MessageBox.Show("Ese pais ya existe.");
            }
            else
            {
                OleDbCommand miCmdAlta = new OleDbCommand(sentencia, miCnx);
                miCmdAlta.ExecuteNonQuery();
                MessageBox.Show("El pais "+nombre+" se ha introducido correctamente.");
            }
            milector.Close();
            miCnx.Close();
            miCnx.Dispose();
            Form1_Load(null, null);
           
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'gestionciudadesDataSet1.provincias' Puede moverla o quitarla según sea necesario.
            this.provinciasTableAdapter.Fill(this.gestionciudadesDataSet1.provincias);
            // TODO: esta línea de código carga datos en la tabla 'gestionciudadesDataSet.paises' Puede moverla o quitarla según sea necesario.
            this.paisesTableAdapter.Fill(this.gestionciudadesDataSet.paises);

        }

        private void añadirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eliminarPaneles();
            panel1.Visible = true;
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eliminarPaneles();
            panel2.Visible = true;
        }

        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eliminarPaneles();
            panel3.Visible = true;
        }


        //Borra paises
        private void button2_Click(object sender, EventArgs e)
        {
            string pais = comboBox1.Text;
            string conexion = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|\\gestionciudades.mdb";
            string sentencia = "delete from paises where id_pais=" + comboBox1.SelectedValue + "";

            OleDbConnection miCnx = new OleDbConnection(conexion);
            OleDbCommand miCmd = new OleDbCommand(sentencia, miCnx);
            miCnx.Open();
            miCmd.ExecuteNonQuery();
            MessageBox.Show("El pais "+pais+" ha sido borrado.");
            miCnx.Close();
            //Refrescamos los datos de paises
            Form1_Load(null, null);

        }

        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eliminarPaneles();
            panel4.Visible = true;
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String provincia = textBox2.Text;
            String pais = comboBox2.Text;
            string conexion = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|\\gestionciudades.mdb";
            string consulta = "select provincia from provincias where provincia='" + provincia + "'";
            string sentencia = "insert into provincias (provincia, id_pais) values('" + provincia + "', " + comboBox2.SelectedValue + ")";

            OleDbConnection miCnx = new OleDbConnection(conexion);

            OleDbCommand miCmdConsulta = new OleDbCommand(consulta, miCnx);
            OleDbDataReader milector;

            //Abrimos la conexion
            miCnx.Open();
            milector = miCmdConsulta.ExecuteReader();
            milector.Read();

            //Comprobamos si la consulta devuelva alguna fila.
            if (milector.HasRows)
            {
                MessageBox.Show("Esa provincia ya existe.");
            }
            else
            {
                OleDbCommand miCmdAlta = new OleDbCommand(sentencia, miCnx);
                miCmdAlta.ExecuteNonQuery();
                MessageBox.Show("La provincia "+provincia+" del pais "+pais+" ha sido introducida en la base de datos.");
            }
            milector.Close();
            miCnx.Close();
            miCnx.Dispose();
            Form1_Load(null, null);
        }

        private void añadirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            eliminarPaneles();
            panel5.Visible = true;
        }

        //Boton listar provincias y paises
        private void borrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            eliminarPaneles();
            panel6.Visible = true;

            String cadConex = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= |DataDirectory|\\gestionciudades.mdb";
            //Formamos la consulta
            String cadConsulta = String.Format("select p.pais as Pais, c.provincia as Provincia from paises p, provincias c where c.id_pais=p.id_pais");
            Console.WriteLine(cadConsulta);
            //Abrimos una conexion a la BBDD
            OleDbConnection conex = new OleDbConnection(cadConex);
            conex.Open();
            OleDbCommand command = new OleDbCommand(cadConsulta, conex);
            //Creamos una instancia de dataAdapter ya que usaremos entorno desconectado
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);
            
            DataSet dataSet = new DataSet();
            //Volcamos el contenido recuperado por la consulta en el DataSet
            adapter.Fill(dataSet, "PaisesProvincias");
            //Introducimos la tabla que hemos creado con la consulta ("NotasAlumnos")
            //en el DataGridView
            this.dataGridView2.DataSource = dataSet.Tables["PaisesProvincias"];
            //Cerramos la conexion
            conex.Close();
        }

        private void borrarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            eliminarPaneles();
            panel7.Visible = true;

            String cadConex = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= |DataDirectory|\\gestionciudades.mdb";
            //Formamos la consulta
            String cadConsulta = String.Format("select p.pais as Pais, c.provincia as Provincia from paises p, provincias c where c.id_pais=p.id_pais");
            Console.WriteLine(cadConsulta);
            //Abrimos una conexion a la BBDD
            OleDbConnection conex = new OleDbConnection(cadConex);
            conex.Open();
            OleDbCommand command = new OleDbCommand(cadConsulta, conex);
            //Creamos una instancia de dataAdapter ya que usaremos entorno desconectado
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);

            DataSet dataSet = new DataSet();
            //Volcamos el contenido recuperado por la consulta en el DataSet
            adapter.Fill(dataSet, "PaisesProvincias");
            //Introducimos la tabla que hemos creado con la consulta ("NotasAlumnos")
            //en el DataGridView
            this.dataGridView3.DataSource = dataSet.Tables["PaisesProvincias"];
            //Cerramos la conexion
            conex.Close();
            Form1_Load(null, null);


            //Guardamos la provincia seleccionada en el grid view
            String provincia = (String)dataGridView3.CurrentCell.Value;


            
        }

        //Boton borrar provincia
        private void button4_Click(object sender, EventArgs e)
        {
            string provincia= (String)dataGridView3.CurrentCell.Value;
            string conexion = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|\\gestionciudades.mdb";
            string borrado = "delete from provincias where provincia='" + provincia + "'";
            OleDbConnection miCnx = new OleDbConnection(conexion);

            OleDbCommand miCmdBorra = new OleDbCommand(borrado, miCnx);
            miCnx.Open();

            if (miCmdBorra.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("La provincia " + provincia + " ha sido borrada.");
                borrarToolStripMenuItem2_Click(null, null);
            }
            else
            {
                MessageBox.Show("Tiene que seleccionar una provincia.");
            }

            miCnx.Close();
            miCnx.Dispose();
            Form1_Load(null, null);
        }

        private void inicioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            eliminarPaneles();
            panel8.Visible = true;
        }

        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            eliminarPaneles();
            panel10.Visible = true;

            String cadConex = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= |DataDirectory|\\gestionciudades.mdb";
            //Formamos la consulta
            String cadConsulta = String.Format("select p.pais as Pais, d.provincia as Provincia, c.ciudad as Ciudad from paises p, provincias d, ciudades c where d.id_pais=p.id_pais and d.id_provincia=c.id_provincia");
            Console.WriteLine(cadConsulta);
            //Abrimos una conexion a la BBDD
            OleDbConnection conex = new OleDbConnection(cadConex);
            conex.Open();
            OleDbCommand command = new OleDbCommand(cadConsulta, conex);
            //Creamos una instancia de dataAdapter ya que usaremos entorno desconectado
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);

            DataSet dataSet = new DataSet();
            //Volcamos el contenido recuperado por la consulta en el DataSet
            adapter.Fill(dataSet, "PaisesProvinciasCiudades");
            //Introducimos la tabla que hemos creado con la consulta ("PaisesProvinciasCiudades")
            //en el DataGridView
            this.dataGridView4.DataSource = dataSet.Tables["PaisesProvinciasCiudades"];
            //Cerramos la conexion
            conex.Close();
        }

        //Combo de provincias que cambia segun el pais seleccionado en el listbox
        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            

        }


        //ListBox de paises
        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*int pais = (Int32)listBox1.SelectedValue;
            String cadConex = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= |DataDirectory|\\gestionciudades.mdb";
            //Formamos la consulta
            String cadConsulta = String.Format("select provincia from provincias where id_pais="+pais+"");
            Console.WriteLine(cadConsulta);
            //Abrimos una conexion a la BBDD
            OleDbConnection conex = new OleDbConnection(cadConex);
            conex.Open();
            OleDbCommand command = new OleDbCommand(cadConsulta, conex);
            
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);

            DataSet dataSet = new DataSet();
            //Volcamos el contenido recuperado por la consulta en el DataSet
            adapter.Fill(dataSet, "Paises_Provincias");
            //Introducimos la tabla que hemos creado con la consulta ("Paises_Provincias")
           
            this.comboBox3.DataSource = dataSet.Tables["Paises_Provincias"];
            //Cerramos la conexion
            conex.Close();*/

        }

        private void añadirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            eliminarPaneles();
            panel9.Visible = true;
        }

        private void iniciToolStripMenuItem_Click(object sender, EventArgs e)
        {
            eliminarPaneles();
            panel11.Visible = true;
        }

        //Grid View Paises, Provincias, Ciudades. Borrar Ciudades
        private void borrarToolStripMenuItem3_Click(object sender, EventArgs e)
        {
            eliminarPaneles();
            panel12.Visible = true;

            String cadConex = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source= |DataDirectory|\\gestionciudades.mdb";
            //Formamos la consulta
            String cadConsulta = String.Format("select p.pais as Pais, d.provincia as Provincia, c.ciudad as Ciudad from paises p, provincias d, ciudades c where d.id_pais=p.id_pais and d.id_provincia=c.id_provincia");
            Console.WriteLine(cadConsulta);
            //Abrimos una conexion a la BBDD
            OleDbConnection conex = new OleDbConnection(cadConex);
            conex.Open();
            OleDbCommand command = new OleDbCommand(cadConsulta, conex);
            //Creamos una instancia de dataAdapter ya que usaremos entorno desconectado
            OleDbDataAdapter adapter = new OleDbDataAdapter(command);

            DataSet dataSet = new DataSet();
            //Volcamos el contenido recuperado por la consulta en el DataSet
            adapter.Fill(dataSet, "PaisesProvinciasCiudades");
            //Introducimos la tabla que hemos creado con la consulta ("PaisesProvinciasCiudades")
            //en el DataGridView
            this.dataGridView5.DataSource = dataSet.Tables["PaisesProvinciasCiudades"];
            //Cerramos la conexion
            conex.Close();
        }


        //Boton Borrar Ciudades
        private void button6_Click(object sender, EventArgs e)
        {
            string ciudad = (String)dataGridView5.CurrentCell.Value;
            string conexion = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|\\gestionciudades.mdb";

            string sentencia = "delete from ciudades where ciudad='" + ciudad + "'";

            OleDbConnection miCnx = new OleDbConnection(conexion);
            OleDbCommand miCmd = new OleDbCommand(sentencia, miCnx);
            miCnx.Open();
            if (miCmd.ExecuteNonQuery() == 1)
            {
                MessageBox.Show("La ciudad " + ciudad + " ha sido borrada.");
                borrarToolStripMenuItem3_Click(null, null);
            }
            else
            {
                MessageBox.Show("Tiene que seleccionar una ciudad.");
            }
            
            miCnx.Close();    

            //Refrescamos los datos de ciudades
            Form1_Load(null, null);
        }



        //Boton añadir ciudades
        private void button5_Click(object sender, EventArgs e)
        {
            String provincia = comboBox3.Text;
            String ciudad = textBox3.Text;
            string conexion = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=|DataDirectory|\\gestionciudades.mdb";
            string consulta = "select ciudad from ciudades where ciudad='" + ciudad + "'";
            String consultaId = "select id_provincia from provincias where provincia= '" + provincia + "'";
            string sentencia = "insert into ciudades c, provincias p (ciudades) values('" + ciudad + "') where id_provincia= ";

            OleDbConnection miCnx = new OleDbConnection(conexion);

            OleDbCommand miCmdConsulta = new OleDbCommand(consulta, miCnx);
            OleDbCommand miCmdConsultaID = new OleDbCommand(consultaId, miCnx);
            OleDbDataReader milector, milector2;

            //Abrimos la conexion
            miCnx.Open();
            milector = miCmdConsulta.ExecuteReader();
            milector.Read();
            milector2 = miCmdConsultaID.ExecuteReader();
         
            //Comprobamos si la consulta devuelva alguna fila.
            if (milector.HasRows)
            {

                MessageBox.Show("Esa ciudad ya existe.");
            }
            else
            {
                OleDbCommand miCmdAlta = new OleDbCommand(sentencia, miCnx);
                miCmdAlta.ExecuteNonQuery();
                MessageBox.Show("La ciudad "+ciudad+" se ha introducido correctamente.");
            }
            milector.Close();
            miCnx.Close();
            miCnx.Dispose();
            Form1_Load(null, null);


        }
    }
}
