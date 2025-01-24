using System;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class AdminMaster : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Any specific logic for the Admin master page can go here
        }

        protected void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear session data
            Session.Clear();
            Session.Abandon();
            // Redirect to the home page
            Response.Redirect("Home.aspx");
        }
    }
}
