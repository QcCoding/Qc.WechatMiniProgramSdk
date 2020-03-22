using System;
using System.Collections.Generic;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Qc.WechatMiniProgramSdk.Utils
{
    /// <summary>
    /// 微信小程序加解密辅助类
    /// </summary>
    public static class WechatMiniEncryptionHelper
    {
        /// <summary>
        /// Aes解密
        /// </summary>
        /// <param name="aesKey"></param>
        /// <param name="aesIv"></param>
        /// <param name="inputData"></param>
        /// <returns></returns>
        public static string AesDecryptData(string aesKey, string aesIv, string inputData)
        {
            try
            {
                byte[] encryptedData = Convert.FromBase64String(inputData);
                using (RijndaelManaged rijndaelCipher = new RijndaelManaged
                {
                    Key = Convert.FromBase64String(aesKey),
                    IV = Convert.FromBase64String(aesIv),
                    Mode = CipherMode.CBC,
                    Padding = PaddingMode.PKCS7
                })
                {
                    using (ICryptoTransform transform = rijndaelCipher.CreateDecryptor())
                    {
                        byte[] plainText = transform.TransformFinalBlock(encryptedData, 0, encryptedData.Length);
                        string result = Encoding.UTF8.GetString(plainText);

                        return result;
                    }
                }
            }
            catch
            {
                return null;
            }
        }
    }
}
