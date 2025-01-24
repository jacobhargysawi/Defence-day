using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class Contact : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; database = HospitalManagementSystem; integrated security = true");

        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            string name = txtName.Text.Trim();
            string email = txtEmail.Text.Trim();
            string website = txtWebsite.Text.Trim();
            string comment = txtComment.Text.Trim();

            if (string.IsNullOrEmpty(name) || string.IsNullOrEmpty(email) || string.IsNullOrEmpty(comment))
            {
                lblMessage.Text = "Name, Email, and Comment fields are required.";
                lblMessage.CssClass = "text-danger";
                return;
            }

            string query = "INSERT INTO Contact (Name, Email, Website, Comment) VALUES (@Name, @Email, @Website, @Comment)";

            con.Open();
            try
            {
                using (SqlCommand command = new SqlCommand(query, con))
                {
                    command.Parameters.AddWithValue("@Name", name);
                    command.Parameters.AddWithValue("@Email", email);
                    command.Parameters.AddWithValue("@Website", website);
                    command.Parameters.AddWithValue("@Comment", comment);

                    command.ExecuteNonQuery();
                    lblMessage.Text = "Thank you for your feedback!";
                    lblMessage.CssClass = "text-success";

                    // Clear the form fields after submission
                    txtName.Text = "";
                    txtEmail.Text = "";
                    txtWebsite.Text = "";
                    txtComment.Text = "";
                }
            }
            catch (Exception ex)
            {
                lblMessage.Text = "An error occurred: " + ex.Message;
                lblMessage.CssClass = "text-danger";
            }
            finally
            {
                con.Close();
            }
        }
    }
}
