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

namespace PracticaFinal
{ 
    public partial class misNotas : Form
    {
        private OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=.\\data\\evalua.accdb");
        private OleDbCommand manejarDatos;
        private OleDbDataReader datos;
        private OleDbDataAdapter adaptador;
        private OleDbCommandBuilder constructor;
        private static List<Panel>panelesAplicacion = new List<Panel>();//Nº paneles aplicación

        public misNotas()
        {
            InitializeComponent();
            /*Añadimos todos los paneles a un ArrayList*/
            panelesAplicacion.Add(pLogin);
            panelesAplicacion.Add(pIntermedio);
            panelesAplicacion.Add(pAltaAlumno);
            panelesAplicacion.Add(pBajaAlumno);
            panelesAplicacion.Add(pModificarAlumno);
            panelesAplicacion.Add(pListarAlumno);
            panelesAplicacion.Add(pAltaUsuario);
            panelesAplicacion.Add(pBajaUsuario);
            panelesAplicacion.Add(pModificarUsuario);
            panelesAplicacion.Add(pListarUsuario);
            panelesAplicacion.Add(pVerNota);
            panelesAplicacion.Add(pInsertarNota);
            visualizarPanel(pLogin);
            /*El menú en el login no se ve*/
            menu.Visible = false;
        }

        /*========LOGIN===================================================*/
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string consulta = "SELECT * FROM Usuario WHERE Nombre='" + tbUser.Text + "' AND Contrasena='" + tbPass.Text+"'";
            
            //Abrimos la conexión con la BBDD y recogemos los datos
            conexion.Open();
            manejarDatos = new OleDbCommand(consulta, conexion);
            datos = manejarDatos.ExecuteReader();

            if (datos.HasRows)
            { 
                visualizarPanel(pAltaUsuario);
                int perfil=0;
                while (datos.Read()) {
                     perfil= datos.GetInt32(3);
                }

                menu.Visible = true;
                manejoMenu(perfil,menu);

                /*Limpio la password para que si vuelvo a la pantalla de login
                 * no aparezca ninguna contraseña puesta
                 */
                tbPass.Text="";
                visualizarPanel(pIntermedio);
            }
            else {
                MessageBox.Show("No ha introducido bien el usuario o contraseña.");
            }
        }
        /*===============================================================*/
        /*=======MENU INTERMEDIO=========================================*/
        private void btnAlumnos_Click(object sender, EventArgs e)
        {
           visualizarPanel(pListarAlumno);
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            visualizarPanel(pListarUsuario);
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            visualizarPanel(pVerNota);
        }
        /*===============================================================*/

        /*=======MENÚ============================================================*/
        //Usuario
        private void altaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizarPanel(pAltaUsuario);
        }
        private void bajaToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizarPanel(pBajaUsuario);
        }
        private void modificaciónToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizarPanel(pModificarUsuario);
        }
        private void listarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizarPanel(pListarUsuario);
        }

        //Alumnos
        private void altaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            visualizarPanel(pAltaAlumno);
        }
        private void bajaToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            visualizarPanel(pBajaAlumno);
        }
        private void modificaciónToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            visualizarPanel(pModificarAlumno);
        }
        private void listarToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            visualizarPanel(pListarAlumno);
        }

        //Notas
        private void insertarToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizarPanel(pInsertarNota);
        }
        private void verToolStripMenuItem_Click(object sender, EventArgs e)
        {
            visualizarPanel(pVerNota);
        }

        //Salir
        private void salirToolStripMenuItem_Click(object sender, EventArgs e)
        {
            menu.Visible = false;
            datos.Close();
            conexion.Close();
            visualizarPanel(pLogin);
        }
        /*======================================================================*/

        /*=======USUARIOS============================================================*/
        private void pAltaUsuario_VisibleChanged(object sender, EventArgs e)
        {
            if (pAltaUsuario.Visible)
            {
                //Se limpia el combobox para que no se repitan los valores
                cbPerfilU.Items.Clear();

                string consulta = "SELECT DISTINCT perfil FROM Usuario";
                manejarDatos = new OleDbCommand(consulta, conexion);
                datos = manejarDatos.ExecuteReader();

                if (datos.HasRows)
                {
                    /*Añado al combobox los perfiles*/
                    while (datos.Read())
                    {
                        cbPerfilU.Items.Add(datos.GetInt32(0));
                    }
                }
            } 
        }
        private void btnAnadirU_Click(object sender, EventArgs e)
        {
            if (!tbNombreU.Text.Equals("") && !tbContrasenaU.Text.Equals("") && !cbPerfilU.SelectedIndex.ToString().Equals("-1")) {
                String nombreIntroducido = tbNombreU.Text;
                List<String> nombresUsuarios = new List<String>();
                manejarDatos = new OleDbCommand("SELECT Nombre FROM Usuario", conexion);
                datos = manejarDatos.ExecuteReader();

                if (datos.HasRows)
                {
                    while (datos.Read())
                    {
                        nombresUsuarios.Add(datos.GetString(0));
                    }
                }
                /*Compruebo que no exista el nombre*/
                if (!nombresUsuarios.Contains(nombreIntroducido)) {
                    String[] valores = new String[3];
                    valores[0] = "'" + tbNombreU.Text + "'";
                    valores[1] = "'" + tbContrasenaU.Text + "'";
                    valores[2] = cbPerfilU.SelectedIndex.ToString();

                    anadirRegistro("Usuario",new String[] {"Nombre","Contrasena","Perfil"} ,valores);

                    /*Limpiamos los valores y mostramos un mensaje*/
                    limpiarComponentes(new TextBox[] {tbNombreU, tbContrasenaU }, new ComboBox[] { cbPerfilU });
                    MessageBox.Show("Se ha introducido correctamente el Usuario");
                }
                else {
                    /*Limpiamos campo nombre y mostramos un mensaje*/
                    limpiarComponentes(new TextBox[] {tbNombreU}, null);
                    MessageBox.Show("Ya existe el usuario "+nombreIntroducido);
                }
            }
            else {
                MessageBox.Show("Deben estar todos los datos rellenos");
            }
        }
        private void pListarUsuario_VisibleChanged(object sender, EventArgs e)
        {
            if (pListarUsuario.Visible)
            {
                String consultaTabla = "Usuario";
                cargarDatos(gvUsuarios, consultaTabla, true, new int[]{0});
            }
        }
        /*=========================================================================*/

        /*=======ALUMNOS============================================================*/
        private void pListarAlumno_VisibleChanged(object sender, EventArgs e)
        {
            if (pListarAlumno.Visible)
            {
                String consultaTabla = "Alumno";
                cargarDatos(gvAlumnos, consultaTabla, true,new int[]{0,1});
            }
        }
        /*=========================================================================*/

        /*=======NOTAS============================================================*/
        private void pVerNota_VisibleChanged(object sender, EventArgs e)
        {
            if (pVerNota.Visible)
            {
                String consultaTabla = "Nota";
                cargarDatos(gvNotas, consultaTabla, true, new int[] {0,1});
            }
        }
        /*=========================================================================*/

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
        /*
         * Activa o Desactiva las opciones del menú dependeiendo del perfil 
         * del usuario logueado.
         */
        private void manejoMenu(int perfil, MenuStrip m)
        {
            if (perfil == 0)
            {//El perfil 0 es administrador
                foreach (ToolStripMenuItem opcion in m.Items)
                {
                    opcion.Enabled = true;
                    opcion.Visible = true;
                    //Submenus
                    foreach (ToolStripMenuItem dd in opcion.DropDownItems)
                    {
                        dd.Enabled = true;
                        dd.Visible = true;
                    }
                }
                btnUsuarios.Enabled = true;
            }
            else if (perfil == 1)
            {//El perfil 1 es profesor 
                int opcionMenu = 0;
                foreach (ToolStripMenuItem opcion in m.Items)
                {
                    if (opcionMenu == 0)
                    {
                        opcion.Enabled = false;
                        opcion.Visible = false;
                    }
                    //Submenus
                    int opcionSubMenu = 0;
                    foreach (ToolStripMenuItem dd in opcion.DropDownItems)
                    {
                        if ((opcionMenu == 1 && opcionSubMenu != 3) ||
                            (opcionMenu == 2 && opcionSubMenu == 0))
                        {
                            dd.Enabled = false;
                            dd.Visible = false;
                        }
                        opcionSubMenu++;
                    }
                    opcionMenu++;
                }

                btnUsuarios.Enabled = false;
            }
        }
        /* -Recibe un DataGridView, una tabla que añadiremos a la consulta 
         * en forma de String, un booleano que indica si dicho gridview es 
         * de solo lectura o no y un array de enteros de columnas que queremos ocultar.
         * -Carga los datos de la consulta en el GridView
         */
        private void cargarDatos(DataGridView gv, String consultaTabla, Boolean readOnly,int[] columnasOcultas)
        {
            String consulta = "SELECT * FROM ";
            DataSet conjuntoDatos = new DataSet();
            DataTable tablaRecuperada = new DataTable();

            manejarDatos = new OleDbCommand(consulta+consultaTabla, conexion);
            adaptador = new OleDbDataAdapter(manejarDatos);
            constructor = new OleDbCommandBuilder(adaptador);

            adaptador.Fill(conjuntoDatos, consultaTabla);
            tablaRecuperada = conjuntoDatos.Tables[consultaTabla];

            gv.DataSource = tablaRecuperada;
            gv.ReadOnly = readOnly;
            gv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;

            for (int i = 0;i<columnasOcultas.Length;i++) {
                gv.Columns[i].Visible = false;
            }
        }
        /*
         * -Recibe un String que corresponde a la tabla
         * -Recibe un conjunto de strings que corresponden a los campos de la tabla (Obviando autonumérico)
         * -Recibe un conjunto de strings que corresponden a los valores introducidos
         * El método introduce en la tabla los valores pasados.
         */
        private void anadirRegistro(String tabla,String[] campos,String[] valores) {
            String nombreCampos = "";
            String valoresCampos = "";
            /*PREPARAMOS LOS CAMPOS*/
            for (int i = 0; i < campos.Length; i++)
            {
                nombreCampos += campos[i] + ",";
            }
            nombreCampos = nombreCampos.Substring(0, nombreCampos.Length - 1);//Borramos útima coma

            /*PREPARAMOS LOS VALORES*/
            for (int i=0;i<valores.Length;i++) {
                valoresCampos += valores[i] + ",";
            }
            valoresCampos = valoresCampos.Substring(0,valoresCampos.Length-1);//Borramos útima coma
            
            /*FORMAMOS LA SENTENCIA*/
            string sentencia = "INSERT INTO "+tabla+"("+nombreCampos+") VALUES ("+valoresCampos+")";

            manejarDatos = new OleDbCommand(sentencia, conexion);
            manejarDatos.ExecuteNonQuery();
        }
        /*
         *El método recibe una serie de componentes que pone a su estado por defecto 
         */
        private void limpiarComponentes(TextBox[] tbs,ComboBox[] cbs) {
            if (tbs!=null) {
                foreach (TextBox t in tbs)
                {
                    t.Clear();
                }
            }
            
            if (cbs!=null) {
                foreach (ComboBox c in cbs)
                {
                    c.SelectedIndex = 0;
                }
            }
            
        }
        /*===============================================================*/
    }
}
