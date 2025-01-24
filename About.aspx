<%@ Page Title="About" Language="C#" MasterPageFile="~/Site1.master" AutoEventWireup="true" CodeBehind="About.aspx.cs" Inherits="HospitalManagementSystem.About" %>

<asp:Content ID="Content1" ContentPlaceHolderID="head" runat="server">
    <style>
        /* Reset margin and padding */
        * {
            margin: 0;
            padding: 0;
            box-sizing: border-box;
        }

        /* Base styling for body */
        body {
            font-family: Arial, sans-serif;
            line-height: 1.6;
        }

        /* Container for the main content */
        .container {
            max-width: 1200px;
            margin: 0 auto;
            padding: 20px;
        }

        /* About Section styling */
        .about-section {
            display: flex;
            flex-direction: column;
            justify-content: center;
            align-items: center;
            padding: 40px 20px;
            text-align: center;
            transition: transform 0.3s ease;
        }

        .about-section:hover {
            transform: scale(1.05);
        }

        .about-section h1 {
            font-size: 2.5rem;
            margin-bottom: 20px;
            color: #0066cc;
            transition: color 0.3s ease;
        }

        .about-section h1:hover {
            color: #003366;
        }

        .about-section p {
            max-width: 800px;
            margin-bottom: 30px;
        }

        /* Features Section styling */
        .features-section {
            padding: 20px;
            text-align: center;
            transition: transform 0.3s ease;
        }

        .features-section:hover {
            transform: scale(1.05);
        }

        .features-section h3 {
            font-size: 2rem;
            margin-bottom: 20px;
            color: #0066cc;
            transition: color 0.3s ease;
        }

        .features-section h3:hover {
            color: #003366;
        }

        .features-section ul {
            list-style: none;
            padding-left: 0;
        }

        .features-section ul li {
            background: #f4f4f4;
            margin-bottom: 10px;
            padding: 10px;
            border-radius: 5px;
            transition: background 0.3s ease;
        }

        .features-section ul li:hover {
            background: #e0e0e0;
        }

        /* Team section styling */
        .team {
            display: flex;
            justify-content: space-around;
            align-items: center;
            flex-wrap: wrap;
            padding: 20px;
            text-align: center;
            transition: transform 0.3s ease;
        }

        .team:hover {
            transform: scale(1.05);
        }

        .team-row {
            display: flex;
            justify-content: space-around;
            width: 100%;
            margin-bottom: 20px;
        }

        .team-member {
            background-color: #f4f4f4;
            padding: 20px;
            margin: 10px;
            border-radius: 8px;
            text-align: center;
            width: 250px;
            transition: transform 0.3s ease, background 0.3s ease;
        }

        .team-member:hover {
            transform: scale(1.05);
            background-color: #e0e0e0;
        }

        .team-member img {
            border-radius: 50%;
            width: 150px;
            height: 150px;
            object-fit: cover;
            margin-bottom: 15px;
        }

        .team-member h3 {
            margin-bottom: 10px;
            font-size: 1.5rem;
            color: #0066cc;
            transition: color 0.3s ease;
        }

        .team-member h3:hover {
            color: #003366;
        }

        .team-member p {
            font-size: 1rem;
            color: #777;
        }

        /* Contact Section styling */
        .contact-section {
            padding: 20px;
            text-align: center;
            transition: transform 0.3s ease;
        }

        .contact-section:hover {
            transform: scale(1.05);
        }

        .contact-section h3 {
            font-size: 2rem;
            margin-bottom: 20px;
            color: #0066cc;
            transition: color 0.3s ease;
        }

        .contact-section h3:hover {
            color: #003366;
        }

        .contact-section p {
            font-size: 1rem;
            color: #555;
        }
    </style>
</asp:Content>

<asp:Content ID="Content2" ContentPlaceHolderID="MainContent" runat="server">
    <div class="container mt-5">
        <section class="about-section">
            <h1>Who We Are</h1>
            <p>Welcome to the Hospital Management System (HMS). Our system is designed to streamline and enhance the management of hospital operations, ensuring efficient service delivery to patients.</p>
            <p>Our mission is to provide a comprehensive solution for managing hospital activities, from patient registration to billing, to improve the overall healthcare experience.</p>
        </section>

        <section class="features-section">
            <h3>Features</h3>
            <ul>
                <li>Patient Registration and Management</li>
                <li>Appointment Scheduling</li>
                <li>Doctor and Staff Management</li>
                <li>Medical Records and Prescriptions</li>
                <li>Billing and Payments</li>
                <li>Reports and Analytics</li>
            </ul>
        </section>

        <h3 style="text-align: center; color: #0066cc; transition: color 0.3s ease;" onmouseover="this.style.color='#003366'" onmouseout="this.style.color='#0066cc'">Our Team</h3>
        <section class="team">
            <div class="team-row">
                <div class="team-member">
                    <img src="JACOB.jpg" alt="Team Member 1">
                    <h3>King Abdirahiim</h3>
                    <p>CEO & Founder</p>
                    <p>The owner who has a degree in software engineering from Meta Company and Abaarso University.</p>
                </div>
                <div class="team-member">
                    <img src="sample.jpg" alt="Team Member 4">
                    <h3>Emily White</h3>
                    <p>Marketing</p>
                    <p>Professional marketer af miishaar from Amazon.</p>
                </div>
                <div class="team-member">
                    <img src="image2.jpg" alt="Team Member 2">
                    <h3>Jane Smith</h3>
                    <p>Lead Developer</p>
                    <p>from Meta Company.</p>
                </div>
            </div>

            <div class="team-row">
                <div class="team-member">
                    <img src="JACOB.jpg" alt="Team Member 1">
                    <h3>King Abdirahiim</h3>
                    <p>CEO & Founder</p>
                    <p>The owner who has a degree in software engineering from Meta Company and Abaarso University.</p>
                </div>
                <div class="team-member">
                    <img src="sample.jpg" alt="Team Member 4">
                    <h3>Emily White</h3>
                    <p>Marketing</p>
                    <p>Professional marketer af miishaar from Amazon.</p>
                </div>
                <div class="team-member">
                    <img src="image2.jpg" alt="Team Member 2">
                    <h3>Jane Smith</h3>
                    <p>Lead Developer</p>
                    <p>from Meta Company.</p>
                </div>
            </div>
        </section>

        <section class="contact-section">
            <h3>Contact Us This number +252633570744</h3>
            <p>If you have any questions or need support, please contact us at <a href="https://bulaale1.com/">we will support @bulaale1.com</a>.</p>
        </section>
    </div>
</asp:Content>
