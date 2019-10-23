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
            this.pAlta = new System.Windows.Forms.Panel();
            this.pBaja = new System.Windows.Forms.Panel();
            this.pModificar = new System.Windows.Forms.Panel();
            this.pInsertar = new System.Windows.Forms.Panel();
            this.pListar = new System.Windows.Forms.Panel();
            this.pVer = new System.Windows.Forms.Panel();
            this.tbUser = new System.Windows.Forms.TextBox();
            this.tbPass = new System.Windows.Forms.TextBox();
            this.btnLogin = new System.Windows.Forms.Button();
            this.lbUser = new System.Windows.Forms.Label();
            this.lbPass = new System.Windows.Forms.Label();
            this.menu = new System.Windows.Forms.MenuStrip();
            this.usuarioToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.notasToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.altaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.bajaToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.modificaciónToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.listarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.verToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.insertarToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.pLogin.SuspendLayout();
            this.menu.SuspendLayout();
            this.SuspendLayout();
            // 
            // pLogin
            // 
            this.pLogin.Controls.Add(this.lbPass);
            this.pLogin.Controls.Add(this.lbUser);
            this.pLogin.Controls.Add(this.btnLogin);
            this.pLogin.Controls.Add(this.tbPass);
            this.pLogin.Controls.Add(this.tbUser);
            this.pLogin.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pLogin.Location = new System.Drawing.Point(0, 0);
            this.pLogin.Name = "pLogin";
            this.pLogin.Size = new System.Drawing.Size(615, 337);
            this.pLogin.TabIndex = 0;
            // 
            // pAlta
            // 
            this.pAlta.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pAlta.Location = new System.Drawing.Point(0, 0);
            this.pAlta.Name = "pAlta";
            this.pAlta.Size = new System.Drawing.Size(615, 337);
            this.pAlta.TabIndex = 0;
            // 
            // pBaja
            // 
            this.pBaja.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pBaja.Location = new System.Drawing.Point(0, 0);
            this.pBaja.Name = "pBaja";
            this.pBaja.Size = new System.Drawing.Size(615, 337);
            this.pBaja.TabIndex = 1;
            // 
            // pModificar
            // 
            this.pModificar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pModificar.Location = new System.Drawing.Point(0, 0);
            this.pModificar.Name = "pModificar";
            this.pModificar.Size = new System.Drawing.Size(615, 337);
            this.pModificar.TabIndex = 2;
            // 
            // pInsertar
            // 
            this.pInsertar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pInsertar.Location = new System.Drawing.Point(0, 0);
            this.pInsertar.Name = "pInsertar";
            this.pInsertar.Size = new System.Drawing.Size(615, 337);
            this.pInsertar.TabIndex = 3;
            // 
            // pListar
            // 
            this.pListar.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pListar.Location = new System.Drawing.Point(0, 0);
            this.pListar.Name = "pListar";
            this.pListar.Size = new System.Drawing.Size(615, 337);
            this.pListar.TabIndex = 4;
            // 
            // pVer
            // 
            this.pVer.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pVer.Location = new System.Drawing.Point(0, 0);
            this.pVer.Name = "pVer";
            this.pVer.Size = new System.Drawing.Size(615, 337);
            this.pVer.TabIndex = 5;
            // 
            // tbUser
            // 
            this.tbUser.Location = new System.Drawing.Point(220, 100);
            this.tbUser.Name = "tbUser";
            this.tbUser.Size = new System.Drawing.Size(157, 20);
            this.tbUser.TabIndex = 0;
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
            // menu
            // 
            this.menu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.usuarioToolStripMenuItem,
            this.notasToolStripMenuItem});
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
            // notasToolStripMenuItem
            // 
            this.notasToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.verToolStripMenuItem,
            this.insertarToolStripMenuItem});
            this.notasToolStripMenuItem.Name = "notasToolStripMenuItem";
            this.notasToolStripMenuItem.Size = new System.Drawing.Size(50, 20);
            this.notasToolStripMenuItem.Text = "Notas";
            // 
            // altaToolStripMenuItem
            // 
            this.altaToolStripMenuItem.Name = "altaToolStripMenuItem";
            this.altaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.altaToolStripMenuItem.Text = "Alta";
            // 
            // bajaToolStripMenuItem
            // 
            this.bajaToolStripMenuItem.Name = "bajaToolStripMenuItem";
            this.bajaToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.bajaToolStripMenuItem.Text = "Baja";
            // 
            // modificaciónToolStripMenuItem
            // 
            this.modificaciónToolStripMenuItem.Name = "modificaciónToolStripMenuItem";
            this.modificaciónToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.modificaciónToolStripMenuItem.Text = "Modificación";
            // 
            // listarToolStripMenuItem
            // 
            this.listarToolStripMenuItem.Name = "listarToolStripMenuItem";
            this.listarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.listarToolStripMenuItem.Text = "Listar";
            // 
            // verToolStripMenuItem
            // 
            this.verToolStripMenuItem.Name = "verToolStripMenuItem";
            this.verToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.verToolStripMenuItem.Text = "Ver";
            // 
            // insertarToolStripMenuItem
            // 
            this.insertarToolStripMenuItem.Name = "insertarToolStripMenuItem";
            this.insertarToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.insertarToolStripMenuItem.Text = "Insertar";
            // 
            // misNotas
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(615, 337);
            this.Controls.Add(this.menu);
            this.Controls.Add(this.pLogin);
            this.Controls.Add(this.pAlta);
            this.Controls.Add(this.pBaja);
            this.Controls.Add(this.pModificar);
            this.Controls.Add(this.pListar);
            this.Controls.Add(this.pVer);
            this.Controls.Add(this.pInsertar);
            this.MainMenuStrip = this.menu;
            this.Name = "misNotas";
            this.Text = "Mis Notas";
            this.pLogin.ResumeLayout(false);
            this.pLogin.PerformLayout();
            this.menu.ResumeLayout(false);
            this.menu.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel pLogin;
        private System.Windows.Forms.TextBox tbPass;
        private System.Windows.Forms.TextBox tbUser;
        private System.Windows.Forms.Panel pAlta;
        private System.Windows.Forms.Panel pBaja;
        private System.Windows.Forms.Panel pModificar;
        private System.Windows.Forms.Panel pInsertar;
        private System.Windows.Forms.Panel pListar;
        private System.Windows.Forms.Panel pVer;
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
    }
}

