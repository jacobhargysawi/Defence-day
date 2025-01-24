<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="PatientReport.aspx.cs" Inherits="HospitalManagementSystem.PatientReport" %>

<!DOCTYPE html>
<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title>Patient Report</title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />
    <style>
        .report-container {
            margin-top: 50px;
            background-color: #f9f9f9;
            padding: 20px;
            border-radius: 8px;
            box-shadow: 0 0 10px rgba(0, 0, 0, 0.1);
        }
        .report-header {
            border-bottom: 2px solid #007bff;
            padding-bottom: 10px;
            margin-bottom: 20px;
        }
        .print-button {
            margin-top: 20px;
        }
    </style>
    <script type="text/javascript">
        function printReport() {
            window.print();
        }
    </script>
</head>
<body>
    <form id="form1" runat="server">
        <div class="container report-container">
            <div class="report-header">
                <h2>Patient Report</h2>
            </div>
            <asp:GridView ID="gvPatientReport" runat="server" AutoGenerateColumns="False" CssClass="table table-striped">
                <Columns>
                    <asp:BoundField DataField="PatientName" HeaderText="Patient Name" />
                    <asp:BoundField DataField="Gender" HeaderText="Gender" />
                    <asp:BoundField DataField="Age" HeaderText="Age" />
                    <asp:BoundField DataField="Contact" HeaderText="Contact" />
                    <asp:BoundField DataField="DoctorName" HeaderText="Doctor Name" />
                    <asp:BoundField DataField="Specialty" HeaderText="Specialty" />
                    <asp:BoundField DataField="MedicationName" HeaderText="Medication Name" />
                    <asp:BoundField DataField="Dosage" HeaderText="Dosage" />
                    <asp:BoundField DataField="Instructions" HeaderText="Instructions" />
                    <asp:BoundField DataField="Price" HeaderText="Price" DataFormatString="{0:C}" />
                </Columns>
            </asp:GridView>
            <asp:Button ID="btnPrint" runat="server" Text="Print Report" CssClass="btn btn-primary print-button" OnClientClick="printReport(); return false;" />
        </div>
    </form>
</body>
</html>
