<%@ Page Title="Generate Reports" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="Reports.aspx.cs" Inherits="HospitalManagementSystem.Reports" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Generate Reports</h2>
        <div class="form-group mb-3">
            <label for="ddlReportType" class="form-label">Select Report Type</label>
            <asp:DropDownList ID="ddlReportType" runat="server" CssClass="form-control">
                <asp:ListItem Text="Select Report" Value=""></asp:ListItem>
                <asp:ListItem Text="Appointments" Value="Appointments"></asp:ListItem>
                <asp:ListItem Text="Patients" Value="Patients"></asp:ListItem>
                <asp:ListItem Text="Doctors" Value="Doctors"></asp:ListItem>
                <asp:ListItem Text="Staff" Value="Staff"></asp:ListItem>
            </asp:DropDownList>
        </div>
        <div class="form-group mb-3">
            <label for="txtStartDate" class="form-label">Start Date</label>
            <asp:TextBox ID="txtStartDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
        <div class="form-group mb-3">
            <label for="txtEndDate" class="form-label">End Date</label>
            <asp:TextBox ID="txtEndDate" runat="server" CssClass="form-control" TextMode="Date"></asp:TextBox>
        </div>
        <asp:Button ID="btnGenerateReportByDate" runat="server" CssClass="btn btn-primary mb-3" Text="Generate Report by Date" OnClick="btnGenerateReportByDate_Click" />
        <asp:Button ID="btnGenerateReport" runat="server" CssClass="btn btn-secondary mb-3" Text="Generate Report" OnClick="btnGenerateReport_Click" />
        <asp:GridView ID="gvReport" runat="server" AutoGenerateColumns="True" CssClass="table table-striped"></asp:GridView>
    </div>
</asp:Content>
