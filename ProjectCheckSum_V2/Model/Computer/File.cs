using ProjectCheckSum_V2.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCheckSum_V2.Model
{
    class File : Folder
    {
        public string fileName { get; set; }
        public long fileSize { get; set; }
        public string fileExtension { get; set; }
        public DateTime fileModifyDate { get; set; }
        public string fileSHA { get; set; }

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
    }
}
