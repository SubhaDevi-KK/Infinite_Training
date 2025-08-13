<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Validator.aspx.cs" Inherits="Validation_Prj.Validator" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Validator Form</title>
    <style>
        .required { color: red; }
        .form-label { display: inline-block; width: 130px; vertical-align: top; }
        .hint { font-size: 12px; color: gray; margin-left: 5px; }
        .error { display: block; margin-left: 135px; color: red; }
        .form-row { margin-bottom: 20px; }
    </style>
</head>
<body>
    <form id="form1" runat="server">
        <div>
            <h2 style="text-align:center; color:darkblue;">Validation Form</h2><br />

            <!-- Name -->
            <div class="form-row">
                <span class="form-label">Name:<span class="required">✱</span></span>
                <asp:TextBox ID="txtName" runat="server" />
                <span class="hint">(Must not match Family Name)</span><br />
                <asp:RequiredFieldValidator ID="rfvName" runat="server" ControlToValidate="txtName"
                    ErrorMessage="Name is required." ForeColor="Red" Display="Dynamic" CssClass="error" ValidationGroup="CheckGroup" />
            </div>

            <!-- Family Name -->
            <div class="form-row">
                <span class="form-label">Family Name:<span class="required">✱</span></span>
                <asp:TextBox ID="txtFamilyName" runat="server" />
                <span class="hint">(Must not match Name)</span><br />
                <asp:RequiredFieldValidator ID="rfvFamilyName" runat="server" ControlToValidate="txtFamilyName"
                    ErrorMessage="Family Name is required." ForeColor="Red" Display="Dynamic" CssClass="error" ValidationGroup="CheckGroup" />
            </div>

            <!-- Address -->
            <div class="form-row">
                <span class="form-label">Address:<span class="required">✱</span></span>
                <asp:TextBox ID="txtAddress" runat="server" />
                <span class="hint">(Minimum 2 characters)</span><br />
                <asp:RequiredFieldValidator ID="rfvAddress" runat="server" ControlToValidate="txtAddress"
                    ErrorMessage="Address is required." ForeColor="Red" Display="Dynamic" CssClass="error" ValidationGroup="CheckGroup" />
            </div>

            <!-- City -->
            <div class="form-row">
                <span class="form-label">City:<span class="required">✱</span></span>
                <asp:TextBox ID="txtCity" runat="server" />
                <span class="hint">(Minimum 2 characters)</span><br />
                <asp:RequiredFieldValidator ID="rfvCity" runat="server" ControlToValidate="txtCity"
                    ErrorMessage="City is required." ForeColor="Red" Display="Dynamic" CssClass="error" ValidationGroup="CheckGroup" />
            </div>

            <!-- Zip Code -->
            <div class="form-row">
                <span class="form-label">Zip Code:<span class="required">✱</span></span>
                <asp:TextBox ID="txtZipCode" runat="server" />
                <span class="hint">(Exactly 5 digits)</span><br />
                <asp:RequiredFieldValidator ID="rfvZipCode" runat="server" ControlToValidate="txtZipCode"
                    ErrorMessage="Zip Code is required." ForeColor="Red" Display="Dynamic" CssClass="error" ValidationGroup="CheckGroup" />
                <asp:RegularExpressionValidator ID="revZip" runat="server" ControlToValidate="txtZipCode"
                    ErrorMessage="Zip Code must be 5 digits." ValidationExpression="^\d{5}$"
                    ForeColor="Red" Display="Dynamic" CssClass="error" ValidationGroup="CheckGroup" />
            </div>

            <!-- Phone -->
            <div class="form-row">
                <span class="form-label">Phone:<span class="required">✱</span></span>
                <asp:TextBox ID="txtPhone" runat="server" />
                <span class="hint">(Format: XX-XXXXXXX or XXX-XXXXXXX)</span><br />
                <asp:RequiredFieldValidator ID="rfvPhone" runat="server" ControlToValidate="txtPhone"
                    ErrorMessage="Phone is required." ForeColor="Red" Display="Dynamic" CssClass="error" ValidationGroup="CheckGroup" />
                <asp:RegularExpressionValidator ID="revPhone" runat="server" ControlToValidate="txtPhone"
                    ErrorMessage="Phone must match format." ValidationExpression="^\d{2}-\d{7}$|^\d{3}-\d{7}$"
                    ForeColor="Red" Display="Dynamic" CssClass="error" ValidationGroup="CheckGroup" />
            </div>

            <!-- Email -->
            <div class="form-row">
                <span class="form-label">Email:<span class="required">✱</span></span>
                <asp:TextBox ID="txtEmail" runat="server" />
                <span class="hint">(e.g. user@example.com)</span><br />
                <asp:RequiredFieldValidator ID="rfvEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Email is required." ForeColor="Red" Display="Dynamic" CssClass="error" ValidationGroup="CheckGroup" />
                <asp:RegularExpressionValidator ID="revEmail" runat="server" ControlToValidate="txtEmail"
                    ErrorMessage="Invalid email format." ValidationExpression="\w+([-+.']\w+)*@\w+([-.]\w+)*\.\w+([-.]\w+)*"
                    ForeColor="Red" Display="Dynamic" CssClass="error" ValidationGroup="CheckGroup" />
            </div>

            <!-- Submit Button -->
            <asp:Button ID="btnCheck" runat="server" Text="Check" OnClick="btnCheck_Click" ValidationGroup="CheckGroup" /><br /><br />

          
            <asp:ValidationSummary ID="ValidationSummary1" runat="server" ForeColor="Red" ValidationGroup="CheckGroup" />
            <asp:Label ID="lblResult" runat="server" ForeColor="Green" />
        </div>
    </form>
</body>
</html>


