﻿using ProjectCheckSum_V2.Model.Watch;
using ProjectCheckSum_V2.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectCheckSum_V2.Model.Start
{
    class ThreadControl
    {
        public void ThreadBegin()
        {

            Log.Write("|---> Begin To Scan:");
            Log.Write("|-> Scan Drives");
            // Get Drives
            Thread _loadDrives = new Thread(new ThreadStart(loadDrives));
            _loadDrives.Start();
            _loadDrives.Join();

            // Get Drives
            Log.Write("|-> Scan Folders");
            Thread _loadFolders = new Thread(new ThreadStart(loadScan));
            _loadFolders.Start();
            _loadFolders.Join();

            // Console Folders
            //Thread _consoleFolder = new Thread(new ThreadStart(consoleFolder));
            //_consoleFolder.Start();
            //_consoleFolder.Join();

            Log.Write("|-> Scan Files");
            // Get Files
            Thread _loadFiles = new Thread(new ThreadStart(loadFile));
            _loadFiles.Start();
            _loadFiles.Join();

            Log.Write("|-> Build Folders");
            // Build table
            Thread _loadTable = new Thread(new ThreadStart(buildDatatable));
            _loadTable.Start();
            _loadTable.Join();

            Log.Write("|-> Render View");
            // Extract Data
            Thread _extractData = new Thread(new ThreadStart(extractData));
            _extractData.Start();
            _extractData.Join();

            Log.Write("|-> Finish");
            Log.Write("Total Scan Files: " + Store.ListOfFile.Count().ToString());
        }

        private void extractData()
        {
            foreach (File myFile in Store.ListOfFile)
            {
                Store.myDataTable.Rows.Add(new Object[] { myFile.fileName, myFile.fileExtension, myFile.fileLocation, myFile.fileSHA, myFile.fileSize, myFile.fileModifyDate });
            }
        }

        private void buildDatatable()
        {
            try
            {
                Store.myDataTable.Columns.Add("Name");
                Store.myDataTable.Columns.Add("Extension");
                Store.myDataTable.Columns.Add("Location");
                Store.myDataTable.Columns.Add("SHA");
                Store.myDataTable.Columns.Add("Size");
                Store.myDataTable.Columns.Add("ModifyDate");
                
            }
            catch (Exception)
            {

            }
        }

        private void loadFile()
        {
            List<Thread> myThread = new List<Thread>();
            foreach (var folder in Store.ListOfFolder)
            {
                Thread newThread = new Thread(new ThreadStart(() => threadLoadFiles(folder.path)));
                myThread.Add(newThread);
            }

            for (var i = 0; i < Store.ListOfFolder.Count(); i++)
            {
                myThread[i].Start();
            }
            for (var i = 0; i < Store.ListOfFolder.Count(); i++)
            {
                myThread[i].Join();
            }

            //foreach (Folder folder in Store.ListOfFolder)
            //{
            //    threadLoadFiles(folder.path);
            //    //Console.WriteLine(folder.path);
            //}

        }

        private void consoleFolder()
        {
            //foreach (var f in Store.ListOfFolder)
            //{
            //    Log.Write("Drives: " + f.label + ", Path: " + f.path);
            //}

            //var full = Store.ListOfDrive.Join(Store.ListOfFolder, x => x.label, y => y.label, (x, y) => new { a = x, b = y });
            //foreach (var d in full)
            //{
            //    Console.WriteLine("Drives: " + d.a.label + ", Path: " + d.b.path);
            //}

        }

        private void loadDrives()
        {
            Drive drives = new Drive();
            Store.ListOfDrive = drives.GetAllDrives();
        }

        private void loadScan()
        {
            List<Thread> myListThread = new List<Thread>();

            if (Setting.Drives == "All")
            {
                foreach (Drive d in Store.ListOfDrive)
                {
                    Thread newthread = new Thread(new ThreadStart(() => threadLoadFolders(d.path)));
                    myListThread.Add(newthread);
                }
            }
            else
            {
                var drives = Setting.Drives.Split(',');
                foreach (string drive in drives)
                {
                    Thread newthread = new Thread(new ThreadStart(() => threadLoadFolders(drive)));
                    newthread.Name = drive;
                    myListThread.Add(newthread);
                }
            }

            for (var i = 0; i < myListThread.Count(); i++)
            {
                myListThread[i].Start();
            }
            for (var i = 0; i < myListThread.Count(); i++)
            {
                myListThread[i].Join();
            }
        }

        private void threadLoadFolders(string path)
        {
            Folder folder = new Folder();
            folder.GetSubFolder(path);
        }

        private void threadLoadFiles(string path)
        {
            File file = new File();
            file.GetFile(path);
        }
    }
}
