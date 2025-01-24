using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class Appointments : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; database = HospitalManagementSystem; integrated security = true");

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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Appointments", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvAppointments.DataSource = dt;
                gvAppointments.DataBind();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log the error)
                throw new Exception("Error binding grid: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnCreateAppointment_Click(object sender, EventArgs e)
        {
            // Redirect to a page for creating a new appointment
            Response.Redirect("CreateAppointment.aspx");
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
            string patientID = (row.Cells[1].Controls[0] as TextBox).Text;
            string doctorID = (row.Cells[2].Controls[0] as TextBox).Text;
            string appointmentDate = (row.Cells[3].Controls[0] as TextBox).Text;
            string status = (row.Cells[4].Controls[0] as TextBox).Text;

            SqlCommand cmd = new SqlCommand("UPDATE Appointments SET PatientID = @PatientID, DoctorID = @DoctorID, AppointmentDate = @AppointmentDate, Status = @Status WHERE AppointmentID = @AppointmentID", con);
            cmd.Parameters.AddWithValue("@PatientID", patientID);
            cmd.Parameters.AddWithValue("@DoctorID", doctorID);
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
    }
}
