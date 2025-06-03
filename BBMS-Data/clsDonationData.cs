using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMS_Data
{
    public class clsDonationData
    {

        public static bool GetDonationByID(int DonationID, ref DateTime DonationDate,ref decimal BloodVolume, ref int DonorID, ref int NurseID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = "select * from Donations where DonationID=@DonationID";

            SqlCommand Command = new SqlCommand(query, connection);
            Command.Parameters.AddWithValue("@DonationID", DonationID);

            try
            {
                connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;

                    DonationDate = (DateTime)reader["DonationDate"];
                    BloodVolume = (int)reader["BloodVolume"];
                    DonorID = (int)reader["DonorID"];
                    NurseID = (int)reader["NurseID"];
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
                connection.Close();
            }

            return IsFound;
        }


        public static DataTable GetAllDonations()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Donations order by DonationID";
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

        public static int AddNewDonation(DateTime DonationDate,decimal BloodVolume, int DonorID, int NurseID)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"insert into Donations (DonationDate,BloodVolume, DonorID, NurseID)
                       VALUES (@DonationDate,@BloodVolume, @DonorID, @NurseID)
                        select scope_identity();";


            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@DonationDate", DonationDate);
            command.Parameters.AddWithValue("@BloodVolume", BloodVolume);
            command.Parameters.AddWithValue("@DonorID", DonorID);
            command.Parameters.AddWithValue("@NurseID", NurseID);

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

        public static bool DeleteDonation(int DonationID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Delete Donations
                            Where DonationID=@DonationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DonationID", DonationID);

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


        public static bool IsDonationExist(int DonationID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select Found = 1 from Donations Where DonationID=@DonationID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@DonationID", DonationID);

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
        
        public static DataTable GetAllNurses()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select * from Nurses_View";
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
