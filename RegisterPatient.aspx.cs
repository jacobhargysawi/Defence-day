using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class RegisterPatient : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; Database=HospitalManagementSystem; Integrated Security=True");

        protected void btnRegister_Click(object sender, EventArgs e)
        {
            try
            {
                string name = txtName.Text.Trim();
                int age;
                if (!int.TryParse(txtAge.Text.Trim(), out age))
                {
                    lblMessage.Text = "Please enter a valid age.";
                    return;
                }
                string gender = txtGender.Text.Trim();
                string contact = txtContact.Text.Trim();
                string email = txtEmail.Text.Trim();
                string address = txtAddress.Text.Trim();
                string medicalHistory = txtMedicalHistory.Text.Trim();

                if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(contact) || string.IsNullOrEmpty(email))
                {
                    lblMessage.Text = "Please fill in all required fields.";
                    return;
                }

                string query = "INSERT INTO Patients (Name, Age, Gender, Contact, Email, Address, MedicalHistory, CreatedAt) VALUES (@Name, @Age, @Gender, @Contact, @Email, @Address, @MedicalHistory, GETDATE())";
                SqlCommand cmd = new SqlCommand(query, con);

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

                // Redirect to Register_patient.aspx after successful registration
                Response.Redirect("Register_patient.aspx");
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
