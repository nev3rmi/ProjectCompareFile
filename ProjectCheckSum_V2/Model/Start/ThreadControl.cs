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

            Log.Write("Test");

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
                Log.Write("Done");
            }
        }

        private void threadLoadFolders(string path)
        {
            Folder folder = new Folder();
            folder.GetSubFolder(path);
        }
    }
}
