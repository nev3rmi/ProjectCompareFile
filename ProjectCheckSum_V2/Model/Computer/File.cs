using ProjectCheckSum_V2.Model.Watch;
using ProjectCheckSum_V2.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading;

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
                //Console.WriteLine(path);
                List<Thread> myThread = new List<Thread>();

                for (int i = 0; i < files.Length; i++)
                {
                    string extension = Path.GetExtension(files[i]);
                    if (Setting.validExtensions.Contains(extension))
                    {
                        Store.TotalFiles++;

                        //Console.WriteLine(files[i]);

                        //try
                        //{
                        //    Thread newThread = new Thread(
                        //        new ThreadStart(() => DoWork(files[i]))
                        //    );
                        //    newThread.Name = files[i];
                        //    myThread.Add(newThread);
                        //}
                        //catch (Exception ex)
                        //{
                        //    Log.Write("Cannot Thread File: " + files[i] + "-> Error: " + ex.Message);
                            FindFiles(files[i]);
                        //}
                        
                    }
                }
                //for (var i = 0; i < myThread.Count(); i++)
                //{
                //    myThread[i].Start();
                //    Log.Write("Process: "+ myThread[i].Name);
                //}
                //for (var i = 0; i < myThread.Count(); i++)
                //{
                //    myThread[i].Join();
                //    Log.Write("Done: "+ myThread[i].Name);
                //}
            }
            catch (Exception ex)
            {
                Log.Write("Error: " + ex.Message);
            }
            
        }

        public static void FindFiles(string filePath)
        {
            try
            {
                File myFile = new File();
                var myFileInfo = new System.IO.FileInfo(filePath);

                //myFile.fileSHA = Hash.GetSHA1Hash(filePath);
                myFile.fileName = Path.GetFileName(filePath);
                //myFile.fileExtension = Path.GetExtension(filePath);
                myFile.fileLocation = filePath;
                myFile.fileSize = myFileInfo.Length;
                //myFile.fileModifyDate = myFileInfo.LastAccessTimeUtc;


                Store.WorkingList.Add(myFile);
                


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

        public static void DoWork(string filePath)
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
