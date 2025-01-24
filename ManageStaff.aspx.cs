using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class ManageStaff : Page
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM Staff", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvStaff.DataSource = dt;
                gvStaff.DataBind();
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

        protected void btnCreateStaff_Click(object sender, EventArgs e)
        {
            // Redirect to a page for creating new staff
            Response.Redirect("CreateStaff.aspx");
        }

        protected void gvStaff_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvStaff.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvStaff_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvStaff.Rows[e.RowIndex];
            int staffID = Convert.ToInt32(gvStaff.DataKeys[e.RowIndex].Values[0]);
            string fullName = (row.FindControl("txtFullName") as TextBox).Text;
            string role = (row.FindControl("txtRole") as TextBox).Text;
            string contact = (row.FindControl("txtContact") as TextBox).Text;
            string email = (row.FindControl("txtEmail") as TextBox).Text;

            SqlCommand cmd = new SqlCommand("UPDATE Staff SET FullName = @FullName, Role = @Role, Contact = @Contact, Email = @Email WHERE StaffID = @StaffID", con);
            cmd.Parameters.AddWithValue("@FullName", fullName);
            cmd.Parameters.AddWithValue("@Role", role);
            cmd.Parameters.AddWithValue("@Contact", contact);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@StaffID", staffID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            gvStaff.EditIndex = -1;
            BindGrid();
        }

        protected void gvStaff_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStaff.EditIndex = -1;
            BindGrid();
        }

        protected void gvStaff_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int staffID = Convert.ToInt32(gvStaff.DataKeys[e.RowIndex].Values[0]);

            SqlCommand cmd = new SqlCommand("DELETE FROM Staff WHERE StaffID = @StaffID", con);
            cmd.Parameters.AddWithValue("@StaffID", staffID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            BindGrid();
        }
    }
}
