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
        private static List<Panel>panelesAplicacion = new List<Panel>();//Nº paneles aplicación
        public misNotas()
        {
            InitializeComponent();
            panelesAplicacion.Add(pLogin);
            panelesAplicacion.Add(pIntermedio);
            panelesAplicacion.Add(pAltaUsuario);
            panelesAplicacion.Add(pBajaUsuario);
            panelesAplicacion.Add(pModificarUsuario);
            panelesAplicacion.Add(pListarUsuario);
            panelesAplicacion.Add(pVerNota);
            panelesAplicacion.Add(pInsertarNota);
            menu.Visible = false;
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            OleDbConnection conexion = new OleDbConnection("Provider=Microsoft.Jet.OLEDB.12.0; Data Source=|DataDirectory|evalua.accdb");
            string consulta = "SELECT Nombre,Contrasena FROM Usuario WHERE Nombre=" + tbUser.Text + " AND Contrasena=" + tbPass.Text;
            string consultaPerfil = "SELECT Perfil FROM Usuario WHERE Nombre=" + tbUser.Text + " AND Contrasena=" + tbPass.Text;


            OleDbCommand comando = new OleDbCommand(consulta, conexion);
            OleDbCommand comandoPerfil = new OleDbCommand(consultaPerfil, conexion);
            OleDbDataReader datos;

            conexion.Open();
            datos = comando.ExecuteReader();
            datos.Read();

            if (datos.HasRows)
            { 
                visualizarPanel(pAltaUsuario);

                datos = comandoPerfil.ExecuteReader();
                datos.Read();
                int perfil = Int32.Parse(datos.GetString(0));


                menu.Visible = true;
                manejoMenu(perfil,menu);

                visualizarPanel(pIntermedio);
            }
            else {
                MessageBox.Show("No ha introducido bien el usuario o contraseña.");
            }
        }

        private static void visualizarPanel(Panel p) {
            foreach (Panel pa in panelesAplicacion) {
                pa.Visible = false;
            }
            p.Visible = true;
        }
        private static void manejoMenu(int perfil,MenuStrip m) {
            if (perfil == 0) {//El perfil 0 es administrador
                for(int i=0;i< m.Items.Count;i++) {
                    m.Items[i].Enabled = true;
                    m.Items[i].Visible = true;
                }
            } else if (perfil == 1) {//El perfil 1 es profesor 
                for (int i = 0; i < m.Items.Count; i++)
                {
                    m.Items[i].Enabled = false;
                    m.Items[i].Visible = false;
                }
                m.Items[m.Items.Count - 1].Enabled = true;
                m.Items[m.Items.Count - 1].Enabled = false;
            }
        }

        private void alumnosToolStripMenuItem_Click(object sender, EventArgs e)
        {

        }

        private void btnAlumnos_Click(object sender, EventArgs e)
        {
           // visualizarPanel();
        }

        private void btnUsuarios_Click(object sender, EventArgs e)
        {
            visualizarPanel(pListarUsuario);
        }

        private void btnNotas_Click(object sender, EventArgs e)
        {
            visualizarPanel(pVerNota);
        }
    }
}
