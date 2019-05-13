using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace EMOASApp.Utils
{
    class EncryptionUtil
    {
        /// <summary>
        /// 默认Des密钥向量
        /// </summary>
        private static byte[] DESIv = { 0x93, 0x5b, 0xbf, 0xf7, 0x04, 0x85, 0xcb, 0xeb, 0xae, 0x11, 0x92, 0xc6, 0x88, 0xed, 0x83, 0xd6 };

        /// <summary>
        /// Des加密
        /// </summary>
        /// <param name="src_str"></param>
        /// <returns></returns>
        public static string DesEncrypt(string src_str)
        {
            try
            {
                byte[] Key = Encoding.UTF8.GetBytes(DateTime.Now.ToString("MMddyyyyMMddyyyy"));
                byte[] IV = DESIv;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(src_str);
                var DCSP = Aes.Create();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateEncryptor(Key, IV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch (Exception ex)
            {
                Console.Write("error[{0}]: {1}", src_str, ex.Message);
                return null;
            }
        }
        
        /// <summary>
        /// MD5加密
        /// </summary>
        /// <param name="md5Hash"></param>
        /// <param name="input"></param>
        /// <returns></returns>
        public static string GetMd5Hash(MD5 md5Hash, string input)
        {

            // Convert the input string to a byte array and compute the hash.
            byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

            // Create a new Stringbuilder to collect the bytes
            // and create a string.
            StringBuilder sBuilder = new StringBuilder();

            // Loop through each byte of the hashed data 
            // and format each one as a hexadecimal string.
            for (int i = 0; i < data.Length; i++)
            {
                sBuilder.Append(data[i].ToString("x2"));
            }

            // Return the hexadecimal string.
            return sBuilder.ToString();
        }
    }
}