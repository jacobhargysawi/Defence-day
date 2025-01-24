<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Home.aspx.cs" Inherits="HospitalManagementSystem.Home" %>

<!DOCTYPE html>
<html lang="en">
<head runat="server">
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Home - Hospital Management System</title>
    <link rel="stylesheet" type="text/css" href="~/Content/bootstrap.min.css" />
    <link rel="stylesheet" type="text/css" href="~/Styles/Site.css" />
    <style>
        body, html {
            height: 100%;
            margin: 0;
            overflow: auto; /* Enable scrolling */
            display: flex;
            flex-direction: column;
        }

        .video-background {
            position: fixed;
            right: 0;
            bottom: 0;
            min-width: 100%;
            min-height: 100%;
            z-index: -1;
        }

        .content {
            position: relative;
            z-index: 1;
            color: white;
            text-align: center;
            flex: 1;
            padding-top: 15%;
        }

        footer {
            position: absolute;
            bottom: 0;
            width: 100%;
            background-color: rgba(0, 0, 0, 0.05);
            color: black;
            padding: 10px 0;
            text-align: center;
        }
    </style>
</head>

<body>
    <form id="form1" runat="server">
        <video autoplay muted loop class="video-background">
            <source src="Hospital.mp4" type="video/mp4">
            Your browser does not support the video tag.
        </video>

        <header>
            <nav class="navbar navbar-expand-lg navbar-light bg-light fixed-top">
                <div class="container-fluid">
                    <a class="navbar-brand" href="default.aspx">Hospital Management</a>
                    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarNav" aria-controls="navbarNav" aria-expanded="false" aria-label="Toggle navigation">
                        <span class="navbar-toggler-icon"></span>
                    </button>
                    <div class="collapse navbar-collapse" id="navbarNav">
                        <ul class="navbar-nav me-auto mb-2 mb-lg-0">
                            <li class="nav-item">
                                <a class="nav-link" href="Register.aspx">Register</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Login.aspx">Login</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="About.aspx">About</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Home.aspx">Home</a>
                            </li>
                            <li class="nav-item">
                                <a class="nav-link" href="Contact.aspx">Contact</a>
                            </li>
                        </ul>
                    </div>
                </div>
            </nav>
        </header>

        <main class="container content">
            <div class="text-center">
                <h1 class="mb-3">Welcome to Hospital Management System</h1>
                <h4 class="mb-4">Efficient, Reliable, and Comprehensive</h4>
                <div class="btn-group" role="group" aria-label="User Role Selection">
                    <asp:Button ID="btnAdmin" runat="server" CssClass="btn btn-primary" Text="Continue as Admin" PostBackUrl="~/Login.aspx?role=admin" />
                    <asp:Button ID="btnDoctor" runat="server" CssClass="btn btn-secondary" Text="Continue as Doctor" PostBackUrl="~/Login_doctor.aspx?role=doctor" />
                    <asp:Button ID="btnPatient" runat="server" CssClass="btn btn-success" Text="Continue as Patient" PostBackUrl="~/Login_patient.aspx?role=patient" />
                    <asp:Button ID="btnStaff" runat="server" CssClass="btn btn-info" Text="Continue as Staff" PostBackUrl="~/Login.aspx?role=staff" />
                </div>
            </div>
        </main>

        <footer class="bg-light text-center text-lg-start mt-5">
            <div class="text-center p-3" style="background-color: rgba(0, 0, 0, 0.05);">
                © <%= DateTime.Now.Year %> Hospital Management System. All rights reserved.
            </div>
        </footer>
    </form>
    
    <script src="Scripts/bootstrap.bundle.min.js"></script>
</body>
</html>
