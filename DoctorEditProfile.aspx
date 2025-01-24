<%@ Page Title="Doctor Edit Profile" Language="C#" MasterPageFile="~/DoctorMaster.master" AutoEventWireup="true" CodeBehind="DoctorEditProfile.aspx.cs" Inherits="HospitalManagementSystem.DoctorEditProfile" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col-md-8 offset-md-2">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h2 class="card-title text-center">Edit Profile</h2>
                        <form runat="server">
                            <div class="form-group mb-3">
                                <label for="txtName" class="form-label">Full Name</label>
                                <asp:TextBox ID="txtName" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group mb-3">
                                <label for="txtSpecialty" class="form-label">Specialty</label>
                                <asp:TextBox ID="txtSpecialty" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group mb-3">
                                <label for="txtContact" class="form-label">Contact Number</label>
                                <asp:TextBox ID="txtContact" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="form-group mb-3">
                                <label for="txtEmail" class="form-label">Email</label>
                                <asp:TextBox ID="txtEmail" runat="server" CssClass="form-control"></asp:TextBox>
                            </div>
                            <div class="d-grid">
                                <asp:Button ID="btnSave" runat="server" CssClass="btn btn-primary btn-block" Text="Save" OnClick="btnSave_Click" />
                            </div>
                        </form>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
