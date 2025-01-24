using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class Register : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; database = HospitalManagementSystem; integrated security = true");

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            if (txtPassword.Text != txtConfirmPassword.Text)
            {
                lblMessage.Text = "Passwords do not match.";
                return;
            }

            string username = txtUsername.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string contactNumber = txtContactNumber.Text.Trim();
            string password = txtPassword.Text.Trim();  // Hash the password in a real implementation

            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contactNumber) || string.IsNullOrEmpty(password))
            {
                lblMessage.Text = "All fields are required.";
                return;
            }

            // Check if the username already exists
            string checkQuery = "SELECT UserID FROM Users WHERE Username = @Username";
            SqlCommand checkCmd = new SqlCommand(checkQuery, con);
            checkCmd.Parameters.AddWithValue("@Username", username);

            con.Open();
            object userId = checkCmd.ExecuteScalar();
            con.Close();

            if (userId != null)
            {
                // Update existing user information
                string updateQuery = "UPDATE Users SET PasswordHash = @PasswordHash, FullName = @FullName, Email = @Email, ContactNumber = @ContactNumber WHERE UserID = @UserID";
                SqlCommand updateCmd = new SqlCommand(updateQuery, con);
                updateCmd.Parameters.AddWithValue("@PasswordHash", password);
                updateCmd.Parameters.AddWithValue("@FullName", fullName);
                updateCmd.Parameters.AddWithValue("@Email", email);
                updateCmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                updateCmd.Parameters.AddWithValue("@UserID", (int)userId);

                con.Open();
                try
                {
                    updateCmd.ExecuteNonQuery();
                    lblMessage.Text = "User information updated successfully!";
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
            else
            {
                // Insert new user if username does not exist
                string insertQuery = "INSERT INTO Users (Username, PasswordHash, UserTypeID, FullName, Email, ContactNumber) VALUES (@Username, @PasswordHash, @UserTypeID, @FullName, @Email, @ContactNumber)";
                SqlCommand insertCmd = new SqlCommand(insertQuery, con);
                insertCmd.Parameters.AddWithValue("@Username", username);
                insertCmd.Parameters.AddWithValue("@PasswordHash", password);
                insertCmd.Parameters.AddWithValue("@UserTypeID", 4);  // Assuming 4 is for patients
                insertCmd.Parameters.AddWithValue("@FullName", fullName);
                insertCmd.Parameters.AddWithValue("@Email", email);
                insertCmd.Parameters.AddWithValue("@ContactNumber", contactNumber);

                con.Open();
                try
                {
                    insertCmd.ExecuteNonQuery();
                    lblMessage.Text = "Registration successful!";
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
}
