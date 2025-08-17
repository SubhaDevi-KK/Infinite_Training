<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="BillEntry.aspx.cs" Inherits="ElectricityProject.BillEntry" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Bill Entry</title>
    <style>
        body {
            font-family: Arial;
            margin: 40px;
        }
        .form-group {
            margin-bottom: 15px;
        }
        label {
            display: block;
            font-weight: bold;
        }
        input[type="text"] {
            width: 300px;
            padding: 5px;
        }
        .submit-btn {
            margin-top: 20px;
        }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <h2>Electricity Bill Entry</h2>

        <div class="form-group">
            <label for="txtTotalBills">Number of Bills to Add:</label>
            <asp:TextBox ID="txtTotalBills" runat="server" />
            <asp:Button ID="btnStart" runat="server" Text="Start Entry" OnClick="btnStart_Click" />
        </div>

        <div class="form-group">
            <asp:Label ID="lblEntryCount" runat="server" Font-Bold="true" />
        </div>

        <div class="form-group">
            <label for="txtConsumerNumber">Consumer Number:</label>
            <asp:TextBox ID="txtConsumerNumber" runat="server" />
        </div>

        <div class="form-group">
            <label for="txtConsumerName">Consumer Name:</label>
            <asp:TextBox ID="txtConsumerName" runat="server" />
        </div>

        <div class="form-group">
            <label for="txtUnitsConsumed">Units Consumed:</label>
            <asp:TextBox ID="txtUnitsConsumed" runat="server" />
        </div>

        <div class="submit-btn">
            <asp:Button ID="btnSubmit" runat="server" Text="Submit Bill" OnClick="btnSubmit_Click" />
            <br /><br />
            <asp:Button ID="btnReturn" runat="server" Text="Return to Main Menu" OnClick="btnReturn_Click" />
        </div>

        <div style="margin-top: 20px;">
            <asp:Label ID="lblStatus" runat="server" ForeColor="Green" />
        </div>

        <div style="margin-top: 20px;">
            <asp:Literal ID="litSummary" runat="server" />
        </div>
    </form>
</body>
</html>

