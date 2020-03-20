using System;
using System.Collections;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.IO;
using System.Windows.Forms;

namespace Practica
{
    public partial class Form1 : Form
    {

        //Atributo con la cadena de conexion a la BBDD
        private String cadConex = "Provider=Microsoft.Jet.OLEDB.4.0; Data Source=evalua.mdb";



        public Form1()
        {
            InitializeComponent();
            //Mostramos el panel de login por defecto
            this.MostrarPanel(this.loginPanel);
        }

        private void loginPanel_Paint(object sender, PaintEventArgs e)
        {
            //Ocultamos el menu de navegacion
            this.menuStrip.Visible = false;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            String texto = this.userTextBox.Text;
        }


        /*
         * Metodo para mostrar el panel que recibe como parametro.
         *
         * Oculta todos los paneles y muestra el recibido.
         */
        private void MostrarPanel(Panel p)
        {
            //Ocultamos todos los paneles
            this.loginPanel.Visible = false;
            this.altaPanel.Visible = false;
            this.bajaPanel.Visible = false;
            this.modificarPanel.Visible = false;
            this.consultarAlumnosPanel.Visible = false;
            this.consultarNotasPanel.Visible = false;

            //Mostramos el panel recibido
            if(p != null) { p.Visible = true; }

        }

        private void OcultarLabels()
        {
            //Array con los labels a ocultar
            Label[] labels = {errorLoginLabel, altaLabel, bajaLabel, modificacionLabel};
            //Ocultamos los labels
            for(int i = 0; i < labels.Length; i++)
            {
                labels[i].Visible = false;
            }

        }

        private void button1_Click(object sender, EventArgs e)
        {
            String user = this.userTextBox.Text;
            String pass = this.passwordTextBox.Text;
            
            //Consulta a realizar
            String cadQuery = "SELECT * FROM Usuarios WHERE user='" + user + "' AND password='" + pass + "'";
            if(!user.Trim().Equals("") && !pass.Trim().Equals(""))
            { 
                //Establecemos la conexion con la BBDD
                OleDbConnection conex = new OleDbConnection(this.cadConex);
                //Establecemos la consulta
                OleDbCommand comand = new OleDbCommand(cadQuery, conex);
                //Abrimos la conexion
                conex.Open();
                //Ejecutamos la consulta (en entorno conectado ya que usamos DataReader)
                OleDbDataReader reader = comand.ExecuteReader();
                //Comprobamos si la consulta a devuelto una columna (el usuario con esa contraseña existe)
                if (reader.HasRows)
                { 
                    //Ocultamos todos los paneles
                    MostrarPanel(null);
                    //Mostramos la barra de herramientas (MenuStrip)
                    this.menuStrip.Visible = true;  
                }
            }
            //Mostramos el label de error en el login
            this.errorLoginLabel.Visible = true;

        }


        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Mostramos el panel para altas
            MostrarPanel(this.altaPanel);
        }

        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Mostramos el panel para bajas
            MostrarPanel(this.bajaPanel);
        }

        private void modificarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Mostramos el panel para modificar
            MostrarPanel(this.modificarPanel);
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Mostramos el panel para consultar los alumnos
            MostrarPanel(this.consultarAlumnosPanel);
        }

        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //Mostramos el panel para consultar las notas
            MostrarPanel(this.consultarNotasPanel);
        }

        private void button4_Click(object sender, EventArgs e)
        {

            //Obtenemos el dni del alumno selecionado en el comboBox
            String nif = this.comboBox2.SelectedValue.ToString();
            String query = "DELETE FROM alumnos WHERE nif='" + nif + "'";
            //Establecemos la conexion
            OleDbConnection conex = new OleDbConnection(this.cadConex);
            //Instanciamos una intancia para ejecutar la consulta
            OleDbCommand comand = new OleDbCommand(query, conex);
            //Abrimos la conexion
            conex.Open();
            //Ejecutamos la consulta
            int nFilas = comand.ExecuteNonQuery();
            //Cerramos la conexion y liberamos recursos
            conex.Close();
            conex.Dispose();
            if(nFilas == 1)
            {
                this.bajaLabel.Visible = true;
            }
            //Actualizamos el origen de datos
            this.RefrescarOrigenesDatos();

        }

        private void button5_Click(object sender, EventArgs e)
        {
            
            String nombre = this.textBox5.Text;
            String nif = this.textBox6.Text;
            Boolean baja = this.checkBox1.Checked;

            if(!nombre.Trim().Equals("") && !nif.Trim().Equals(""))
            {
                String query = "INSERT INTO Alumnos VALUES ('" + nif + "','" + nombre + "'," + baja + ")";
                //Instancia para la conexion
                OleDbConnection conex = new OleDbConnection(cadConex);
                OleDbCommand comand = new OleDbCommand(query, conex);
                //Abrimos la conexion
                conex.Open();
                int filasInsertadas;
                try //Capturamos la excepción que se producirá si el usuario introduce un usuario con el
                    //mismo nif en la BBDD
                {
                    //Ejecutamos la consulta (tipo nonQuery puesto que no devuelve registros)
                    filasInsertadas = comand.ExecuteNonQuery();
                }
                catch
                {
                    filasInsertadas = -1;
                }
                //Cerramos la conexion y liberamos recursos
                conex.Close();
                conex.Dispose();
                if (filasInsertadas > 0)
                {
                    //Refrescamos el origen de datos  para que el usuario visualice dichos cambios
                    //en tiempo real
                    this.RefrescarOrigenesDatos();
                    //Cambiamos el color y el texto del label para indicar el transcurso
                    //de la operacion
                    this.altaLabel.Text = "Alumno dado de alta correctamente.";
                    this.altaLabel.ForeColor = System.Drawing.Color.Green;
                }
                else
                {
                    //Cambiamos el color y el texto del label para indicar el transcurso
                    //de la operacion
                    this.altaLabel.Text = "ERROR. No se ha dado de alta al alumno.";
                    this.altaLabel.ForeColor = System.Drawing.Color.Red;
                }
                //Mostramos el cartel indicando que el registro ha sido introducido correctamente
                this.altaLabel.Visible = true;
                //Actualizamos el origen de datos
                this.RefrescarOrigenesDatos();
            }
            else
            {
                //Cambiamos el color y el texto del label para indicar el transcurso
                //de la operacion
                this.altaLabel.Text = "ERROR. Los campos nombre y/o nif no pueden estar vacios.";
                this.altaLabel.ForeColor = System.Drawing.Color.Red;
            }

        }

        public void RefrescarOrigenesDatos()
        {
            this.alumnosTableAdapter.Fill(this.evaluaDataSet2.Alumnos);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Comprobamos que los campos de nombre y nif contengan valores
            if(!this.textBox3.Text.Trim().Equals("") && !this.textBox4.Text.Trim().Equals(""))
            {
                //Recogemos el nif original
                String nifOriginal = this.comboBox1.SelectedValue.ToString();
                //Recogemos el nombre y nif modificados
                String nombre = this.textBox3.Text;
                String nifModificado = this.textBox4.Text;
                Boolean baja = this.checkBox4.Checked;

                String query = "UPDATE Alumnos SET nif='" + nifModificado + "', nombre='" + nombre + "', baja=" + baja + " WHERE nif='" + nifOriginal + "'";
                //Instancia para la conexion
                OleDbConnection conex = new OleDbConnection(this.cadConex);
                //Instancia para la consulta
                OleDbCommand comand = new OleDbCommand(query, conex);
                //Abrimos la conexion
                conex.Open();
                int filas;
                //Ejecutamos la consulta (mediante ExecuteNonQuery() ya que la consulta
                //UPDATE no devuelve registros
                try
                {
                    filas = comand.ExecuteNonQuery();
                    conex.Close();
                    conex.Dispose();
                }
                catch{
                    filas = -1;
                }
                if(filas > 0)
                {
                    this.modificacionLabel.Text = "Datos actualizados correctamente.";
                    this.modificacionLabel.ForeColor = System.Drawing.Color.Green;
                    //Recargamos los origenes de datos
                    this.RefrescarOrigenesDatos();
                }
                else
                {
                    this.modificacionLabel.Text = "ERROR. No se han actualizado los datos.";
                    this.modificacionLabel.ForeColor = System.Drawing.Color.Red;
                }
            }
            else
            {
                this.modificacionLabel.Text = "Las campos Nif y Nombre deben contener valores.";
                this.modificacionLabel.ForeColor = System.Drawing.Color.Red;
            }
            //Mostramos el label
            this.modificacionLabel.Visible = true;

        }

        private void button6_Click(object sender, EventArgs e)
        {
            //¡¡¡¡¡ IMPORTANTE !!!!!!
            //Para marcar un valor por defecto en el comboBox se hace mediante
            //la propiedad Text

            //Obtenemos el periodo seleccionado
            String periodo = "";
            String[] periodos = { "Todos","Diciembre", "Marzo", "Junio", "Ordinaria", "Extraordinaria" };
            String[] valorPeriodos = { "%", "1", "2", "3", "J", "S" };
            for(int i = 0; i < periodos.Length; i++)
            {
                if(this.comboBox3.SelectedItem.ToString() == periodos[i])
                {
                    periodo = valorPeriodos[i];
                }
            }

            //Obtenemos los alumnos cuyas notas se mostraran
            String alumnos;
            if (this.checkBox3.Checked)//Si no se ha filtrado por alumnos mostraremos todos
            {
                alumnos = "LIKE '%'";
            }
            else
            {
                alumnos = "IN (";
                //Obtenemos los alumos seleccionados
                foreach(DataRowView drw in listBox2.SelectedItems)
                {
                    alumnos += "'" + drw[0] +"',";
                }
                //Quitamos la coma final
                alumnos = alumnos.Substring(0, alumnos.Length - 1);
                //Añadimos el parentesis final
                alumnos += ")";
            }

            //Formamos la consulta
            String query = "SELECT a.nombre AS Alumno, n.periodo, n.fol, n.ina, n.fpr, n.ral, n.sim FROM Alumnos a, Notas n WHERE (a.nif = n.nifAlumno) AND n.periodo LIKE '" + periodo + "' AND n.nifAlumno " + alumnos;

            //Recuperamos los datos de la BBDD
            OleDbConnection conex = new OleDbConnection(this.cadConex);
            //Abrimos la conexion
            conex.Open();
            OleDbCommand comand = new OleDbCommand(query, conex);
            OleDbDataAdapter adapter = new OleDbDataAdapter(comand);
            //Creamos una instancia de DataSet donde volcaremos en contenido recuperado
            //(usando entorno desconectado)
            DataSet dataSet = new DataSet();
            //Volcamos el contenido recuperado por la consulta en el DataSet
            adapter.Fill(dataSet, "Notas");
            //Introducimos la tabla "Notas" en el DataGridView
            this.dataGridView2.DataSource = dataSet.Tables["Notas"];
            //Cerramos la conexion
            conex.Close();

            //Mostramos el panel con las notas
            this.verFiltrosNotasPanel.Visible = false;
            this.verNotasPanel.Visible = true;

        }

        private void button7_Click(object sender, EventArgs e)
        {
            //Ocultamos el panel con las notas y mostramos el panel con los filtros
            this.verNotasPanel.Visible = false;
            this.verFiltrosNotasPanel.Visible = true;
        }

        private void checkBox3_CheckedChanged(object sender, EventArgs e)
        {
            if (this.checkBox3.Checked)
            {
                //Deshabilitamos el listBox con los alumnos
                this.listBox2.Enabled = false;
            }
            else
            {
                this.listBox2.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // TODO: esta línea de código carga datos en la tabla 'evaluaDataSet2.Alumnos' Puede moverla o quitarla según sea necesario.
            this.alumnosTableAdapter.Fill(this.evaluaDataSet2.Alumnos);

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //Obtenemos el nif selecionado del comboBox
            String nif = this.comboBox1.SelectedValue.ToString();
            //Formamos la consulta
            String query = "SELECT nif, nombre, baja FROM Alumnos WHERE nif='" + nif + "'";
            //Establecemos la instancia para la conexion
            OleDbConnection conex = new OleDbConnection(this.cadConex);
            //Establecemos la instancia para realizar las consultas 
            OleDbCommand comand = new OleDbCommand(query, conex);
            //Abrimos la conexion
            conex.Open();
            //Establecemos la instancia para 
            OleDbDataReader reader = comand.ExecuteReader();
            //Volcamos los datos recuperados en los textBox
            while (reader.Read())
            {
                this.textBox3.Text = reader.GetString(1);//1 --> Nif
                this.textBox4.Text = reader.GetString(0);//2 --> Nombre
                this.checkBox4.Checked = reader.GetBoolean(2);// --> Baja
            }
            //Cerramos la conexion y liberamos recursos
            conex.Close();
            conex.Dispose();
            //Mostramos el panel para modificar los datos
            this.camposModificarPanel.Visible = true;
        }

        private void verAyudaToolStripMenuItem_Click(object sender, EventArgs e)
        {

            Help.ShowHelp(this, "file:AyudaPrueba.chm");
            //mostrarAyuda();
        }

        private void mostrarAyuda()
        {
            string path = Path.GetDirectoryName(Application.ExecutablePath);
            path = "file://" + Path.Combine(path, "AyudaPrueba.chm");
            Help.ShowHelp(this, path);
        }

        protected override bool ProcessCmdKey(ref Message msg, Keys keyData)
        {
            if (keyData == Keys.F1)
            {
                mostrarAyuda();
                return true;
            }
            return base.ProcessCmdKey(ref msg, keyData);
        }
    }
}
