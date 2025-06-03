using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMS_Data
{
    public class clsPatientData
    {
        public static bool GetPatientByID(int PatientID, ref string BloodType, ref string MedicalCondition, ref int PersonID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from Patients where PatientID=@PatientID";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PatientID", PatientID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    BloodType = (string)reader["BloodType"];
                    PersonID = (int)reader["PersonID"];
                    MedicalCondition = reader["MedicalCondition"] != DBNull.Value ? (string)reader["MedicalCondition"] : "";
                }
                else
                {
                    IsFound = false;
                }
            }

            catch (Exception)
            {
                return IsFound = false;
            }

            finally
            {
                Connection.Close();
            }

            return IsFound;
        }

        public static DataTable GetAllPatients()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Patients_View";
            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.HasRows)
                {
                    dt.Load(reader);
                }

                reader.Close();
            }

            catch (Exception ex)
            {

            }
            finally
            {
                connection.Close();
            }

            return dt;
        }

        public static int AddNewPatient(string BloodType, string MedicalCondition, int PersonID)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Patients (BloodType, MedicalCondition, PersonID)
                                                    VALUES (@BloodType, @MedicalCondition, @PersonID);
                                                    SELECT SCOPE_IDENTITY();;";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BloodType", BloodType);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@MedicalCondition", string.IsNullOrEmpty(MedicalCondition) ? (object)DBNull.Value : MedicalCondition);

            try
            {
                connection.Open();
                object res = command.ExecuteScalar();

                if (res != null && int.TryParse(res.ToString(), out int InsertedID))
                {
                    return InsertedID;
                }
                else
                {
                    return -1;
                }
            }
            catch (Exception ex)
            {

            }

            finally
            {
                connection.Close();
            }

            return -1;
        }

        public static bool UpdatePatient(int PatientID, string BloodType, string MedicalCondition, int PersonID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Patients
            SET BloodType=@BloodType,
            MedicalCondition=@MedicalCondition,
            PersonID=@PersonID
            WHERE PatientID=@PatientID";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@BloodType", BloodType);
            command.Parameters.AddWithValue("@MedicalCondition", MedicalCondition);
            command.Parameters.AddWithValue("@PersonID", PersonID);
            command.Parameters.AddWithValue("@PatientID", PatientID);

            try
            {
                Connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }

            catch (Exception)
            {
                return false;
            }
            finally
            {
                Connection.Close();
            }

            return RowsAffected > 0;
        }

        public static bool DeletePatient(int PatientID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Delete Patients 
                            Where PatientID=@PatientID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PatientID", PatientID);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return RowsAffected > 0;
        }

        public static bool IsPatientExist(int PersonID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select Found = 1 from Patients Where PersonID=@PersonID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PersonID", PersonID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();
                IsFound = reader.HasRows;
                reader.Close();
            }
            catch (Exception)
            {
                return IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }
    }
}
