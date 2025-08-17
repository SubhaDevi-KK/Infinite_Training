using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ElectricityProject
{
    public partial class RetrieveBills : Page
    {
        protected void btnRetrieve_Click(object sender, EventArgs e)
        {
            int count = int.Parse(txtCount.Text);
            ElectricityBoard board = new ElectricityBoard();
            List<ElectricityBill> bills = board.Generate_N_BillDetails(count);
            gvBills.DataSource = bills;
            gvBills.DataBind();
        }
        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }

    }
}