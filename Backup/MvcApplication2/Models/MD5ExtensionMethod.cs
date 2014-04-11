using System.Security.Cryptography;
using System.Text;
using ZeitGeist.ExtensionsMethods;

namespace MvcApplication2.Models
{
    public static class MD5ExtensionMethod
    {
        public static string GetMD5(this string value)
        {
            MD5 md = MD5.Create();
            StringBuilder sBuilder = new StringBuilder();
            byte[] data = md.ComputeHash(value.GetBytesFromASCII());
            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }
            return sBuilder.ToString();

        }
    }
}