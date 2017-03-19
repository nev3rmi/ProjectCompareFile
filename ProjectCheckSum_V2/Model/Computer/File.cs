using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCheckSum_V2.Model
{
    class File : Folder
    {
        public string fileName { get; set; }
        public long fileSize { get; set; }
        public string fileExtension { get; set; }
        public DateTime fileModifyDate { get; set; }
        public string fileSHA { get; set; }
    }
}
