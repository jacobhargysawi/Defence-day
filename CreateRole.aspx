<%@ Page Title="Create Role" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="CreateRole.aspx.cs" Inherits="HospitalManagementSystem.CreateRole" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Create New Role</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Text=""></asp:Label>
        <div class="form-group mb-3">
            <label for="txtRoleName" class="form-label">Role Name</label>
            <asp:TextBox ID="txtRoleName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="d-grid mb-3">
            <asp:Button ID="btnSaveRole" runat="server" CssClass="btn btn-primary btn-block" Text="Save Role" OnClick="btnSaveRole_Click" />
        </div>
    </div>
</asp:Content>
