using ProjectCheckSum.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCheckSum.Model
{
    class Log
    {
        public static void LogMe(string message, bool firstBreakLine = true, bool secondBreakLine = false)
        {
            DataViewModel.myLog += message + (firstBreakLine == true ? Environment.NewLine : "") + (secondBreakLine == true ? Environment.NewLine : "") ;
        }
    }
}
