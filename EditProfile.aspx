<%@ Page Title="Edit User Profile" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="EditUserProfile.aspx.cs" Inherits="HospitalManagementSystem.EditUserProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Additional head content if needed -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Edit User Profile</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Text=""></asp:Label>
        <div class="form-group mb-3">
            <label for="txtFullName" class="form-label">Full Name</label>
            <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" Placeholder="Enter full name"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Enter email"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtContactNumber" class="form-label">Contact Number</label>
            <asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control" Placeholder="Enter contact number"></asp:TextBox>
        </div>
        <div class="d-grid mb-3">
            <asp:Button ID="btnSaveChanges" runat="server" CssClass="btn btn-primary btn-block" Text="Save Changes" OnClick="btnSaveChanges_Click" />
        </div>
    </div>
</asp:Content>
