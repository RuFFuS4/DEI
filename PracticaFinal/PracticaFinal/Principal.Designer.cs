namespace PracticaFinal
{
    partial class misNotas
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.pLogin = new System.Windows.Forms.Panel();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lbPass = new System.Windows.Forms.Label();
            this.lbUser = new System.Windows.Forms.Label();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.pAltaUsuario = new System.Windows.Forms.Panel();
            this.pBajaUsuario = new System.Windows.Forms.Panel();
            this.pModificarUsuario = new System.Windows.Forms.Panel();
            this.pInsertarNota = new System.Windows.Forms.Panel();
            this.pListarUsuario = new System.Windows.Forms.Panel();
            this.gvUsuarios = new System.Windows.Forms.DataGridView();
            this.label1 = new System.Windows.Forms.Label();
            this.pVerNota = new System.Windows.Forms.Panel();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.alumnosToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaciónToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.notasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salirToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pIntermedio = new System.Windows.Forms.Panel();
            this.btnNotas = new System.Windows.Forms.Button();
            this.btnAlumnos = new System.Windows.Forms.Button();
            this.btnUsuarios = new System.Windows.Forms.Button();
            this.pAltaAlumno = new System.Windows.Forms.Panel();
            this.pBajaAlumno = new System.Windows.Forms.Panel();
            this.pModificarAlumno = new System.Windows.Forms.Panel();
            this.pListarAlumno = new System.Windows.Forms.Panel();
            this.pLogin.SuspendLayout();
            this.pListarUsuario.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsuarios)).BeginInit();
            this.menu.SuspendLayout();
            this.pIntermedio.SuspendLayout();
            this.SuspendLayout();
            // 
            // pLogin
            // 
            this.pLogin.Controls.Add(this.btnLogin);
            this.pLogin.Controls.Add(this.lbPass);
            this.pLogin.Controls.Add(this.lbUser);
            this.pLogin.Controls.Add(this.tbPass);
            this.pLogin.Controls.Add(this.tbUser);
            this.pLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLogin.Location = new System.Drawing.Point(0, 24);
            this.pLogin.Name = "pLogin";
            this.pLogin.Size = new System.Drawing.Size(615, 313);
            this.pLogin.TabIndex = 0;
            // 
            // btnLogin
            // 
            this.btnLogin.Font = new System.Drawing.Font("Roboto Cn", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnLogin.Location = new System.Drawing.Point(262, 258);
            this.btnLogin.Name = "btnLogin";
            this.btnLogin.Size = new System.Drawing.Size(71, 37);
            this.btnLogin.TabIndex = 2;
            this.btnLogin.Text = "Login";
            this.btnLogin.UseVisualStyleBackColor = true;
            this.btnLogin.Click += new System.EventHandler(this.btnLogin_Click);
            // 
            // lbPass
            // 
            this.lbPass.AutoSize = true;
            this.lbPass.Font = new System.Drawing.Font("Roboto Cn", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbPass.Location = new System.Drawing.Point(242, 143);
            this.lbPass.Name = "lbPass";
            this.lbPass.Size = new System.Drawing.Size(107, 25);
            this.lbPass.TabIndex = 4;
            this.lbPass.Text = "Contraseña";
            // 
            // lbUser
            // 
            this.lbUser.AutoSize = true;
            this.lbUser.Font = new System.Drawing.Font("Roboto Cn", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbUser.Location = new System.Drawing.Point(257, 46);
            this.lbUser.Name = "lbUser";
            this.lbUser.Size = new System.Drawing.Size(76, 25);
            this.lbUser.TabIndex = 3;
            this.lbUser.Text = "Usuario";
            // 
            // tbPass
            // 
            this.tbPass.Location = new System.Drawing.Point(220, 192);
            this.tbPass.Name = "tbPass";
            this.tbPass.PasswordChar = '*';
            this.tbPass.Size = new System.Drawing.Size(157, 20);
            this.tbPass.TabIndex = 1;
            this.tbPass.UseSystemPasswordChar = true;
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(220, 100);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(157, 20);
            this.tbUser.TabIndex = 0;
            // 
            // pAltaUsuario
            // 
            this.pAltaUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAltaUsuario.Location = new System.Drawing.Point(0, 0);
            this.pAltaUsuario.Name = "pAltaUsuario";
            this.pAltaUsuario.Size = new System.Drawing.Size(615, 337);
            this.pAltaUsuario.TabIndex = 0;
            // 
            // pBajaUsuario
            // 
            this.pBajaUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBajaUsuario.Location = new System.Drawing.Point(0, 0);
            this.pBajaUsuario.Name = "pBajaUsuario";
            this.pBajaUsuario.Size = new System.Drawing.Size(615, 337);
            this.pBajaUsuario.TabIndex = 1;
            // 
            // pModificarUsuario
            // 
            this.pModificarUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pModificarUsuario.Location = new System.Drawing.Point(0, 0);
            this.pModificarUsuario.Name = "pModificarUsuario";
            this.pModificarUsuario.Size = new System.Drawing.Size(615, 337);
            this.pModificarUsuario.TabIndex = 2;
            // 
            // pInsertarNota
            // 
            this.pInsertarNota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pInsertarNota.Location = new System.Drawing.Point(0, 0);
            this.pInsertarNota.Name = "pInsertarNota";
            this.pInsertarNota.Size = new System.Drawing.Size(615, 337);
            this.pInsertarNota.TabIndex = 3;
            // 
            // pListarUsuario
            // 
            this.pListarUsuario.Controls.Add(this.gvUsuarios);
            this.pListarUsuario.Controls.Add(this.label1);
            this.pListarUsuario.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pListarUsuario.Location = new System.Drawing.Point(0, 24);
            this.pListarUsuario.Name = "pListarUsuario";
            this.pListarUsuario.Size = new System.Drawing.Size(615, 313);
            this.pListarUsuario.TabIndex = 4;
            this.pListarUsuario.VisibleChanged += new System.EventHandler(this.pListarUsuario_VisibleChanged);
            // 
            // gvUsuarios
            // 
            this.gvUsuarios.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.gvUsuarios.Location = new System.Drawing.Point(88, 74);
            this.gvUsuarios.Name = "gvUsuarios";
            this.gvUsuarios.Size = new System.Drawing.Size(444, 203);
            this.gvUsuarios.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Roboto Cn", 15.75F, System.Drawing.FontStyle.Bold);
            this.label1.Location = new System.Drawing.Point(231, 35);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(156, 25);
            this.label1.TabIndex = 0;
            this.label1.Text = "Lista de Usuarios";
            // 
            // pVerNota
            // 
            this.pVerNota.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pVerNota.Location = new System.Drawing.Point(0, 0);
            this.pVerNota.Name = "pVerNota";
            this.pVerNota.Size = new System.Drawing.Size(615, 337);
            this.pVerNota.TabIndex = 5;
            // 
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarioToolStripMenuItem,
            this.alumnosToolStripMenuItem,
            this.notasToolStripMenuItem,
            this.salirToolStripMenuItem});
            this.menu.Location = new System.Drawing.Point(0, 0);
            this.menu.Name = "menu";
            this.menu.Size = new System.Drawing.Size(615, 24);
            this.menu.TabIndex = 0;
            this.menu.Text = "menuStrip1";
            // 
            // usuarioToolStripMenuItem
            // 
            this.usuarioToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaToolStripMenuItem,
            this.bajaToolStripMenuItem,
            this.modificaciónToolStripMenuItem,
            this.listarToolStripMenuItem});
            this.usuarioToolStripMenuItem.Name = "usuarioToolStripMenuItem";
            this.usuarioToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.usuarioToolStripMenuItem.Text = "Usuario";
            // 
            // altaToolStripMenuItem
            // 
            this.altaToolStripMenuItem.Name = "altaToolStripMenuItem";
            this.altaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.altaToolStripMenuItem.Text = "Alta";
            this.altaToolStripMenuItem.Click += new System.EventHandler(this.altaToolStripMenuItem_Click);
            // 
            // bajaToolStripMenuItem
            // 
            this.bajaToolStripMenuItem.Name = "bajaToolStripMenuItem";
            this.bajaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bajaToolStripMenuItem.Text = "Baja";
            this.bajaToolStripMenuItem.Click += new System.EventHandler(this.bajaToolStripMenuItem_Click);
            // 
            // modificaciónToolStripMenuItem
            // 
            this.modificaciónToolStripMenuItem.Name = "modificaciónToolStripMenuItem";
            this.modificaciónToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modificaciónToolStripMenuItem.Text = "Modificación";
            this.modificaciónToolStripMenuItem.Click += new System.EventHandler(this.modificaciónToolStripMenuItem_Click);
            // 
            // listarToolStripMenuItem
            // 
            this.listarToolStripMenuItem.Name = "listarToolStripMenuItem";
            this.listarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listarToolStripMenuItem.Text = "Listar";
            this.listarToolStripMenuItem.Click += new System.EventHandler(this.listarToolStripMenuItem_Click);
            // 
            // alumnosToolStripMenuItem
            // 
            this.alumnosToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.altaToolStripMenuItem1,
            this.bajaToolStripMenuItem1,
            this.modificaciónToolStripMenuItem1,
            this.listarToolStripMenuItem1});
            this.alumnosToolStripMenuItem.Name = "alumnosToolStripMenuItem";
            this.alumnosToolStripMenuItem.Size = new System.Drawing.Size(67, 20);
            this.alumnosToolStripMenuItem.Text = "Alumnos";
            // 
            // altaToolStripMenuItem1
            // 
            this.altaToolStripMenuItem1.Name = "altaToolStripMenuItem1";
            this.altaToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.altaToolStripMenuItem1.Text = "Alta";
            this.altaToolStripMenuItem1.Click += new System.EventHandler(this.altaToolStripMenuItem1_Click);
            // 
            // bajaToolStripMenuItem1
            // 
            this.bajaToolStripMenuItem1.Name = "bajaToolStripMenuItem1";
            this.bajaToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.bajaToolStripMenuItem1.Text = "Baja";
            this.bajaToolStripMenuItem1.Click += new System.EventHandler(this.bajaToolStripMenuItem1_Click);
            // 
            // modificaciónToolStripMenuItem1
            // 
            this.modificaciónToolStripMenuItem1.Name = "modificaciónToolStripMenuItem1";
            this.modificaciónToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.modificaciónToolStripMenuItem1.Text = "Modificación";
            this.modificaciónToolStripMenuItem1.Click += new System.EventHandler(this.modificaciónToolStripMenuItem1_Click);
            // 
            // listarToolStripMenuItem1
            // 
            this.listarToolStripMenuItem1.Name = "listarToolStripMenuItem1";
            this.listarToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.listarToolStripMenuItem1.Text = "Listar";
            this.listarToolStripMenuItem1.Click += new System.EventHandler(this.listarToolStripMenuItem1_Click);
            // 
            // notasToolStripMenuItem
            // 
            this.notasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.insertarToolStripMenuItem,
            this.verToolStripMenuItem});
            this.notasToolStripMenuItem.Name = "notasToolStripMenuItem";
            this.notasToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.notasToolStripMenuItem.Text = "Notas";
            // 
            // insertarToolStripMenuItem
            // 
            this.insertarToolStripMenuItem.Name = "insertarToolStripMenuItem";
            this.insertarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.insertarToolStripMenuItem.Text = "Insertar";
            this.insertarToolStripMenuItem.Click += new System.EventHandler(this.insertarToolStripMenuItem_Click);
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.verToolStripMenuItem.Text = "Ver";
            this.verToolStripMenuItem.Click += new System.EventHandler(this.verToolStripMenuItem_Click);
            // 
            // salirToolStripMenuItem
            // 
            this.salirToolStripMenuItem.Name = "salirToolStripMenuItem";
            this.salirToolStripMenuItem.Size = new System.Drawing.Size(41, 20);
            this.salirToolStripMenuItem.Text = "Salir";
            this.salirToolStripMenuItem.Click += new System.EventHandler(this.salirToolStripMenuItem_Click);
            // 
            // pIntermedio
            // 
            this.pIntermedio.Controls.Add(this.btnNotas);
            this.pIntermedio.Controls.Add(this.btnAlumnos);
            this.pIntermedio.Controls.Add(this.btnUsuarios);
            this.pIntermedio.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pIntermedio.Location = new System.Drawing.Point(0, 0);
            this.pIntermedio.Name = "pIntermedio";
            this.pIntermedio.Size = new System.Drawing.Size(615, 337);
            this.pIntermedio.TabIndex = 5;
            // 
            // btnNotas
            // 
            this.btnNotas.Font = new System.Drawing.Font("Roboto Cn", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnNotas.Location = new System.Drawing.Point(206, 192);
            this.btnNotas.Name = "btnNotas";
            this.btnNotas.Size = new System.Drawing.Size(193, 94);
            this.btnNotas.TabIndex = 6;
            this.btnNotas.Text = "NOTAS";
            this.btnNotas.UseVisualStyleBackColor = true;
            this.btnNotas.Click += new System.EventHandler(this.btnNotas_Click);
            // 
            // btnAlumnos
            // 
            this.btnAlumnos.Font = new System.Drawing.Font("Roboto Cn", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlumnos.Location = new System.Drawing.Point(88, 59);
            this.btnAlumnos.Name = "btnAlumnos";
            this.btnAlumnos.Size = new System.Drawing.Size(193, 94);
            this.btnAlumnos.TabIndex = 5;
            this.btnAlumnos.Text = "ALUMNOS";
            this.btnAlumnos.UseVisualStyleBackColor = true;
            this.btnAlumnos.Click += new System.EventHandler(this.btnAlumnos_Click);
            // 
            // btnUsuarios
            // 
            this.btnUsuarios.Font = new System.Drawing.Font("Roboto Cn", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnUsuarios.Location = new System.Drawing.Point(339, 59);
            this.btnUsuarios.Name = "btnUsuarios";
            this.btnUsuarios.Size = new System.Drawing.Size(193, 94);
            this.btnUsuarios.TabIndex = 4;
            this.btnUsuarios.Text = "USUARIOS";
            this.btnUsuarios.UseVisualStyleBackColor = true;
            this.btnUsuarios.Click += new System.EventHandler(this.btnUsuarios_Click);
            // 
            // pAltaAlumno
            // 
            this.pAltaAlumno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAltaAlumno.Location = new System.Drawing.Point(0, 0);
            this.pAltaAlumno.Name = "pAltaAlumno";
            this.pAltaAlumno.Size = new System.Drawing.Size(615, 337);
            this.pAltaAlumno.TabIndex = 5;
            // 
            // pBajaAlumno
            // 
            this.pBajaAlumno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBajaAlumno.Location = new System.Drawing.Point(0, 0);
            this.pBajaAlumno.Name = "pBajaAlumno";
            this.pBajaAlumno.Size = new System.Drawing.Size(615, 337);
            this.pBajaAlumno.TabIndex = 0;
            // 
            // pModificarAlumno
            // 
            this.pModificarAlumno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pModificarAlumno.Location = new System.Drawing.Point(0, 0);
            this.pModificarAlumno.Name = "pModificarAlumno";
            this.pModificarAlumno.Size = new System.Drawing.Size(615, 337);
            this.pModificarAlumno.TabIndex = 0;
            // 
            // pListarAlumno
            // 
            this.pListarAlumno.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pListarAlumno.Location = new System.Drawing.Point(0, 0);
            this.pListarAlumno.Name = "pListarAlumno";
            this.pListarAlumno.Size = new System.Drawing.Size(615, 337);
            this.pListarAlumno.TabIndex = 0;
            // 
            // misNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 337);
            this.Controls.Add(this.pLogin);
            this.Controls.Add(this.pListarUsuario);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.pIntermedio);
            this.Controls.Add(this.pAltaAlumno);
            this.Controls.Add(this.pBajaAlumno);
            this.Controls.Add(this.pModificarAlumno);
            this.Controls.Add(this.pListarAlumno);
            this.Controls.Add(this.pAltaUsuario);
            this.Controls.Add(this.pBajaUsuario);
            this.Controls.Add(this.pModificarUsuario);
            this.Controls.Add(this.pVerNota);
            this.Controls.Add(this.pInsertarNota);
            this.MainMenuStrip = this.menu;
            this.Name = "misNotas";
            this.Text = "Mis Notas";
            this.pLogin.ResumeLayout(false);
            this.pLogin.PerformLayout();
            this.pListarUsuario.ResumeLayout(false);
            this.pListarUsuario.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gvUsuarios)).EndInit();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.pIntermedio.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pLogin;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Panel pAltaUsuario;
        private System.Windows.Forms.Panel pBajaUsuario;
        private System.Windows.Forms.Panel pModificarUsuario;
        private System.Windows.Forms.Panel pInsertarNota;
        private System.Windows.Forms.Panel pListarUsuario;
        private System.Windows.Forms.Panel pVerNota;
        private System.Windows.Forms.Label lbPass;
        private System.Windows.Forms.Label lbUser;
        private System.Windows.Forms.Button btnLogin;
        private System.Windows.Forms.MenuStrip menu;
        private System.Windows.Forms.ToolStripMenuItem usuarioToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem bajaToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem modificaciónToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem notasToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem verToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem insertarToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem alumnosToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem altaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem bajaToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem modificaciónToolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem listarToolStripMenuItem1;
        private System.Windows.Forms.Panel pIntermedio;
        private System.Windows.Forms.Button btnNotas;
        private System.Windows.Forms.Button btnAlumnos;
        private System.Windows.Forms.Button btnUsuarios;
        private System.Windows.Forms.ToolStripMenuItem salirToolStripMenuItem;
        private System.Windows.Forms.DataGridView gvUsuarios;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pAltaAlumno;
        private System.Windows.Forms.Panel pBajaAlumno;
        private System.Windows.Forms.Panel pModificarAlumno;
        private System.Windows.Forms.Panel pListarAlumno;
    }
}

