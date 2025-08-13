using System;
using System.Web.UI;

namespace Validation_Prj
{
    public partial class Validator : Page
    {
        protected void btnCheck_Click(object sender, EventArgs e)
        {
            if (Page.IsValid)
            {
                if (txtName.Text == txtFamilyName.Text)
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "Name must be different from Family Name.";
                }
                else if (txtAddress.Text.Length < 2)
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "Address must be at least 2 characters.";
                }
                else if (txtCity.Text.Length < 2)
                {
                    lblResult.ForeColor = System.Drawing.Color.Red;
                    lblResult.Text = "City must be at least 2 characters.";
                }
                else
                {
                    lblResult.ForeColor = System.Drawing.Color.Green;
                    lblResult.Text = "All inputs are valid!";
                }
            }
        }

    }
}


