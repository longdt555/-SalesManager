using System;
using System.Security.Cryptography;
using System.Text;

namespace Lib.Common.Helpers
{
    public static class Security
    {
        public static string Encrypt(string toEncrypt, string key, bool useHashing = true)
        {
            byte[] keyArray;
            byte[] toEncryptArray = UTF8Encoding.UTF8.GetBytes(toEncrypt);

            if (useHashing)
            {
                var hashmd5 = new MD5CryptoServiceProvider();
                keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
            }
            else
                keyArray = UTF8Encoding.UTF8.GetBytes(key);

            var tdes = new TripleDESCryptoServiceProvider();
            tdes.Key = keyArray;
            tdes.Mode = CipherMode.ECB;
            tdes.Padding = PaddingMode.PKCS7;

            var cTransform = tdes.CreateEncryptor();
            byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }

        public static string Decrypt(string toDecrypt, string key, bool useHashing = true)
        {
            var rt = "";
            try
            {
                byte[] keyArray;
                byte[] toEncryptArray = Convert.FromBase64String(toDecrypt);

                if (useHashing)
                {
                    var hashmd5 = new MD5CryptoServiceProvider();
                    keyArray = hashmd5.ComputeHash(UTF8Encoding.UTF8.GetBytes(key));
                }
                else
                    keyArray = UTF8Encoding.UTF8.GetBytes(key);

                var tdes = new TripleDESCryptoServiceProvider();
                tdes.Key = keyArray;
                tdes.Mode = CipherMode.ECB;
                tdes.Padding = PaddingMode.PKCS7;

                var cTransform = tdes.CreateDecryptor();
                byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                rt = UTF8Encoding.UTF8.GetString(resultArray);
            }
            catch
            {
                //return "";
            }
            return rt;
        }

        public static string ConvertKey(string toDecrypt, string key)
        {
            var encryptedTicket = Decrypt(toDecrypt, key);
            return encryptedTicket;
        }
        public static string EncryptKey(string encryptKey)
        {
            using (MD5 md5Hash = MD5.Create())
            {
                // Convert the input string to a byte array and compute the hash.
                byte[] data = md5Hash.ComputeHash(Encoding.UTF8.GetBytes(encryptKey));

                // Create a new Stringbuilder to collect the bytes
                // and create a string.
                var sBuilder = new StringBuilder();

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
}
