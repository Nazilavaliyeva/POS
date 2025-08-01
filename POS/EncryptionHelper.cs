using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

public static class EncryptionHelper
{
    // DİQQƏT: Real layihədə bu açarlar heç vaxt kodda saxlanmamalıdır!

    // DÜZƏLİŞ: Açarın uzunluğu 31 bayt idi, 32 bayta tamamlandı (sonuna '5' əlavə edildi).
    // AES alqoritmi üçün açar mütləq 16, 24 və ya 32 bayt olmalıdır.
    private static readonly byte[] Key = Encoding.UTF8.GetBytes("Bu32ByteUzunluqluBirAcardir12345"); // 32 byte (256-bit)
    private static readonly byte[] IV = Encoding.UTF8.GetBytes("Bu16ByteIVdir123");              // 16 byte (128-bit)

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
            // Əgər məlumat şifrələnməyibsə (köhnə fayldırsa), olduğu kimi qaytar
            return cipherText;
        }
        catch (CryptographicException)
        {
            // DÜZƏLİŞ: Yanlış açar və ya pozulmuş data ilə deşifrələməyə çalışanda xəta baş verərsə,
            // proqramın çökmeməsi üçün xətanı tuturuq.
            // Bu halda, orijinal şifrəli mətni qaytarmaq daha təhlükəsizdir.
            return cipherText;
        }
    }
}