using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMS_Data
{
    public class clsDonorData
    {
        public static bool GetDonorByID(int DonorID, ref decimal Height, ref decimal Weight, ref DateTime? LastDonationDate, ref string MedicalRecord, ref bool CanDonate, ref int PersonID)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from Donors where DonorID=@DonorID";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@DonorID", DonorID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    Height = (decimal)reader["Height"];
                    Weight = (decimal)reader["Weight"];

                    LastDonationDate = reader["LastDonationDate"] != DBNull.Value ? (DateTime?)reader["LastDonationDate"] : DateTime.Now;
                    MedicalRecord = reader["MedicalRecord"] != DBNull.Value ? (string)reader["MedicalRecord"] : "";

                    CanDonate = (bool)reader["CanDonate"];
                    PersonID = (int)reader["PersonID"];
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

        public static DataTable GetAllDonors()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM Donors_View order by DonorID";
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

        public static DataTable GetAllValidDonors()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "SELECT * FROM ValidDonors_View ";
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

        public static int AddNewDonor(decimal Height, decimal Weight, DateTime? LastDonationDate, string MedicalRecord, bool CanDonate, int PersonID)
        {

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Donors (Height, Weight, LastDonationDate, MedicalRecord, CanDonate, PersonID)
                            VALUES
                            (@Height, @Weight, @LastDonationDate, @MedicalRecord, @CanDonate, @PersonID)
                            select scope_identity();";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@Height", Height);
            command.Parameters.AddWithValue("@Weight", Weight);
            command.Parameters.AddWithValue("@MedicalRecord",string.IsNullOrEmpty(MedicalRecord) ? (object)DBNull.Value : MedicalRecord);
            command.Parameters.AddWithValue("@LastDonationDate",LastDonationDate.HasValue ? (object)LastDonationDate.Value : DBNull.Value);
            command.Parameters.AddWithValue("@CanDonate", CanDonate);
            command.Parameters.AddWithValue("@PersonID", PersonID);


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

        public static bool UpdateDonor(int DonorID, decimal Height, decimal Weight, DateTime? LastDonationDate, string MedicalRecord, bool CanDonate)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Donors
                SET Height = @Height, 
                Weight = @Weight,
                LastDonationDate = @LastDonationDate,
                MedicalRecord = @MedicalRecord,
                CanDonate = @CanDonate
                WHERE DonorID=@DonorID";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@DonorID", DonorID);
            command.Parameters.AddWithValue("@Height", Height);
            command.Parameters.AddWithValue("@Weight", Weight);
            if (LastDonationDate.HasValue)
            {
                command.Parameters.AddWithValue("@LastDonationDate", LastDonationDate.Value);
            }
            else
            {
                command.Parameters.AddWithValue("@LastDonationDate", DBNull.Value); 
            }
            if (!string.IsNullOrEmpty(MedicalRecord))
            {
            command.Parameters.AddWithValue("@MedicalRecord", MedicalRecord);
            }
            else
            {
                command.Parameters.AddWithValue("@MedicalRecord", DBNull.Value);
            }

            command.Parameters.AddWithValue("@CanDonate", CanDonate);

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

        public static bool DeleteDonor(int DonorID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Delete Donors 
                            Where DonorID=@DonorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DonorID", DonorID);

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

        public static bool IsDonorExist(int DonorID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select Found = 1 from Donors Where DonorID=@DonorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DonorID", DonorID);

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

        public static bool CanDonate(int DonorID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"SELECT Found=1 FROM Donors
                               WHERE CanDonate=1
                               AND (LastDonationDate <= DATEADD(MONTH, -3, GETDATE()) or LastDonationDate is null) and DonorID = @DonorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DonorID", DonorID);

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
        
        public static bool IsDonorExistByPersonID(int PersonID)
        {
            bool IsFound = false;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString); ;
            string Query = "Select Found =1 from Donors where PersonID=@PersonID";
            SqlCommand Command = new SqlCommand(Query, Connection);
            Command.Parameters.AddWithValue("@PersonID", PersonID);


            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();
                IsFound = reader.HasRows;
                reader.Close();
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

    }
}
