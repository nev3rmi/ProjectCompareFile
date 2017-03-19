using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ProjectCheckSum_V2.ViewModel;

namespace ProjectCheckSum_V2.Model.Start
{
    class Start
    {
        public void Go()
        {
            ThreadControl myThread = new ThreadControl();
            myThread.ThreadBegin();




            Console.Write(Store.ListOfDrive.Count());
        }
    }
}
