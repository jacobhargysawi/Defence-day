using System;
using System.Data.SqlClient;
using System.Web.UI;

namespace HospitalManagementSystem
{
    public partial class CreateMedication : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; database=HospitalManagementSystem; integrated security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnAddMedication_Click(object sender, EventArgs e)
        {
            string medicationName = txtMedicationName.Text.Trim();
            string dosage = txtDosage.Text.Trim();
            string instructions = txtInstructions.Text.Trim();
            string priceText = txtPrice.Text.Trim();

            if (string.IsNullOrEmpty(medicationName) || string.IsNullOrEmpty(dosage) || string.IsNullOrEmpty(instructions) || string.IsNullOrEmpty(priceText))
            {
                lblMessage.Text = "All fields are required.";
                return;
            }

            if (!decimal.TryParse(priceText, out decimal price))
            {
                lblMessage.Text = "Price must be a valid decimal number.";
                return;
            }

            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("INSERT INTO Medications (MedicationName, Dosage, Instructions, Price) VALUES (@MedicationName, @Dosage, @Instructions, @Price)", con);
                cmd.Parameters.AddWithValue("@MedicationName", medicationName);
                cmd.Parameters.AddWithValue("@Dosage", dosage);
                cmd.Parameters.AddWithValue("@Instructions", instructions);
                cmd.Parameters.AddWithValue("@Price", price);

                cmd.ExecuteNonQuery();
                lblMessage.Text = "Medication added successfully.";
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
            finally
            {
                con.Close();
            }
        }
    }
}
