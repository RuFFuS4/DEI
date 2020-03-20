using PracticaFinal;
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

namespace GomezRubio_Rafael_ExamenRecuperacion_CRUD
{
    public partial class cambiarNombre : Form
    {
        private static String nombreBD = "videoclub.accdb";
        private OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=|DataDirectory|\\"+nombreBD);
        private OleDbCommand manejarDatos;
        private OleDbDataReader datos;
        private OleDbDataAdapter adaptador;
        private OleDbCommandBuilder constructor;
        private DataTable tablaRecuperada;
        private static List<Panel> panelesAplicacion = new List<Panel>();//Nº paneles aplicación
        private String condition = ""; //Variable que variaremos para las condiciones de las busquedas

        public cambiarNombre()
        {
            InitializeComponent();
            /*Añadimos todos los paneles a un ArrayList*/
            panelesAplicacion.Add(pAltaActuacion);
            panelesAplicacion.Add(pBajaActuacion);
            panelesAplicacion.Add(pModificacionActuacion);
            panelesAplicacion.Add(pListarActuacion);
            panelesAplicacion.Add(pTotales);
            panelesAplicacion.Add(pAltaPelicula);
            panelesAplicacion.Add(pBajaPelicula);
            panelesAplicacion.Add(pModificacionPelicula);
            panelesAplicacion.Add(pListarPelicula);
            panelesAplicacion.Add(pAltaPersona);
            panelesAplicacion.Add(pBajaPersona);
            panelesAplicacion.Add(pModificacionPersona);
            panelesAplicacion.Add(pListarPersonas);
            visualizarPanel(pPrincipal);
            /*Abrimos la conexion*/
            conexion.Open();
            /*El menú en el login no se ve*/
            menu.Visible = false;
            /*Posicionamos en el centro de la pantalla la ventana*/
            this.StartPosition = FormStartPosition.CenterScreen;
        }

        /*=======MENÚ============================================================*/
        //Peliculas
        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizarPanel(pAltaPelicula);
        }
        private void btnAltaPelicula_Click(object sender, EventArgs e)
        {
            if (!tbTituloAlta.Text.Equals("") && !tbPresupuestoAlta.Text.Equals(""))
            {
                String tituloIntroducido = tbTituloAlta.Text;
                List<String> titulosPeliculas = new List<String>();
                manejarDatos = new OleDbCommand("SELECT titulo FROM Pelicula", conexion);
                datos = manejarDatos.ExecuteReader();

                if (datos.HasRows)
                {
                    while (datos.Read())
                    {
                        titulosPeliculas.Add(datos.GetString(0));
                    }
                }

                if (titulosPeliculas.Contains(tituloIntroducido))
                {
                    limpiarComponentes(new TextBox[] { tbTituloAlta,tbPresupuestoAlta}, null, null);
                    MessageBox.Show("Ya existe una pelicula con nombre: " + tituloIntroducido);
                }
                else
                {
                    String[] valores = new String[2];
                    valores[0] = "'" + tbTituloAlta.Text + "'";
                    valores[1] = tbPresupuestoAlta.Text;

                    anadirRegistro("Pelicula", new String[] { "titulo", "presupuesto"}, valores);

                    /*Limpiamos los valores y mostramos un mensaje*/
                    limpiarComponentes(new TextBox[] { tbTituloAlta, tbPresupuestoAlta }, null, null);
                    MessageBox.Show("Se ha introducido correctamente la pelicula");
                }
            }
            else
            {
                MessageBox.Show("Deben estar todos los datos rellenos");
            }
        }

        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizarPanel(pListarPelicula);
        }
        private void pListarPelicula_VisibleChanged(object sender, EventArgs e)
        {
            if (pListarPelicula.Visible)
            {
                String consultaTabla = "Pelicula";
                cargarDatos(gvListarPelicula, "*", consultaTabla, condition, true, new int[] { 0 });
            }
        }
        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizarPanel(pBajaPelicula);
        }
        private void pBajaPelicula_VisibleChanged(object sender, EventArgs e)
        {
            if (pBajaPelicula.Visible)
            {
                //Se cargan los datos del combobox
                string consulta = "SELECT cod_pelicula,titulo FROM Pelicula";
                manejarDatos = new OleDbCommand(consulta, conexion);
                datos = manejarDatos.ExecuteReader();

                cargarComboBox(cbBajaPelicula, 2, true);

            }
        }
        private void btnBajaPelicula_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Quiere eliminar esta pelicula?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                borrarRegistro("Pelicula", "cod_pelicula = " + (cbBajaPelicula.SelectedItem as ListItem).Value.ToString());
                /*Cambiamos la visibilidad para recargar los datos*/
                pBajaPelicula.Visible = false;
                pBajaPelicula.Visible = true;

            }
        }
        //Personas
        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            visualizarPanel(pListarPersonas);
        }
        private void pListarPersonas_VisibleChanged(object sender, EventArgs e)
        {
            if (pListarPersonas.Visible) {
                String consultaTabla = "Persona";
                cargarDatos(gvListarPersonas, "*", consultaTabla, condition, true, new int[] { 0 });
            }
        }
        private void bajaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            visualizarPanel(pBajaPersona);
        }
        private void pBajaPersona_VisibleChanged(object sender, EventArgs e)
        {
            if (pBajaPersona.Visible)
            {
                //Se cargan los datos del combobox
                string consulta = "SELECT cod_persona,nombre,apellidos FROM Persona";
                manejarDatos = new OleDbCommand(consulta, conexion);
                datos = manejarDatos.ExecuteReader();

                cargarComboBox(cbBajaPersona, 3, true);

            }
        }
        private void btnBajaPersona_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Quiere eliminar esta persona?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                borrarRegistro("Persona", "cod_persona = " + (cbBajaPersona.SelectedItem as ListItem).Value.ToString());
                /*Cambiamos la visibilidad para recargar los datos*/
                pBajaPersona.Visible = false;
                pBajaPersona.Visible = true;

            }
        }
        private void altaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            visualizarPanel(pAltaPersona);
        }
        private void btnAltaPersona_Click(object sender, EventArgs e)
        {
            if (!tbNombrePersona.Text.Equals("") && !tbApellidoPersona.Text.Equals("") && !tbSueldoPersona.Text.Equals(""))
            {
                String[] valores = new String[3];
                valores[0] = "'" + tbNombrePersona.Text + "'";
                valores[1] = "'" + tbApellidoPersona.Text + "'";
                valores[2] = tbSueldoPersona.Text;

                anadirRegistro("Persona", new String[] { "nombre","apellidos","sueldo" }, valores);

                /*Limpiamos los valores y mostramos un mensaje*/
                 limpiarComponentes(new TextBox[] { tbNombrePersona, tbApellidoPersona,tbSueldoPersona }, null, null);
                 MessageBox.Show("Se ha introducido correctamente la persona");
                
            }
            else
            {
                MessageBox.Show("Deben estar todos los datos rellenos");
            }
        }
        //Totales
        private void totalesToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizarPanel(pTotales);
        }
        private void pTotales_VisibleChanged(object sender, EventArgs e)
        {
            if (pTotales.Visible) {
                //Se cargan los datos del combobox
                string consulta = "SELECT cod_pelicula,titulo FROM Pelicula";
                manejarDatos = new OleDbCommand(consulta, conexion);
                datos = manejarDatos.ExecuteReader();

                cargarComboBox(cbTotales, 2, true);

            }
        }
        private void cbTotales_SelectedIndexChanged(object sender, EventArgs e)
        {
            string consulta = "SELECT presupuesto FROM Pelicula WHERE cod_pelicula = "+(cbTotales.SelectedItem as ListItem).Value.ToString();
            manejarDatos = new OleDbCommand(consulta, conexion);
            datos = manejarDatos.ExecuteReader();

            if (datos.HasRows)
            {
                datos.Read();
                tbPresupuestoTotales.Text = datos.GetInt32(0) + "€";
            }
            /*string consulta = "SELECT sum(p.sueldo) FROM Persona p,Actuan a WHERE a.cod_pelicula = " + (cbTotales.SelectedItem as ListItem).Value.ToString()
                +" AND a.cod_Persona IN (SELECT cod_persona FROM Persona WHERE )";
            manejarDatos = new OleDbCommand(consulta, conexion);
            datos = manejarDatos.ExecuteReader();

            if (datos.HasRows)
            {
                datos.Read();
                tbSueldoTotales.Text = datos.GetInt32(0) + "€";
            }*/
        }
        //Actuan
        private void altaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            visualizarPanel(pAltaActuacion);
        }
        private void listarToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            visualizarPanel(pListarActuacion);
        }
        private void bajaToolStripMenuItem2_Click(object sender, EventArgs e)
        {
            visualizarPanel(pBajaActuacion);
        }
        
        private void pAltaActuacion_VisibleChanged(object sender, EventArgs e)
        {
            if (pAltaActuacion.Visible)
            {
                //Se cargan los datos del combobox
                string consulta = "SELECT cod_pelicula,titulo FROM Pelicula";
                manejarDatos = new OleDbCommand(consulta, conexion);
                datos = manejarDatos.ExecuteReader();

                cargarComboBox(cbAltaActuacion, 2, true);

                //Se cargan los datos del listbox
                consulta = "SELECT cod_persona,nombre,apellidos FROM Persona";
                manejarDatos = new OleDbCommand(consulta, conexion);
                datos = manejarDatos.ExecuteReader();

                cargarListBox(lbAltaActuacion);
            }
        }
        private void btnAltaActuacion_Click(object sender, EventArgs e)
        {
            Boolean menosDos = false;
            /*FORMAMOS LA SENTENCIA*/
            string sentencia = "SELECT count(cod_persona) FROM Actuan WHERE cod_pelicula = " + (cbAltaActuacion.SelectedItem as ListItem).Value.ToString();

            manejarDatos = new OleDbCommand(sentencia, conexion);
            datos = manejarDatos.ExecuteReader();
            int cantidadRegistros = 2;
            if (datos.HasRows)
            { 
                datos.Read();
                cantidadRegistros = datos.GetInt32(0);
            }
            if ( cantidadRegistros<2) {
                menosDos = true;
            }
            if (menosDos)
            {
                String[] v = new String[2];
                v[0] = (cbAltaActuacion.SelectedItem as ListItem).Value.ToString();
                v[1] = (lbAltaActuacion.SelectedItem as ListItem).Value.ToString();

                anadirRegistro("Actuan", new String[] { "cod_pelicula", "cod_persona" }, v);
                MessageBox.Show("Se ha contratado una nueva persona para la pelicula.");
                visualizarPanel(pAltaActuacion);
            }
            else {
                MessageBox.Show("Ya hay al menos 2 personas trabajando en esta pelicula. Lo siento.");
            }
            
        }
        private void pListarActuacion_VisibleChanged(object sender, EventArgs e)
        {
            if (pListarActuacion.Visible) {
                String consulta = "SELECT a.Id,pl.titulo, pr.nombre,pr.apellidos FROM Pelicula pl, Persona pr, Actuan a" +
                    " WHERE a.cod_pelicula = pl.cod_pelicula AND a.cod_persona = pr.cod_persona";
                DataSet conjuntoDatos = new DataSet();
                tablaRecuperada = new DataTable();

                manejarDatos = new OleDbCommand(consulta, conexion);
                adaptador = new OleDbDataAdapter(manejarDatos);
                constructor = new OleDbCommandBuilder(adaptador);

                adaptador.Fill(conjuntoDatos, "Videoclub");
                tablaRecuperada = conjuntoDatos.Tables["Videoclub"];

                gvListarActuaciones.DataSource = tablaRecuperada;
                gvListarActuaciones.ReadOnly = true;
                gvListarActuaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                gvListarActuaciones.Columns[0].Visible = false;
            }
        }
        private void pBajaActuacion_VisibleChanged(object sender, EventArgs e)
        {
            if (pBajaActuacion.Visible)
            {
                String consulta = "SELECT a.Id,pl.titulo, pr.nombre,pr.apellidos FROM Pelicula pl, Persona pr, Actuan a" +
                    " WHERE a.cod_pelicula = pl.cod_pelicula AND a.cod_persona = pr.cod_persona";
                DataSet conjuntoDatos = new DataSet();
                tablaRecuperada = new DataTable();

                manejarDatos = new OleDbCommand(consulta, conexion);
                adaptador = new OleDbDataAdapter(manejarDatos);
                constructor = new OleDbCommandBuilder(adaptador);

                adaptador.Fill(conjuntoDatos, "Videoclub");
                tablaRecuperada = conjuntoDatos.Tables["Videoclub"];

                gvBorrarActuaciones.DataSource = tablaRecuperada;
                gvBorrarActuaciones.ReadOnly = true;
                gvBorrarActuaciones.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

                gvBorrarActuaciones.Columns[0].Visible = false;
            }
        }
        private void button1_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Seguro que quiere eliminar esta actuación?", "Borrar", MessageBoxButtons.YesNo) == DialogResult.Yes)
            {
                
                condition = "Id =" + gvBorrarActuaciones.SelectedRows[0].ToString();
                MessageBox.Show(condition);
                borrarRegistro("Actuan", condition);

                pBajaActuacion.Visible = false;
                pBajaActuacion.Visible = true;
            }
        }
        private void cbAltaActuacion_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }
        
        //Salir
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            datos.Close();
            conexion.Close();
            Application.Exit();
        }
        /*======================================================================*/
        private void button1_Click(object sender, EventArgs e)
        {
            visualizarPanel(pAltaPelicula);
            menu.Visible = true;
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
        private void cargarDatos(DataGridView gv, String campos,String consultaTabla, String condicion, Boolean readOnly, int[] columnasOcultas)
        {
            String consulta = "SELECT "+campos+" FROM ";//campos=* si queremos todos
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

            for (int i = 0; i < columnasOcultas.Length; i++)
            {
                gv.Columns[i].Visible = false;
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
                /*Añado al combobox los perfiles*/
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
                    item.Text = datos.GetString(2) + ", " + datos.GetString(1);

                    lb.Items.Add(item);
                }
            }
            lb.SelectedIndex = 0;
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
            if(datos.HasRows)
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

        private void label10_Click(object sender, EventArgs e)
        {

        }


        /*===============================================================*/
    }
}
