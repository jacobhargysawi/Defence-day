using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class StaffRolesManagement : Page
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
                SqlCommand cmd = new SqlCommand("SELECT * FROM StaffRoles", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvStaffRoles.DataSource = dt;
                gvStaffRoles.DataBind();
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

        protected void btnCreateRole_Click(object sender, EventArgs e)
        {
            // Redirect to a page for creating a new role
            Response.Redirect("CreateRole.aspx");
        }

        protected void gvStaffRoles_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvStaffRoles.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvStaffRoles_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvStaffRoles.Rows[e.RowIndex];
            int staffRoleID = Convert.ToInt32(gvStaffRoles.DataKeys[e.RowIndex].Values[0]);
            string roleName = (row.FindControl("RoleName") as TextBox).Text;

            SqlCommand cmd = new SqlCommand("UPDATE StaffRoles SET RoleName = @RoleName WHERE StaffRoleID = @StaffRoleID", con);
            cmd.Parameters.AddWithValue("@RoleName", roleName);
            cmd.Parameters.AddWithValue("@StaffRoleID", staffRoleID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            gvStaffRoles.EditIndex = -1;
            BindGrid();
        }

        protected void gvStaffRoles_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvStaffRoles.EditIndex = -1;
            BindGrid();
        }

        protected void gvStaffRoles_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int staffRoleID = Convert.ToInt32(gvStaffRoles.DataKeys[e.RowIndex].Values[0]);

            SqlCommand cmd = new SqlCommand("DELETE FROM StaffRoles WHERE StaffRoleID = @StaffRoleID", con);
            cmd.Parameters.AddWithValue("@StaffRoleID", staffRoleID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            BindGrid();
        }
    }
}
