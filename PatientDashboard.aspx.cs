using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class PatientDashboard : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; Database=HospitalManagementSystem; Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userID = Convert.ToInt32(Session["UserID"]);
                lblWelcome.Text = "Welcome, " + GetPatientName(userID);
            }
        }

        private string GetPatientName(int userID)
        {
            string name = "";
            try
            {
                con.Open();
                string query = "SELECT FullName FROM Users WHERE UserID = @UserID AND UserTypeID = 4";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    name = reader["FullName"].ToString();
                }
                reader.Close();
            }
            catch (Exception ex)
            {
                lblWelcome.Text = "Error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
            return name;
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            Session.Clear();
            Response.Redirect("Login_patient.aspx");
        }
    }
}
