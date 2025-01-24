<%@ Page Title="Patient Registration" Language="C#" MasterPageFile="~/PatientMaster.master" AutoEventWireup="true" CodeBehind="RegisterPatient.aspx.cs" Inherits="HospitalManagementSystem.RegisterPatient" %>

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
                            <label for="txtName" class="form-label">Name</label>
                            <asp:TextBox ID="txtName" runat="server" CssClass="form-control" Placeholder="Enter your name"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label for="txtAge" class="form-label">Age</label>
                            <asp:TextBox ID="txtAge" runat="server" CssClass="form-control" Placeholder="Enter your age"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label for="txtGender" class="form-label">Gender</label>
                            <asp:TextBox ID="txtGender" runat="server" CssClass="form-control" Placeholder="Enter your gender"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label for="txtContact" class="form-label">Contact</label>
                            <asp:TextBox ID="txtContact" runat="server" CssClass="form-control" Placeholder="Enter your contact number"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label for="txtEmail" class="form-label">Email</label>
                            <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control" Placeholder="Enter your email"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label for="txtAddress" class="form-label">Address</label>
                            <asp:TextBox ID="txtAddress" runat="server" CssClass="form-control" Placeholder="Enter your address"></asp:TextBox>
                        </div>
                        <div class="form-group mb-3">
                            <label for="txtMedicalHistory" class="form-label">Medical History</label>
                            <asp:TextBox ID="txtMedicalHistory" runat="server" CssClass="form-control" TextMode="MultiLine" Placeholder="Enter your medical history"></asp:TextBox>
                        </div>
                        <div class="d-grid">
                            <asp:Button ID="btnRegister" runat="server" CssClass="btn btn-primary btn-block" Text="Continue Next" OnClick="btnRegister_Click" />
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
