<%@ Page Title="Dashboard" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Default.aspx.cs" Inherits="Smart_Inventory_and_Sales_Analytics_Web_Applications._Default" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <h2>Smart Inventory Analytics</h2>
    <hr />

    <div style="margin-bottom:20px;">
        <h4>Total Products:</h4>
        <asp:Label ID="lblTotalProducts" runat="server" Font-Size="Large" ForeColor="Blue"></asp:Label>
    </div>

    <div style="margin-bottom:20px;">
        <h4>Total Categories:</h4>
        <asp:Label ID="lblTotalCategories" runat="server" Font-Size="Large" ForeColor="Green"></asp:Label>
    </div>
    <div style="margin-bottom:20px;">
    <h4>Total Revenue:</h4>
    <asp:Label ID="Label1" runat="server" Font-Size="Large" ForeColor="Purple"></asp:Label>
</div>
    <div style="margin-bottom:20px;">
        <h4>Total Revenue (Sales):</h4>
        <asp:Label ID="lblTotalRevenue" runat="server" Font-Size="Large" ForeColor="Purple" Font-Bold="true"></asp:Label>
    </div>

    <div style="margin-bottom:20px;">
        <h4>Low Stock Items (Quantity < 5):</h4>
        <asp:Label ID="lblLowStock" runat="server" Font-Size="Large" ForeColor="Red"></asp:Label>
    </div>

    <hr />

    <h3>Low Stock Product Details</h3>

    <asp:GridView ID="gvLowStock" 
        runat="server" 
        AutoGenerateColumns="true" 
        CssClass="table table-bordered"
        Width="100%">
    </asp:GridView>
<br />
    <asp:HiddenField ID="hfChartLabels" runat="server" />
    <asp:HiddenField ID="hfChartData" runat="server" />

    <div class="card shadow mb-4">
        <div class="card-header bg-primary text-white">
            <h5 class="m-0"><i class="fas fa-chart-bar me-2"></i>Sales Analytics: Top Performing Products</h5>
        </div>
        <div class="card-body">
            <canvas id="myBarChart" style="max-height: 400px;"></canvas>
        </div>
    </div>

    <script src="https://cdn.jsdelivr.net/npm/chart.js"></script>
    <script>
        document.addEventListener("DOMContentLoaded", function () {
            // Get the data that C# sent us
            var rawLabels = document.getElementById('<%= hfChartLabels.ClientID %>').value;
            var rawData = document.getElementById('<%= hfChartData.ClientID %>').value;

            // If there is no data, don't try to draw
            if (!rawLabels || !rawData) return;

            var ctx = document.getElementById("myBarChart").getContext('2d');
            var myChart = new Chart(ctx, {
                type: 'bar', 
                data: {
                    labels: rawLabels.split(','), // Convert string "A,B,C" to array ["A","B","C"]
                    datasets: [{
                        label: 'Quantity Sold',
                        data: rawData.split(','), // Convert string "10,5,2" to array [10,5,2]
                        backgroundColor: 'rgba(54, 162, 235, 0.6)',
                        borderColor: 'rgba(54, 162, 235, 1)',
                        borderWidth: 1
                    }]
                },
                options: {
                    responsive: true,
                    scales: {
                        y: { beginAtZero: true }
                    }
                }
            });
        });
    </script>
</asp:Content>