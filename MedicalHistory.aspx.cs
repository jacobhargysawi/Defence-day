using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class MedicalHistory : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; Database=HospitalManagementSystem; Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                int userID = Convert.ToInt32(Session["UserID"]);
                LoadMedicalHistory(userID);
            }
        }

        private void LoadMedicalHistory(int userID)
        {
            try
            {
                con.Open();
                string query = @"SELECT 
                                    A.AppointmentDate, 
                                    D.Name AS DoctorName, 
                                    M.MedicationName, 
                                    PR.Dosage, 
                                    PR.Instructions, 
                                    PR.PrescriptionStatus 
                                FROM 
                                    Appointments A
                                JOIN 
                                    Prescriptions PR ON A.AppointmentID = PR.AppointmentID
                                JOIN 
                                    Medications M ON PR.MedicationID = M.MedicationID
                                JOIN 
                                    Doctors D ON A.DoctorID = D.DoctorID
                                WHERE 
                                    A.PatientID = (SELECT PatientID FROM Patients WHERE UserID = @UserID)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@UserID", userID);
                SqlDataReader reader = cmd.ExecuteReader();

                if (reader.HasRows)
                {
                    gvMedicalHistory.DataSource = reader;
                    gvMedicalHistory.DataBind();
                }
                else
                {
                    lblMessage.Text = "No medical history found.";
                }

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
