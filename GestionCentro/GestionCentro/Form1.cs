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

namespace GestionCentro
{
    public partial class Form1 : Form
    {
        private OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=.\\data\\Centros.accdb");
        private OleDbCommand manejarDatos;
        private OleDbDataReader datos;
        private OleDbDataAdapter adaptador;
        private OleDbCommandBuilder constructor;
        private static List<Panel> panelesAplicacion = new List<Panel>();//Nº paneles aplicación
        private String condition = ""; //Variable que variaremos para las condiciones de las busquedas
        public Form1()
        {
            InitializeComponent();
            //Abrimos la conexión con la BBDD
            conexion.Open();
            /*Añadimos todos los paneles a un ArrayList*/
            panelesAplicacion.Add(pInicio);
            panelesAplicacion.Add(pAddCentro);
            panelesAplicacion.Add(pShowCentros);
            panelesAplicacion.Add(pDeleteCentro);
            panelesAplicacion.Add(pAddDepartamento);
            panelesAplicacion.Add(pShowDepartamentos);
            panelesAplicacion.Add(pDeleteDepartamento);
            panelesAplicacion.Add(pAddEmpleado);
            panelesAplicacion.Add(pShowEmpleados);
            visualizarPanel(pInicio);
            /*Posicionamos en el centro de la pantalla la ventana*/
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        /*=======ABRIR CERRAR CONEXION=================================================*/
        private void Form1_Load(object sender, EventArgs e)
        {
            //Abrimos la conexión con la BBDD
            //conexion.Open();
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            /*datos.Close();
            conexion.Close();*/
        }
        /*=======CENTROS=================================================*/
        private void añadirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizarPanel(pAddCentro);
        }
        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizarPanel(pShowCentros);
        }
        private void borrarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizarPanel(pDeleteCentro);
        }
        private void inicioToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizarPanel(pInicio);
        }
        private void btnAddCentro_Click(object sender, EventArgs e)
        {
            if (!tBAddCentro.Text.Equals(""))
            {
                String nombreCentro = tBAddCentro.Text;
                List<String> nombresCentros = new List<String>();
                manejarDatos = new OleDbCommand("SELECT Centro FROM Centros", conexion);
                datos = manejarDatos.ExecuteReader();

                if (datos.HasRows)
                {
                    while (datos.Read())
                    {
                        nombresCentros.Add(datos.GetString(0));
                    }
                }
                /*Compruebo que no exista el nombre*/
                if (nombresCentros.Contains(nombreCentro))
                {
                    /*Limpiamos campo nombre y mostramos un mensaje*/
                    limpiarComponentes(new TextBox[] { tBAddCentro }, null, null);
                    MessageBox.Show("Ya existe el centro " + nombreCentro);
                }
                else
                {
                    String[] valores = new String[1];
                    valores[0] = "'" + tBAddCentro.Text + "'";

                    anadirRegistro("Centros", new String[] { "Centro"}, valores);

                    /*Limpiamos los valores y mostramos un mensaje*/
                    MessageBox.Show("El centro "+tBAddCentro.Text+"ha sido introducido correctamente.");
                    limpiarComponentes(new TextBox[] { tBAddCentro }, null, null);
                    
                }
            }
            else
            {
                MessageBox.Show("Debe rellenar el campo.");
            }
        }
        private void pShowCentros_VisibleChanged(object sender, EventArgs e)
        {
            if (pShowCentros.Visible)
            {
                String consultaTabla = "Centros";
                cargarDatos(gvCentros,new String[] {"*"}, consultaTabla, "", true, new int[] { 0 });
            }
        }
        private void pDeleteCentro_VisibleChanged(object sender, EventArgs e)
        {
            if (pDeleteCentro.Visible)
            {
                //Se cargan los datos del combobox
                string consulta = "SELECT Id_Centro,Centro FROM Centros";
                manejarDatos = new OleDbCommand(consulta, conexion);
                datos = manejarDatos.ExecuteReader();

                cargarComboBox(cbDeleteCentros, 2, true);
            }
        }
        private void btnDeleteCentro_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Quiere eliminar este centro?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                condition = "Id_Centro =" + (cbDeleteCentros.SelectedItem as ListItem).Value.ToString();
                borrarRegistro("Centros", condition);
                /*Cambiamos la visibilidad para recargar los datos*/
                pDeleteCentro.Visible = false;
                pDeleteCentro.Visible = true;
            }
        }

        /*=======DEPARTAMENTOS=================================================*/
        private void añadirToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            visualizarPanel(pAddDepartamento);
        }
        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            visualizarPanel(pShowDepartamentos);
        }
        private void inicioToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            visualizarPanel(pInicio);
        }
        private void borrarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            visualizarPanel(pDeleteDepartamento);
        }
        private void pAddDepartamento_VisibleChanged(object sender, EventArgs e)
        {
            if (pAddDepartamento.Visible)
            {
                //Se cargan los datos del combobox
                string consulta = "SELECT Id_Centro,Centro FROM Centros";
                manejarDatos = new OleDbCommand(consulta, conexion);
                datos = manejarDatos.ExecuteReader();

                cargarComboBox(cbAddDepartamento, 2, true);

               
            }
            
        }
        private void btnAddDepartamento_Click(object sender, EventArgs e)
        {
            if (!tbAddDepartamento.Text.Equals(""))
            {
                String depIntroducido = tbAddDepartamento.Text;
                List<String> departamentosExistentes = new List<String>();
                manejarDatos = new OleDbCommand("SELECT Departamento FROM Departamentos", conexion);
                datos = manejarDatos.ExecuteReader();

                if (datos.HasRows)
                {
                    while (datos.Read())
                    {
                        departamentosExistentes.Add(datos.GetString(0));
                    }
                }
                /*Compruebo que no exista el departamento*/
                if (departamentosExistentes.Contains(depIntroducido.Trim()))
                {
                    /*Limpiamos campo nombre y mostramos un mensaje*/
                    limpiarComponentes(new TextBox[] { tbAddDepartamento }, new ComboBox[] { cbAddDepartamento }, null);
                    MessageBox.Show("Ya existe el departamento: " + depIntroducido.Trim());
                }
                else
                {
                    String[] valores = new String[3];
                    String identificador = tbAddDepartamento.Text.Substring(0,3);
                     valores[0] = "'" + identificador + "'";
                     valores[1] = (cbAddDepartamento.SelectedItem as ListItem).Value.ToString();
                     valores[2] = "'" + tbAddDepartamento.Text + "'";

                     anadirRegistro("Departamentos", new String[] { "Id_Departamento", "Id_Centro", "Departamento" }, valores);

                     /*Limpiamos los valores y mostramos un mensaje*/
                     MessageBox.Show("Se ha introducido correctamente el Departamento "+tbAddDepartamento.Text);
                     limpiarComponentes(new TextBox[] { tbAddDepartamento }, new ComboBox[] { cbAddDepartamento}, null);
                }
            }
            else
            {
                MessageBox.Show("Deben rellenar el campo.");
            }
        }
        private void pShowDepartamentos_VisibleChanged(object sender, EventArgs e)
        {
            if (pShowDepartamentos.Visible)
            {
                String consultaTabla = "Centros c, Departamentos d ";
                cargarDatos(gvDepartamentos,new String[] {"c.Centro","d.Departamento"},consultaTabla, 
                    "WHERE c.Id_Centro = d.Id_Centro", true, null);
            }
        }
        
        /*=======EMPLEADOS=================================================*/
        private void añadirToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            visualizarPanel(pAddEmpleado);
        }
        private void listarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            visualizarPanel(pShowEmpleados);
        }
        private void inicioToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            visualizarPanel(pInicio);
        }
        private void pShowEmpleados_VisibleChanged(object sender, EventArgs e)
        {
            if (pShowDepartamentos.Visible)
            {
                String consultaTabla = "Empleados e, Departamentos d, Centros c ";
                cargarDatos(gvEmpleados, new String[] { "c.Centro", "d.Departamento, e.Empleado" }, consultaTabla,
                    "WHERE e.Id_Departamento=d.Id_Departamento AND d.Id_Centro=c.Id_Centro", true, null);
            }
        }
        private void pAddEmpleado_VisibleChanged(object sender, EventArgs e)
        {
            if (pAddEmpleado.Visible) {
                //Se cargan los datos del listbox
                String consulta = "SELECT Id_Centro,Centro FROM Centros";
                manejarDatos = new OleDbCommand(consulta, conexion);
                datos = manejarDatos.ExecuteReader();

                cargarListBox(listbAddEmpleado);
            }
            
        }
        private void listbAddEmpleado_SelectedIndexChanged(object sender, EventArgs e)
        {
            //Se cargan los datos del combobox
            string consulta = "SELECT Id_Departamento,Departamento FROM Departamentos " +
                "WHERE Id_Centro="+ (listbAddEmpleado.SelectedItem as ListItem).Value.ToString();
            manejarDatos = new OleDbCommand(consulta, conexion);
            datos = manejarDatos.ExecuteReader();

            cargarComboBox(cbAddEmpleado, 2, false);
            
        }
        private void btnaddEmpleado_Click(object sender, EventArgs e)
        {
            if (!tbAddEmpleado.Text.Equals(""))
            {
                String empIntroducido = tbAddEmpleado.Text;
                List<String> empleadosExistentes = new List<String>();
                manejarDatos = new OleDbCommand("SELECT Empleado FROM Empleados", conexion);
                datos = manejarDatos.ExecuteReader();

                if (datos.HasRows)
                {
                    while (datos.Read())
                    {
                        empleadosExistentes.Add(datos.GetString(0));
                    }
                }
                /*Compruebo que no exista el departamento*/
                if (empleadosExistentes.Contains(empIntroducido.Trim()))
                {
                    /*Limpiamos campo nombre y mostramos un mensaje*/
                    limpiarComponentes(new TextBox[] { tbAddEmpleado }, null, null);
                    MessageBox.Show("Ya existe el empleado: " + empIntroducido.Trim());
                }
                else
                {
                    String[] valores = new String[3];
                    valores[0] = (listbAddEmpleado.SelectedItem as ListItem).Value.ToString();
                    valores[1] = "'"+(cbAddEmpleado.SelectedItem as ListItem).Value.ToString()+"'";
                    valores[2] = "'" + tbAddEmpleado.Text + "'";

                    anadirRegistro("Empleados", new String[] { "Id_Empleado", "Id_Departamento", "Empleado" }, valores);

                    /*Limpiamos los valores y mostramos un mensaje*/
                    MessageBox.Show("Se ha introducido correctamente el Empleado " + tbAddEmpleado.Text);
                    limpiarComponentes(new TextBox[] { tbAddEmpleado }, null, null);
                }
            }
            else
            {
                MessageBox.Show("Deben rellenar el campo.");
            }
        }
        /*=======METODOS=================================================*/
        /*Recibe un objeto tipo Panel
         * Pone a Visible.False todos los paneles de panelesAplicacion
         * Pone a Visible.True el Panel pasado
         */
        private void visualizarPanel(Panel p)
        {
            foreach (Panel pa in panelesAplicacion)
            {
                pa.Visible = false;
            }
            p.Visible = true;
        }
        /* -Recibe un DataGridView, una tabla que añadiremos a la consulta 
         * en forma de String, un booleano que indica si dicho gridview es 
         * de solo lectura o no y un array de enteros de columnas que queremos ocultar.
         * -Carga los datos de la consulta en el GridView
         */
        private void cargarDatos(DataGridView gv, String[] campos,String consultaTabla, String condicion, Boolean readOnly, int[] columnasOcultas)
        {
            String consulta = "SELECT ";
            /*PREPARAMOS LAS CAMPOS*/
            for (int i = 0; i < campos.Length; i++)
            {
                consulta += campos[i] + ",";
            }
            consulta = consulta.Substring(0, consulta.Length - 1);//Borramos útima coma
            consulta += " FROM ";//Sumamos el FROM
            DataSet conjuntoDatos = new DataSet();
            DataTable tablaRecuperada = new DataTable();

            manejarDatos = new OleDbCommand(consulta + consultaTabla + condicion, conexion);
            adaptador = new OleDbDataAdapter(manejarDatos);
            constructor = new OleDbCommandBuilder(adaptador);

            adaptador.Fill(conjuntoDatos, consultaTabla);
            tablaRecuperada = conjuntoDatos.Tables[consultaTabla];

            gv.DataSource = tablaRecuperada;
            gv.ReadOnly = readOnly;
            gv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            if (columnasOcultas != null) {
                for (int i = 0; i < columnasOcultas.Length; i++)
                {
                    gv.Columns[i].Visible = false;
                }
            }
            
        }
        /* 
         * -Recibe un ComboBox que se rellenara con los datos que haya en la variable datos
         * -Recibe un entero que indica el numero de columnas que manejamos
         * -Recibe un boolean que indica si la clave es un entero o no
         */
        private void cargarComboBox(ComboBox cb, int numColumnas, Boolean esInt)
        {
            //Se limpia el combobox para que no se repitan los valores
            cb.Items.Clear();
            if (datos.HasRows)
            {
                while (datos.Read())
                {
                    ListItem item = new ListItem();
                    if (esInt)
                    {
                        item.Value = datos.GetInt32(0);
                    }
                    else
                    {
                        item.Value = datos.GetString(0);
                    }
                    switch (numColumnas)
                    {
                        case 2:
                            item.Text = datos.GetString(1);
                            break;
                        case 3:
                            item.Text = datos.GetString(2) + ", " + datos.GetString(1);
                            break;
                    }
                    cb.Items.Add(item);
                }

            }
            cb.SelectedIndex = 0;
        }
        /* 
         * -Recibe un ComboBox que se rellenara con los datos que haya en la variable datos
         */
        private void cargarListBox(ListBox lb)
        {
            //Se limpia el listbox para que no se repitan los valores
            lb.Items.Clear();
            if (datos.HasRows)
            {
                /*Añado al combobox los perfiles*/
                while (datos.Read())
                {
                    ListItem item = new ListItem();
                    item.Value = datos.GetInt32(0);
                    item.Text = datos.GetString(1);

                    lb.Items.Add(item);
                }
            }
            lb.SelectedIndex = 0;
        }
        /*
         * El método recibe una serie de componentes que pone a su estado por defecto 
         */
        private void limpiarComponentes(TextBox[] tbs, ComboBox[] cbs, CheckBox[] chbs)
        {
            if (tbs != null)
            {
                foreach (TextBox t in tbs)
                {
                    t.Clear();
                }
            }

            if (cbs != null)
            {
                foreach (ComboBox c in cbs)
                {
                    c.SelectedIndex = 0;
                }
            }

            if (chbs != null)
            {
                foreach (CheckBox ch in chbs)
                {
                    ch.Checked = false;
                }
            }
        }
        /*
         * -Recibe un String que corresponde a la tabla
         * -Recibe un conjunto de strings que corresponden a los campos de la tabla (Obviando autonumérico)
         * -Recibe un conjunto de strings que corresponden a los valores introducidos
         * El método introduce en la tabla los valores pasados.
         */
        private void anadirRegistro(String tabla, String[] campos, String[] valores)
        {
            String nombreCampos = "";
            String valoresCampos = "";
            /*PREPARAMOS LOS CAMPOS*/
            for (int i = 0; i < campos.Length; i++)
            {
                nombreCampos += campos[i] + ",";
            }
            nombreCampos = nombreCampos.Substring(0, nombreCampos.Length - 1);//Borramos útima coma

            /*PREPARAMOS LOS VALORES*/
            for (int i = 0; i < valores.Length; i++)
            {
                valoresCampos += valores[i] + ",";
            }
            valoresCampos = valoresCampos.Substring(0, valoresCampos.Length - 1);//Borramos útima coma

            /*FORMAMOS LA SENTENCIA*/
            string sentencia = "INSERT INTO " + tabla + "(" + nombreCampos + ") VALUES (" + valoresCampos + ")";

            manejarDatos = new OleDbCommand(sentencia, conexion);
            manejarDatos.ExecuteNonQuery();
        }
        /*
         * -Recibe un String que corresponde a la tabla donde se va a borrar
         * -Recibe un String que corresponde a la condición de los campos a borrar
         */
        private void borrarRegistro(String tabla, String condicion)
        {
            /*FORMAMOS LA SENTENCIA*/
            string sentencia = "DELETE FROM " + tabla + " WHERE " + condicion;

            manejarDatos = new OleDbCommand(sentencia, conexion);
            manejarDatos.ExecuteNonQuery();
        }
        /*
         * -Recibe un String que corresponde a la tabla donde se va a obtener
         * -Recibe un String que corresponde a la condición
         */
        private List<Object> obtenerRegistro(String tabla, String condicion, int numCamposRecuperar, List<Int32> camposInt)
        {
            /*FORMAMOS LA SENTENCIA*/
            string sentencia = "SELECT * FROM " + tabla + " WHERE " + condicion;

            manejarDatos = new OleDbCommand(sentencia, conexion);
            datos = manejarDatos.ExecuteReader();

            List<Object> valores = new List<Object>();
            if (datos.HasRows)
            {
                datos.Read();
                for (int i = 0; i < numCamposRecuperar; i++)
                {
                    if (camposInt.Contains(i))
                    {
                        valores.Add(datos.GetInt32(i));
                    }
                    else
                    {
                        valores.Add(datos.GetString(i));
                    }
                }
            }

            return valores;
        }

        
    }
}
