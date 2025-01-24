using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class Prescriptions : Page
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
                SqlCommand cmd = new SqlCommand("SELECT P.PrescriptionID, P.AppointmentID, M.MedicationName, P.Dosage, P.Instructions, P.PrescriptionStatus FROM Prescriptions P JOIN Medications M ON P.MedicationID = M.MedicationID", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvPrescriptions.DataSource = dt;
                gvPrescriptions.DataBind();
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

        protected void gvPrescriptions_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPrescriptions.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvPrescriptions_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvPrescriptions.Rows[e.RowIndex];
            int prescriptionID = Convert.ToInt32(gvPrescriptions.DataKeys[e.RowIndex].Values[0]);
            string medicationName = (row.FindControl("MedicationName") as TextBox).Text;
            string dosage = (row.FindControl("Dosage") as TextBox).Text;
            string instructions = (row.FindControl("Instructions") as TextBox).Text;
            string status = (row.FindControl("PrescriptionStatus") as TextBox).Text;

            SqlCommand cmd = new SqlCommand("UPDATE Prescriptions SET MedicationID = (SELECT MedicationID FROM Medications WHERE MedicationName = @MedicationName), Dosage = @Dosage, Instructions = @Instructions, PrescriptionStatus = @Status WHERE PrescriptionID = @PrescriptionID", con);
            cmd.Parameters.AddWithValue("@MedicationName", medicationName);
            cmd.Parameters.AddWithValue("@Dosage", dosage);
            cmd.Parameters.AddWithValue("@Instructions", instructions);
            cmd.Parameters.AddWithValue("@Status", status);
            cmd.Parameters.AddWithValue("@PrescriptionID", prescriptionID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            gvPrescriptions.EditIndex = -1;
            BindGrid();
        }

        protected void gvPrescriptions_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPrescriptions.EditIndex = -1;
            BindGrid();
        }

        protected void gvPrescriptions_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int prescriptionID = Convert.ToInt32(gvPrescriptions.DataKeys[e.RowIndex].Values[0]);

            SqlCommand cmd = new SqlCommand("DELETE FROM Prescriptions WHERE PrescriptionID = @PrescriptionID", con);
            cmd.Parameters.AddWithValue("@PrescriptionID", prescriptionID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            BindGrid();
        }

        protected void btnCreatePrescription_Click(object sender, EventArgs e)
        {
            // Redirect to a page for creating a new prescription
            Response.Redirect("CreatePrescription.aspx");
        }
    }
}
