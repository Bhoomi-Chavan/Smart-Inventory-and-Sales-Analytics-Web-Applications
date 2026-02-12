<%@ Page Title="Manage Products" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Products.aspx.cs" Inherits="Smart_Inventory_and_Sales_Analytics_Web_Applications.Products" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">

    <div class="card shadow-sm mt-4">
        <div class="card-header bg-primary text-white">
            <h5 class="mb-0"><i class="fas fa-box-open me-2"></i>Add New Product</h5>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-4">
                    <label class="form-label fw-bold">Product Name</label>
                    <asp:TextBox ID="txtProductName" runat="server" CssClass="form-control" placeholder="Enter product name"></asp:TextBox>
                </div>
                <div class="col-md-4">
                    <label class="form-label fw-bold">Category</label>
                    <asp:DropDownList ID="ddlCategory" runat="server" CssClass="form-select">
                        <asp:ListItem Text="-- Select Category --" Value=""></asp:ListItem>
                        <asp:ListItem Text="Electronics" Value="1"></asp:ListItem>
                        <asp:ListItem Text="Clothing" Value="2"></asp:ListItem>
                    </asp:DropDownList>
                </div>
                <div class="col-md-4">
                    <label class="form-label fw-bold">SKU Code</label>
                    <asp:TextBox ID="txtSKU" runat="server" CssClass="form-control" placeholder="e.g., ELEC-001"></asp:TextBox>
                </div>

                <div class="col-md-3">
                    <label class="form-label fw-bold">Cost Price (₹)</label>
                    <asp:TextBox ID="txtCostPrice" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label class="form-label fw-bold">Selling Price (₹)</label>
                    <asp:TextBox ID="txtSellingPrice" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-md-3">
                    <label class="form-label fw-bold">Initial Stock Qty</label>
                    <asp:TextBox ID="txtQuantity" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                </div>
                <div class="col-md-3 d-flex align-items-end">
                    <asp:Button ID="btnSaveProduct" runat="server" Text="Save Product" CssClass="btn btn-success w-100" />
                </div>
            </div>
        </div>
    </div>

    <div class="card shadow-sm mt-4">
        <div class="card-header bg-dark text-white d-flex justify-content-between align-items-center">
            <h5 class="mb-0"><i class="fas fa-boxes me-2"></i>Inventory List</h5>
            
            <div class="d-flex">
                <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control form-control-sm me-2" placeholder="Search products..."></asp:TextBox>
                <asp:Button ID="btnSearch" runat="server" Text="Search" CssClass="btn btn-sm btn-outline-light" />
            </div>
        </div>
        <div class="card-body">
            <table class="table table-bordered table-hover">
                <thead class="table-light">
                    <tr>
                        <th>SKU</th>
                        <th>Product Name</th>
                        <th>Category</th>
                        <th>Price</th>
                        <th>Stock</th>
                        <th class="text-center">Actions</th>
                    </tr>
                </thead>
              <tbody>
    <asp:Repeater ID="rptProducts" runat="server">
        <ItemTemplate>
            <tr>
                <td><%# Eval("SKUCode") %></td>
                <td><%# Eval("Name") %></td>
                <td><%# Eval("CategoryName") %></td>
                <td>₹ <%# Eval("SellingPrice") %></td>
                <td><%# Eval("Quantity") %></td>
            </tr>
        </ItemTemplate>
    </asp:Repeater>
</tbody>
            </table>
        </div>
    </div>

</asp:Content>