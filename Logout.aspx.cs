using System;
using System.Web;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class Logout : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            // Clear session data
            Session.Clear();
            Session.Abandon();
            // Redirect to the home page
            Response.Redirect("Home.aspx");
        }
    }
}
