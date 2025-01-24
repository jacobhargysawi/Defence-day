<%@ Page Title="Manage Users" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="ManageUsers.aspx.cs" Inherits="HospitalManagementSystem.ManageUsers" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Manage Users</h2>
        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Placeholder="Enter username to search" />
        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary mt-2" Text="Search" OnClick="btnSearch_Click" />
        <asp:GridView ID="gvUsers" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" DataKeyNames="UserID" OnRowEditing="gvUsers_RowEditing" OnRowUpdating="gvUsers_RowUpdating" OnRowCancelingEdit="gvUsers_RowCancelingEdit" OnRowDeleting="gvUsers_RowDeleting">
            <Columns>
                <asp:BoundField DataField="UserID" HeaderText="ID" ReadOnly="True" />
                <asp:TemplateField HeaderText="Username">
                    <ItemTemplate>
                        <%# Eval("Username") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtUsername" runat="server" Text='<%# Bind("Username") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Full Name">
                    <ItemTemplate>
                        <%# Eval("FullName") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtFullName" runat="server" Text='<%# Bind("FullName") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Email">
                    <ItemTemplate>
                        <%# Eval("Email") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtEmail" runat="server" Text='<%# Bind("Email") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contact Number">
                    <ItemTemplate>
                        <%# Eval("ContactNumber") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtContactNumber" runat="server" Text='<%# Bind("ContactNumber") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:BoundField DataField="RoleName" HeaderText="Role" />
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnCreateUser" runat="server" CssClass="btn btn-primary mt-3" Text="Create New User" OnClick="btnCreateUser_Click" />
    </div>
</asp:Content>
