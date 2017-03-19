using ProjectCheckSum_V2.ViewModel;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ProjectCheckSum_V2.Model
{
    class Folder : Drive
    {
        public string totalFile { get; set; }

        public List<Folder> GetSubFolder(string path)
        {
            List<Folder> subFolder = new List<Folder>();
            try
            {

                string[] childDirectories = Directory.GetDirectories(path);

                for (int i = 0; i < childDirectories.Length; i++)
                {
                    Folder folder = new Folder();
                    folder.path = childDirectories[i];
                    subFolder.Add(folder);
                    Console.WriteLine(folder.path);
                    //GetSubFolder(childDirectories[i]);

                    //Thread myAnotherThread = new Thread(new ThreadStart(() => GetSubFolder(childDirectories[i])));
                    //myAnotherThread.Start();
                }
            }
            catch (Exception)
            {

            }
            return subFolder;
        }


        //public List<Folder> GetAllFolderInCurrentPath(string location)
        //{
        //    List<Folder> result = new List<Folder>();
        //    try
        //    {
        //        string[] childDirectories = Directory.GetDirectories(location);

        //        for (int i = 0; i < childDirectories.Length; i++)
        //        {
                    
        //            File file = new File();
        //            file.path = childDirectories[i];
        //            Store.WorkingList.Add(file);


        //            GetAllFolderInCurrentPath(childDirectories[i]);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }
        //    return result;
        //}

        //public void GetAllFolderInCurrent(string path)
        //{
        //    try
        //    {
        //        var listOfFolder = new List<Folder>();
        //        string[] childDirectories = Directory.GetDirectories(path);

        //        foreach (var dir in childDirectories)
        //        {
        //            File folder = new File();
        //            folder.path = dir;
        //            Store.WorkingList.Add(folder);
        //        }
        //    }
        //    catch (Exception)
        //    {

        //    }
        //}

        //public void GetAllFolder()
        //{
        //    //GetAllFolderInCurrent(file.path);
        //    //foreach (File file in Store.WorkingList)
        //    //{
        //    //    try
        //    //    {
        //    //        Console.WriteLine(file.path);
        //    //        GetAllFolderInCurrent(file.path);
        //    //        Store.WorkingList.Remove(file);
        //    //        Store.ListOfFolder.Add(file);
        //    //    }
        //    //    catch (Exception)
        //    //    {

        //    //    }

        //    //}
        //}
    }
}
