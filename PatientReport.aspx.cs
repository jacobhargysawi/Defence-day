using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class PatientReport : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; Database=HospitalManagementSystem; Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string patientInfoID = Request.QueryString["PatientInfoID"];
                if (!string.IsNullOrEmpty(patientInfoID))
                {
                    LoadPatientReport(patientInfoID);
                }
            }
        }

        private void LoadPatientReport(string patientInfoID)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT PatientName, Gender, Age, Contact, DoctorName, Specialty, MedicationName, Dosage, Instructions, Price FROM PatientInfo WHERE PatientInfoID = @PatientInfoID", con);
                cmd.Parameters.AddWithValue("@PatientInfoID", patientInfoID);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvPatientReport.DataSource = dt;
                gvPatientReport.DataBind();
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            finally
            {
                con.Close();
            }
        }
    }
}
