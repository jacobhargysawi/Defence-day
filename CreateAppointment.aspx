<%@ Page Title="Create Appointment" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="CreateAppointment.aspx.cs" Inherits="HospitalManagementSystem.CreateAppointment" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Create New Appointment</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Text=""></asp:Label>
        <div class="form-group mb-3">
            <label for="ddlPatientName" class="form-label">Patient Name</label>
            <asp:DropDownList ID="ddlPatientName" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlPatientName_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="form-group mb-3">
            <label for="txtPatientID" class="form-label">Patient ID</label>
            <asp:TextBox ID="txtPatientID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="ddlDoctorName" class="form-label">Doctor Name</label>
            <asp:DropDownList ID="ddlDoctorName" runat="server" CssClass="form-control" AutoPostBack="true" OnSelectedIndexChanged="ddlDoctorName_SelectedIndexChanged"></asp:DropDownList>
        </div>
        <div class="form-group mb-3">
            <label for="txtDoctorID" class="form-label">Doctor ID</label>
            <asp:TextBox ID="txtDoctorID" runat="server" CssClass="form-control" ReadOnly="true"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtAppointmentDate" class="form-label">Appointment Date</label>
            <asp:TextBox ID="txtAppointmentDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtStatus" class="form-label">Status</label>
            <asp:TextBox ID="txtStatus" runat="server" CssClass="form-control"></asp:TextBox>
        </div>
        <div class="d-grid mb-3">
            <asp:Button ID="btnSaveAppointment" runat="server" CssClass="btn btn-primary btn-block" Text="Save Appointment" OnClick="btnSaveAppointment_Click" />
        </div>
    </div>
</asp:Content>
