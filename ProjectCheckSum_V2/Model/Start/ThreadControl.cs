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
            Thread _loadFolders = new Thread(new ThreadStart(loadFolders));
            _loadFolders.Start();
            _loadFolders.Join();

        }

        private void loadDrives()
        {
            Drive drives = new Drive();
            Store.ListOfDrive = drives.GetAllDrives();
        }

        private void loadFolders()
        {
            foreach (Drive d in Store.ListOfDrive)
            {
                Thread newthread = new Thread(new ThreadStart(() => threadLoadFolders(d.path)));
                newthread.Start();
                newthread.Join();
            }
        }

        private void threadLoadFolders(string path)
        {
            Folder folder = new Folder();
            Store.ListOfFolder = folder.GetSubFolder(path);
        }


        //private void AutoGetFolder()
        //{
        //    foreach (var drive in Store.ListOfDrive)
        //    {
        //        try
        //        {
        //            threadLoadFolders(drive.path);
        //        }
        //        catch (Exception ex)
        //        {

        //        }
        //    }
        //}

        //private void threadLoadFolders(string path)
        //{
        //    try
        //    {
        //        Thread _loadFolders = new Thread(new ThreadStart(() => loadFolders(path)));
        //        _loadFolders.Start();
        //        _loadFolders.Join();
        //    }
        //    catch (Exception)
        //    {
        //        return;
        //    }

        //}

        //private void loadFolders(string path)
        //{
        //    File file = new Model.File();
        //    file.path = path;
        //    Store.WorkingList.Add(file);

        //    Folder folders = new Folder();
        //    folders.GetAllFolder();
        //}

        //private void loadFiles(string path)
        //{
        //    File file = new File();
        //    file.GetAllFiles(path);
        //}
    }
}
