using ProjectCheckSum_V2.Model.Watch;
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
            // Get Drives
            Thread _loadDrives = new Thread(new ThreadStart(loadDrives));
            _loadDrives.Start();
            _loadDrives.Join();

            // Get Drives
            Thread _loadFolders = new Thread(new ThreadStart(loadScan));
            _loadFolders.Start();
            _loadFolders.Join();

            // Console Folders
            Thread _consoleFolder = new Thread(new ThreadStart(consoleFolder));
            _consoleFolder.Start();
            _consoleFolder.Join();

            // Get Files
            Thread _loadFiles = new Thread(new ThreadStart(loadFile));
            _loadFiles.Start();
            _loadFiles.Join();

            Log.Write(Store.ListOfFile.Count().ToString());
        }

        private void loadFile()
        {
            //List<Thread> myThread = new List<Thread>();
            //foreach (var folder in Store.ListOfFolder)
            //{
            //    Thread newThread = new Thread(new ThreadStart(() => threadLoadFiles(folder.path)));
            //    myThread.Add(newThread);
            //}

            //for (var i = 0; i < Store.ListOfFolder.Count(); i++)
            //{
            //    myThread[i].Start();
            //}
            //for (var i = 0; i < Store.ListOfFolder.Count(); i++)
            //{
            //    myThread[i].Join();
            //}

            foreach (Folder folder in Store.ListOfFolder)
            {
                threadLoadFiles(folder.path);
                //Console.WriteLine(folder.path);
            }

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
