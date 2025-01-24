using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class CreatePrescription : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; database=HospitalManagementSystem; integrated security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["AppointmentID"] != null)
                {
                    hfAppointmentID.Value = Request.QueryString["AppointmentID"];
                }
                lblMessage.Text = "";
            }
        }

        protected void btnCreatePrescription_Click(object sender, EventArgs e)
        {
            try
            {
                string medication = txtMedication.Text.Trim();
                string dosage = txtDosage.Text.Trim();
                string instructions = txtInstructions.Text.Trim();
                decimal price = Convert.ToDecimal(txtPrice.Text.Trim());
                int appointmentID = Convert.ToInt32(hfAppointmentID.Value);

                if (string.IsNullOrEmpty(medication) || string.IsNullOrEmpty(dosage) || string.IsNullOrEmpty(instructions) || price <= 0)
                {
                    lblMessage.Text = "All fields are required and price must be greater than zero.";
                    return;
                }

                SqlCommand cmd = new SqlCommand("INSERT INTO Medications (MedicationName, Dosage, Instructions, Price) VALUES (@MedicationName, @Dosage, @Instructions, @Price); SELECT SCOPE_IDENTITY();", con);
                cmd.Parameters.AddWithValue("@MedicationName", medication);
                cmd.Parameters.AddWithValue("@Dosage", dosage);
                cmd.Parameters.AddWithValue("@Instructions", instructions);
                cmd.Parameters.AddWithValue("@Price", price);

                con.Open();
                int medicationID = Convert.ToInt32(cmd.ExecuteScalar());

                SqlCommand updateCmd = new SqlCommand("UPDATE Appointments SET MedicationID = @MedicationID WHERE AppointmentID = @AppointmentID", con);
                updateCmd.Parameters.AddWithValue("@MedicationID", medicationID);
                updateCmd.Parameters.AddWithValue("@AppointmentID", appointmentID);
                updateCmd.ExecuteNonQuery();

                con.Close();

                lblMessage.Text = "Prescription created successfully.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}
