<%@ Page Title="Manage Medications" Language="C#" MasterPageFile="~/DoctorMaster.master" AutoEventWireup="true" CodeBehind="ManageMedications.aspx.cs" Inherits="HospitalManagementSystem.ManageMedications" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Manage Medications</h2>
        <asp:Label ID="lblMessage" runat="server" CssClass="text-primary font-weight-bold" Text="" />
        <asp:GridView ID="gvMedications" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" DataKeyNames="MedicationID" OnRowEditing="gvMedications_RowEditing" OnRowUpdating="gvMedications_RowUpdating" OnRowCancelingEdit="gvMedications_RowCancelingEdit" OnRowDeleting="gvMedications_RowDeleting">
            <Columns>
                <asp:BoundField DataField="MedicationID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="MedicationName" HeaderText="Medication Name" />
                <asp:BoundField DataField="Dosage" HeaderText="Dosage" />
                <asp:BoundField DataField="Instructions" HeaderText="Instructions" />
                <asp:BoundField DataField="Price" HeaderText="Price" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnCreateMedication" runat="server" CssClass="btn btn-primary mt-3" Text="Add New Medication" OnClick="btnCreateMedication_Click" />
    </div>
</asp:Content>
