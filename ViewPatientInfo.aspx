<%@ Page Title="View Patient Information" Language="C#" MasterPageFile="~/DoctorMaster.master" AutoEventWireup="true" CodeBehind="ViewPatientInfo.aspx.cs" Inherits="HospitalManagementSystem.ViewPatientInfo" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Patient Information</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-primary font-weight-bold" Text="" />
        <div class="form-group mb-3">
            <label for="txtPatientName" class="form-label">Patient Name</label>
            <asp:TextBox ID="txtPatientName" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtGender" class="form-label">Gender</label>
            <asp:TextBox ID="txtGender" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtAge" class="form-label">Age</label>
            <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtContact" class="form-label">Contact</label>
            <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtDoctorName" class="form-label">Doctor Name</label>
            <asp:TextBox ID="txtDoctorName" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtSpecialty" class="form-label">Specialty</label>
            <asp:TextBox ID="txtSpecialty" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="ddlMedications" class="form-label">Medications</label>
            <asp:DropDownList ID="ddlMedications" runat="server" CssClass="form-control" AutoPostBack="True" OnSelectedIndexChanged="ddlMedications_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="form-group mb-3">
            <label for="txtDosage" class="form-label">Dosage</label>
            <asp:TextBox ID="txtDosage" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtInstructions" class="form-label">Instructions</label>
            <asp:TextBox ID="txtInstructions" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtPrice" class="form-label">Price</label>
            <asp:TextBox ID="txtPrice" runat="server" CssClass="form-control" ReadOnly="True"></asp:TextBox>
        </div>
        <div class="d-grid mb-3">
            <asp:Button ID="btnPrescribeMedication" runat="server" CssClass="btn btn-primary btn-block" Text="Prescribe Medication" OnClick="btnPrescribeMedication_Click" />
        </div>
    </div>
</asp:Content>
