using System;
using System.Collections.Generic;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityProject
{
    public partial class RetrieveBills : Page
    {
        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            int count;
            if (!int.TryParse(txtCount.Text, out count) || count <= 0)
            {
                lblStatus.Text = "Please enter valid input (greater than 0).";
                gvBills.DataSource = null;
                gvBills.DataBind();
                return;
            }

            ElectricityBoard board = new ElectricityBoard();
            List<ElectricityBill> bills = board.Generate_N_BillDetails(count);
            gvBills.DataSource = bills;
            gvBills.DataBind();
            lblStatus.Text = $" Retrieved {count} bill successfully.";
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }
    }
}
