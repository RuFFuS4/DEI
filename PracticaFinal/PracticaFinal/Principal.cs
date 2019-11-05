using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.OleDb;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
        private List<Int32> perfiles = new List<Int32>();//Distintos perfiles
        private Boolean perfilesPrimeraVez = true;//Necesario para cargar los perfiles correctamente
        private String condition = ""; //Variable que variaremos para las condiciones de las busquedas
        private String usuarioLogueado = "";

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
            /*Posicionamos en el centro de la pantalla la ventana*/
            this.StartPosition = FormStartPosition.CenterScreen;
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
                int perfil=0;
                while (datos.Read()) {
                     perfil= datos.GetInt32(3);
                }

                menu.Visible = true;
                manejoMenu(perfil,menu);

                /*Guardo el nombre del usuario logueado para no poder borrarlo por ejemplo*/
                usuarioLogueado = tbUser.Text;
                /*Limpio la password para que si vuelvo a la pantalla de login
                 * no aparezca ninguna contraseña puesta
                 */
                tbPass.Text="";
                visualizarPanel(pIntermedio);
            }
            else {
                MessageBox.Show("No ha introducido bien el usuario o contraseña.");
                conexion.Close();
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
                /*Se cargan los datos del combobox
                 * -Para que esto funcione debe haber al menos un usuario de cada perfil
                 * en la base de datos para poder cargarlo en el combobox. La otra opción
                 * sería guardar en un array los tipos de perfiles.
                 */
                if (perfilesPrimeraVez) {
                    string consulta = "SELECT DISTINCT perfil FROM Usuario";
                    manejarDatos = new OleDbCommand(consulta, conexion);
                    datos = manejarDatos.ExecuteReader();

                    if (datos.HasRows)
                    {
                        /*Añado al combobox los perfiles*/
                        while (datos.Read())
                        {
                            perfiles.Add(datos.GetInt32(0));
                        }
                    }
                    perfilesPrimeraVez = false;
                }

                foreach (Int32 i in perfiles) {
                    cbPerfilU.Items.Add(i);
                }
                cbPerfilU.SelectedIndex = 0;
                //Se ponen todos los campos por defecto
                limpiarComponentes(new TextBox[] {tbNombreU,tbContrasenaU},null,null);
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
                if (nombresUsuarios.Contains(nombreIntroducido)) {
                    /*Limpiamos campo nombre y mostramos un mensaje*/
                    limpiarComponentes(new TextBox[] { tbNombreU }, null,null);
                    MessageBox.Show("Ya existe el usuario " + nombreIntroducido);
                }
                else {
                    String[] valores = new String[3];
                    valores[0] = "'" + tbNombreU.Text + "'";
                    valores[1] = "'" + tbContrasenaU.Text + "'";
                    valores[2] = cbPerfilU.SelectedIndex.ToString();

                    anadirRegistro("Usuario", new String[] { "Nombre", "Contrasena", "Perfil" }, valores);

                    /*Limpiamos los valores y mostramos un mensaje*/
                    limpiarComponentes(new TextBox[] { tbNombreU, tbContrasenaU }, new ComboBox[] { cbPerfilU },null);
                    MessageBox.Show("Se ha introducido correctamente el Usuario");
                }
            }
            else {
                MessageBox.Show("Deben estar todos los datos rellenos");
            }
        }
        private void pBajaUsuario_VisibleChanged(object sender, EventArgs e)
        {
            if (pBajaUsuario.Visible)
            {
                //Se cargan los datos del combobox
                string consulta = "SELECT Id,Nombre FROM Usuario";
                manejarDatos = new OleDbCommand(consulta, conexion);
                datos = manejarDatos.ExecuteReader();

                cargarComboBox(cbNombreBajaU,2,true);
            }
        }
        private void cbNombreBajaU_SelectedIndexChanged(object sender, EventArgs e)
        {
            String consultaTabla = "Usuario";
            condition = " WHERE Id="+ (cbNombreBajaU.SelectedItem as ListItem).Value.ToString();
            cargarDatos(gvBajaU, consultaTabla, condition,true, new int[] { 0 });
        }
        private void btnEliminarU_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Quiere eliminar este usuario?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                if (usuarioLogueado.Equals(cbNombreBajaU.Text))
                {
                    MessageBox.Show("El usuario esta logueado, no puede ser borrado");
                }
                else {
                    condition = "Id ="+ (cbNombreBajaU.SelectedItem as ListItem).Value.ToString();
                    borrarRegistro("Usuario", condition);
                    /*Cambiamos la visibilidad para recargar los datos*/
                    pBajaUsuario.Visible = false;
                    pBajaUsuario.Visible = true;
                }
            }
        }
        private void pModificarUsuario_VisibleChanged(object sender, EventArgs e)
        {
            if (pModificarUsuario.Visible)
            {
                //Se cargan los datos del combobox
                string consulta = "SELECT Id,Nombre FROM Usuario";
                manejarDatos = new OleDbCommand(consulta, conexion);
                datos = manejarDatos.ExecuteReader();

                cargarComboBox(cbNombreMU, 2, true);

                //Se limpia el combobox para que no se repitan los valores
                cbPerfilMU.Items.Clear();
                /*Se cargan los datos del combobox
                 * -Para que esto funcione debe haber al menos un usuario de cada perfil
                 * en la base de datos para poder cargarlo en el combobox. La otra opción
                 * sería guardar en un array los tipos de perfiles.
                 */
                if (perfilesPrimeraVez)
                {
                    consulta = "SELECT DISTINCT perfil FROM Usuario";
                    manejarDatos = new OleDbCommand(consulta, conexion);
                    datos = manejarDatos.ExecuteReader();

                    if (datos.HasRows)
                    {
                        /*Añado al combobox los perfiles*/
                        while (datos.Read())
                        {
                            perfiles.Add(datos.GetInt32(0));
                        }
                    }
                    perfilesPrimeraVez = false;
                }

                foreach (Int32 i in perfiles)
                {
                    cbPerfilMU.Items.Add(i);
                }
                cbPerfilMU.SelectedIndex = 0;

                /*Se deshabilitan los componentes necesarios*/
                cbPerfilMU.Enabled = false;
                tbContrasenaMU.Enabled = false;
                this.Visible = true;
            }
        }
        private void cbNombreMU_SelectedIndexChanged(object sender, EventArgs e)
        {
            condition = "Id =" + (cbNombreMU.SelectedItem as ListItem).Value.ToString();
            List<Object> valores = obtenerRegistro("Usuario",condition,4,new List<Int32>{0,3});//4 campos y primero y ultimo son enteros
            tbContrasenaMU.Text = valores[2].ToString();
            cbPerfilMU.SelectedItem = Convert.ToInt32(valores[3]);
        }
        private void btnEditarMU_Click(object sender, EventArgs e)
        {
            cbPerfilMU.Enabled = true;
            tbContrasenaMU.Enabled = true;
            cbNombreMU.Enabled = false;
            btnEditarMU.Visible = false;
        }
        private void btnConfirmarMU_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Quiere modificar este usuario?", "Modificar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                /*Cambiamos la visibilidad para recargar los datos*/
                pModificarUsuario.Visible = false;
                pModificarUsuario.Visible = true;

                btnEditarMU.Visible = true;
            }
        }
        private void pListarUsuario_VisibleChanged(object sender, EventArgs e)
        {
            if (pListarUsuario.Visible)
            {
                String consultaTabla = "Usuario";
                cargarDatos(gvUsuarios, consultaTabla,"", true, new int[]{0});
            }
        }
        /*=========================================================================*/

        /*=======ALUMNOS============================================================*/
        private void pAltaAlumno_VisibleChanged(object sender, EventArgs e)
        {
            //Se ponen todos los campos por defecto
            limpiarComponentes(new TextBox[] { tbNIFA, tbNombreA, tbApellido1A, tbApellido2A }, null, new CheckBox[] { cbBajaA });
            tbNIFA.Text = "00000000A";
            tbNIFA.ForeColor = Color.Gray;
        }
        /*Al perder el foco del componente se comprueba la validez del dni*/
        private void tbNIFA_Leave(object sender, EventArgs e)
        {
            if (!compruebaDNI(tbNIFA.Text))
            {
                MessageBox.Show("Debe introducir un DNI válido\nFormato: 00000000A");
                tbNIFA.Text = "";
            }
        }
        /*Si al coger el foco del componente está el texto por defecto se borra*/
        private void tbNIFA_Enter(object sender, EventArgs e)
        {
            if (tbNIFA.Text.Equals("00000000A")) {
                tbNIFA.Text = "";
                tbNIFA.ForeColor = Color.Black;
            }
        }
        private void btnAnadirA_Click(object sender, EventArgs e)
        {
            if (!tbNombreA.Text.Equals("") && !tbApellido1A.Text.Equals("") && !tbApellido2A.Text.Equals("")
                && !tbNIFA.Text.Equals(""))
            {
                String dniIntroducido = tbNIFA.Text;
                List<String> dniAlumnos = new List<String>();
                manejarDatos = new OleDbCommand("SELECT NIF FROM Alumno", conexion);
                datos = manejarDatos.ExecuteReader();

                if (datos.HasRows)
                {
                    while (datos.Read())
                    {
                        dniAlumnos.Add(datos.GetString(0));
                    }
                }
                /*Compruebo que no exista el dni*/
                if (dniAlumnos.Contains(dniIntroducido))
                {
                    /*Limpiamos campo nombre y mostramos un mensaje*/
                    limpiarComponentes(new TextBox[] { tbNIFA }, null,null);
                    MessageBox.Show("Ya existe un alumno con DNI: " + dniIntroducido);
                }
                else
                {
                    String[] valores = new String[4];
                    valores[0] = "'" + tbNIFA.Text + "'";
                    valores[1] = "'" + tbNombreA.Text + "'";
                    valores[2] = "'" + tbApellido1A.Text + " " + tbApellido2A.Text + "'";
                    valores[3] = cbBajaA.Checked.ToString();

                    anadirRegistro("Alumno", new String[] { "NIF", "Nombre", "Apellidos", "Baja" }, valores);

                    /*Limpiamos los valores y mostramos un mensaje*/
                    limpiarComponentes(new TextBox[] { tbNIFA,tbNombreA,tbApellido1A,tbApellido2A },null, new CheckBox[] { cbBajaA });
                    tbNIFA.Text = "00000000A";
                    tbNIFA.ForeColor = Color.Gray;
                    MessageBox.Show("Se ha introducido correctamente el Alumno");
                }
            }
            else
            {
                MessageBox.Show("Deben estar todos los datos rellenos");
            }
        }
        private void pBajaAlumno_VisibleChanged(object sender, EventArgs e)
        {
            if (pBajaAlumno.Visible)
            {
                //Se cargan los datos del combobox
                string consulta = "SELECT Id,Nombre,Apellidos FROM Alumno";
                manejarDatos = new OleDbCommand(consulta, conexion);
                datos = manejarDatos.ExecuteReader();

                cargarComboBox(cbAlumnoBajaA,3,true);
            }
        }
        private void cbAlumnoBajaA_SelectedIndexChanged(object sender, EventArgs e)
        {
            String consultaTabla = "Alumno";
            condition = " WHERE Id="+ (cbAlumnoBajaA.SelectedItem as ListItem).Value.ToString();
            cargarDatos(gvBajaA, consultaTabla, condition, true, new int[] { 0 });
        }
        private void btnEliminarA_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("¿Quiere eliminar este alumno?", "Eliminar", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                condition = "Id ="+(cbAlumnoBajaA.SelectedItem as ListItem).Value.ToString();
                borrarRegistro("Alumno",condition);
                /*Cambiamos la visibilidad para recargar los datos*/
                pBajaAlumno.Visible = false;
                pBajaAlumno.Visible = true;

            }
        }
        private void pListarAlumno_VisibleChanged(object sender, EventArgs e)
        {
            if (pListarAlumno.Visible)
            {
                String consultaTabla = "Alumno";
                cargarDatos(gvAlumnos, consultaTabla,"", true,new int[]{0,1});
            }
        }
        /*=========================================================================*/

        /*=======NOTAS============================================================*/
        private void pVerNota_VisibleChanged(object sender, EventArgs e)
        {
            if (pVerNota.Visible)
            {
                //Se cargan los datos del combobox
                string consulta = "SELECT Id,Periodo FROM Periodo";
                manejarDatos = new OleDbCommand(consulta, conexion);
                datos = manejarDatos.ExecuteReader();

                cargarComboBox(cbPeriodoVerNota,2,false);

                //Se cargan los datos del listbox
                consulta = "SELECT Id,Nombre,Apellidos FROM Alumno";
                manejarDatos = new OleDbCommand(consulta, conexion);
                datos = manejarDatos.ExecuteReader();

                cargarListBox(lsbAlumnosVerNota);
            }
        }
        private void cbTodosVerNota_CheckedChanged(object sender, EventArgs e)
        {
            if (cbTodosVerNota.Checked)
            {
                for (int i = 0; i < lsbAlumnosVerNota.Items.Count; i++)
                {
                    lsbAlumnosVerNota.SelectedIndex = i;
                }
            }
            else {
                lsbAlumnosVerNota.SelectedIndex = -1;
            }
        }
        private void lsbAlumnosVerNota_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lsbAlumnosVerNota.SelectedIndex == -1)
            {
                gvNotas.DataSource = null;
            }
            else {
                String consultaTabla = "Nota";
                string idsAlumnosSeleccionados = "(";
                for (int i=0;i<lsbAlumnosVerNota.SelectedItems.Count;i++) {
                    idsAlumnosSeleccionados += (lsbAlumnosVerNota.SelectedItems[i] as ListItem).Value.ToString() + ",";
                }
                idsAlumnosSeleccionados = idsAlumnosSeleccionados.Substring(0,idsAlumnosSeleccionados.Length-1)+ ")"; //Se borra la última coma
                condition = " WHERE id_alumno IN" +idsAlumnosSeleccionados+" AND id_periodo='"
                    +(cbPeriodoVerNota.SelectedItem as ListItem).Value.ToString()+"'";
                cargarDatos(gvNotas, consultaTabla, condition, true, new int[] { 0,1,2,3 });
            }
        }
        private void cbPeriodoVerNota_SelectedIndexChanged(object sender, EventArgs e)
        {
           String consultaTabla = "Nota";
           string idsAlumnosSeleccionados = "(";
           if (lsbAlumnosVerNota.SelectedItems.Count>0) {
                for (int i = 0; i < lsbAlumnosVerNota.SelectedItems.Count; i++)
                {
                    idsAlumnosSeleccionados += (lsbAlumnosVerNota.SelectedItems[i] as ListItem).Value.ToString() + ",";
                }
                idsAlumnosSeleccionados = idsAlumnosSeleccionados.Substring(0, idsAlumnosSeleccionados.Length - 1) + ")"; //Se borra la última coma
                condition = " WHERE id_alumno IN" + idsAlumnosSeleccionados + " AND id_periodo='"
                + (cbPeriodoVerNota.SelectedItem as ListItem).Value.ToString() + "'";
                cargarDatos(gvNotas, consultaTabla, condition, true, new int[] { 0,1,2,3});
            }
        }
        private void pInsertarNota_VisibleChanged(object sender, EventArgs e)
        {
            if (pInsertarNota.Visible)
            {
                //Se cargan los datos del combobox
                string consulta = "SELECT Id,Nombre,Apellidos FROM Alumno";
                manejarDatos = new OleDbCommand(consulta, conexion);
                datos = manejarDatos.ExecuteReader();

                cargarComboBox(cbAlumnoInsertarNota, 3, true);

                //Se cargan los datos del combobox
                consulta = "SELECT Id,Periodo FROM Periodo";
                manejarDatos = new OleDbCommand(consulta, conexion);
                datos = manejarDatos.ExecuteReader();

                cargarComboBox(cbPeriodoInsertarNota, 2, false);
            }
        }
        private void btnInsertarNota_Click(object sender, EventArgs e)
        {

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
        private void cargarDatos(DataGridView gv, String consultaTabla, String condicion,Boolean readOnly,int[] columnasOcultas)
        {
            String consulta = "SELECT * FROM ";
            DataSet conjuntoDatos = new DataSet();
            DataTable tablaRecuperada = new DataTable();

            manejarDatos = new OleDbCommand(consulta+consultaTabla+condicion, conexion);
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
         * -Recibe un ComboBox que se rellenara con los datos que haya en la variable datos
         * -Recibe un entero que indica el numero de columnas que manejamos
         * -Recibe un boolean que indica si la clave es un entero o no
         */
        private void cargarComboBox(ComboBox cb,int numColumnas,Boolean esInt)
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
                    else {
                        item.Value = datos.GetString(0);
                    }
                    switch (numColumnas) {
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
         * -Recibe un String que corresponde a la tabla donde se va a borrar
         * -Recibe un String que corresponde a la condición de los campos a borrar
         */
        private void borrarRegistro(String tabla,String condicion)
        {
            /*FORMAMOS LA SENTENCIA*/
            string sentencia = "DELETE FROM " + tabla + " WHERE "+condicion;

            manejarDatos = new OleDbCommand(sentencia, conexion);
            manejarDatos.ExecuteNonQuery();
        }
        /*
         * -Recibe un String que corresponde a la tabla donde se va a obtener
         * -Recibe un String que corresponde a la condición
         */
        private List<Object> obtenerRegistro(String tabla, String condicion,int numCamposRecuperar,List<Int32> camposInt)
        {
            /*FORMAMOS LA SENTENCIA*/
            string sentencia = "SELECT * FROM " + tabla + " WHERE " + condicion;

            manejarDatos = new OleDbCommand(sentencia, conexion);
            datos = manejarDatos.ExecuteReader();

            List<Object> valores = new List<Object>();
            if (datos.HasRows)
            {
                datos.Read();
                for (int i=0;i<numCamposRecuperar;i++) {
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
        private void limpiarComponentes(TextBox[] tbs,ComboBox[] cbs, CheckBox[] chbs) {
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

            if (chbs != null)
            {
                foreach (CheckBox ch in chbs)
                {
                    ch.Checked=false;
                }
            }
        }
        /*
         * Recibe una cadena de caracteres y comprueba que tiene formato y validez de DNI
         */
        private Boolean compruebaDNI(String dni) {
            Boolean correcto = false;
            if (dni.Length == 9)
            {
                //Comprobamos que tiene el formato 00000000A
                string pattern = "^(([A-Z])|\\d)?\\d{8}(\\d|[A-Z])?$";
                Match m = Regex.Match(dni,pattern);
                if (m.Success) {
                    String secuenciaLetrasDNI = "TRWAGMYFPDXBNJZSQVHLCKE";
                    dni = dni.ToUpper();

                    //Longitud: cadena de texto menos última posición. Así obtenemos solo el número.
                    String numeroDNI = dni.Substring(0, dni.Length - 1);

                    //Obtenemos la letra con un char que nos servirá también para el índice de las secuenciaLetrasDNI
                    char letraDNI = dni.ToCharArray()[8];
                    int i = Int32.Parse(numeroDNI) % 23;
                    correcto = (letraDNI == secuenciaLetrasDNI.ToCharArray()[i]);
                }
            }
            return correcto;
        }
        /*===============================================================*/
    }
}
