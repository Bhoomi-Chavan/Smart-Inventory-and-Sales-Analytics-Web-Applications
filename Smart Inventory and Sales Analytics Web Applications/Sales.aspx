<%@ Page Title="Record Sale" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Sales.aspx.cs" Inherits="Smart_Inventory_and_Sales_Analytics_Web_Applications.Sales" %><asp:Content ID="Content1" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row mt-4">
        <div class="col-md-6 mx-auto">
            <div class="card shadow">
                <div class="card-header bg-primary text-white">
                    <h5 class="mb-0">New Sale Transaction</h5>
                </div>
                <div class="card-body">
                    <div class="mb-3">
                        <label class="form-label fw-bold">Select Product</label>
                        <asp:DropDownList ID="ddlProducts" runat="server" CssClass="form-select"></asp:DropDownList>
                    </div>

                    <div class="mb-3">
                        <label class="form-label fw-bold">Quantity to Sell</label>
                        <asp:TextBox ID="txtQty" runat="server" CssClass="form-control" TextMode="Number"></asp:TextBox>
                    </div>

                    <asp:Button ID="btnCompleteSale" runat="server" Text="Complete Sale & Deduct Stock" 
                                CssClass="btn btn-success w-100" OnClick="btnCompleteSale_Click" />
                    
                    <hr />
                    <asp:Label ID="lblStatus" runat="server" CssClass="fw-bold d-block text-center"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>