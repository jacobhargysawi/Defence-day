<%@ Page Title="Admin Dashboard" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="AdminDashboard.aspx.cs" Inherits="HospitalManagementSystem.AdminDashboard" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Additional head content if needed -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h2 class="card-title text-center">Admin Dashboard</h2>
                        <asp:Label ID="lblWelcome" runat="server" CssClass="text-primary font-weight-bold" Text="Welcome, Admin!" />
                        <div class="mt-4">
                            <h3>Manage System</h3>
                            <ul class="list-group list-group-flush">
                                <li class="list-group-item"><a href="ManageDoctors.aspx" class="btn btn-outline-primary btn-block">Manage Doctors</a></li>
                                <li class="list-group-item"><a href="ManagePatients.aspx" class="btn btn-outline-primary btn-block">Manage Patients</a></li>
                                <li class="list-group-item"><a href="ManageStaff.aspx" class="btn btn-outline-primary btn-block">Manage Staff</a></li>
                                <li class="list-group-item"><a href="StaffRolesManagement.aspx" class="btn btn-outline-primary btn-block">Staff Roles Management</a></li>
                                <li class="list-group-item"><a href="Appointments.aspx" class="btn btn-outline-primary btn-block">Manage Appointments</a></li>
                                <li class="list-group-item"><a href="Reports.aspx" class="btn btn-outline-primary btn-block">Generate Reports</a></li>
                                <li class="list-group-item"><a href="ManageUsers.aspx" class="btn btn-outline-primary btn-block">Manage Users</a></li> <!-- New Button for Manage Users -->
                                <li class="list-group-item"><a href="ViewContacts.aspx" class="btn btn-outline-primary btn-block">View Contacts</a></li>
                                <li class="list-group-item"><a href="ManageAppointments.aspx" class="btn btn-outline-primary btn-block">Manage appoitment</a></li>
                                <li class="list-group-item"><a href=" ViewPatientInfoList.aspx" class="btn btn-outline-primary btn-block">view patient info list</a></li>

                               

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
