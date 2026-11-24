using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DVLD_Presentation.Global_Classes
{
    internal class clsUtil
    {    
        public static string GenerateGUID()
        {
            // Generate a new GUID
            Guid guid = Guid.NewGuid();

            // convert the GUID to a string
            return guid.ToString();
        }
        public static bool CreateFolderIfDoesNotExect(string FolderPath)
        {
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    MessageBox.Show("" + ex.Message);
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
        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            string DestinationFolder = @"C:\Users\Ahmed\Documents\DeskTopApp\DVLD_Presentation\DVLDImage";

            if (!CreateFolderIfDoesNotExect(DestinationFolder))
            {
                return false;
            }
            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, destinationFile, true);
                
            }
            catch (IOException IOX)
            {
                MessageBox.Show(IOX.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
            sourceFile = destinationFile;
            return true;
        }
    }
}
     



        