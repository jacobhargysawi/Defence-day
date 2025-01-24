<%@ Page Title="Change Password" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="ChangePassword.aspx.cs" Inherits="HospitalManagementSystem.ChangePassword" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Additional head content if needed -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow-lg">
                    <div class="card-header bg-gradient-primary text-white text-center">
                        <h2>Change Password</h2>
                    </div>
                    <div class="card-body">
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Text=""></asp:Label>
                        <div class="form-group mb-3">
                            <label for="txtCurrentPassword" class="form-label">Current Password</label>
                            <asp:TextBox ID="txtCurrentPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Enter current password"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label for="txtNewPassword" class="form-label">New Password</label>
                            <asp:TextBox ID="txtNewPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Enter new password"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label for="txtConfirmNewPassword" class="form-label">Confirm New Password</label>
                            <asp:TextBox ID="txtConfirmNewPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Confirm new password"></asp:TextBox>
                        </div>
                        <div class="d-grid mb-3">
                            <asp:Button ID="btnChangePassword" runat="server" CssClass="btn btn-primary btn-block" Text="Change Password" OnClick="btnChangePassword_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
