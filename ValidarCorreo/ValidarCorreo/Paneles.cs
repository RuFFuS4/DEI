using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ValidarCorreo
{
    public partial class Paneles : Form
    {
        public Paneles()
        {
            InitializeComponent();
        }

        private void Paneles_Load(object sender, EventArgs e)
        {
            limpiarPaneles();
            V1.Visible = true;
        }

        private void ventana1ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiarPaneles();
            V1.Visible = true;
        }

        private void ventana2ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiarPaneles();
            V2.Visible = true;
        }

        private void ventana3ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            limpiarPaneles();
            V3.Visible = true;
        }

        private void limpiarPaneles()
        {
            V1.Visible = false;
            V2.Visible = false;
            V3.Visible = false;
        }
    }
}
