<%@ Page Title="View Contacts" Language="C#" MasterPageFile="~/AdminMaster.master" AutoEventWireup="true" CodeBehind="ViewContacts.aspx.cs" Inherits="HospitalManagementSystem.ViewContacts" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Additional head content if needed -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h2 class="card-title text-center">Contact Information</h2>
                        <asp:TextBox ID="txtSearch" runat="server" CssClass="form-control" Placeholder="Enter name to search" />
                        <asp:Button ID="btnSearch" runat="server" CssClass="btn btn-primary mt-2" Text="Search" OnClick="btnSearch_Click" />
                        <asp:GridView ID="GridViewContacts" runat="server" AutoGenerateColumns="False" CssClass="table table-bordered" DataKeyNames="ContactID" OnRowDeleting="GridViewContacts_RowDeleting">
                            <Columns>
                                <asp:BoundField DataField="ContactID" HeaderText="ID" />
                                <asp:BoundField DataField="Name" HeaderText="Name" />
                                <asp:BoundField DataField="Email" HeaderText="Email" />
                                <asp:BoundField DataField="Website" HeaderText="Website" />
                                <asp:BoundField DataField="Comment" HeaderText="Comment" />
                                <asp:BoundField DataField="CreatedAt" HeaderText="Created At" DataFormatString="{0:yyyy-MM-dd HH:mm}" />
                                <asp:CommandField ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
