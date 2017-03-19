using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCheckSum.ViewModel;

namespace ProjectCheckSum.Model
{
    class Files
    {
        public static List<String> listOfFilesToBeEncrypt = new List<string>();
        public static List<FileInfoClass> ListOfFileAndItInfo = new List<FileInfoClass>();

        public static void GetAllFolderAndFile(string location)
        {
            try
            {

                string[] files = Directory.GetFiles(location);
                string[] childDirectories = Directory.GetDirectories(location);

                for (int i = 0; i < files.Length; i++)
                {
                    string extension = Path.GetExtension(files[i]);
                    if (Setting.validExtensions.Contains(extension))
                    {
                        DataViewModel.myTotalScanFile += 1;
                        DoWork(files[i]);
                    }
                }

                for (int i = 0; i < childDirectories.Length; i++)
                {
                    GetAllFolderAndFile(childDirectories[i]);
                }
            }
            catch (Exception)
            {

            }
        }
        public static FileStream GetFileStream(string pathName)
        {
            return (new FileStream(pathName, System.IO.FileMode.Open,
                      FileAccess.Read, System.IO.FileShare.ReadWrite));
        }

        private static void AnalysicFiles(string filePath)
        {
            try
            {
                FileInfoClass myFile = new FileInfoClass();
                var myFileInfo = new System.IO.FileInfo(filePath);

                myFile.FileName = Path.GetFileName(filePath);
                myFile.FileExtension = Path.GetExtension(filePath);
                myFile.FileLocation = filePath;
                myFile.FileSize = Converter.BytesToString(myFileInfo.Length);
                myFile.ModifyDate = myFileInfo.LastAccessTimeUtc.ToString();

                ListOfFileAndItInfo.Add(myFile);
            }catch (Exception){

            }
        }

        private static void DoWork(string filePath)
        {
            try
            {
                FileInfoClass myFile = new FileInfoClass();
                var myFileInfo = new System.IO.FileInfo(filePath);

                myFile.FileSHA = Hash.GetSHA1Hash(filePath);
                myFile.FileName = Path.GetFileName(filePath);
                myFile.FileExtension = Path.GetExtension(filePath);
                myFile.FileLocation = filePath;
                myFile.FileSize = Converter.BytesToString(myFileInfo.Length);
                myFile.ModifyDate = myFileInfo.LastAccessTimeUtc.ToString();


                ListOfFileAndItInfo.Add(myFile);

                DataViewModel.myDataTable.Rows.Add(new Object[] { myFile.FileName, myFile.FileExtension, myFile.FileLocation, myFile.FileSHA, myFile.FileSize, myFile.ModifyDate });

                //// Show It
                //Console.Write(
                //    "File Name: " + myFile.FileName +
                //    " - File Extension:" + myFile.FileExtension +
                //    " - File SHA:" + myFile.FileSHA +
                //    " - File Location:" + myFile.FileLocation +
                //    " - File Size:" + myFile.FileSize +
                //    " - Modify Date:" + myFile.ModifyDate +
                //    Environment.NewLine);

                // Clean it
                myFile = null;

            }
            catch (Exception)
            {

            }


        }
    }

}
