using ProjectCheckSum_V2.Model.Checker;
using ProjectCheckSum_V2.Model.Watch;
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

        public void GetSubFolder(string path)
        {
            try
            {

                string[] childDirectories = Directory.GetDirectories(path);

                for (int i = 0; i < childDirectories.Length; i++)
                {
                    if (!Setting.folderToRemove.Contains(childDirectories[i]) && Check.CanRead(childDirectories[i]))
                    {
                        Folder folder = new Folder();
                        folder.path = childDirectories[i];
                        folder.label = childDirectories[i].Substring(0, 3);
                        Store.ListOfFolder.Add(folder);
                        //Console.WriteLine(folder.path);
                        GetSubFolder(childDirectories[i]);
                    }
                }
            }
            catch (Exception ex)
            {
                Log.Write("Error: " + ex.Message);
            }
        }

        public void RemoveFolder(string path)
        {
            try
            {

            }
            catch (Exception)
            {

            }
        }
    }
}
