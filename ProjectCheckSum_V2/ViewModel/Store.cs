using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCheckSum_V2.Model;
using System.Data;

namespace ProjectCheckSum_V2.ViewModel
{
    class Store
    {
        public static List<Drive> ListOfDrive = new List<Drive>();
        public static List<Folder> ListOfFolder = new List<Folder>();
        public static List<File> ListOfFile = new List<File>();

        public static List<File> WorkingList = new List<File>();

        public static string Log = "";

        public static DataTable myDataTable = new DataTable();

    }
}
