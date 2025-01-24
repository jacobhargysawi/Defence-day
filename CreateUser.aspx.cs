using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class CreateUser : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; database = HospitalManagementSystem; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
                LoadUserTypes();
            }
        }

        protected void LoadUserTypes()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT UserTypeID, RoleName FROM UserTypes", con);
                SqlDataReader reader = cmd.ExecuteReader();
                ddlUserType.DataSource = reader;
                ddlUserType.DataValueField = "UserTypeID";
                ddlUserType.DataTextField = "RoleName";
                ddlUserType.DataBind();
                reader.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading user types: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnSaveUser_Click(object sender, EventArgs e)
        {
            try
            {
                string username = txtUsername.Text.Trim();
                string fullName = txtFullName.Text.Trim();
                string email = txtEmail.Text.Trim();
                string contactNumber = txtContactNumber.Text.Trim();
                string userTypeID = ddlUserType.SelectedValue;
                string password = txtPassword.Text.Trim();

                if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(contactNumber) || string.IsNullOrEmpty(userTypeID) || string.IsNullOrEmpty(password))
                {
                    lblMessage.Text = "All fields are required.";
                    return;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Users (Username, FullName, Email, ContactNumber, UserTypeID, PasswordHash, CreatedAt) VALUES (@Username, @FullName, @Email, @ContactNumber, @UserTypeID, @PasswordHash, GETDATE())", con);
                cmd.Parameters.AddWithValue("@Username", username);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
                cmd.Parameters.AddWithValue("@UserTypeID", userTypeID);
                cmd.Parameters.AddWithValue("@PasswordHash", password); // Make sure to hash the password before storing

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lblMessage.Text = "User created successfully.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}
