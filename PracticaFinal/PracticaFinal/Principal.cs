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
        private OleDbCommand lectorDatos;
        private OleDbDataReader datos;
        private OleDbDataAdapter adaptador;
        private OleDbCommandBuilder constructor;
        private static List<Panel>panelesAplicacion = new List<Panel>();//Nº paneles aplicación

        public misNotas()
        {
            InitializeComponent();
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
            menu.Visible = false;
        }

        /*========LOGIN===================================================*/
        private void btnLogin_Click(object sender, EventArgs e)
        {
            string consulta = "SELECT * FROM Usuario WHERE Nombre='" + tbUser.Text + "' AND Contrasena='" + tbPass.Text+"'";
            
            //Abrimos la conexión con la BBDD y recogemos los datos
            conexion.Open();
            lectorDatos = new OleDbCommand(consulta, conexion);
            datos = lectorDatos.ExecuteReader();

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
            conexion.Close();
            visualizarPanel(pLogin);
        }
        /*======================================================================*/

        /*=======USUARIOS============================================================*/
        private void pListarUsuario_VisibleChanged(object sender, EventArgs e)
        {
            if (pListarUsuario.Visible)
            {
                String consulta = "SELECT * FROM Usuario";
                cargarDatos(gvUsuarios, consulta, true);
            }
        }
        /*=========================================================================*/

        /*=======ALUMNOS============================================================*/
        /*=========================================================================*/

        /*=======NOTAS============================================================*/
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
        /* -Recibe un DataGridView, una consulta en forma de String y un booleano
         * que indica si dicho gridview es de solo lectura o no.
         * -Carga los datos de la consulta en el GridView
         */
        private void cargarDatos(DataGridView gv, String consulta, Boolean readOnly)
        {

            DataSet conjuntoDatos = new DataSet();
            DataTable tablaRecuperada = new DataTable();

            lectorDatos = new OleDbCommand(consulta, conexion);
            adaptador = new OleDbDataAdapter(lectorDatos);
            constructor = new OleDbCommandBuilder(adaptador);

            adaptador.Fill(conjuntoDatos, "Usuario");
            tablaRecuperada = conjuntoDatos.Tables["Usuario"];

            gv.DataSource = tablaRecuperada;
            gv.ReadOnly = readOnly;
            gv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
        }

        /*===============================================================*/
    }
}
