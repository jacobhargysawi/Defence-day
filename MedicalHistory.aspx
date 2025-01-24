<%@ Page Title="Medical History" Language="C#" MasterPageFile="~/PatientMaster.master" AutoEventWireup="true" CodeBehind="MedicalHistory.aspx.cs" Inherits="HospitalManagementSystem.MedicalHistory" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server"></asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="ContentPlaceHolder1" runat="server">
    <div class="container mt-5">
        <div class="row">
            <div class="col">
                <div class="card shadow-sm">
                    <div class="card-body">
                        <h2 class="card-title text-center">Medical History</h2>
                        <asp:Label ID="lblMessage" runat="server" CssClass="text-primary font-weight-bold" Text="" />
                        <asp:GridView ID="gvMedicalHistory" runat="server" CssClass="table table-striped">
                            <Columns>
                                <asp:BoundField DataField="AppointmentDate" HeaderText="Appointment Date" DataFormatString="{0:yyyy-MM-dd}" />
                                <asp:BoundField DataField="DoctorName" HeaderText="Doctor Name" />
                                <asp:BoundField DataField="MedicationName" HeaderText="Medication" />
                                <asp:BoundField DataField="Dosage" HeaderText="Dosage" />
                                <asp:BoundField DataField="Instructions" HeaderText="Instructions" />
                                <asp:BoundField DataField="PrescriptionStatus" HeaderText="Status" />
                            </Columns>
                        </asp:GridView>
                    </div>
                </div>
            </div>
        </div>
    </div>
</asp:Content>
