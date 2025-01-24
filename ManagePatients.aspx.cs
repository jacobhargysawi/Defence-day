using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class ManagePatients : Page
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Patients", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvPatients.DataSource = dt;
                gvPatients.DataBind();
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Patients WHERE Name LIKE @Name", con);
                    cmd.Parameters.AddWithValue("@Name", "%" + searchQuery + "%");
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    gvPatients.DataSource = dt;
                    gvPatients.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., log the error)
                    throw new Exception("Error searching patients: " + ex.Message);
                }
                finally
                {
                    con.Close();
                }
            }
            else
            {
                BindGrid();
            }
        }

        protected void btnCreatePatient_Click(object sender, EventArgs e)
        {
            // Redirect to a page for creating a new patient
            Response.Redirect("CreatePatient.aspx");
        }

        protected void gvPatients_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvPatients.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvPatients_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvPatients.Rows[e.RowIndex];
            int patientID = Convert.ToInt32(gvPatients.DataKeys[e.RowIndex].Values[0]);
            string name = (row.FindControl("txtName") as TextBox).Text;
            string age = (row.FindControl("txtAge") as TextBox).Text;
            string gender = (row.FindControl("txtGender") as TextBox).Text;
            string contact = (row.FindControl("txtContact") as TextBox).Text;
            string email = (row.FindControl("txtEmail") as TextBox).Text;
            string address = (row.FindControl("txtAddress") as TextBox).Text;
            string medicalHistory = (row.FindControl("txtMedicalHistory") as TextBox).Text;

            SqlCommand cmd = new SqlCommand("UPDATE Patients SET Name = @Name, Age = @Age, Gender = @Gender, Contact = @Contact, Email = @Email, Address = @Address, MedicalHistory = @MedicalHistory WHERE PatientID = @PatientID", con);
            cmd.Parameters.AddWithValue("@Name", name);
            cmd.Parameters.AddWithValue("@Age", age);
            cmd.Parameters.AddWithValue("@Gender", gender);
            cmd.Parameters.AddWithValue("@Contact", contact);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@Address", address);
            cmd.Parameters.AddWithValue("@MedicalHistory", medicalHistory);
            cmd.Parameters.AddWithValue("@PatientID", patientID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            gvPatients.EditIndex = -1;
            BindGrid();
        }

        protected void gvPatients_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvPatients.EditIndex = -1;
            BindGrid();
        }

        protected void gvPatients_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int patientID = Convert.ToInt32(gvPatients.DataKeys[e.RowIndex].Values[0]);

            SqlCommand cmd = new SqlCommand("DELETE FROM Patients WHERE PatientID = @PatientID", con);
            cmd.Parameters.AddWithValue("@PatientID", patientID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            BindGrid();
        }
    }
}
