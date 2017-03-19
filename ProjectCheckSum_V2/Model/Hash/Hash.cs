using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectCheckSum_V2.Model.Hash
{
    class Hash
    {
        // Get SHA1 Of a single File
        //public static string GetSHA1Hash(string pathName)
        //{
        //    string strResult = "";
        //    string strHashData = "";

        //    byte[] arrbytHashValue;
        //    System.IO.FileStream oFileStream = null;

        //    System.Security.Cryptography.SHA1CryptoServiceProvider oSHA1Hasher =
        //               new System.Security.Cryptography.SHA1CryptoServiceProvider();

        //    try
        //    {
        //        oFileStream = Files.GetFileStream(pathName);
        //        arrbytHashValue = oSHA1Hasher.ComputeHash(oFileStream);
        //        oFileStream.Close();

        //        strHashData = System.BitConverter.ToString(arrbytHashValue);
        //        strHashData = strHashData.Replace("-", "");
        //        strResult = strHashData;
        //    }
        //    catch (Exception)
        //    {
        //        //System.Windows.Forms.MessageBox.Show(ex.Message, "Error!",
        //        //         System.Windows.Forms.MessageBoxButtons.OK,
        //        //         System.Windows.Forms.MessageBoxIcon.Error,
        //        //         System.Windows.Forms.MessageBoxDefaultButton.Button1);
        //    }

        //    return (strResult);
        //}
    }
}
