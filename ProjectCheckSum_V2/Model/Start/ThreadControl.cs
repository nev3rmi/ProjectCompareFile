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

        }

        private void loadDrives()
        {
            Drive drives = new Drive();
            Store.ListOfDrive = drives.GetAllDrives();
        }

        private void loadScan()
        {
            //foreach (Drive d in Store.ListOfDrive)
            //{
            //    Thread newthread = new Thread(new ThreadStart(() => threadLoadFolders(d.path)));
            //    newthread.Start();
            //}

            Thread newthread = new Thread(new ThreadStart(() => threadLoadFolders("B:\\")));
            newthread.Start();
            newthread.Join();
        }

        private void threadLoadFolders(string path)
        {
            Folder folder = new Folder();
            folder.GetSubFolder(path);
        }
    }
}
