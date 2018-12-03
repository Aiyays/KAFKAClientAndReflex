using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace CommonTool
{
    public class DeEncryption
    {
        public static string AESKey
        {
            get;
            set;
        }

        private static string AESsKey
        {
            get;
            set;
        }

        private static string ivParameter
        {
            get;
            set;
        }
        private static void AESKeyCut(string key)
        {
            DeEncryption.AESKey = key;
            DeEncryption.AESsKey = key.Substring(0, 16);
            DeEncryption.ivParameter = key.Substring(16, 16);
        }

        public static string AESEncrypt(string plainStr)
        {
            return DeEncryption.AESEncrypt(plainStr, DeEncryption.AESKey);
        }

        public static string AESEncrypt(string plainStr, string key)
        {
            DeEncryption.AESKeyCut(key);
            byte[] bytes = Encoding.UTF8.GetBytes(DeEncryption.AESsKey);
            byte[] bytes2 = Encoding.UTF8.GetBytes(DeEncryption.ivParameter);
            byte[] bytes3 = Encoding.UTF8.GetBytes(plainStr);
            string result = null;
            Rijndael rijndael = Rijndael.Create();
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateEncryptor(bytes, bytes2), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(bytes3, 0, bytes3.Length);
                        cryptoStream.FlushFinalBlock();
                        result = Convert.ToBase64String(memoryStream.ToArray());
                    }
                }
            }
            catch
            {
            }
            rijndael.Clear();
            return result;
        }

        public static string AESEncrypt(string plainStr, bool returnNull)
        {
            string text = DeEncryption.AESEncrypt(plainStr);
            return returnNull ? text : ((text == null) ? string.Empty : text);
        }

        public static string AESDecrypt(string encryptStr)
        {
            return DeEncryption.AESDecrypt(encryptStr, DeEncryption.AESKey);
        }

        public static string AESDecrypt(string encryptStr, string key)
        {
            DeEncryption.AESKeyCut(key);
            byte[] bytes = Encoding.UTF8.GetBytes(DeEncryption.AESsKey);
            byte[] bytes2 = Encoding.UTF8.GetBytes(DeEncryption.ivParameter);
            byte[] array = Convert.FromBase64String(encryptStr);
            string result = null;
            Rijndael rijndael = Rijndael.Create();
            try
            {
                using (MemoryStream memoryStream = new MemoryStream())
                {
                    using (CryptoStream cryptoStream = new CryptoStream(memoryStream, rijndael.CreateDecryptor(bytes, bytes2), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(array, 0, array.Length);
                        cryptoStream.FlushFinalBlock();
                        result = Encoding.UTF8.GetString(memoryStream.ToArray());
                    }
                }
            }
            catch
            {
            }
            rijndael.Clear();
            return result;
        }

        public static string AESDecrypt(string encryptStr, bool returnNull)
        {
            string text = DeEncryption.AESDecrypt(encryptStr);
            return returnNull ? text : ((text == null) ? string.Empty : text);
        }

        public static string MD5(string str)
        {
            MD5 mD = new MD5CryptoServiceProvider();
            byte[] value = mD.ComputeHash(Encoding.Default.GetBytes(str));
            return BitConverter.ToString(value).Replace("-", "").ToUpper();
        }

        public static string MD5bit16(string str)
        {
            MD5 mD = new MD5CryptoServiceProvider();
            byte[] value = mD.ComputeHash(Encoding.Default.GetBytes(str));
            return BitConverter.ToString(value).Replace("-", "").ToUpper().Substring(8, 16);
        }
    }
}
