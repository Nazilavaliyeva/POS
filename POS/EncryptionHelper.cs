using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using System.Configuration; // Bu sətirin olduğundan əmin olun

public static class EncryptionHelper
{
    private static readonly byte[] Key;
    private static readonly byte[] IV;

    // DƏYİŞİKLİK: Açarları oxumaq və yoxlamaq üçün static constructor əlavə edildi
    static EncryptionHelper()
    {
        string keyString = ConfigurationManager.AppSettings["EncryptionKey"];
        string ivString = ConfigurationManager.AppSettings["EncryptionIV"];

        if (string.IsNullOrEmpty(keyString))
        {
            throw new ConfigurationErrorsException("Xəta: App.config faylında 'EncryptionKey' tapılmadı və ya dəyəri boşdur.");
        }
        if (string.IsNullOrEmpty(ivString))
        {
            throw new ConfigurationErrorsException("Xəta: App.config faylında 'EncryptionIV' tapılmadı və ya dəyəri boşdur.");
        }

        Key = Encoding.UTF8.GetBytes(keyString);
        IV = Encoding.UTF8.GetBytes(ivString);

        // Təhlükəsizlik üçün yoxlama: Açarın və Vektorun uzunluğunu yoxlayırıq.
        if (Key.Length != 32)
        {
            throw new ConfigurationErrorsException("'EncryptionKey' dəyəri App.config faylında 32 simvol olmalıdır.");
        }
        if (IV.Length != 16)
        {
            throw new ConfigurationErrorsException("'EncryptionIV' dəyəri App.config faylında 16 simvol olmalıdır.");
        }
    }

    public static string Encrypt(string plainText)
    {
        if (string.IsNullOrEmpty(plainText))
            return plainText;

        using (Aes aesAlg = Aes.Create())
        {
            aesAlg.Key = Key;
            aesAlg.IV = IV;

            ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);

            using (MemoryStream msEncrypt = new MemoryStream())
            {
                using (CryptoStream csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (StreamWriter swEncrypt = new StreamWriter(csEncrypt))
                    {
                        swEncrypt.Write(plainText);
                    }
                }
                return Convert.ToBase64String(msEncrypt.ToArray());
            }
        }
    }

    public static string Decrypt(string cipherText)
    {
        if (string.IsNullOrEmpty(cipherText))
            return cipherText;

        try
        {
            using (Aes aesAlg = Aes.Create())
            {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

                ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                byte[] cipherBytes = Convert.FromBase64String(cipherText);

                using (MemoryStream msDecrypt = new MemoryStream(cipherBytes))
                {
                    using (CryptoStream csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                    {
                        using (StreamReader srDecrypt = new StreamReader(csDecrypt))
                        {
                            return srDecrypt.ReadToEnd();
                        }
                    }
                }
            }
        }
        catch (FormatException)
        {
            return cipherText;
        }
        catch (CryptographicException)
        {
            return cipherText;
        }
    }
}