using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace BBMS_Data
{
    public class clsBloodStockData
    {

        public static bool GetBloodUnitByID(int BloodUnitID, ref string BloodType, ref DateTime ExpirationDate,  ref byte TestStatus, ref string ExaminationNotes, ref byte CurrentStatus, ref int DonationID)
        {
            bool isFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "SELECT * FROM BloodStock WHERE BloodUnitID = @BloodUnitID";
            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BloodUnitID", BloodUnitID);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;

                    BloodType = (string)reader["BloodType"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    TestStatus = (byte)reader["TestStatus"];

                    if (reader["ExaminationNotes"] != DBNull.Value)
                    {
                        ExaminationNotes = (string)reader["ExaminationNotes"];
                    }
                    else {ExaminationNotes = "";}

                    CurrentStatus = (byte)reader["CurrentStatus"];
                    DonationID = (int)reader["DonationID"];
                }
                else
                {
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static int AddBloodUnit(string BloodType, DateTime ExpirationDate, byte TestStatus, string ExaminationNotes, byte CurrentStatus, int DonationID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO BloodStock
           (BloodType, ExpirationDate, TestStatus, ExaminationNotes, CurrentStatus, DonationID)
            VALUES
           (@BloodType, @ExpirationDate, @TestStatus, @ExaminationNotes, @CurrentStatus, @DonationID);
            select scope_identity();";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@BloodType", BloodType);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@TestStatus", TestStatus);

            if (ExaminationNotes != "" && ExaminationNotes != null)
                command.Parameters.AddWithValue("@ExaminationNotes", ExaminationNotes);
            else
                command.Parameters.AddWithValue("@ExaminationNotes", System.DBNull.Value);

            command.Parameters.AddWithValue("@CurrentStatus", CurrentStatus);
            command.Parameters.AddWithValue("@DonationID", DonationID);


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

        public static bool UpdateBloodUnit(int BloodUnitID, string BloodType,DateTime ExpirationDate, byte TestStatus, string ExaminationNotes, byte CurrentStatus,int DonationID)
        {
            int RowsAffected = 0;

            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE BloodStock
                             SET BloodType = @BloodType,
                              ExpirationDate = @ExpirationDate,
                              TestStatus = @TestStatus,
                              ExaminationNotes = @ExaminationNotes,
                              CurrentStatus = @CurrentStatus,
                              DonationID = @DonationID
                          WHERE BloodUnitID=@BloodUnitID";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@BloodType", BloodType);
            command.Parameters.AddWithValue("@ExpirationDate", ExpirationDate);
            command.Parameters.AddWithValue("@TestStatus", TestStatus);

            if (ExaminationNotes != "" && ExaminationNotes != null)
                command.Parameters.AddWithValue("@ExaminationNotes", ExaminationNotes);
            else
                command.Parameters.AddWithValue("@ExaminationNotes", System.DBNull.Value);

            command.Parameters.AddWithValue("@CurrentStatus", CurrentStatus);
            command.Parameters.AddWithValue("@DonationID", DonationID);
            command.Parameters.AddWithValue("@BloodUnitID", BloodUnitID);

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

        public static bool DeleteBloodUnit(int BloodUnitID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Delete BloodStock 
                            Where BloodUnitID=@BloodUnitID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BloodUnitID", BloodUnitID);

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

        public static bool IsBloodUnitExist(int BloodUnitID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select Found = 1 from BloodStock Where BloodUnitID=@BloodUnitID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BloodUnitID", BloodUnitID);

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

        public static bool UpdateExpiredUnits()
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);


            string query = @"Update BloodStock 
                             set CurrentStatus=4
                             where ExpirationDate< CAST(GETDATE() AS DATE)";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                RowsAffected = command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                return false;
            }
            finally
            {
                connection.Close();
            }

            return RowsAffected > 0;
        }

        public static short GetBloodUnitStatus(int BloodUnitID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"select CurrentStatus from BloodStock
                     WHERE BloodUnitID = @BloodUnitID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BloodUnitID", BloodUnitID);

            try
            {
                connection.Open();
                object result = command.ExecuteScalar();

                if (result != null && short.TryParse(result.ToString(), out short status))
                {
                    return status;
                }

                return -1;
            }
            catch (Exception ex)
            {
                return -1;
            }
            finally
            {
                connection.Close();
            }
        }

        public static bool IsUnitTested(int BloodUnitID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select Found = 1 from BloodStock Where BloodUnitID=@BloodUnitID and (TestStatus != 0 and CurrentStatus!=0)";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@BloodUnitID", BloodUnitID);

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

        public static string GetDonorBloodType(int DonorID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string BloodType = "";
            string query = @"Select Top 1 BloodType from BloodStock B
                                inner join Donations Don on Don.DonationID=B.DonationID
                                inner join Donors D on D.DonorID=Don.DonorID 
                                Where D.DonorID=@DonorID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DonorID", DonorID);

            try
            {

                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    BloodType = (string)reader["BloodType"];

                }
                else
                {
                    return null;
                }

            }
            catch (Exception ex)
            {
                return null;
            }
            finally
            {
                connection.Close();
            }
            return BloodType;
        }

        public static bool GetMatchingBloodUnit(List<string> MatchingList,ref int BloodUnitID, ref string BloodType, ref DateTime ExpirationDate, ref byte TestStatus, ref string ExaminationNotes,
            ref byte CurrentStatus, ref int DonationID)
        {
            bool isFound = false;
            if (MatchingList == null || MatchingList.Count == 0)
            {
                return false;
            }
                string MatchingTypes = string.Join(",", MatchingList.Select(bt => $"'{bt}'"));
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = $@"  SELECT TOP 1 * FROM BloodStock
                                WHERE BloodType IN ({MatchingTypes})
                                and  TestStatus =2 and CurrentStatus=2
                                ORDER BY ExpirationDate ASC";

            SqlCommand command = new SqlCommand(query, connection);


            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    isFound = true;
                    BloodUnitID = (int)reader["BloodUnitID"];
                    BloodType = (string)reader["BloodType"];
                    ExpirationDate = (DateTime)reader["ExpirationDate"];
                    TestStatus = (byte)reader["TestStatus"];

                    if (reader["ExaminationNotes"] != DBNull.Value)
                    {
                        ExaminationNotes = (string)reader["ExaminationNotes"];
                    }
                    else { ExaminationNotes = ""; }

                    CurrentStatus = (byte)reader["CurrentStatus"];
                    DonationID = (int)reader["DonationID"];
                }
                else
                {
                    isFound = false;
                }

                reader.Close();
            }
            catch (Exception ex)
            {
                isFound = false;
            }
            finally
            {
                connection.Close();
            }

            return isFound;
        }

        public static DataTable GetAllUnits()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"Select * from BloodStock_View";
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

        public static DataTable GetAllCompatibleUnits(List<string> MatchingList)
        {

            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string MatchingTypes = string.Join(",", MatchingList.Select(bt => $"'{bt}'"));

            string query = $@"SELECT  * FROM BloodStock_view
                             WHERE BloodType IN ({MatchingTypes})and 
                            TestStatus ='Accepted' and CurrentStatus='Qualified'
                             ORDER BY ExpirationDate ASC";
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
       
    }
}
