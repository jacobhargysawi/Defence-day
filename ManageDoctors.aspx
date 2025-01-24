<%@ Page Title="Manage Doctors" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="ManageDoctors.aspx.cs" Inherits="HospitalManagementSystem.ManageDoctors" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Manage Doctors</h2>
        <asp:GridView ID="gvDoctors" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" DataKeyNames="DoctorID" OnRowEditing="gvDoctors_RowEditing" OnRowUpdating="gvDoctors_RowUpdating" OnRowCancelingEdit="gvDoctors_RowCancelingEdit" OnRowDeleting="gvDoctors_RowDeleting">
            <Columns>
                <asp:BoundField DataField="DoctorID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="Name" HeaderText="Name" />
                <asp:BoundField DataField="Specialty" HeaderText="Specialty" />
                <asp:BoundField DataField="Contact" HeaderText="Contact" />
                <asp:BoundField DataField="Email" HeaderText="Email" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnCreateDoctor" runat="server" CssClass="btn btn-primary mt-3" Text="Create New Doctor" OnClick="btnCreateDoctor_Click" />
    </div>
</asp:Content>
