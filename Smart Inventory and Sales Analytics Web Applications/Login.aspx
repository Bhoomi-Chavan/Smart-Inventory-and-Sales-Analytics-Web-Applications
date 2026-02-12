<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Login.aspx.cs" Inherits="Smart_Inventory_and_Sales_Analytics_Web_Applications.Login" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Login - Smart Inventory</title>
</head>
<body>
    <form id="form1" runat="server">

        <div style="width:400px;margin:auto;margin-top:100px;padding:20px;border:1px solid #ccc;border-radius:10px;">
            
            <h2 style="text-align:center;">Smart Inventory</h2>

            <asp:Button ID="btnShowLogin" runat="server" Text="Sign In" OnClick="btnShowLogin_Click" />
            <asp:Button ID="btnShowRegister" runat="server" Text="Sign Up" OnClick="btnShowRegister_Click" />

            <hr />

            <!-- LOGIN -->
            <asp:Panel ID="pnlLogin" runat="server">
                <h3>Sign In</h3>

                Email:
                <asp:TextBox ID="txtLoginEmail" runat="server" />
                <br />

                Password:
                <asp:TextBox ID="txtLoginPassword" runat="server" TextMode="Password" />
                <br /><br />

                <asp:Button ID="btnLogin" runat="server" Text="Login" OnClick="btnLogin_Click" />
                <br />
                <asp:Label ID="lblLoginMessage" runat="server" ForeColor="Red" />
            </asp:Panel>

            <!-- REGISTER -->
            <asp:Panel ID="pnlRegister" runat="server" Visible="false">
                <h3>Sign Up</h3>

                Full Name:
                <asp:TextBox ID="txtFullName" runat="server" />
                <br />

                Email:
                <asp:TextBox ID="txtRegisterEmail" runat="server" />
                <br />

                Password:
                <asp:TextBox ID="txtRegisterPassword" runat="server" TextMode="Password" />
                <br /><br />

                <asp:Button ID="btnRegister" runat="server" Text="Register" OnClick="btnRegister_Click" />
                <br />
                <asp:Label ID="lblRegisterMessage" runat="server" ForeColor="Green" />
            </asp:Panel>

        </div>

    </form>
</body>
</html>
