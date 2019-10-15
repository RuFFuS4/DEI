using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text.RegularExpressions;

namespace ValidarCorreo
{
    public partial class ValidarCorreo : Form
    {
        public ValidarCorreo()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Regex Val = new Regex(@"\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)* ");
            if (Val.IsMatch(textBox1.Text))
            {
                MessageBox.Show("Correcto");
            }
            else
            {
                MessageBox.Show("Incorrecto");
            }
        }
    }
}
