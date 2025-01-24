using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class ManageMedications : Page
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
                SqlCommand cmd = new SqlCommand("SELECT MedicationID, MedicationName, Dosage, Instructions, Price FROM Medications", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvMedications.DataSource = dt;
                gvMedications.DataBind();
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error binding grid: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }

        protected void gvMedications_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvMedications.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvMedications_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvMedications.Rows[e.RowIndex];
            int medicationID = Convert.ToInt32(gvMedications.DataKeys[e.RowIndex].Values[0]);
            string medicationName = (row.Cells[1].Controls[0] as TextBox).Text;
            string dosage = (row.Cells[2].Controls[0] as TextBox).Text;
            string instructions = (row.Cells[3].Controls[0] as TextBox).Text;
            decimal price = Convert.ToDecimal((row.Cells[4].Controls[0] as TextBox).Text);

            SqlCommand cmd = new SqlCommand("UPDATE Medications SET MedicationName = @MedicationName, Dosage = @Dosage, Instructions = @Instructions, Price = @Price WHERE MedicationID = @MedicationID", con);
            cmd.Parameters.AddWithValue("@MedicationName", medicationName);
            cmd.Parameters.AddWithValue("@Dosage", dosage);
            cmd.Parameters.AddWithValue("@Instructions", instructions);
            cmd.Parameters.AddWithValue("@Price", price);
            cmd.Parameters.AddWithValue("@MedicationID", medicationID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            gvMedications.EditIndex = -1;
            BindGrid();
        }

        protected void gvMedications_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvMedications.EditIndex = -1;
            BindGrid();
        }

        protected void gvMedications_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int medicationID = Convert.ToInt32(gvMedications.DataKeys[e.RowIndex].Values[0]);

            SqlCommand cmd = new SqlCommand("DELETE FROM Medications WHERE MedicationID = @MedicationID", con);
            cmd.Parameters.AddWithValue("@MedicationID", medicationID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            BindGrid();
        }

        protected void btnCreateMedication_Click(object sender, EventArgs e)
        {
            Response.Redirect("CreateMedication.aspx");
        }
    }
}
