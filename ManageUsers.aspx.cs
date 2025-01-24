using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class ManageUsers : Page
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
                SqlCommand cmd = new SqlCommand("SELECT U.UserID, U.Username, U.FullName, U.Email, U.ContactNumber, UT.RoleName FROM Users U JOIN UserTypes UT ON U.UserTypeID = UT.UserTypeID", con);
                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvUsers.DataSource = dt;
                gvUsers.DataBind();
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
                    SqlCommand cmd = new SqlCommand("SELECT U.UserID, U.Username, U.FullName, U.Email, U.ContactNumber, UT.RoleName FROM Users U JOIN UserTypes UT ON U.UserTypeID = UT.UserTypeID WHERE U.Username LIKE @Username", con);
                    cmd.Parameters.AddWithValue("@Username", "%" + searchQuery + "%");
                    SqlDataAdapter sda = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    sda.Fill(dt);
                    gvUsers.DataSource = dt;
                    gvUsers.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., log the error)
                    throw new Exception("Error searching users: " + ex.Message);
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

        protected void gvUsers_RowEditing(object sender, GridViewEditEventArgs e)
        {
            gvUsers.EditIndex = e.NewEditIndex;
            BindGrid();
        }

        protected void gvUsers_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            GridViewRow row = gvUsers.Rows[e.RowIndex];
            int userID = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Values[0]);
            string username = (row.FindControl("txtUsername") as TextBox).Text;
            string fullName = (row.FindControl("txtFullName") as TextBox).Text;
            string email = (row.FindControl("txtEmail") as TextBox).Text;
            string contactNumber = (row.FindControl("txtContactNumber") as TextBox).Text;

            SqlCommand cmd = new SqlCommand("UPDATE Users SET Username = @Username, FullName = @FullName, Email = @Email, ContactNumber = @ContactNumber WHERE UserID = @UserID", con);
            cmd.Parameters.AddWithValue("@Username", username);
            cmd.Parameters.AddWithValue("@FullName", fullName);
            cmd.Parameters.AddWithValue("@Email", email);
            cmd.Parameters.AddWithValue("@ContactNumber", contactNumber);
            cmd.Parameters.AddWithValue("@UserID", userID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            gvUsers.EditIndex = -1;
            BindGrid();
        }

        protected void gvUsers_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            gvUsers.EditIndex = -1;
            BindGrid();
        }

        protected void gvUsers_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int userID = Convert.ToInt32(gvUsers.DataKeys[e.RowIndex].Values[0]);

            SqlCommand cmd = new SqlCommand("DELETE FROM Users WHERE UserID = @UserID", con);
            cmd.Parameters.AddWithValue("@UserID", userID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            BindGrid();
        }

        protected void btnCreateUser_Click(object sender, EventArgs e)
        {
            // Redirect to a page for creating a new user
            Response.Redirect("CreateUser.aspx");
        }
    }
}
