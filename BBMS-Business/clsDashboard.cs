using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BBMS_Data;

namespace BBMS_Business
{
    public class clsDashboard
    {
        public static bool GetBloodTypesCount(Dictionary<string, int> BloodTypesCount)
        {
            return clsDashboardData.GetBloodTypesCount(BloodTypesCount);
        }

        public static bool GetStatusPercentage(Dictionary<string, int> StatusPercentage)
        {
            return clsDashboardData.GetStatusPercentage(StatusPercentage);
        }
        public static bool GetGenderPercentage(Dictionary<string, int> GenderPercentage)
        {
            return clsDashboardData.GetGenderPercentage(GenderPercentage);
        }

        public static bool GetMostWantedBloodType(Dictionary<string, int> MostWanted)
        {
            return clsDashboardData.GetMostWantedBloodType(MostWanted);
        }

        public static bool GetDonorsToPatientRatio(Dictionary<string, int> DonorsToPatient)
        {
            return clsDashboardData.GetDonorsToPatientRatio(DonorsToPatient);
        }


        public static int NumberOfRequests()
        {
            return clsDashboardData.GetRequestsNumber();
        }
        public static int NumberOfDonors()
        {
            return clsDashboardData.GetDonorsNumber();
        }
        public static int NumberOfUnits()
        {
            return clsDashboardData.GetUnitsNumber();
        }
        public static int NumberOfEmployees()
        {
            return clsDashboardData.GetEmployeesNumber();
        }
        public static bool GetDailyReport(Dictionary<string, int> DailyReport)
        {
            return clsDashboardData.GetDailyReport(DailyReport);
        }



    }
}
