using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class CreateStaff : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; database = HospitalManagementSystem; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
            }
        }

        protected void btnSaveStaff_Click(object sender, EventArgs e)
        {
            try
            {
                string fullName = txtFullName.Text.Trim();
                string role = txtRole.Text.Trim();
                string contact = txtContact.Text.Trim();
                string email = txtEmail.Text.Trim();

                if (string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(role) || string.IsNullOrEmpty(contact) || string.IsNullOrEmpty(email))
                {
                    lblMessage.Text = "All fields are required.";
                    return;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Staff (FullName, Role, Contact, Email, CreatedAt, UserID) VALUES (@FullName, @Role, @Contact, @Email, GETDATE(), 1)", con);
                cmd.Parameters.AddWithValue("@FullName", fullName);
                cmd.Parameters.AddWithValue("@Role", role);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@Email", email);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lblMessage.Text = "Staff created successfully.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}
