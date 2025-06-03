using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMS_Data
{
    public class clsTransfusionData
    {
        public static bool GetTransfusionByID(int TransfusionID, ref DateTime TransfusionRequestDate, ref DateTime? TransfusionDate, ref int QuantityRequested, ref byte TransfusionStatus, ref int PatientID, ref int BloodUnitID, ref int PerformedBy)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from Transfusions where TransfusionID=@TransfusionID";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@TransfusionID", TransfusionID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    TransfusionRequestDate = (DateTime)reader["TransfusionRequestDate"];
                    TransfusionDate = reader["TransfusionDate"] != DBNull.Value ? (DateTime?)reader["TransfusionDate"] : null;
                    QuantityRequested = (int)reader["QuantityRequested"];
                    TransfusionStatus = (byte)reader["TransfusionStatus"];
                    PatientID = (int)reader["PatientID"];

                    if (reader["BloodUnitID"] != DBNull.Value)
                    {
                        BloodUnitID = (int)reader["BloodUnitID"];
                    }
                    else {BloodUnitID = -1;}

                    if (reader["PerformedBy"] != DBNull.Value)
                    {
                        PerformedBy = (int)reader["PerformedBy"];
                    }
                    else {PerformedBy = -1;}
                   
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

        public static bool GetTransfusionByPatientID(ref int TransfusionID, ref DateTime TransfusionRequestDate, ref DateTime? TransfusionDate, ref int QuantityRequested, ref byte TransfusionStatus, int PatientID, ref int BloodUnitID, ref int PerformedBy)
        {
            bool IsFound = false;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string Query = "select * from Transfusions where PatientID=@PatientID";
            SqlCommand Command = new SqlCommand(Query, Connection);

            Command.Parameters.AddWithValue("@PatientID", PatientID);

            try
            {
                Connection.Open();
                SqlDataReader reader = Command.ExecuteReader();

                if (reader.Read())
                {
                    IsFound = true;
                    TransfusionRequestDate = (DateTime)reader["TransfusionRequestDate"];
                    TransfusionID = (int)reader["TransfusionID"];
                    TransfusionDate = reader["TransfusionDate"] != DBNull.Value ? (DateTime?)reader["TransfusionDate"] : null;
                    QuantityRequested = (int)reader["QuantityRequested"];
                    TransfusionStatus = (byte)reader["TransfusionStatus"];
                    PatientID = (int)reader["PatientID"];

                    if (reader["BloodUnitID"] != DBNull.Value)
                    {
                        BloodUnitID = (int)reader["BloodUnitID"];
                    }
                    else { BloodUnitID = -1; }

                    if (reader["PerformedBy"] != DBNull.Value)
                    {
                        PerformedBy = (int)reader["PerformedBy"];
                    }
                    else { PerformedBy = -1; }

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

        public static DataTable GetAllTransfusions()
        {
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "select * from Transfusions_View";
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

        public static int AddNewTransfusion( DateTime TransfusionRequestDate, DateTime? TransfusionDate, int QuantityRequested, byte TransfusionStatus,int PatientID, int BloodUnitID, int PerformedBy)
        {
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"INSERT INTO Transfusions
                    (TransfusionRequestDate,TransfusionDate, QuantityRequested, TransfusionStatus, PatientID, BloodUnitID, PerformedBy)
                    VALUES
                    (@TransfusionRequestDate,@TransfusionDate, @QuantityRequested, @TransfusionStatus, @PatientID, @BloodUnitID, @PerformedBy);
                    SELECT SCOPE_IDENTITY();";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TransfusionRequestDate", TransfusionRequestDate);
            command.Parameters.AddWithValue("@TransfusionDate", TransfusionDate.HasValue ? (object)TransfusionDate.Value : DBNull.Value);
            command.Parameters.AddWithValue("@QuantityRequested", QuantityRequested);
            command.Parameters.AddWithValue("@TransfusionStatus", TransfusionStatus);
            command.Parameters.AddWithValue("@PatientID", PatientID);
            command.Parameters.AddWithValue("@BloodUnitID", BloodUnitID == -1 ? DBNull.Value : (object)BloodUnitID);
            command.Parameters.AddWithValue("@PerformedBy", PerformedBy == -1 ? DBNull.Value : (object)PerformedBy);

            try
            {
                connection.Open();
                object res = command.ExecuteScalar();

                if (res != null && int.TryParse(res.ToString(), out int InsertedID))
                {
                    return InsertedID;
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

        public static bool UpdateTransfusion(int TransfusionID, DateTime TransfusionRequestDate, DateTime? TransfusionDate, int QuantityRequested, byte TransfusionStatus, int PatientID, int BloodUnitID, int PerformedBy)
        {
            int RowsAffected = 0;
            SqlConnection Connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = @"UPDATE Transfusions
                    SET TransfusionDate = @TransfusionDate,
                     TransfusionRequestDate = @TransfusionRequestDate,
                        QuantityRequested = @QuantityRequested,
                        TransfusionStatus = @TransfusionStatus,
                        PatientID = @PatientID,
                        BloodUnitID = @BloodUnitID,
                        PerformedBy = @PerformedBy
                    WHERE TransfusionID = @TransfusionID";

            SqlCommand command = new SqlCommand(query, Connection);

            command.Parameters.AddWithValue("@TransfusionRequestDate", TransfusionRequestDate);
            command.Parameters.AddWithValue("@TransfusionDate", TransfusionDate.HasValue ? (object)TransfusionDate.Value : DBNull.Value);
            command.Parameters.AddWithValue("@QuantityRequested", QuantityRequested);
            command.Parameters.AddWithValue("@TransfusionStatus", TransfusionStatus);
            command.Parameters.AddWithValue("@PatientID", PatientID);
            command.Parameters.AddWithValue("@BloodUnitID", BloodUnitID == -1 ? DBNull.Value : (object)BloodUnitID);
            command.Parameters.AddWithValue("@PerformedBy", PerformedBy == -1 ? DBNull.Value : (object)PerformedBy);
            command.Parameters.AddWithValue("@TransfusionID", TransfusionID);

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

        public static bool DeleteTransfusion(int TransfusionID)
        {
            int RowsAffected = 0;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Delete Transfusions
                            Where TransfusionID=@TransfusionID";

            SqlCommand command = new SqlCommand(query, connection);

            command.Parameters.AddWithValue("@TransfusionID", TransfusionID);

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

        public static bool DoesPatientHasActiveRequest(int PatientID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select found=1 from Transfusions where PatientID=@PatientID and TransfusionStatus=0";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@PatientID", PatientID);

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

        public static bool IsTransfusionExist(int TransfusionID)
        {
            bool IsFound = false;

            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);

            string query = "Select Found = 1 from Transfusions Where TransfusionID=@TransfusionID";

            SqlCommand command = new SqlCommand(query, connection);
            command.Parameters.AddWithValue("@TransfusionID", TransfusionID);

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
