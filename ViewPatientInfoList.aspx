<%@ Page Title="View Patient Info List" Language="C#" MasterPageFile="~/DoctorMaster.master" AutoEventWireup="true" CodeBehind="ViewPatientInfoList.aspx.cs" Inherits="HospitalManagementSystem.ViewPatientInfoList" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>
<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <h2>Patient Information List</h2>

        <!-- Search Box and Button -->
        <div class="mb-3">
            <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" placeholder="Search by Patient Name"></asp:TextBox>
            <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary mt-2" Text="Search" OnClick="btnSearch_Click" />
        </div>

        <asp:GridView ID="gvPatientInfo" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" DataKeyNames="PatientInfoID" OnRowCommand="gvPatientInfo_RowCommand">
            <Columns>
                <asp:BoundField DataField="PatientName" HeaderText="Patient Name" />
                <asp:BoundField DataField="Gender" HeaderText="Gender" />
                <asp:BoundField DataField="Age" HeaderText="Age" />
                <asp:BoundField DataField="Contact" HeaderText="Contact" />
                <asp:BoundField DataField="DoctorName" HeaderText="Doctor Name" />
                <asp:BoundField DataField="Specialty" HeaderText="Specialty" />
                <asp:BoundField DataField="MedicationName" HeaderText="Medication Name" />
                <asp:BoundField DataField="Dosage" HeaderText="Dosage" />
                <asp:BoundField DataField="Instructions" HeaderText="Instructions" />
                <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                <asp:ButtonField Text="View Report" CommandName="ViewReport" ButtonType="Button" />
            </Columns>
        </asp:GridView>
    </div>
</asp:Content>
