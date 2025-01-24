<%@ Page Title="Add New Medication" Language="C#" MasterPageFile="~/DoctorMaster.master" AutoEventWireup="true" CodeBehind="CreateMedication.aspx.cs" Inherits="HospitalManagementSystem.CreateMedication" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Add New Medication</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-primary font-weight-bold" Text="" />
        <div class="form-group mb-3">
            <label for="txtMedicationName" class="form-label">Medication Name</label>
            <asp:TextBox ID="txtMedicationName" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtDosage" class="form-label">Dosage</label>
            <asp:TextBox ID="txtDosage" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtInstructions" class="form-label">Instructions</label>
            <asp:TextBox ID="txtInstructions" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtPrice" class="form-label">Price</label>
            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="d-grid mb-3">
            <asp:Button ID="btnAddMedication" runat="server" CssClass="btn btn-primary btn-block" Text="Add Medication" OnClick="btnAddMedication_Click" />
        </div>
    </div>
</asp:Content>
