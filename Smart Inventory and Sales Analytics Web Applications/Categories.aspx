<%@ Page Title="Manage Categories" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Categories.aspx.cs" Inherits="Smart_Inventory_and_Sales_Analytics_Web_Applications.Categories" %>

<asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    
    <div class="card shadow-sm mt-4">
        <div class="card-header bg-primary text-white">
            <h5 class="mb-0">Add New Category</h5>
        </div>
        <div class="card-body">
            <div class="row g-3">
                <div class="col-md-5">
                    <label class="form-label fw-bold">Category Name</label>
                    <asp:TextBox ID="txtCategoryName" runat="server" CssClass="form-control"></asp:TextBox>
                    <asp:RequiredFieldValidator ID="valName" runat="server"
                        ControlToValidate="txtCategoryName"
                        ErrorMessage="Category Name is required."
                        CssClass="text-danger"
                        Display="Dynamic" />
                </div>
                <div class="col-md-5">
                    <label class="form-label fw-bold">Description</label>
                    <asp:TextBox ID="txtDescription" runat="server" CssClass="form-control"></asp:TextBox>
                </div>
                <div class="col-md-2 d-flex align-items-end">
                    <asp:Button ID="btnSave" runat="server" Text="Save Category" CssClass="btn btn-success w-100" OnClick="btnSave_Click" />
                </div>
            </div>
        </div>
    </div>

    <div class="card shadow-sm mt-4">
        <div class="card-header bg-dark text-white">
            <h5 class="mb-0">Current Categories</h5>
        </div>
        <div class="card-body">
            <table class="table table-bordered table-hover">
                <thead class="table-light">
                    <tr>
                        <th>ID</th>
                        <th>Category Name</th>
                        <th>Description</th>
                    </tr>
                </thead>
                <tbody>
                    <asp:Repeater ID="rptCategories" runat="server">
                        <ItemTemplate>
                            <tr>
                                <td><%# Eval("CategoryId") %></td>
                                <td><%# Eval("Name") %></td>
                                <td><%# Eval("Description") %></td>
                            </tr>
                        </ItemTemplate>
                    </asp:Repeater>
                </tbody>
            </table>
        </div>
    </div>

</asp:Content>