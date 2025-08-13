<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="ProductViewer.aspx.cs" Inherits="ProductViewerApp.ProductViewer" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Product Viewer</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Select a Product</h2>
            <asp:DropDownList ID="ddlProducts" runat="server" AutoPostBack="true" OnSelectedIndexChanged="ddlProducts_SelectedIndexChanged">
            </asp:DropDownList>
            <br /><br />

            <asp:Image ID="imgProduct" runat="server" Width="200px" Height="200px" />
            <br /><br />

            <asp:Button ID="btnGetPrice" runat="server" Text="Get Price" OnClick="btnGetPrice_Click" />
            <br /><br />

            <asp:Label ID="lblPrice" runat="server" Font-Bold="true" ForeColor="Green" />
        </div>
    </form>
</body>
</html>

