using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class ManageAppointments : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; database=HospitalManagementSystem; integrated security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid()
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("SELECT A.AppointmentID, P.Name AS PatientName, D.Name AS DoctorName, A.AppointmentDate, A.Status FROM Appointments A JOIN Patients P ON A.PatientID = P.PatientID JOIN Doctors D ON A.DoctorID = D.DoctorID", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvAppointments.DataSource = dt;
                gvAppointments.DataBind();
            }
            catch (Exception ex)
            {
                throw new Exception("Error binding grid: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        protected void gvAppointments_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvAppointments.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvAppointments_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvAppointments.Rows[e.RowIndex];
            int appointmentID = Convert.ToInt32(gvAppointments.DataKeys[e.RowIndex].Values[0]);

            // Use FindControl to get the controls from the GridView row
            string patientName = ((TextBox)row.Cells[1].Controls[0]).Text;
            string doctorName = ((TextBox)row.Cells[2].Controls[0]).Text;
            string appointmentDate = ((TextBox)row.Cells[3].Controls[0]).Text;
            string status = ((TextBox)row.Cells[4].Controls[0]).Text;

            SqlCommand cmd = new SqlCommand("UPDATE Appointments SET PatientID = (SELECT PatientID FROM Patients WHERE Name = @PatientName), DoctorID = (SELECT DoctorID FROM Doctors WHERE Name = @DoctorName), AppointmentDate = @AppointmentDate, Status = @Status WHERE AppointmentID = @AppointmentID", con);
            cmd.Parameters.AddWithValue("@PatientName", patientName);
            cmd.Parameters.AddWithValue("@DoctorName", doctorName);
            cmd.Parameters.AddWithValue("@AppointmentDate", appointmentDate);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            gvAppointments.EditIndex = -1;
            BindGrid();
        }

        protected void gvAppointments_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvAppointments.EditIndex = -1;
            BindGrid();
        }

        protected void gvAppointments_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int appointmentID = Convert.ToInt32(gvAppointments.DataKeys[e.RowIndex].Values[0]);

            SqlCommand cmd = new SqlCommand("DELETE FROM Appointments WHERE AppointmentID = @AppointmentID", con);
            cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            BindGrid();
        }

        protected void gvAppointments_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "CreatePrescription")
            {
                int appointmentID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"CreatePrescription.aspx?AppointmentID={appointmentID}");
            }
            else if (e.CommandName == "ViewMedications")
            {
                int appointmentID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"ViewMedications.aspx?AppointmentID={appointmentID}");
            }
            else if (e.CommandName == "ViewPatient")
            {
                int appointmentID = Convert.ToInt32(e.CommandArgument);
                Response.Redirect($"ViewPatientInfo.aspx?AppointmentID={appointmentID}");
            }
        }

        protected void btnCreateAppointment_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateAppointment.aspx");
        }
    }
}
