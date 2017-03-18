using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCheckSum.Model
{
    class Setting
    {
        public static string Drives = "All";
        public static string[] validExtensions = new[]{
                                                    ".txt", ".doc", ".docx", ".xls", ".xlsx", ".ppt", ".pptx", ".odt", ".jpg", ".png", ".csv", ".sql",
                                                    ".mdb", ".sln", ".php", ".asp", ".aspx", ".html", ".xml", ".psd",
                                                    ".3gp", ".7z", ".aac", ".ace", ".aif", ".arj", ".asf", ".avi", ".bin", ".bz2", ".gz", ".gzip",
                                                    ".img", ".iso", ".lzh", ".m4a", ".m4v", ".mkv", ".mov", ".mp3", ".mp4", ".mpa", ".mpe", ".mpeg",
                                                    ".mpg", ".msi", ".msu", ".ogg", ".ogv", ".pdf", ".plj", ".pps", ".ppt", ".qt", ".r0*", ".r1*",
                                                    ".ra", ".rar", ".rm", ".rmvb", ".sea", ".sit", ".sitx", ".tar", ".tif", ".tiff", ".wav", ".wma",
                                                    ".wmv", ".z", ".zip"
            //, ".exe", ".dll"
                                                };
        //public static string[] validExtensions = new[]{
        //                                            ".txt" };

    }
}
