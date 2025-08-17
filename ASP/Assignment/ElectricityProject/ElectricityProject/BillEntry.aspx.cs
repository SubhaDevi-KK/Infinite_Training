using System;
using System.Collections.Generic;
using System.Web.UI;
using ElectricityProject;

namespace ElectricityProject
{
    public partial class BillEntry : Page
    {
        private List<ElectricityBill> Bills
        {
            get => ViewState["Bills"] as List<ElectricityBill> ?? new List<ElectricityBill>();
            set => ViewState["Bills"] = value;
        }

        private int RemainingEntries
        {
            get => ViewState["RemainingEntries"] != null ? (int)ViewState["RemainingEntries"] : 0;
            set => ViewState["RemainingEntries"] = value;
        }

        protected void btnStart_Click(object sender, EventArgs e)
        {
            if (int.TryParse(txtTotalBills.Text, out int total) && total > 0)
            {
                RemainingEntries = total;
                Bills = new List<ElectricityBill>();
                lblEntryCount.Text = $"Enter details for consumer 1 of {total}";
                lblStatus.Text = "";
                litSummary.Text = "";
            }
            else
            {
                lblStatus.Text = "Please enter a valid number of bills.";
            }
        }

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            try
            {
                ElectricityBill bill = new ElectricityBill
                {
                    ConsumerNumber = txtConsumerNumber.Text,
                    ConsumerName = txtConsumerName.Text,
                    UnitsConsumed = int.Parse(txtUnitsConsumed.Text)
                };

                ElectricityBoard board = new ElectricityBoard();
                board.CalculateBill(bill);
                board.AddBill(bill);

                Bills.Add(bill);
                RemainingEntries--;

                if (RemainingEntries > 0)
                {
                    int current = Bills.Count + 1;
                    lblEntryCount.Text = $"Enter details for consumer {current} of {Bills.Count + RemainingEntries}";
                    lblStatus.Text = $"Bill added for {bill.ConsumerName}. Amount: ₹{bill.BillAmount}";
                    txtConsumerNumber.Text = "";
                    txtConsumerName.Text = "";
                    txtUnitsConsumed.Text = "";
                }
                else
                {
                    lblEntryCount.Text = "";
                    lblStatus.Text = "All bills added successfully.";
                    DisplaySummary();
                    ViewState.Remove("RemainingEntries");
                    ViewState.Remove("Bills");
                }
            }
            catch (FormatException ex)
            {
                lblStatus.Text = $"Format Error: {ex.Message}";
            }
            catch (Exception ex)
            {
                lblStatus.Text = $"Error: {ex.Message}";
            }
        }

        private void DisplaySummary()
        {
            string summary = "<h3>Bill Summary</h3><ul>";
            foreach (var bill in Bills)
            {
                summary += $"<li>{bill.ConsumerNumber} {bill.ConsumerName} {bill.UnitsConsumed} Bill Amount : ₹{bill.BillAmount}</li>";
            }
            summary += "</ul>";
            litSummary.Text = summary;
        }

        protected void btnReturn_Click(object sender, EventArgs e)
        {
            Response.Redirect("Welcome.aspx");
        }
    }
}

