using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityProject
{
    public partial class Login : Page
    {
        protected void btnLogin_Click(object sender, EventArgs e)
        {
            string username = txtUsername.Text;
            string password = txtPassword.Text;

            
            if (username == "admin" && password == "admin123")
            {
                Session["User"] = username;
                Response.Redirect("Welcome.aspx");
            }
            else
            {
                lblMessage.Text = "Invalid credentials!";
            }
        }

    }
}