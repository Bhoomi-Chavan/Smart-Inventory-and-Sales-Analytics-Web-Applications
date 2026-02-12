<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Dashboard.aspx.cs" Inherits="Smart_Inventory_and_Sales_Analytics_Web_Application.Dashboard" %>

<!DOCTYPE html>
<html>
<head runat="server">
    <title>Dashboard</title>
</head>
<body>
    <form id="form1" runat="server">

        <h2>Welcome to Smart Inventory Dashboard</h2>
        <hr />

        <asp:Button ID="btnProducts" runat="server" Text="Manage Products" PostBackUrl="Products.aspx" />
        <asp:Button ID="btnSales" runat="server" Text="Manage Sales" PostBackUrl="Sales.aspx" />
        <asp:Button ID="btnAnalytics" runat="server" Text="Sales Analytics" PostBackUrl="Analytics.aspx" />
        <asp:Button ID="btnLogout" runat="server" Text="Logout" OnClick="btnLogout_Click" />

    </form>
</body>
</html>
