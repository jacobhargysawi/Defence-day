<%@ Page Title="Doctor Dashboard" Language="C#" MasterPageFile="~/DoctorMaster.master" AutoEventWireup="true" CodeBehind="DoctorDashboard.aspx.cs" Inherits="HospitalManagementSystem.DoctorDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h2 class="card-title text-center">Doctor Dashboard</h2>
                        <asp:Label ID="lblWelcome" runat="server" CssClass="text-primary font-weight-bold" Text="Welcome, Doctor!" />
                        <div class="mt-4">
                            <h3>Manage Your Appointments</h3>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item"><a href="ManageAppointments.aspx" class="btn btn-outline-primary btn-block">View Appointments</a></li>
                            </ul>
                        </div>
                        <div class="mt-4">
                            <h3>Medications</h3>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item"><a href="ManageMedications.aspx" class="btn btn-outline-primary btn-block">Manage Medications</a></li>
                            </ul>
                        </div>
                        <div class="mt-4">
                            <h3>Patient Info</h3>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item"><a href="ViewPatientInfoList.aspx" class="btn btn-outline-primary btn-block">View Patient Info</a></li>
                            </ul>
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
