using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class CreateRole : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; database = HospitalManagementSystem; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                lblMessage.Text = "";
            }
        }

        protected void btnSaveRole_Click(object sender, EventArgs e)
        {
            try
            {
                string roleName = txtRoleName.Text.Trim();

                if (string.IsNullOrEmpty(roleName))
                {
                    lblMessage.Text = "Role name is required.";
                    return;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO StaffRoles (RoleName) VALUES (@RoleName)", con);
                cmd.Parameters.AddWithValue("@RoleName", roleName);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                lblMessage.Text = "Role created successfully.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}
