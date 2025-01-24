using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class ViewPrescriptions : Page
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
            SqlCommand cmd = new SqlCommand("SELECT * FROM Prescriptions", con);
            SqlDataAdapter sda = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sda.Fill(dt);
            gvPrescriptions.DataSource = dt;
            gvPrescriptions.DataBind();
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
            string medication = (row.FindControl("txtMedication") as TextBox).Text;
            string dosage = (row.FindControl("txtDosage") as TextBox).Text;
            string instructions = (row.FindControl("txtInstructions") as TextBox).Text;
            string status = (row.FindControl("txtStatus") as TextBox).Text;

            SqlCommand cmd = new SqlCommand("UPDATE Prescriptions SET Medication = @Medication, Dosage = @Dosage, Instructions = @Instructions, PrescriptionStatus = @Status WHERE PrescriptionID = @PrescriptionID", con);
            cmd.Parameters.AddWithValue("@Medication", medication);
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
    }
}
