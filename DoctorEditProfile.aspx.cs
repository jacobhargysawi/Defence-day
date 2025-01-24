using System;
using System.Data.SqlClient;
using System.Configuration;

namespace HospitalManagementSystem
{
    public partial class DoctorEditProfile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                LoadProfile();
            }
        }

        private void LoadProfile()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["HospitalManagementSystemDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "SELECT Name, Specialty, Contact, Email FROM Doctors WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    if (reader.Read())
                    {
                        txtName.Text = reader["Name"].ToString();
                        txtSpecialty.Text = reader["Specialty"].ToString();
                        txtContact.Text = reader["Contact"].ToString();
                        txtEmail.Text = reader["Email"].ToString();
                    }
                    con.Close();
                }
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            string name = txtName.Text;
            string specialty = txtSpecialty.Text;
            string contact = txtContact.Text;
            string email = txtEmail.Text;

            string connectionString = ConfigurationManager.ConnectionStrings["HospitalManagementSystemDB"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionString))
            {
                string query = "UPDATE Doctors SET Name = @Name, Specialty = @Specialty, Contact = @Contact, Email = @Email WHERE UserID = @UserID";
                using (SqlCommand cmd = new SqlCommand(query, con))
                {
                    cmd.Parameters.AddWithValue("@Name", name);
                    cmd.Parameters.AddWithValue("@Specialty", specialty);
                    cmd.Parameters.AddWithValue("@Contact", contact);
                    cmd.Parameters.AddWithValue("@Email", email);
                    cmd.Parameters.AddWithValue("@UserID", Session["UserID"]);
                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();
                }
            }

            // Optionally, redirect to the dashboard or show a success message
            Response.Redirect("~/DoctorDashboard.aspx");
        }
    }
}
