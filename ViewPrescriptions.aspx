<%@ Page Title="View Prescriptions" Language="C#" MasterPageFile="~/DoctorMaster.master" AutoEventWireup="true" CodeBehind="ViewPrescriptions.aspx.cs" Inherits="HospitalManagementSystem.ViewPrescriptions" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h2 class="card-title text-center">View Prescriptions</h2>
                        <asp:GridView ID="gvPrescriptions" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                            <Columns>
                                <asp:BoundField DataField="PrescriptionID" HeaderText="ID" />
                                <asp:BoundField DataField="Medication" HeaderText="Medication" />
                                <asp:BoundField DataField="Dosage" HeaderText="Dosage" />
                                <asp:BoundField DataField="Instructions" HeaderText="Instructions" />
                                <asp:BoundField DataField="PrescriptionStatus" HeaderText="Status" />
                                <asp:CommandField ShowEditButton="True" ShowDeleteButton="True" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
