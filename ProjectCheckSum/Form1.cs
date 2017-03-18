using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCheckSum
{
    public partial class Form1 : Form
    {
        private List<String> listOfFilesToBeEncrypt = new List<string>();
        private List<FileInfoClass> ListOfFileAndItInfo = new List<FileInfoClass>();
        private string Drives = "D:\\";
        private string[] validExtensions = new[]{
                                                    ".txt", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".odt", ".jpg", ".png", ".csv", ".sql",
                                                    ".mdb", ".sln", ".php", ".asp", ".aspx", ".html", ".xml", ".psd",
                                                    ".3gp", ".7z", ".aac", ".ace", ".aif", ".arj", ".asf", ".avi", ".bin", ".bz2", ".gz", ".gzip",
                                                    ".img", ".iso", ".lzh", ".m4a", ".m4v", ".mkv", ".mov", ".mp3", ".mp4", ".mpa", ".mpe", ".mpeg",
                                                    ".mpg", ".msi", ".msu", ".ogg", ".ogv", ".pdf", ".plj", ".pps", ".ppt", ".qt", ".r0*", ".r1*",
                                                    ".ra", ".rar", ".rm", ".rmvb", ".sea", ".sit", ".sitx", ".tar", ".tif", ".tiff", ".wav", ".wma",
                                                    ".wmv", ".z", ".zip"
            //, ".exe", ".dll"
                                                };

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Start();
        }



        private void Start()
        {
            // Get List Of File

            ConsoleRich("|-> Information:", true);
            ConsoleRich("Path to Scan: [ " + Drives + " ]");
            ConsoleRich("Start: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), true);



            if (Drives == "All")
            {
                ConsoleRich("|-> Scan Drive:", true);
                ConsoleRich("-> Scan Start - " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));

                DriveInfo[] allDrives = DriveInfo.GetDrives();
                var drive = "";
                foreach (DriveInfo d in allDrives)
                {
                    drive = d.Name;
                    var StartScan = DateTime.Now;
                    ConsoleRich("Drive: [ " + drive + " ] -> Start: " + StartScan.ToString("dd/MM/yyyy hh:mm:ss tt"));
                    GetAllFolderAndFile(drive);
                    var EndScan = DateTime.Now;
                    ConsoleRich("Drive: [ " + drive + " ] -> End: " + EndScan.ToString("dd/MM/yyyy hh:mm:ss tt"));
                    ConsoleRich("|| Total Scan Drive [ " + drive + " ]: " + (EndScan - StartScan).ToString());
                }
            }
            else
            {
                ConsoleRich("|-> Scan Path:", true);
                ConsoleRich("-> Scan Start - " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));

                var drives = Drives.Split(',');
                foreach (string drive in drives)
                {
                    var StartScan = DateTime.Now;
                    ConsoleRich("Path: [ " + drive + " ] -> Start: " + StartScan.ToString("dd/MM/yyyy hh:mm:ss tt"));
                    GetAllFolderAndFile(drive);
                    var EndScan = DateTime.Now;
                    ConsoleRich("Path: [ " + drive + " ] -> End: " + EndScan.ToString("dd/MM/yyyy hh:mm:ss tt"));
                    ConsoleRich("|| Total Scan Path [ " + drive + " ]: " + (EndScan - StartScan).ToString());
                }
            }
            ConsoleRich("-> Scan Done - " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), true);


            ConsoleRich("|-> Show File:", true);
            ShowWork();
            ConsoleRich("Done", true);
        }

        private void ConsoleRich(string String, bool secondBreakLine = false)
        {
            richTextBox1.Text += String + Environment.NewLine + (secondBreakLine == true ? Environment.NewLine : "");
        }

        private void ShowWork()
        {
            DataTable data = new DataTable();

            //FileInfoClass a = new FileInfoClass();

            //foreach (var b in a.GetType().GetProperties()) {
            //    data.Columns.Add("FileLocation");
            //} 

            data.Columns.Add("Name");
            data.Columns.Add("Extension");
            data.Columns.Add("Location");
            data.Columns.Add("SHA");
            data.Columns.Add("Size");
            data.Columns.Add("ModifyDate");

            foreach (FileInfoClass file in ListOfFileAndItInfo)
            {
                data.Rows.Add(new Object[] { file.FileName, file.FileExtension, file.FileLocation, file.FileSHA, file.FileSize, file.ModifyDate });
            }

            dataGridView1.DataSource = data;
            dataGridView1.Sort(this.dataGridView1.Columns[3],
                                    ListSortDirection.Ascending);

        }

        private void DoWork(string filePath)
        {
            try
            {
                FileInfoClass myFile = new FileInfoClass();
                var myFileInfo = new System.IO.FileInfo(filePath);

                myFile.FileSHA = GetSHA1Hash(filePath);
                myFile.FileName = Path.GetFileName(filePath);
                myFile.FileExtension = Path.GetExtension(filePath);
                myFile.FileLocation = filePath;
                try
                {
                    myFile.FileSize = BytesToString(myFileInfo.Length);
                    myFile.ModifyDate = myFileInfo.LastAccessTimeUtc.ToString();
                }
                catch (FileNotFoundException e)
                {

                }
               
                ListOfFileAndItInfo.Add(myFile);
                //myFile = null;
                // Show It
                Console.Write(
                    "File Name: " + myFile.FileName +
                    " - File Extension:" + myFile.FileExtension +
                    " - File SHA:" + myFile.FileSHA +
                    " - File Location:" + myFile.FileLocation +
                    " - File Size:" + myFile.FileSize +
                    " - Modify Date:" + myFile.ModifyDate +
                    Environment.NewLine);
            }
            catch (Exception e)
            {

            }
            
            
        }

        private static String BytesToString(long byteCount)
        {
            string[] suf = { "B", "KB", "MB", "GB", "TB", "PB", "EB" }; //Longs run out around EB
            if (byteCount == 0)
                return "0" + suf[0];
            long bytes = Math.Abs(byteCount);
            int place = Convert.ToInt32(Math.Floor(Math.Log(bytes, 1024)));
            double num = Math.Round(bytes / Math.Pow(1024, place), 1);
            return (Math.Sign(byteCount) * num).ToString() + suf[place];
        }

        private static System.IO.FileStream GetFileStream(string pathName)
        {
            return (new System.IO.FileStream(pathName, System.IO.FileMode.Open,
                      System.IO.FileAccess.Read, System.IO.FileShare.ReadWrite));
        }


        // Get SHA1 Of a single File
        public static string GetSHA1Hash(string pathName)
        {
            string strResult = "";
            string strHashData = "";

            byte[] arrbytHashValue;
            System.IO.FileStream oFileStream = null;

            System.Security.Cryptography.SHA1CryptoServiceProvider oSHA1Hasher =
                       new System.Security.Cryptography.SHA1CryptoServiceProvider();

            try
            {
                oFileStream = GetFileStream(pathName);
                arrbytHashValue = oSHA1Hasher.ComputeHash(oFileStream);
                oFileStream.Close();

                strHashData = System.BitConverter.ToString(arrbytHashValue);
                strHashData = strHashData.Replace("-", "");
                strResult = strHashData;
            }
            catch (System.Exception ex)
            {
                System.Windows.Forms.MessageBox.Show(ex.Message, "Error!",
                         System.Windows.Forms.MessageBoxButtons.OK,
                         System.Windows.Forms.MessageBoxIcon.Error,
                         System.Windows.Forms.MessageBoxDefaultButton.Button1);
            }

            return (strResult);
        }

        private void GetAllFolderAndFile(string location)
        {
            try
            {

                string[] files = Directory.GetFiles(location);
                string[] childDirectories = Directory.GetDirectories(location);



                for (int i = 0; i < files.Length; i++)
                {
                    string extension = Path.GetExtension(files[i]);
                    if (validExtensions.Contains(extension))
                    {
                        DoWork(files[i]);
                    }
                }

                for (int i = 0; i < childDirectories.Length; i++)
                {
                    GetAllFolderAndFile(childDirectories[i]);
                }
            }
            catch (UnauthorizedAccessException)
            {

            }
            catch (DirectoryNotFoundException)
            {

            }
            catch (FileNotFoundException)
            {

            }

        }
    }
}
