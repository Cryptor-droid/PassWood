using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Passwood
{
    class AES
    {
        private static byte[] GetKEY(byte[] data)
        {
            

                var sha256Hash = SHA256.Create();
                var q = sha256Hash.ComputeHash(data);
            
            
            return q;
        }
        private static byte[] GetIV()
        {
            using (RNGCryptoServiceProvider rng = new RNGCryptoServiceProvider())
            {
                byte[] ret = new byte[16];
                rng.GetBytes(ret);
                return ret;
            }
        }
        public static byte[] Encrypt(byte[] data, byte[] Key)
        {
            byte[] buff;
            using (RijndaelManaged aes = new RijndaelManaged())
            {
                byte[] IV = GetIV();
                aes.Key = GetKEY(Key);
                aes.IV = IV;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.ISO10126;
                using (ICryptoTransform enc = aes.CreateEncryptor(aes.Key, aes.IV))
                {
                    using (MemoryStream ms = new MemoryStream())
                    {
                        using (CryptoStream cs = new CryptoStream(ms, enc, CryptoStreamMode.Write))
                        {
                            byte[] encd;
                            using (StreamWriter sw = new StreamWriter(cs))
                            {
                                
                                sw.Write(Convert.ToBase64String(data));
                                sw.Close();
                                encd = ms.ToArray();
                            }

                            buff = new byte[encd.Length + 16];
                            Array.Copy(IV, buff, 16);
                            encd.CopyTo(buff, 16);
                            //Array.Copy(encd, 0, buff, 15, encd.Length);
                        }
                    }
                }
            }
            return buff;
        }

        static string byto(byte[] data)
        {
            string ret = "";
            foreach (byte dat in data)
            {
                ret += dat.ToString() + " ,";
            }
            return ret;
        }

        private static byte[] Get_Bytes(byte[] src, int startindex, int count)
        {
            byte[] retval = new byte[count];
            for (int i = 0; i < count; i++)
            {
                retval[i] = src[startindex + i];
            }
            return retval;
        }

        public static byte[] Decrypt(byte[] data, byte[] Key)
        {
            byte[] buff;
            using (RijndaelManaged aes = new RijndaelManaged())
            {
                byte[] IV = Get_Bytes(data, 0, 16);
                byte[] todec = Get_Bytes(data, 16, data.Length - 16);
                aes.Key = GetKEY(Key);
                aes.IV = IV;
                aes.Mode = CipherMode.CBC;
                aes.Padding = PaddingMode.ISO10126;
                using (ICryptoTransform dec = aes.CreateDecryptor(aes.Key, aes.IV))
                {
                    using (MemoryStream ms = new MemoryStream(todec))
                    {
                        using (CryptoStream cs = new CryptoStream(ms, dec, CryptoStreamMode.Read))
                        {
                            using (StreamReader sr = new StreamReader(cs))
                            {
                                buff = Convert.FromBase64String(sr.ReadToEnd());
                            }
                        }
                    }
                }
            }
            return buff;
        }
    }
}
