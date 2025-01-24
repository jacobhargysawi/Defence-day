<%@ Page Title="Patient Appointments" Language="C#" MasterPageFile="~/PatientMaster.master" AutoEventWireup="true" CodeBehind="PatientAppointments.aspx.cs" Inherits="HospitalManagementSystem.PatientAppointments" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h2 class="card-title text-center">Your Appointments</h2>
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-primary font-weight-bold" Text="" />
                        <asp:GridView ID="gvAppointments" runat="server" CssClass="table table-striped">
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
