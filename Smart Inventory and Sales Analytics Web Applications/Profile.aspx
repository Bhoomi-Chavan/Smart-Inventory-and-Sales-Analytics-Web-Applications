<%@ Page Title="Profile Settings" Language="C#" MasterPageFile="~/Site.Master" AutoEventWireup="true" CodeBehind="Profile.aspx.cs" Inherits="Smart_Inventory_and_Sales_Analytics_Web_Applications.Profile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="HeadContent" runat="server">
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="row">
        <div class="col-md-4">
            <div class="card shadow text-center p-4 mb-4">
                <div class="mb-3">
                    <i class="fas fa-user-circle text-secondary" style="font-size: 80px;"></i>
                </div>
                <h4><asp:Label ID="lblUsername" runat="server" Text="User"></asp:Label></h4>
                <p class="text-muted">Administrator</p>
                <hr />
                <div class="text-start">
                    <strong><i class="fas fa-calendar-alt me-2"></i> Joined:</strong> 2024<br />
                    <strong><i class="fas fa-shield-alt me-2"></i> Role:</strong> Super Admin
                </div>
            </div>
        </div>

        <div class="col-md-8">
            <div class="card shadow">
                <div class="card-header bg-primary text-white">
                    <h5 class="mb-0"><i class="fas fa-lock me-2"></i> Security Settings</h5>
                </div>
                <div class="card-body">
                    
                    <div class="mb-3">
                        <label>Current Password</label>
                        <asp:TextBox ID="txtOldPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                    </div>
                    
                    <div class="row">
                        <div class="col-md-6 mb-3">
                            <label>New Password</label>
                            <asp:TextBox ID="txtNewPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        </div>
                        <div class="col-md-6 mb-3">
                            <label>Confirm New Password</label>
                            <asp:TextBox ID="txtConfirmPass" runat="server" CssClass="form-control" TextMode="Password"></asp:TextBox>
                        </div>
                    </div>

                    <asp:Button ID="btnUpdate" runat="server" Text="Update Password" 
                        CssClass="btn btn-success" OnClick="btnUpdate_Click" />
                    
                    <br /><br />
                    <asp:Label ID="lblMsg" runat="server" CssClass="fw-bold"></asp:Label>
                </div>
            </div>
        </div>
    </div>
</asp:Content>