using System;
using System.Data;
using System.Data.SqlClient;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class Reports : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; database = HospitalManagementSystem; integrated security = true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                ddlReportType.SelectedIndex = 0;
            }
        }

        protected void btnGenerateReport_Click(object sender, EventArgs e)
        {
            string reportType = ddlReportType.SelectedValue;
            if (string.IsNullOrEmpty(reportType))
            {
                // Display a message to select a report type
                return;
            }

            BindReport(reportType);
        }

        protected void btnGenerateReportByDate_Click(object sender, EventArgs e)
        {
            string reportType = ddlReportType.SelectedValue;
            string startDate = txtStartDate.Text.Trim();
            string endDate = txtEndDate.Text.Trim();

            if (string.IsNullOrEmpty(reportType))
            {
                // Display a message to select a report type
                return;
            }

            BindReportByDate(reportType, startDate, endDate);
        }

        protected void BindReport(string reportType)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                switch (reportType)
                {
                    case "Appointments":
                        cmd.CommandText = "SELECT * FROM Appointments";
                        break;
                    case "Patients":
                        cmd.CommandText = "SELECT * FROM Patients";
                        break;
                    case "Doctors":
                        cmd.CommandText = "SELECT * FROM Doctors";
                        break;
                    case "Staff":
                        cmd.CommandText = "SELECT * FROM Staff";
                        break;
                    default:
                        return;
                }

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvReport.DataSource = dt;
                gvReport.DataBind();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log the error)
                throw new Exception("Error generating report: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }

        protected void BindReportByDate(string reportType, string startDate, string endDate)
        {
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand();
                cmd.Connection = con;

                switch (reportType)
                {
                    case "Appointments":
                        cmd.CommandText = "SELECT * FROM Appointments WHERE AppointmentDate BETWEEN @StartDate AND @EndDate";
                        break;
                    case "Patients":
                        cmd.CommandText = "SELECT * FROM Patients WHERE CreatedAt BETWEEN @StartDate AND @EndDate";
                        break;
                    case "Doctors":
                        cmd.CommandText = "SELECT * FROM Doctors WHERE CreatedAt BETWEEN @StartDate AND @EndDate";
                        break;
                    case "Staff":
                        cmd.CommandText = "SELECT * FROM Staff WHERE CreatedAt BETWEEN @StartDate AND @EndDate";
                        break;
                    default:
                        return;
                }

                cmd.Parameters.AddWithValue("@StartDate", startDate);
                cmd.Parameters.AddWithValue("@EndDate", endDate);

                SqlDataAdapter sda = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                sda.Fill(dt);
                gvReport.DataSource = dt;
                gvReport.DataBind();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log the error)
                throw new Exception("Error generating report: " + ex.Message);
            }
            finally
            {
                con.Close();
            }
        }
    }
}
