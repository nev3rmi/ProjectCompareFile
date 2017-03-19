using ProjectCheckSum_V2.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace ProjectCheckSum_V2.Model
{
    class File : Folder
    {
        public string fileName { get; set; }
        public long fileSize { get; set; }
        public string fileExtension { get; set; }
        public DateTime fileModifyDate { get; set; }
        public string fileSHA { get; set; }
        public string fileLocation { get; set; }
        

        public void GetFile(string path)
        {
            try
            {
                string[] files = Directory.GetFiles(path);
                Console.WriteLine(path);
                for (int i = 0; i < files.Length; i++)
                {
                    string extension = Path.GetExtension(files[i]);
                    if (Setting.validExtensions.Contains(extension))
                    {
                        DoWork(files[i]);
                    }
                }
            }
            catch (Exception)
            {

            }
            
        }


        private static void DoWork(string filePath)
        {
            try
            {
                File myFile = new File();
                var myFileInfo = new System.IO.FileInfo(filePath);

                myFile.fileSHA = Hash.GetSHA1Hash(filePath);
                myFile.fileName = Path.GetFileName(filePath);
                myFile.fileExtension = Path.GetExtension(filePath);
                myFile.fileLocation = filePath;
                myFile.fileSize = myFileInfo.Length;
                myFile.fileModifyDate = myFileInfo.LastAccessTimeUtc;


                Store.ListOfFile.Add(myFile);

                //DataViewModel.myDataTable.Rows.Add(new Object[] { myFile.FileName, myFile.FileExtension, myFile.FileLocation, myFile.FileSHA, myFile.FileSize, myFile.ModifyDate });

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

        public void GetAllFiles(string path)
        {
            var listOfFile = new List<File>();
            string[] filePaths = Directory.GetFiles(path);

            foreach (var filePath in filePaths)
            {
                File myFile = new File();
                var myFileInfo = new System.IO.FileInfo(filePath);
                myFile.fileName = myFileInfo.FullName;

                Store.ListOfFile.Add(myFile);
            }
        }

        public static FileStream GetFileStream(string pathName)
        {
            return (new FileStream(pathName, System.IO.FileMode.Open,
                      FileAccess.Read, System.IO.FileShare.ReadWrite));
        }
    }
}
