using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCheckSum_V2.ViewModel;

namespace ProjectCheckSum_V2.Model.Watch
{
    class Log
    {
        public static void Write(string text = "", bool newLine = true)
        {
            Store.Log += DateTime.Now.ToString("dd/MM/yyyy hh:mm:ss tt") + " => " + text + ((newLine) ? Environment.NewLine : "");
        }
    }
}
