<%@ Page Title="Patient Registration" Language="C#" MasterPageFile="~/PatientMaster.master" AutoEventWireup="true" CodeBehind="Register_patient.aspx.cs" Inherits="HospitalManagementSystem.Register_patient" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-8">
                <div class="card shadow-lg">
                    <div class="card-header bg-gradient-primary text-white text-center">
                        <h2>Patient Registration</h2>
                    </div>
                    <div class="card-body">
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-danger" Text=""></asp:Label>
                        <div class="form-group mb-3">
                            <label for="txtUsername" class="form-label">Username</label>
                            <asp:TextBox ID="txtUsername" runat="server" CssClass="form-control" Placeholder="Enter your username"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label for="txtPassword" class="form-label">Password</label>
                            <asp:TextBox ID="txtPassword" runat="server" CssClass="form-control" TextMode="Password" Placeholder="Enter your password"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label for="txtFullName" class="form-label">Full Name</label>
                            <asp:TextBox ID="txtFullName" runat="server" CssClass="form-control" Placeholder="Enter your full name"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label for="txtEmail" class="form-label">Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Enter your email"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label for="txtContactNumber" class="form-label">Contact Number</label>
                            <asp:TextBox ID="txtContactNumber" runat="server" CssClass="form-control" Placeholder="Enter your contact number"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label for="txtAddress" class="form-label">Address</label>
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Placeholder="Enter your address"></asp:TextBox>
                        </div>
                        <div class="d-grid">
                            <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-primary btn-block" Text="Register" OnClick="btnRegister_Click" />
                        </div>
                    </div>
                    <div class="card-footer text-center">
                        <small>© <%= DateTime.Now.Year %> Hospital Management System. All rights reserved.</small>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
