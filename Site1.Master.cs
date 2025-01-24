using System;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class Site1 : MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (Session["UserID"] != null)
            {
                string userRole = Session["UserRole"] as string;

                // Dynamically adjust navigation links based on the user's role
                if (userRole == "Admin")
                {
                    // Add admin-specific links if needed
                }
                else if (userRole == "Doctor")
                {
                    // Add doctor-specific links if needed
                }
                else if (userRole == "Patient")
                {
                    // Add patient-specific links if needed
                }
                else if (userRole == "Staff")
                {
                    // Add staff-specific links if needed
                }
            }
        }
    }
}
