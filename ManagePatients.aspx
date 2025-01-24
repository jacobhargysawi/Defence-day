<%@ Page Title="Manage Patients" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="ManagePatients.aspx.cs" Inherits="HospitalManagementSystem.ManagePatients" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <h2>Manage Patients</h2>
        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Placeholder="Enter patient name to search" />
        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary mt-2" Text="Search" OnClick="btnSearch_Click" />
        <asp:GridView ID="gvPatients" runat="server" AutoGenerateColumns="False" CssClass="table table-striped" DataKeyNames="PatientID" OnRowEditing="gvPatients_RowEditing" OnRowUpdating="gvPatients_RowUpdating" OnRowCancelingEdit="gvPatients_RowCancelingEdit" OnRowDeleting="gvPatients_RowDeleting">
            <Columns>
                <asp:BoundField DataField="PatientID" HeaderText="ID" ReadOnly="True" />
                <asp:TemplateField HeaderText="Name">
                    <ItemTemplate>
                        <%# Eval("Name") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtName" runat="server" Text='<%# Bind("Name") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Age">
                    <ItemTemplate>
                        <%# Eval("Age") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAge" runat="server" Text='<%# Bind("Age") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Gender">
                    <ItemTemplate>
                        <%# Eval("Gender") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtGender" runat="server" Text='<%# Bind("Gender") %>' CssClass="form-control"></asp:TextBox>
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
                <asp:TemplateField HeaderText="Address">
                    <ItemTemplate>
                        <%# Eval("Address") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtAddress" runat="server" Text='<%# Bind("Address") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:TemplateField HeaderText="Medical History">
                    <ItemTemplate>
                        <%# Eval("MedicalHistory") %>
                    </ItemTemplate>
                    <EditItemTemplate>
                        <asp:TextBox ID="txtMedicalHistory" runat="server" Text='<%# Bind("MedicalHistory") %>' CssClass="form-control"></asp:TextBox>
                    </EditItemTemplate>
                </asp:TemplateField>
                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
            </Columns>
        </asp:GridView>
        <asp:Button ID="btnCreatePatient" runat="server" CssClass="btn btn-primary mt-3" Text="Create New Patient" OnClick="btnCreatePatient_Click" />
    </div>
</asp:Content>
