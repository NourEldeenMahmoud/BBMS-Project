using System;
using System.Drawing;
using System.IO;
using System.Windows.Forms;

namespace BBMS_Business
{
    public static class clsImageManager
    {
        private const string PERSON_IMAGES_FOLDER = "PersonImages";
        private const string DEFAULT_IMAGE_FOLDER = "Resources";
        private const string ICONS_FOLDER = "Icons";

        // Default placeholder images
        public static Image DefaultPersonImage { get; private set; }
        public static Image DefaultBloodBagImage { get; private set; }
        public static Image DefaultIconImage { get; private set; }

        static clsImageManager()
        {
            try
            {
                // Initialize default images
                DefaultPersonImage = Image.FromFile(Path.Combine(Application.StartupPath, ICONS_FOLDER, "man.png"));
                DefaultBloodBagImage = Image.FromFile(Path.Combine(Application.StartupPath, DEFAULT_IMAGE_FOLDER, "general-blood-bag.png"));
                DefaultIconImage = Image.FromFile(Path.Combine(Application.StartupPath, ICONS_FOLDER, "add.png"));
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading default images: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public static Image GetPersonImage(string imagePath)
        {
            if (string.IsNullOrEmpty(imagePath))
                return DefaultPersonImage;

            string fullPath = Path.Combine(Application.StartupPath, PERSON_IMAGES_FOLDER, imagePath);
            return File.Exists(fullPath) ? Image.FromFile(fullPath) : DefaultPersonImage;
        }

        public static Image GetBloodBagImage(string bloodType)
        {
            string imageName = bloodType switch
            {
                "A+" => "blood-bag A+.png",
                "A-" => "blood-bag A-.png",
                "B+" => "blood-bag B+.png",
                "B-" => "blood-bag B-.png",
                "AB+" => "blood-bag AB+.png",
                "AB-" => "blood-bag AB-.png",
                "O+" => "blood-bag O+.png",
                "O-" => "blood-bag O-.png",
                _ => "general-blood-bag.png"
            };

            string fullPath = Path.Combine(Application.StartupPath, DEFAULT_IMAGE_FOLDER, imageName);
            return File.Exists(fullPath) ? Image.FromFile(fullPath) : DefaultBloodBagImage;
        }

        public static Image GetIconImage(string iconName)
        {
            string fullPath = Path.Combine(Application.StartupPath, ICONS_FOLDER, iconName);
            return File.Exists(fullPath) ? Image.FromFile(fullPath) : DefaultIconImage;
        }

        public static bool SavePersonImage(string sourcePath, string destinationFileName)
        {
            try
            {
                string destinationFolder = Path.Combine(Application.StartupPath, PERSON_IMAGES_FOLDER);
                
                // Create directory if it doesn't exist
                if (!Directory.Exists(destinationFolder))
                    Directory.CreateDirectory(destinationFolder);

                string destinationPath = Path.Combine(destinationFolder, destinationFileName);
                
                // Delete existing file if it exists
                if (File.Exists(destinationPath))
                    File.Delete(destinationPath);

                // Copy the new file
                File.Copy(sourcePath, destinationPath);
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving person image: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        public static void CleanupUnusedImages()
        {
            try
            {
                string personImagesFolder = Path.Combine(Application.StartupPath, PERSON_IMAGES_FOLDER);
                if (!Directory.Exists(personImagesFolder))
                    return;

                // Get all image files
                string[] imageFiles = Directory.GetFiles(personImagesFolder, "*.*");
                foreach (string imageFile in imageFiles)
                {
                    // Check if image is referenced in database
                    if (!IsImageReferenced(Path.GetFileName(imageFile)))
                    {
                        try
                        {
                            File.Delete(imageFile);
                        }
                        catch (Exception ex)
                        {
                            // Log error but continue with other files
                            Console.WriteLine($"Error deleting unused image {imageFile}: {ex.Message}");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error cleaning up unused images: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private static bool IsImageReferenced(string imageFileName)
        {
            // TODO: Implement database check to see if image is referenced
            // This should check if the image is used by any person in the database
            return false;
        }
    }
} 