﻿using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class Login_patient : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; Database=HospitalManagementSystem; Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = string.Empty;
            }
        }

        protected void btnLogin_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string password = txtPassword.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
                {
                    lblMessage.Text = "Please fill in both username and password.";
                    return;
                }

                // Query to check user credentials for patients
                string query = "SELECT UserTypeID, UserID FROM Users WHERE Username = @Username AND PasswordHash = @PasswordHash AND UserTypeID = 4";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@PasswordHash", password);

                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    int userTypeID = (int)reader["UserTypeID"];
                    int userID = (int)reader["UserID"];
                    if (userTypeID == 4)
                    {
                        Session["UserID"] = userID;
                        Response.Redirect("PatientDashboard.aspx");
                    }
                }
                else
                {
                    lblMessage.Text = "Invalid username or password.";
                }
                reader.Close();
            }
            catch (SqlException sqlEx)
            {
                lblMessage.Text = "Database Error: " + sqlEx.Message;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
