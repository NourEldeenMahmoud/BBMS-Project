using BBMS_Business;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BBMS_Business
{
    public class clsGlobal
    {
        public static clsEmployee LoggedInEmployee = new clsEmployee();
        public static string GenerateGUID()
        {

            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();

        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {

            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    return false;
                }
            }

            return true;

        }

        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            // Full file name. Change your file name   
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;

        }

        public static bool CopyImageToProjectImagesFolder(ref string ImageName)
        {
            // Get the path to the images folder relative to the application directory
            string DestinationFolder = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "PersonImages");

            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string DestinationFile = Path.Combine(DestinationFolder, ReplaceFileNameWithGUID(ImageName));//كده بدلنا الاسم القديم باسم عبارة عن جويد + الاكستنشن
            //كده معانا الصوره القديمة (مكانها واسمها ) موجوده في ) imgage name
            //كده معانا الصوره الجديدة (مكانها واسمها ) موجوده في ) destinationFile

            try
            {
                File.Copy(ImageName, DestinationFile, true);
            }
            catch (IOException )
            {
                return false;
            }

            ImageName = DestinationFile;
            return true;
        }


    }
}
