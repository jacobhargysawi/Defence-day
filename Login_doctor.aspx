<%@ Page Title="Doctor Login" Language="C#" MasterPageFile="~/DoctorMaster.master" AutoEventWireup="true" CodeBehind="Login_doctor.aspx.cs" Inherits="HospitalManagementSystem.Login_doctor" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row justify-content-center">
            <div class="col-md-6">
                <div class="card shadow-lg">
                    <div class="card-header bg-gradient-primary text-white text-center">
                        <h2>Doctor Login</h2>
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
                        <div class="d-grid mb-3">
                            <asp:Button ID="btnLogin" runat="server" CssClass="btn btn-primary btn-block" Text="Login" OnClick="btnLogin_Click" />
                        </div>
                        <div class="d-flex justify-content-between">
                            <a href="ChangePassword.aspx" class="text-primary">Forgot Password?</a>
                            <a href="Register.aspx" class="text-primary">Create an Account</a>
                        </div>
                    </div>
                    <div class="card-footer text-center">
                        <small>© <%: DateTime.Now.Year %> Hospital Management System. All rights reserved.</small>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
