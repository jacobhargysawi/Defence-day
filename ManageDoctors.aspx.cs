using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class ManageDoctors : Page
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Doctors", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvDoctors.DataSource = dt;
                gvDoctors.DataBind();
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

        protected void btnCreateDoctor_Click(object sender, EventArgs e)
        {
            // Redirect to a page for creating a new doctor
            Response.Redirect("CreateDoctor.aspx");
        }

        protected void gvDoctors_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvDoctors.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvDoctors_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvDoctors.Rows[e.RowIndex];
            int doctorID = Convert.ToInt32(gvDoctors.DataKeys[e.RowIndex].Values[0]);
            string name = (row.Cells[1].Controls[0] as TextBox).Text;
            string specialty = (row.Cells[2].Controls[0] as TextBox).Text;
            string contact = (row.Cells[3].Controls[0] as TextBox).Text;
            string email = (row.Cells[4].Controls[0] as TextBox).Text;

            SqlCommand cmd = new SqlCommand("UPDATE Doctors SET Name = @Name, Specialty = @Specialty, Contact = @Contact, Email = @Email WHERE DoctorID = @DoctorID", con);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Specialty", specialty);
            cmd.Parameters.AddWithValue("@Contact", contact);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@DoctorID", doctorID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            gvDoctors.EditIndex = -1;
            BindGrid();
        }

        protected void gvDoctors_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvDoctors.EditIndex = -1;
            BindGrid();
        }

        protected void gvDoctors_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int doctorID = Convert.ToInt32(gvDoctors.DataKeys[e.RowIndex].Values[0]);

            SqlCommand cmd = new SqlCommand("DELETE FROM Doctors WHERE DoctorID = @DoctorID", con);
            cmd.Parameters.AddWithValue("@DoctorID", doctorID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            BindGrid();
        }
    }
}
