<%@ Page Title="Contact Us" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="Contact.aspx.cs" Inherits="HospitalManagementSystem.Contact" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <!-- Additional head content if needed -->
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card shadow-lg">
                    <div class="card-header bg-gradient-primary text-white text-center">
                        <h2>Contact Us</h2>
                    </div>
                    <div class="card-body">
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Text=""></asp:Label>
                        <div class="form-group mb-3">
                            <label for="txtName" class="form-label">Name</label>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Placeholder="Enter your name"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label for="txtEmail" class="form-label">Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Enter your email"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label for="txtWebsite" class="form-label">Website (optional)</label>
                            <asp:TextBox ID="txtWebsite" runat="server" CssClass="form-control" Placeholder="Enter your website"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label for="txtComment" class="form-label">Comment</label>
                            <asp:TextBox ID="txtComment" runat="server" CssClass="form-control" TextMode="MultiLine" Rows="5" Placeholder="Enter your comment"></asp:TextBox>
                        </div>
                        <div class="d-grid mb-3">
                            <asp:Button ID="btnSubmit" runat="server" CssClass="btn btn-primary btn-block" Text="Submit" OnClick="btnSubmit_Click" />
                        </div>
                    </div>
                    <div class="card-footer text-center">
                        <small>We appreciate your feedback and will get back to you as soon as possible.</small>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
