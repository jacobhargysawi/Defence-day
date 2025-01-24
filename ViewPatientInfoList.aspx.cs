using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class ViewPatientInfoList : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; Database=HospitalManagementSystem; Integrated Security=True");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindGrid();
            }
        }

        protected void BindGrid(string searchQuery = null)
        {
            try
            {
                con.Open();
                SqlCommand cmd;
                if (string.IsNullOrEmpty(searchQuery))
                {
                    cmd = new SqlCommand("SELECT PatientName, Gender, Age, Contact, DoctorName, Specialty, MedicationName, Dosage, Instructions, Price, PatientInfoID FROM PatientInfo", con);
                }
                else
                {
                    cmd = new SqlCommand("SELECT PatientName, Gender, Age, Contact, DoctorName, Specialty, MedicationName, Dosage, Instructions, Price, PatientInfoID FROM PatientInfo WHERE PatientName LIKE @SearchQuery", con);
                    cmd.Parameters.AddWithValue("@SearchQuery", "%" + searchQuery + "%");
                }

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvPatientInfo.DataSource = dt;
                gvPatientInfo.DataBind();
            }
            catch (Exception ex)
            {
                // Handle exception
            }
            finally
            {
                con.Close();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            string searchQuery = txtSearch.Text.Trim();
            BindGrid(searchQuery);
        }

        protected void gvPatientInfo_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            if (e.CommandName == "ViewReport")
            {
                int rowIndex = Convert.ToInt32(e.CommandArgument);
                GridViewRow row = gvPatientInfo.Rows[rowIndex];
                string patientId = gvPatientInfo.DataKeys[rowIndex].Value.ToString();
                Response.Redirect("PatientReport.aspx?PatientInfoID=" + patientId);
            }
        }
    }
}
