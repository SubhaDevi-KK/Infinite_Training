using System;
using System.Collections.Generic;

namespace ProductViewerApp
{
    public partial class ProductViewer : System.Web.UI.Page
    {
        Dictionary<string, string> productImages = new Dictionary<string, string>()
        {
            { "Laptop", "~/Images/laptop.jpg" },
            { "Phone", "~/Images/phone.jpg" },
            { "Headphones", "~/Images/headphones.jpg" }
        };

        Dictionary<string, string> productPrices = new Dictionary<string, string>()
        {
            { "Laptop", "1200" },
            { "Phone", "800" },
            { "Headphones", "150" }
        };

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlProducts.Items.Add("Select Product");
                foreach (var item in productImages.Keys)
                {
                    ddlProducts.Items.Add(item);
                }
            }
        }

        protected void ddlProducts_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selected = ddlProducts.SelectedValue;
            if (productImages.ContainsKey(selected))
            {
                imgProduct.ImageUrl = productImages[selected];
                lblPrice.Text = ""; // Clear price when selection changes
            }
            else
            {
                imgProduct.ImageUrl = "";
            }
        }

        protected void btnGetPrice_Click(object sender, EventArgs e)
        {
            string selected = ddlProducts.SelectedValue;
            if (productPrices.ContainsKey(selected))
            {
                lblPrice.Text = "Price: " + productPrices[selected];
            }
            else
            {
                lblPrice.Text = "Please select a valid product.";
            }
        }
    }
}
