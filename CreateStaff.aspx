<%@ Page Title="Create Staff" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="CreateStaff.aspx.cs" Inherits="HospitalManagementSystem.CreateStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Create New Staff</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Text=""></asp:Label>
        <div class="form-group mb-3">
            <label for="txtFullName" class="form-label">Full Name</label>
            <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtRole" class="form-label">Role</label>
            <asp:TextBox ID="txtRole" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtContact" class="form-label">Contact</label>
            <asp:TextBox ID="txtContact" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="d-grid mb-3">
            <asp:Button ID="btnSaveStaff" runat="server" CssClass="btn btn-primary btn-block" Text="Save Staff" OnClick="btnSaveStaff_Click" />
        </div>
    </div>
</asp:Content>
