<%@ Page Title="Manage Prescriptions" Language="C#" MasterPageFile="~/DoctorMaster.master" AutoEventWireup="true" CodeBehind="Prescriptions.aspx.cs" Inherits="HospitalManagementSystem.Prescriptions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Manage Prescriptions</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-primary font-weight-bold" Text="" />
        <asp:GridView ID="gvPrescriptions" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" DataKeyNames="PrescriptionID" OnRowEditing="gvPrescriptions_RowEditing" OnRowUpdating="gvPrescriptions_RowUpdating" OnRowCancelingEdit="gvPrescriptions_RowCancelingEdit" OnRowDeleting="gvPrescriptions_RowDeleting">
            <Columns>
                <asp:BoundField DataField="PrescriptionID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="AppointmentID" HeaderText="Appointment ID" />
                <asp:BoundField DataField="MedicationName" HeaderText="Medication" />
                <asp:BoundField DataField="Dosage" HeaderText="Dosage" />
                <asp:BoundField DataField="Instructions" HeaderText="Instructions" />
                <asp:BoundField DataField="PrescriptionStatus" HeaderText="Status" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnCreatePrescription" runat="server" CssClass="btn btn-primary mt-3" Text="Create New Prescription" OnClick="btnCreatePrescription_Click" />
    </div>
</asp:Content>
