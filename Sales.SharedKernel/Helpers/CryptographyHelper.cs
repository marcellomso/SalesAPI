using System.Security.Cryptography;

namespace Sales.SharedKernel.Helpers
{
    public class CryptographyHelper
    {
        private const string _key = "Uj1a08NLG1FsbjvPdc0vUvkVczaJ8vqX00snX8ovS3U=";
        private const string _iv = "gdUlB0mAe7gLcQ20Q+IsSg==";

        public static string Encrypt(string plainText)
        {
            using Aes myAes = Aes.Create();
            byte[] encrypted = EncryptStringToBytes_Aes(plainText);
            return Convert.ToBase64String(encrypted);
        }

        public static string Dencrypt(string cipherText)
        {
            using Aes myAes = Aes.Create();
            var dencrypted = DecryptStringFromBytes_Aes(Convert.FromBase64String(cipherText));
            return dencrypted;
        }

        private static byte[] EncryptStringToBytes_Aes(string plainText)
        {
            if (plainText == null || plainText.Length <= 0)
                throw new ArgumentNullException(nameof(plainText));
            byte[] encrypted;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(_key);
                aesAlg.IV = Convert.FromBase64String(_iv);

                ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

                using MemoryStream msEncrypt = new();
                using CryptoStream csEncrypt = new(msEncrypt, encryptor, CryptoStreamMode.Write);
                using (StreamWriter swEncrypt = new(csEncrypt))
                {
                    swEncrypt.Write(plainText);
                }
                encrypted = msEncrypt.ToArray();
            }

            return encrypted;
        }

        private static string DecryptStringFromBytes_Aes(byte[] cipherText)
        {
            if (cipherText == null || cipherText.Length <= 0)
                throw new ArgumentNullException(nameof(cipherText));

            string? plaintext = null;

            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Convert.FromBase64String(_key);
                aesAlg.IV = Convert.FromBase64String(_iv);

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);

                using MemoryStream msDecrypt = new(cipherText);
                using CryptoStream csDecrypt = new(msDecrypt, decryptor, CryptoStreamMode.Read);
                using StreamReader srDecrypt = new(csDecrypt);

                plaintext = srDecrypt.ReadToEnd();
            }

            return plaintext;
        }
    }
}
