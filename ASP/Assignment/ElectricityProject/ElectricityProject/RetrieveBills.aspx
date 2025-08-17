<<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetrieveBills.aspx.cs" Inherits="ElectricityProject.RetrieveBills" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Retrieve Bills</title>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Retrieve Recent Bills</h2>
            <asp:Label ID="lblCount" runat="server" Text="Number of Bills:" />
            <asp:TextBox ID="txtCount" runat="server" />
            <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve" OnClick="btnRetrieve_Click" />
            <br /><br />
            <asp:GridView ID="gvBills" runat="server" AutoGenerateColumns="true" />
            <br /><br />
            <asp:Button ID="btnReturn" runat="server" Text="Return to Main Menu" OnClick="btnReturn_Click" />

        </div>
    </form>
</body>
</html>
