using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class ChangePassword : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; database = HospitalManagementSystem; integrated security = true");

        protected void btnChangePassword_Click(object sender, EventArgs e)
        {
            string currentPassword = txtCurrentPassword.Text.Trim();
            string newPassword = txtNewPassword.Text.Trim();
            string confirmNewPassword = txtConfirmNewPassword.Text.Trim();

            if (newPassword != confirmNewPassword)
            {
                lblMessage.Text = "New passwords do not match.";
                return;
            }

            string username = Session["Username"]?.ToString();  // Assume username is stored in session on login

            if (string.IsNullOrEmpty(username))
            {
                lblMessage.Text = "User not logged in.";
                return;
            }

            string query = "UPDATE Users SET PasswordHash = @NewPassword WHERE Username = @Username AND PasswordHash = @CurrentPassword";

            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@NewPassword", newPassword);  // Hash the password in a real implementation
            cmd.Parameters.AddWithValue("@CurrentPassword", currentPassword);  // Hash the password in a real implementation
            cmd.Parameters.AddWithValue("@Username", username);

            con.Open();
            try
            {
                int rowsAffected = cmd.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    lblMessage.Text = "Password changed successfully.";
                }
                else
                {
                    lblMessage.Text = "Current password is incorrect.";
                }
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
