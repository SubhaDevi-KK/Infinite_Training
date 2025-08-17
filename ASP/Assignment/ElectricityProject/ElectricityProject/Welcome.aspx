<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Welcome.aspx.cs" Inherits="ElectricityProject.Welcome" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Main Menu</title>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Welcome, <%= Session["User"] %></h2>
        <asp:Button ID="btnBillEntry" runat="server" Text="Bill Entry" OnClick="btnBillEntry_Click" />
        <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve Bills" OnClick="btnRetrieve_Click" />
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />
    </form>
</body>
</html>
