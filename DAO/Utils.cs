using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CuaHangTraSuaHKT
{
    internal class Utils
    {
        public static string GetMD5(string str)
        {
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();

            //MD5 md5 = MD5.Create();

            byte[] bHash = md5.ComputeHash(Encoding.UTF8.GetBytes(str));

            StringBuilder sd = new StringBuilder();
            foreach (byte b in bHash)
            {
                sd.Append(String.Format("{0:x2}", b));
            }

            return sd.ToString();
        }
    }
}
