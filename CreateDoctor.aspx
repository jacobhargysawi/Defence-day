<%@ Page Title="Create Doctor" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="CreateDoctor.aspx.cs" Inherits="HospitalManagementSystem.CreateDoctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Create New Doctor</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Text=""></asp:Label>
        <div class="form-group mb-3">
            <label for="txtName" class="form-label">Name</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtSpecialty" class="form-label">Specialty</label>
            <asp:TextBox ID="txtSpecialty" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtContact" class="form-label">Contact</label>
            <asp:TextBox ID="txtContact" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtEmail" class="form-label">Email</label>
            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtAvailableFrom" class="form-label">Available From</label>
            <asp:TextBox ID="txtAvailableFrom" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtAvailableTo" class="form-label">Available To</label>
            <asp:TextBox ID="txtAvailableTo" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="d-grid mb-3">
            <asp:Button ID="btnSaveDoctor" runat="server" CssClass="btn btn-primary btn-block" Text="Save Doctor" OnClick="btnSaveDoctor_Click" />
        </div>
    </div>
</asp:Content>
