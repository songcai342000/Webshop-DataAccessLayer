using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataAccess;
using System.Security.Cryptography;
using System.IO;

namespace Members
{
    public class Plusreduce
    {
        static byte[] Key = Convert.FromBase64String("1sMwISVZxYUAKJG6Qm4WtrW07uPhzVOC5YwQ1rtgGYA=");
        static byte[] IV = Convert.FromBase64String("Sj62XxTqpLU1xh7YZAT3kg==");
         public static byte[] EncryptStringToBytes_Aes(string plainText)
         {
             // Check arguments.
             if (plainText == null || plainText.Length <= 0)
                 throw new ArgumentNullException("plainText");
             if (Key == null || Key.Length <= 0)
                 throw new ArgumentNullException("Key");
             if (IV == null || IV.Length <= 0)
                 throw new ArgumentNullException("IV");
             byte[] encrypted;
             // Create an Aes object
             // with the specified key and IV.
             using (Aes aesAlg = Aes.Create())
             {
                 aesAlg.Key = Key;
                 aesAlg.IV = IV;

                 // Create a encrytor to perform the stream transform.
                 ICryptoTransform encryptor = aesAlg.CreateEncryptor(aesAlg.Key
     , aesAlg.IV);

                 // Create the streams used for encryption.
                 using (MemoryStream msEncrypt = new MemoryStream())
                 {
                     using (CryptoStream csEncrypt = new CryptoStream(msEncrypt
     , encryptor, CryptoStreamMode.Write))
                     {
                         using (StreamWriter swEncrypt = new StreamWriter(
     csEncrypt))
                         {

                             //Write all data to the stream.
                             swEncrypt.Write(plainText);
                         }
                         encrypted = msEncrypt.ToArray();
                     }
                 }
             }


             // Return the encrypted bytes from the memory stream.
             return encrypted;

         }

         public static string DecryptStringFromBytes_Aes(byte[] cipherText)
         {
             // Check arguments.
             if (cipherText == null || cipherText.Length <= 0)
                 throw new ArgumentNullException("cipherText");
             if (Key == null || Key.Length <= 0)
                 throw new ArgumentNullException("Key");
             if (IV == null || IV.Length <= 0)
                 throw new ArgumentNullException("IV");

             // Declare the string used to hold
             // the decrypted text.
             string plaintext = null;

             // Create an Aes object
             // with the specified key and IV.
              using (Aes aesAlg = Aes.Create())
              {
                aesAlg.Key = Key;
                aesAlg.IV = IV;

             // Create a decrytor to perform the stream transform.
             ICryptoTransform decryptor = aesAlg.CreateDecryptor(aesAlg.Key
              , aesAlg.IV);

             // Create the streams used for decryption.
             using (MemoryStream msDecrypt = new MemoryStream(cipherText))
                 {
                     using (CryptoStream csDecrypt = new CryptoStream(msDecrypt
     , decryptor, CryptoStreamMode.Read))
                     {
                         using (StreamReader srDecrypt = new StreamReader(
     csDecrypt))
                         {

                             // Read the decrypted bytes from the decrypting stream

                             // and place them in a string.
                             plaintext = srDecrypt.ReadToEnd();
                         }
                     }
                 }

             }

             return plaintext;

         }

     }
    
}
