﻿using System;
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
        public static DataTable myPreDataTable = new DataTable();

        public static List<Folder> ListOfSysFolder = new List<Folder>();

        public static int TotalFiles = 0;
        public static int ProcessFile = 0;
        public static int DoneFile = 0;
        public static double ProcessBarValue = 0;

        // Store
        public static int TotalWorking = 0;
        public static int CurrentWorking = 0;
        public static int CurrentMyWorkingIs = 0;

    }
}
