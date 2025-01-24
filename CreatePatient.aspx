<%@ Page Title="Create Patient" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="CreatePatient.aspx.cs" Inherits="HospitalManagementSystem.CreatePatient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Create New Patient</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Text=""></asp:Label>
        <div class="form-group mb-3">
            <label for="txtName" class="form-label">Name</label>
            <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtAge" class="form-label">Age</label>
            <asp:TextBox ID="txtAge" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtGender" class="form-label">Gender</label>
            <asp:TextBox ID="txtGender" runat="server" CssClass="form-control"></asp:TextBox>
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
            <label for="txtAddress" class="form-label">Address</label>
            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtMedicalHistory" class="form-label">Medical History</label>
            <asp:TextBox ID="txtMedicalHistory" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="d-grid mb-3">
            <asp:Button ID="btnSavePatient" runat="server" CssClass="btn btn-primary btn-block" Text="Save Patient" OnClick="btnSavePatient_Click" />
        </div>
    </div>
</asp:Content>
