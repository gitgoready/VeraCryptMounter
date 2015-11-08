using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace TrueCrypt_Mounter
{
    /// <summary>
    /// Encode and decode strings with aes.
    /// </summary>
    public static class StringCipher
    {

        // This constant is used to determine the keysize of the encryption algorithm.
        private const int keysize = 256;
        /// <summary>
        /// Encrypt string with aes. Retrun base 64 string with salt.
        /// </summary>
        /// <param name="plainText">The plain text string.</param>
        /// <param name="passPhrase">The password for the encryption.</param>
        /// <returns></returns>
        public static string Encrypt(string plainText, string passPhrase)
        {
            byte[] initVectorBytes = new byte[32]; 
            byte[] plainTextBytes = Encoding.UTF8.GetBytes(plainText);
            using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
            {
                byte[] keyBytes = password.GetBytes(keysize / 8);
                using (RijndaelManaged symmetricKey = new RijndaelManaged())
                {
                    symmetricKey.Mode = CipherMode.CBC;
                    symmetricKey.BlockSize = keysize;
                    symmetricKey.GenerateIV();
                    initVectorBytes = symmetricKey.IV;
                    using (ICryptoTransform encryptor = symmetricKey.CreateEncryptor(keyBytes, initVectorBytes))
                    {
                        using (MemoryStream memoryStream = new MemoryStream())
                        {
                            using (CryptoStream cryptoStream = new CryptoStream(memoryStream, encryptor, CryptoStreamMode.Write))
                            {
                                cryptoStream.Write(plainTextBytes, 0, plainTextBytes.Length);
                                cryptoStream.FlushFinalBlock();
                                byte[] cipherTextBytes = memoryStream.ToArray();
                                string value = Convert.ToBase64String(cipherTextBytes);
                                string salt = Convert.ToBase64String(initVectorBytes);
                                var ret = string.Concat(value, salt);
                                return ret;
                            }
                        }
                    }
                }
            }
        }

        /// <summary>
        /// Decrypt base64 string with salt
        /// </summary>
        /// <param name="cipherText"></param>
        /// <param name="passPhrase"></param>
        /// <returns></returns>
        public static string Decrypt(string cipherText, string passPhrase)
        {
            byte[] initVectorBytes = new byte[32];
            string salt = cipherText.Substring(cipherText.Length - 44);
            cipherText = cipherText.Substring(0, cipherText.Length - 44);
            initVectorBytes = Convert.FromBase64String(salt);

            byte[] cipherTextBytes = Convert.FromBase64String(cipherText);
            try
            {
                using (PasswordDeriveBytes password = new PasswordDeriveBytes(passPhrase, null))
                {
                    byte[] keyBytes = password.GetBytes(keysize / 8);
                    using (RijndaelManaged symmetricKey = new RijndaelManaged())
                    {
                        symmetricKey.Mode = CipherMode.CBC;
                        symmetricKey.BlockSize = keysize;
                        using (ICryptoTransform decryptor = symmetricKey.CreateDecryptor(keyBytes, initVectorBytes))
                        {
                            using (MemoryStream memoryStream = new MemoryStream(cipherTextBytes))
                            {
                                using (CryptoStream cryptoStream = new CryptoStream(memoryStream, decryptor, CryptoStreamMode.Read))
                                {
                                    byte[] plainTextBytes = new byte[cipherTextBytes.Length];
                                    int decryptedByteCount = cryptoStream.Read(plainTextBytes, 0, plainTextBytes.Length);
                                    return Encoding.UTF8.GetString(plainTextBytes, 0, decryptedByteCount);
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception)
            {
                //Console.WriteLine(ex.Message);
                return null;
            }
        }
    }
}