using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMS_Data
{
    public class clsDashboardData
    {

        public static bool GetBloodTypesCount(Dictionary<string, int> BloodTypesCount)
        {
            bool IsFound = true;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @" Select BloodType,Count(*) as 'NumberOfBags' from BloodStock
                            group by BloodType";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IsFound = true;
                    string BloodType = reader["BloodType"].ToString();
                    int Count = Convert.ToInt32(reader["NumberOfBags"]);
                    BloodTypesCount[BloodType] = Count;
                }
               

                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool GetStatusPercentage(Dictionary<string, int> StatusPercentage)
        {
            bool IsFound = true;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 
                              CASE 
                                WHEN CurrentStatus = 0 THEN 'Pending'
                                WHEN CurrentStatus = 1 OR CurrentStatus = 4 THEN 'Disposed'
                                WHEN CurrentStatus = 2 THEN 'Qualified'
                                WHEN CurrentStatus = 3 THEN 'Transfused'
                                ELSE 'Unknown'
                              END AS Status,
                              COUNT(*) AS Count,
                              CAST(COUNT(*) * 100.0 / SUM(COUNT(*)) OVER() AS DECIMAL(5,2)) AS 'Status Percentage'
                            FROM BloodStock
                            GROUP BY 
                              CASE 
                                WHEN CurrentStatus = 0 THEN 'Pending'
                                WHEN CurrentStatus = 1 OR CurrentStatus = 4 THEN 'Disposed'
                                WHEN CurrentStatus = 2 THEN 'Qualified'
                                WHEN CurrentStatus = 3 THEN 'Transfused'
                                ELSE 'Unknown'
                              END";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IsFound = true;
                    string Status = reader["Status"].ToString();
                    int Percentage = Convert.ToInt32(reader["Status Percentage"]);
                    StatusPercentage[Status] = Percentage;
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool GetGenderPercentage(Dictionary<string, int> GenderPercentage)
        {
            bool IsFound = true;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"SELECT 
                              CASE 
                                WHEN P.Gender = 0 THEN 'Male' 
                                ELSE 'Female' 
                              END AS Gender,
                              CAST(COUNT(*) * 100.0 / SUM(COUNT(*)) OVER() AS DECIMAL(5, 2)) AS Percentage
                            FROM Donors D
                            INNER JOIN People P ON D.PersonID = P.PersonID
                            GROUP BY P.Gender
                            ";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IsFound = true;
                    string Status = reader["Gender"].ToString();
                    int Percentage = Convert.ToInt32(reader["Percentage"]);
                    GenderPercentage[Status] = Percentage;
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool GetMostWantedBloodType(Dictionary<string, int> MostWanted)
        {
            bool IsFound = true;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Select top 3 BloodType,Count(*) as 'Wanted'
                            from BloodStock
                            group by BloodType
                            order by Wanted desc";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IsFound = true;
                    string BloodType = reader["BloodType"].ToString();
                    int Wanted = Convert.ToInt32(reader["Wanted"]);
                    MostWanted[BloodType] = Wanted;
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool GetDonorsToPatientRatio(Dictionary<string, int> DonorsToPatient)
        {
            bool IsFound = true;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Select 'Donors' as 'Type' ,Count(*) as 'Count' from Donors union all Select 'Patients',Count(*) as ' Count' from Patients";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IsFound = true;
                    string Type = reader["Type"].ToString();
                    int Count = Convert.ToInt32(reader["Count"]);
                    DonorsToPatient[Type] = Count;
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static bool GetDailyReport(Dictionary<string, int> DailyReport)
        {
            bool IsFound = true;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"  Select 'Donations' as 'Process', Count(*) as 'Count Today' from Donations WHERE CAST(DonationDate AS DATE) = CAST(GETDATE() AS DATE)
                              union all 
                             Select 'Requests' , Count(*) as 'Count Today' from Transfusions WHERE CAST(TransfusionRequestDate AS DATE) = CAST(GETDATE() AS DATE)
                              union all 
                             Select 'Units Transfused' , Count(*) as 'Count Today' from Transfusions WHERE TransfusionStatus=1 and CAST(TransfusionDate AS DATE) = CAST(GETDATE() AS DATE)
                              union all 
                             Select 'Expired' , Count(*) as 'Count Today' from BloodStock WHERE CAST(ExpirationDate AS DATE) = CAST(GETDATE() AS DATE)
                               union all 
                             Select 'Pending Reqeusts' , Count(*) as 'Count Today' from Transfusions WHERE TransfusionStatus=0 and CAST(TransfusionRequestDate AS DATE) = CAST(GETDATE() AS DATE)";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    IsFound = true;
                    string Process = reader["Process"].ToString();
                    int Count = Convert.ToInt32(reader["Count Today"]);
                    DailyReport[Process] = Count;
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                IsFound = false;
            }
            finally
            {
                connection.Close();
            }

            return IsFound;
        }

        public static int GetRequestsNumber()
        {
            int NumberOfRequests = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @" Select count(*) as 'Number Of Requests' from Transfusions where TransfusionStatus=0";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    NumberOfRequests = Convert.ToInt32(reader["Number Of Requests"]);
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                NumberOfRequests = -1;
            }
            finally
            {
                connection.Close();
            }

            return NumberOfRequests;
        }

        public static int GetDonorsNumber()
        {
            int NumberOfDonors = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @" Select Count(*) as 'Number of Donors'
                            from Donors";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    NumberOfDonors = Convert.ToInt32(reader["Number of Donors"]);
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                NumberOfDonors = -1;
            }
            finally
            {
                connection.Close();
            }

            return NumberOfDonors;
        }

        public static int GetEmployeesNumber()
        {
            int NumberOfEmployees = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @" Select Count(*) as 'Number of Employees'
                            from Employees";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    NumberOfEmployees = Convert.ToInt32(reader["Number of Employees"]);
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                NumberOfEmployees = -1;
            }
            finally
            {
                connection.Close();
            }

            return NumberOfEmployees;
        }

        public static int GetUnitsNumber()
        {
            int NumberOfUnits = -1;
            SqlConnection connection = new SqlConnection(clsDataAccessSettings.ConnectionString);
            string query = @"Select Count(*) as 'Number of Units' 
                                from BloodStock Where CurrentStatus=2";

            SqlCommand command = new SqlCommand(query, connection);

            try
            {
                connection.Open();
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    NumberOfUnits = Convert.ToInt32(reader["Number of Units"]);
                }


                reader.Close();
            }
            catch (Exception ex)
            {
                NumberOfUnits = -1;
            }
            finally
            {
                connection.Close();
            }

            return NumberOfUnits;
        }

    }
}
