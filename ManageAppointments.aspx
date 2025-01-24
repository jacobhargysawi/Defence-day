<%@ Page Title="Manage Appointments" Language="C#" MasterPageFile="~/DoctorMaster.master" AutoEventWireup="true" CodeBehind="ManageAppointments.aspx.cs" Inherits="HospitalManagementSystem.ManageAppointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Manage Appointments</h2>
        <asp:GridView ID="gvAppointments" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" 
            DataKeyNames="AppointmentID" OnRowEditing="gvAppointments_RowEditing" 
            OnRowUpdating="gvAppointments_RowUpdating" OnRowCancelingEdit="gvAppointments_RowCancelingEdit" 
            OnRowDeleting="gvAppointments_RowDeleting" OnRowCommand="gvAppointments_RowCommand">
            <Columns>
                <asp:BoundField DataField="AppointmentID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="PatientName" HeaderText="Patient Name" />
                <asp:BoundField DataField="DoctorName" HeaderText="Doctor Name" />
                <asp:BoundField DataField="AppointmentDate" HeaderText="Appointment Date" DataFormatString="{0:yyyy-MM-dd HH:mm:ss}" />
                <asp:BoundField DataField="Status" HeaderText="Status" />
                <asp:TemplateField HeaderText="Actions">
                    <ItemTemplate>
                        <asp:Button ID="btnViewPatient" runat="server" Text="Give Him medication" 
                            CommandName="ViewPatient" CommandArgument='<%# Eval("AppointmentID") %>' 
                            CssClass="btn btn-secondary btn-sm" />
                    </ItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnCreateAppointment" runat="server" CssClass="btn btn-success mt-3" Text="Create New Appointment" 
            OnClick="btnCreateAppointment_Click" />
    </div>
</asp:Content>
