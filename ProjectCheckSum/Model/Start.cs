using ProjectCheckSum.ViewModel;
using System;
using System.Collections.Generic;
using System.Data;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectCheckSum.Model
{
    class Start
    {
        //private void Start()
        //{
        //    // Get List Of File

        //    ConsoleRich("|-> Information:", true);
        //    ConsoleRich("Path to Scan: [ " + Drives + " ]");
        //    ConsoleRich("Start: " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), true);



        //    if (Drives == "All")
        //    {
        //        ConsoleRich("|-> Scan Drive:", true);
        //        ConsoleRich("-> Scan Start - " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));

        //        DriveInfo[] allDrives = DriveInfo.GetDrives();
        //        var drive = "";
        //        foreach (DriveInfo d in allDrives)
        //        {
        //            drive = d.Name;
        //            var StartScan = DateTime.Now;
        //            ConsoleRich("Drive: [ " + drive + " ] -> Start: " + StartScan.ToString("dd/MM/yyyy hh:mm:ss tt"));
        //            GetAllFolderAndFile(drive);
        //            var EndScan = DateTime.Now;
        //            ConsoleRich("Drive: [ " + drive + " ] -> End: " + EndScan.ToString("dd/MM/yyyy hh:mm:ss tt"));
        //            ConsoleRich("|| Total Scan Drive [ " + drive + " ]: " + (EndScan - StartScan).ToString());
        //        }
        //    }
        //    else
        //    {
        //        ConsoleRich("|-> Scan Path:", true);
        //        ConsoleRich("-> Scan Start - " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"));

        //        var drives = Drives.Split(',');
        //        foreach (string drive in drives)
        //        {
        //            var StartScan = DateTime.Now;
        //            ConsoleRich("Path: [ " + drive + " ] -> Start: " + StartScan.ToString("dd/MM/yyyy hh:mm:ss tt"));
        //            GetAllFolderAndFile(drive);
        //            var EndScan = DateTime.Now;
        //            ConsoleRich("Path: [ " + drive + " ] -> End: " + EndScan.ToString("dd/MM/yyyy hh:mm:ss tt"));
        //            ConsoleRich("|| Total Scan Path [ " + drive + " ]: " + (EndScan - StartScan).ToString());
        //        }
        //    }
        //    ConsoleRich("-> Scan Done - " + DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt"), true);


        //    ConsoleRich("|-> Show File:", true);
        //    ShowWork();
        //    ConsoleRich("Done", true);
        //}

           

        public void Go()
        {
            Thread _buildDataTable = new Thread(new ThreadStart(buildDataTable));
            Thread _scanPath = new Thread(new ThreadStart(scanPath));
           

            _buildDataTable.Start();
            _scanPath.Start();

            // Log
            Log.LogMe("|-> Information:", true, true);
            Log.LogMe("Path to Scan: [ " + Setting.Drives + " ]", true, true);
        }

        private void buildDataTable()
        {
            // Build Header
            DataViewModel.myDataTable.Columns.Add("Name");
            DataViewModel.myDataTable.Columns.Add("Extension");
            DataViewModel.myDataTable.Columns.Add("Location");
            DataViewModel.myDataTable.Columns.Add("SHA");
            DataViewModel.myDataTable.Columns.Add("Size");
            DataViewModel.myDataTable.Columns.Add("ModifyDate");
        }

        

        private void scanPath()
        {
            try
            {
                // Log
                Log.LogMe("|-> Drives/Path:", true, true);
                Log.LogMe("-> Scanning:", true, true);
                
                if (Setting.Drives == "All")
                {

                    DriveInfo[] allDrives = DriveInfo.GetDrives();
                    var drive = "";
                    foreach (DriveInfo d in allDrives)
                    {
                        drive = d.Name;
                        var StartScan = DateTime.Now;
                        Log.LogMe("Drive: [ " + drive + " ] -> Start: " + StartScan.ToString("dd/MM/yyyy hh:mm:ss tt"));
                        Log.LogMe(drive + " In Process...");
                        Files.GetAllFolderAndFile(drive);
                        var EndScan = DateTime.Now;
                        Log.LogMe("Drive: [ " + drive + " ] -> End: " + EndScan.ToString("dd/MM/yyyy hh:mm:ss tt"));
                        Log.LogMe("|| Total Time Scan Drive [ " + drive + " ]: " + (EndScan - StartScan).ToString());
                        
                    }
                }
                else
                {
                    var drives = Setting.Drives.Split(',');
                    foreach (string drive in drives)
                    {
                        var StartScan = DateTime.Now;
                        Log.LogMe("Drive/Path: [ " + drive + " ] -> Start: " + StartScan.ToString("dd/MM/yyyy hh:mm:ss tt"));
                        Log.LogMe(drive + " In Process...");
                        Files.GetAllFolderAndFile(drive);
                        var EndScan = DateTime.Now;
                        Log.LogMe("Drive/Path: [ " + drive + " ] -> End: " + EndScan.ToString("dd/MM/yyyy hh:mm:ss tt"));
                        Log.LogMe("|| Total Time Scan Path [ " + drive + " ]: " + (EndScan - StartScan).ToString());
                    }
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
