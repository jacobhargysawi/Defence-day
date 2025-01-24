using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class EditUserProfile : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; database = HospitalManagementSystem; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["UserID"] != null)
                {
                    int userId = Convert.ToInt32(Request.QueryString["UserID"]);
                    LoadUserProfile(userId);
                }
                else
                {
                    lblMessage.Text = "User ID not provided.";
                }
            }
        }

        private void LoadUserProfile(int userId)
        {
            string query = "SELECT FullName, Email, ContactNumber FROM Users WHERE UserID = @UserID";
            SqlCommand cmd = new SqlCommand(query, con);
            cmd.Parameters.AddWithValue("@UserID", userId);

            con.Open();
            try
            {
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtFullName.Text = reader["FullName"].ToString();
                    txtEmail.Text = reader["Email"].ToString();
                    txtContactNumber.Text = reader["ContactNumber"].ToString();
                }
                reader.Close();
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

        protected void btnSaveChanges_Click(object sender, EventArgs e)
        {
            if (Request.QueryString["UserID"] != null)
            {
                int userId = Convert.ToInt32(Request.QueryString["UserID"]);
                string fullName = txtFullName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string contactNumber = txtContactNumber.Text.Trim();

                if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contactNumber))
                {
                    lblMessage.Text = "All fields are required.";
                    return;
                }

                string query = "UPDATE Users SET FullName = @FullName, Email = @Email, ContactNumber = @ContactNumber WHERE UserID = @UserID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                cmd.Parameters.AddWithValue("@UserID", userId);

                con.Open();
                try
                {
                    cmd.ExecuteNonQuery();
                    lblMessage.Text = "Profile updated successfully!";
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
                lblMessage.Text = "User ID not provided.";
            }
        }
    }
}
