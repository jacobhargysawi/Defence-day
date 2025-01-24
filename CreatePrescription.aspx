<%@ Page Title="Create Prescription" Language="C#" MasterPageFile="~/DoctorMaster.master" AutoEventWireup="true" CodeBehind="CreatePrescription.aspx.cs" Inherits="HospitalManagementSystem.CreatePrescription" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Create Prescription</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Text=""></asp:Label>
        <asp:HiddenField ID="hfAppointmentID" runat="server" />
        <div class="form-group mb-3">
            <label for="txtMedication" class="form-label">Medication</label>
            <asp:TextBox ID="txtMedication" runat="server" CssClass="form-control"></asp:TextBox>
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
            <asp:Button ID="btnCreatePrescription" runat="server" CssClass="btn btn-primary btn-block" Text="Create Prescription" OnClick="btnCreatePrescription_Click" />
        </div>
    </div>
</asp:Content>
