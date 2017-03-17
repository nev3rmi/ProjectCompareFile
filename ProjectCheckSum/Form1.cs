using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjectCheckSum
{
    public partial class Form1 : Form
    {
        private List<String> listOfFilesToBeEncrypt = new List<string>();
        private List<FileInfoClass> ListOfFileAndItInfo = new List<FileInfoClass>();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Start();
        }

        

        private void Start() {
            // Get List Of File
            var StartTime = DateTime.Today;
            Console.Write(StartTime);
            GetAllFolderAndFile("C:\\");
            var EndTime = DateTime.Today;
            Console.Write(EndTime);
            ShowWork();
        }

        private void ShowWork() {
            foreach (var File in ListOfFileAndItInfo) {
                richTextBox1.Text += ("File Name: " + File.FileName + " - File Extension:" + File.FileExtension + " - File SHA:" + File.FileSHA + " - File Location:" + File.FileLocation) + Environment.NewLine; 
            }
        }

        private void DoWork(string filePath) {
            FileInfoClass myFile = new FileInfoClass();
            myFile.FileSHA = GetSHA1Hash(filePath);
            myFile.FileName = Path.GetFileName(filePath);
            myFile.FileExtension = Path.GetExtension(filePath);
            myFile.FileLocation = filePath;
            ListOfFileAndItInfo.Add(myFile);
            //myFile = null;
            // Show It
            Console.Write("File Name: " + myFile.FileName + " - File Extension:" + myFile.FileExtension + " - File SHA:" + myFile.FileSHA + " - File Location:" + myFile.FileLocation + Environment.NewLine);
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

                var validExtensions = new[]
                {
                ".txt",
                ".doc",
                ".docx",
                ".xls",
                ".xlsx",
                ".ppt",
                ".pptx",
                ".odt",
                ".jpg",
                ".png",
                ".csv",
                ".sql",
                ".mdb",
                ".sln",
                ".php",
                ".asp",
                ".aspx",
                ".html",
                ".xml",
                ".psd",
                ".3gp", ".7z", ".aac", ".ace", ".aif", ".arj", ".asf", ".avi", ".bin", ".bz2", ".gz", ".gzip", ".img", ".iso", ".lzh", ".m4a", ".m4v", ".mkv", ".mov", ".mp3", ".mp4", ".mpa", ".mpe", ".mpeg", ".mpg", ".msi", ".msu", ".ogg", ".ogv", ".pdf", ".plj", ".pps", ".ppt", ".qt", ".r0*", ".r1*", ".ra", ".rar", ".rm", ".rmvb", ".sea", ".sit", ".sitx", ".tar", ".tif", ".tiff", ".wav", ".wma", ".wmv", ".z", ".zip"
            };

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

        }
    }
}
