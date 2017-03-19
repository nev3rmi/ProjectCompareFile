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
                    Folder folder = new Folder();
                    folder.path = childDirectories[i];
                    folder.label = childDirectories[i].Substring(0, 4);
                    Store.ListOfFolder.Add(folder);
                    Console.WriteLine(folder.path);
                    GetSubFolder(childDirectories[i]);
                }
            }
            catch (Exception)
            {

            }
        }
    }
}
