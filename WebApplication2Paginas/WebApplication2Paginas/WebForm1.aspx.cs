using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace WebApplication2Paginas
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (CheckBox1.Checked == true)
            {
                ListBox1.Attributes.Add("disabled", "true");
            }
            else {
                ListBox1.Attributes.Remove("disabled");
            }
        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            //Response.Redirect("WebForm2.aspx?alumno="+ ListBox1.SelectedValue+"&periodo="+DropDownList1.SelectedValue);
            if (CheckBox1.Checked == true)
            {
                Session["alumno"] = "%";
            }
            else
            {
                Session["alumno"] = ListBox1.SelectedValue.ToString();
            }
            Session["periodo"] = DropDownList1.SelectedValue.ToString();
            Response.Redirect("WebForm2.aspx");
        }
    }
}