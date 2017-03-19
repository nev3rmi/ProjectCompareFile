using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCheckSum_V2.Model
{
    class Drive
    {
        public string label { get; set; }

        public string path { get; set; }
        public long totalSize { get; set; }

        public List<Drive> GetAllDrives()
        {
            var Drives = new List<Drive>();
            
            DriveInfo[] allDrives = DriveInfo.GetDrives();
            foreach (DriveInfo drive in allDrives) {
                try
                {
                    var thisDrive = new Drive();
                    thisDrive.path = drive.Name;
                    thisDrive.totalSize = drive.TotalSize;
                    Drives.Add(thisDrive);
                }
                catch (Exception)
                {

                }
            }
            return Drives;
        }

        public void AnalystDrive(string DriveName)
        {
            DriveInfo sysDrive = new DriveInfo(DriveName);
            var thisDrive = new Drive();
            thisDrive.label = sysDrive.Name;
            thisDrive.totalSize = sysDrive.TotalSize;
        }
    }
}
