using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (IsPostBack)
            {
                limpiar();
                Label1.Text = "Hola " + TextBox1.Text + ". Has elegido el pedido " + DropDownList1.SelectedItem.ToString() + " que tiene un valor de " + DropDownList1.SelectedValue + " y ocupa la posición " + (DropDownList1.SelectedIndex + 1) + ".";

            }

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
        }

        protected void limpiar() {
            TextBox1.Visible = false;
            DropDownList1.Visible = false;
            Button1.Visible = false;
            Label2.Visible = false;
            Label3.Visible = false;
        }
    }
}