using System;
using System.Data.SqlClient;
using System.Globalization;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace HospitalManagementSystem
{
    public partial class ViewPatientInfo : Page
    {
        SqlConnection con = new SqlConnection("Server=DESKTOP-QR4BNH8\\MSSQLSERVER04; database=HospitalManagementSystem; integrated security=true");

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                if (Request.QueryString["AppointmentID"] != null)
                {
                    int appointmentID = Convert.ToInt32(Request.QueryString["AppointmentID"]);
                    LoadPatientInfo(appointmentID);
                    LoadMedications();
                }
            }
        }

        private void LoadPatientInfo(int appointmentID)
        {
            try
            {
                con.Open();
                string query = @"SELECT A.AppointmentID, P.Name AS PatientName, P.Gender, P.Age, P.Contact, D.Name AS DoctorName, D.Specialty 
                                 FROM Appointments A 
                                 JOIN Patients P ON A.PatientID = P.PatientID 
                                 JOIN Doctors D ON A.DoctorID = D.DoctorID 
                                 WHERE A.AppointmentID = @AppointmentID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtPatientName.Text = reader["PatientName"].ToString();
                    txtGender.Text = reader["Gender"].ToString();
                    txtAge.Text = reader["Age"].ToString();
                    txtContact.Text = reader["Contact"].ToString();
                    txtDoctorName.Text = reader["DoctorName"].ToString();
                    txtSpecialty.Text = reader["Specialty"].ToString();
                }
                reader.Close();
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

        private void LoadMedications()
        {
            try
            {
                con.Open();
                string query = "SELECT MedicationID, MedicationName, Dosage, Instructions, Price FROM Medications";
                SqlCommand cmd = new SqlCommand(query, con);
                SqlDataReader reader = cmd.ExecuteReader();
                ddlMedications.DataSource = reader;
                ddlMedications.DataTextField = "MedicationName";
                ddlMedications.DataValueField = "MedicationID";
                ddlMedications.DataBind();
                reader.Close();
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

        protected void ddlMedications_SelectedIndexChanged(object sender, EventArgs e)
        {
            try
            {
                int medicationID = Convert.ToInt32(ddlMedications.SelectedValue);
                con.Open();
                string query = "SELECT Dosage, Instructions, Price FROM Medications WHERE MedicationID = @MedicationID";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@MedicationID", medicationID);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    txtDosage.Text = reader["Dosage"].ToString();
                    txtInstructions.Text = reader["Instructions"].ToString();
                    txtPrice.Text = reader["Price"].ToString();
                }
                reader.Close();
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

        protected void btnPrescribeMedication_Click(object sender, EventArgs e)
        {
            try
            {
                int appointmentID = Convert.ToInt32(Request.QueryString["AppointmentID"]);
                int medicationID = Convert.ToInt32(ddlMedications.SelectedValue);

                // Ensure the price is in the correct decimal format
                string priceString = txtPrice.Text.Trim();
                if (decimal.TryParse(priceString, NumberStyles.Any, CultureInfo.InvariantCulture, out decimal price))
                {
                    // Insert medication details into PatientInfo table
                    SqlCommand cmd = new SqlCommand(@"INSERT INTO PatientInfo (PatientName, Gender, Age, Contact, DoctorName, Specialty, MedicationName, Dosage, Instructions, Price, AppointmentID)
                                                      VALUES (@PatientName, @Gender, @Age, @Contact, @DoctorName, @Specialty, @MedicationName, @Dosage, @Instructions, @Price, @AppointmentID)", con);
                    cmd.Parameters.AddWithValue("@PatientName", txtPatientName.Text);
                    cmd.Parameters.AddWithValue("@Gender", txtGender.Text);
                    cmd.Parameters.AddWithValue("@Age", txtAge.Text);
                    cmd.Parameters.AddWithValue("@Contact", txtContact.Text);
                    cmd.Parameters.AddWithValue("@DoctorName", txtDoctorName.Text);
                    cmd.Parameters.AddWithValue("@Specialty", txtSpecialty.Text);
                    cmd.Parameters.AddWithValue("@MedicationName", ddlMedications.SelectedItem.Text);
                    cmd.Parameters.AddWithValue("@Dosage", txtDosage.Text);
                    cmd.Parameters.AddWithValue("@Instructions", txtInstructions.Text);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@AppointmentID", appointmentID);

                    con.Open();
                    cmd.ExecuteNonQuery();
                    con.Close();

                    lblMessage.Text = "Medication prescribed and details saved successfully.";
                }
                else
                {
                    lblMessage.Text = "Error: Price format is incorrect. Ensure that the price uses a period as the decimal separator.";
                }
            }
            catch (FormatException ex)
            {
                lblMessage.Text = "Error: Invalid format. " + ex.Message;
            }
            catch (SqlException ex)
            {
                lblMessage.Text = "Database Error: " + ex.Message;
            }
            catch (Exception ex)
            {
                lblMessage.Text = "Error: " + ex.Message;
            }
        }
    }
}
