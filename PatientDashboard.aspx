<%@ Page Title="Patient Dashboard" Language="C#" MasterPageFile="~/PatientMaster.master" AutoEventWireup="true" CodeBehind="PatientDashboard.aspx.cs" Inherits="HospitalManagementSystem.PatientDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h2 class="card-title text-center">Patient Dashboard</h2>
                        <asp:Label ID="lblWelcome" runat="server" CssClass="text-primary font-weight-bold" Text="Welcome, Patient!" />
                        <div class="mt-4">
                            <h3>Your Medical History</h3>
                            <a href="MedicalHistory.aspx" class="btn btn-outline-primary btn-block">View Medical History</a>
                        </div>
                        <div class="mt-4">
                            <h3>Your Appointments</h3>
                            <a href="PatientAppointments.aspx" class="btn btn-outline-primary btn-block">View Appointments</a>
                        </div>
                        <div class="mt-4">
                            <h3>Create Appointment</h3>
                            <a href="CreateYourAppointment.aspx" class="btn btn-primary btn-block">Create Appointment</a>
                        </div>
                        <div class="mt-4">
                            <asp:Button ID="btnLogout" runat="server" CssClass="btn btn-danger btn-block" Text="Logout" OnClick="btnLogout_Click" />
                        </div>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
