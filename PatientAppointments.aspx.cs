using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class PatientAppointments : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; Database=HospitalManagementSystem; Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userID = Convert.ToInt32(Session["UserID"]);
                LoadAppointments(userID);
            }
        }

        private void LoadAppointments(int userID)
        {
            try
            {
                con.Open();
                string query = "SELECT * FROM Appointments WHERE PatientID = (SELECT PatientID FROM Patients WHERE UserID = @UserID)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataReader reader = cmd.ExecuteReader();

                // Assuming you are using a GridView to show the appointments
                gvAppointments.DataSource = reader;
                gvAppointments.DataBind();

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
    }
}
