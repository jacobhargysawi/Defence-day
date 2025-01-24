<%@ Page Title="Manage Staff" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="ManageStaff.aspx.cs" Inherits="HospitalManagementSystem.ManageStaff" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Manage Staff</h2>
        <asp:GridView ID="gvStaff" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" DataKeyNames="StaffID" OnRowEditing="gvStaff_RowEditing" OnRowUpdating="gvStaff_RowUpdating" OnRowCancelingEdit="gvStaff_RowCancelingEdit" OnRowDeleting="gvStaff_RowDeleting">
            <Columns>
                <asp:BoundField DataField="StaffID" HeaderText="ID" ReadOnly="True" />
                <asp:TemplateField HeaderText="Full Name">
                    <ItemTemplate>
                        <%# Eval("FullName") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtFullName" runat="server" Text='<%# Bind("FullName") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Role">
                    <ItemTemplate>
                        <%# Eval("Role") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtRole" runat="server" Text='<%# Bind("Role") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Contact">
                    <ItemTemplate>
                        <%# Eval("Contact") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtContact" runat="server" Text='<%# Bind("Contact") %>' CssClass="form-control"></asp:TextBox>
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
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnCreateStaff" runat="server" CssClass="btn btn-primary mt-3" Text="Create New Staff" OnClick="btnCreateStaff_Click" />
    </div>
</asp:Content>
