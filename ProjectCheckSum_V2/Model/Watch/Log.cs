using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCheckSum_V2.ViewModel;
using System.IO;

namespace ProjectCheckSum_V2.Model.Watch
{
    class Log
    {
        public static void Write(string text = "", bool newLine = true)
        {
            Store.Log += DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + " => " + text + ((newLine) ? Environment.NewLine : "");
        }

        public static void Export(string path)
        {
            try
            {

                // Delete the file if it exists.
                if (System.IO.File.Exists(path))
                {
                    // Note that no lock is put on the
                    // file and the possibility exists
                    // that another process could do
                    // something with it between
                    // the calls to Exists and Delete.
                    System.IO.File.Delete(path);
                }

                // Create the file.
                using (FileStream fs = System.IO.File.Create(path))
                {
                    Byte[] info = new UTF8Encoding(true).GetBytes(Store.Log);
                    // Add some information to the file.
                    fs.Write(info, 0, info.Length);
                }

                // Open the stream and read it back.
                using (StreamReader sr = System.IO.File.OpenText(path))
                {
                    string s = "";
                    while ((s = sr.ReadLine()) != null)
                    {
                        Console.WriteLine(s);
                    }
                }
            }

            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }
        }
    }
}
