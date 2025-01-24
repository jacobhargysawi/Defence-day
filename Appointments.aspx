<%@ Page Title="Manage Appointments" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="Appointments.aspx.cs" Inherits="HospitalManagementSystem.Appointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Manage Appointments</h2>
        <asp:GridView ID="gvAppointments" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" DataKeyNames="AppointmentID" OnRowEditing="gvAppointments_RowEditing" OnRowUpdating="gvAppointments_RowUpdating" OnRowCancelingEdit="gvAppointments_RowCancelingEdit" OnRowDeleting="gvAppointments_RowDeleting">
            <Columns>
                <asp:BoundField DataField="AppointmentID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="PatientID" HeaderText="Patient ID" />
                <asp:BoundField DataField="DoctorID" HeaderText="Doctor ID" />
                <asp:BoundField DataField="AppointmentDate" HeaderText="Appointment Date" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnCreateAppointment" runat="server" CssClass="btn btn-primary mt-3" Text="Create New Appointment" OnClick="btnCreateAppointment_Click" />
    </div>
</asp:Content>
