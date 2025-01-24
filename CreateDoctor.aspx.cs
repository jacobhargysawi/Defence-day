using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class CreateDoctor : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; database = HospitalManagementSystem; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
            }
        }

        protected void btnSaveDoctor_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string specialty = txtSpecialty.Text.Trim();
                string contact = txtContact.Text.Trim();
                string email = txtEmail.Text.Trim();
                string availableFrom = txtAvailableFrom.Text.Trim();
                string availableTo = txtAvailableTo.Text.Trim();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(specialty) || string.IsNullOrEmpty(contact) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(availableFrom) || string.IsNullOrEmpty(availableTo))
                {
                    lblMessage.Text = "All fields are required.";
                    return;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Doctors (Name, Specialty, Contact, Email, AvailableFrom, AvailableTo, CreatedAt, UserID) VALUES (@Name, @Specialty, @Contact, @Email, @AvailableFrom, @AvailableTo, GETDATE(), 1)", con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Specialty", specialty);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@AvailableFrom", availableFrom);
                cmd.Parameters.AddWithValue("@AvailableTo", availableTo);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lblMessage.Text = "Doctor created successfully.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}
