using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class CreatePatient : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; database = HospitalManagementSystem; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
            }
        }

        protected void btnSavePatient_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                string age = txtAge.Text.Trim();
                string gender = txtGender.Text.Trim();
                string contact = txtContact.Text.Trim();
                string email = txtEmail.Text.Trim();
                string address = txtAddress.Text.Trim();
                string medicalHistory = txtMedicalHistory.Text.Trim();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(age) || string.IsNullOrEmpty(gender) || string.IsNullOrEmpty(contact) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(medicalHistory))
                {
                    lblMessage.Text = "All fields are required.";
                    return;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Patients (Name, Age, Gender, Contact, Email, Address, MedicalHistory, CreatedAt, UserID) VALUES (@Name, @Age, @Gender, @Contact, @Email, @Address, @MedicalHistory, GETDATE(), 1)", con);
                cmd.Parameters.AddWithValue("@Name", name);
                cmd.Parameters.AddWithValue("@Age", age);
                cmd.Parameters.AddWithValue("@Gender", gender);
                cmd.Parameters.AddWithValue("@Contact", contact);
                cmd.Parameters.AddWithValue("@Email", email);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@MedicalHistory", medicalHistory);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lblMessage.Text = "Patient created successfully.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}
