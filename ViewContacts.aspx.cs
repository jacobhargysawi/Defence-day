using System;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class ViewContacts : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; database = HospitalManagementSystem; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        private void BindGrid()
        {
            string query = "SELECT * FROM Contact";
            SqlCommand cmd = new SqlCommand(query, con);

            con.Open();
            GridViewContacts.DataSource = cmd.ExecuteReader();
            GridViewContacts.DataBind();
            con.Close();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(searchQuery))
            {
                try
                {
                    con.Open();
                    SqlCommand cmd = new SqlCommand("SELECT * FROM Contact WHERE Name LIKE @Name", con);
                    cmd.Parameters.AddWithValue("@Name", "%" + searchQuery + "%");
                    GridViewContacts.DataSource = cmd.ExecuteReader();
                    GridViewContacts.DataBind();
                }
                catch (Exception ex)
                {
                    // Handle exception (e.g., log the error)
                    throw new Exception("Error searching contacts: " + ex.Message);
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

        protected void GridViewContacts_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            int contactID = Convert.ToInt32(GridViewContacts.DataKeys[e.RowIndex].Values[0]);

            SqlCommand cmd = new SqlCommand("DELETE FROM Contact WHERE ContactID = @ContactID", con);
            cmd.Parameters.AddWithValue("@ContactID", contactID);

            con.Open();
            cmd.ExecuteNonQuery();
            con.Close();

            BindGrid();
        }
    }
}
