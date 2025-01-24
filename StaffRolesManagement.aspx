<%@ Page Title="Staff Roles Management" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="StaffRolesManagement.aspx.cs" Inherits="HospitalManagementSystem.StaffRolesManagement" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Staff Roles Management</h2>
        <asp:GridView ID="gvStaffRoles" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" DataKeyNames="StaffRoleID" OnRowEditing="gvStaffRoles_RowEditing" OnRowUpdating="gvStaffRoles_RowUpdating" OnRowCancelingEdit="gvStaffRoles_RowCancelingEdit" OnRowDeleting="gvStaffRoles_RowDeleting">
            <Columns>
                <asp:BoundField DataField="StaffRoleID" HeaderText="ID" ReadOnly="True" />
                <asp:BoundField DataField="RoleName" HeaderText="Role Name" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnCreateRole" runat="server" CssClass="btn btn-primary mt-3" Text="Create New Role" OnClick="btnCreateRole_Click" />
    </div>
</asp:Content>
