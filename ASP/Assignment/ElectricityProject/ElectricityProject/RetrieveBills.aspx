<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="RetrieveBills.aspx.cs" Inherits="ElectricityProject.RetrieveBills" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Retrieve Bills</title>
    <style>
        body {
            font-family: Arial;
            margin: 40px;
        }
        .form-group {
            margin-bottom: 15px;
        }
        input[type="text"] {
            width: 200px;
            padding: 5px;
        }
        .status-label {
            margin-top: 20px;
            font-weight: bold;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2>Retrieve Recent Bills</h2>

            <div class="form-group">
                <asp:Label ID="lblCount" runat="server" Text="Number of Bills:" />
                <asp:TextBox ID="txtCount" runat="server" />
                <asp:Button ID="btnRetrieve" runat="server" Text="Retrieve" OnClick="btnRetrieve_Click" />
            </div>

            <asp:Label ID="lblStatus" runat="server" CssClass="status-label" ForeColor="Green" />

            <br /><br />
            <asp:GridView ID="gvBills" runat="server" AutoGenerateColumns="true" />
            <br /><br />
            <asp:Button ID="btnReturn" runat="server" Text="Return to Main Menu" OnClick="btnReturn_Click" />
        </div>
    </form>
</body>
</html>
