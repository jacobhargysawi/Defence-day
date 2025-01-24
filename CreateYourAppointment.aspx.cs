using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class CreateYourAppointment : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; database = HospitalManagementSystem; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
                // Load available patients into the dropdown list
                LoadPatients();
                // Load available doctors into the dropdown list
                LoadDoctors();
            }
        }

        private void LoadPatients()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT PatientID, Name FROM Patients", con);
                SqlDataReader dr = cmd.ExecuteReader();
                ddlPatientName.DataSource = dr;
                ddlPatientName.DataTextField = "Name";
                ddlPatientName.DataValueField = "PatientID";
                ddlPatientName.DataBind();
                ddlPatientName.Items.Insert(0, new ListItem("Select Patient", "0"));
                con.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading patients: " + ex.Message;
            }
        }

        protected void ddlPatientName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Automatically set the PatientID when a patient is selected from the dropdown
            txtPatientID.Text = ddlPatientName.SelectedValue;
        }

        private void LoadDoctors()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT DoctorID, Name FROM Doctors", con);
                SqlDataReader dr = cmd.ExecuteReader();
                ddlDoctorName.DataSource = dr;
                ddlDoctorName.DataTextField = "Name";
                ddlDoctorName.DataValueField = "DoctorID";
                ddlDoctorName.DataBind();
                ddlDoctorName.Items.Insert(0, new ListItem("Select Doctor", "0"));
                con.Close();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error loading doctors: " + ex.Message;
            }
        }

        protected void ddlDoctorName_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Automatically set the DoctorID when a doctor is selected from the dropdown
            txtDoctorID.Text = ddlDoctorName.SelectedValue;
        }

        protected void btnSaveAppointment_Click(object sender, EventArgs e)
        {
            try
            {
                string patientID = txtPatientID.Text.Trim();
                string patientName = ddlPatientName.SelectedItem != null ? ddlPatientName.SelectedItem.Text : "";
                string doctorID = txtDoctorID.Text.Trim();
                string doctorName = ddlDoctorName.SelectedItem != null ? ddlDoctorName.SelectedItem.Text : "";
                string appointmentDate = txtAppointmentDate.Text.Trim();
                string status = txtStatus.Text.Trim();

                if (string.IsNullOrEmpty(patientID) || string.IsNullOrEmpty(patientName) || string.IsNullOrEmpty(doctorID) || string.IsNullOrEmpty(doctorName) || string.IsNullOrEmpty(appointmentDate) || string.IsNullOrEmpty(status))
                {
                    lblMessage.Text = "All fields are required.";
                    return;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Appointments (PatientID, PatientName, DoctorID, DoctorName, AppointmentDate, Status, CreatedAt) VALUES (@PatientID, @PatientName, @DoctorID, @DoctorName, @AppointmentDate, @Status, GETDATE())", con);
                cmd.Parameters.AddWithValue("@PatientID", Convert.ToInt32(patientID));
                cmd.Parameters.AddWithValue("@PatientName", patientName);
                cmd.Parameters.AddWithValue("@DoctorID", Convert.ToInt32(doctorID));
                cmd.Parameters.AddWithValue("@DoctorName", doctorName);
                cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
                cmd.Parameters.AddWithValue("@Status", status);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lblMessage.Text = "Appointment created successfully.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}
