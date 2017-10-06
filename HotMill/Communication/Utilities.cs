using System;
using System.Collections.Generic;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Kvics.Communication
{
    public class Utilities
    {
        public static Byte[] GenerateRandomValue()
        {
            // Array to be filled with strong random bytes
            Byte[] bytes = new Byte[16];

            // Abstract class represents specific RNG implementation
            RandomNumberGenerator rng = new RNGCryptoServiceProvider();

            // Generate random value including zero values
            rng.GetBytes(bytes);
            return bytes;
        }

        public static Byte[] GenerateRandomNonZeroValue()
        {
            // Array to be filled with strong random bytes
            Byte[] bytes = new Byte[16];

            // Abstract class represents specific RNG implementation
            RandomNumberGenerator rng = new RNGCryptoServiceProvider();

            // Generate random nonzero value
            rng.GetNonZeroBytes(bytes);
            return bytes;
        }

        public static Byte[] GenerateRandomNumber()
        {
            // Constants are defined in wincrypt.h in VC SDK
            const int PROV_RSA_FULL = 1;

            // Array to be filled with strong random bytes
            Byte[] bytes = new Byte[16];
            CspParameters csp = new CspParameters(PROV_RSA_FULL);
            RandomNumberGenerator rng = new RNGCryptoServiceProvider(csp);

            // Generate random value including zero values
            rng.GetBytes(bytes);
            return bytes;
        }


        public static String GenerateRandomNumberString()
        {
            Random rand = new Random();
            return rand.Next().ToString();
        }

        public static Byte[] MD5(String msg)
        {
            // Create MD5 provider to do hashing on plain text
            MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider();
            // Calculate hash value on plain text to be encrypted
            return md5.ComputeHash(Encoding.ASCII.GetBytes(msg));
        }

        public static Byte[] SHA160(String msg)
        {
            // This is a 160-bit sha hash provider
            SHA1CryptoServiceProvider sha = new SHA1CryptoServiceProvider();
            return sha.ComputeHash(Encoding.ASCII.GetBytes(msg));
        }

        public static Byte[] SHA256(String msg)
        {
            // This is a 256-bit managed sha hash provider
            SHA256Managed sha256 = new SHA256Managed();
            return sha256.ComputeHash(Encoding.ASCII.GetBytes(msg));
        }

        public static Byte[] SHA384(String msg)
        {
            // this is a 512-bit managed sha hash provider
            SHA384Managed sha384 = new SHA384Managed();
            return sha384.ComputeHash(Encoding.ASCII.GetBytes(msg));
        }

        public static Byte[] SHA512(String msg)
        {
            // this is a 512-bit managed sha hash provider
            SHA512Managed sha512 = new SHA512Managed();
            return sha512.ComputeHash(Encoding.ASCII.GetBytes(msg));
        }

        public static String BytesToHexa(Byte[] bytes)
        {
            StringBuilder sb = new StringBuilder(bytes.Length * 2, bytes.Length * 2);
            for (Int32 i = 0; i < bytes.Length; i++)
            {
                if (bytes[i] < 16)
                {
                    sb.Append('0');
                }
                sb.Append(bytes[i].ToString("x"));
            }
            return sb.ToString();
        }

        // Create a byte array from a decimal
        public static Byte[] DecimalToBytes(Decimal src)
        {
            // Create a MemoryStream as a buffer to hold the binary data
            using (MemoryStream stream = new MemoryStream())
            {
                // Create a BinaryWriter to write binary data to the stream
                using (BinaryWriter writer = new BinaryWriter(stream))
                {
                    // Write the decimal to the BinaryWriter/MemoryStream
                    writer.Write(src);

                    // Return the byte representation of the decimal
                    return stream.ToArray();
                }
            }
        }

        // Create a decimal from a byte array
        public static Decimal BytesToDecimal(Byte[] src)
        {
            // Create a MemoryStream containing the byte array
            using (MemoryStream stream = new MemoryStream(src))
            {
                // Create a BinaryReader to read the decimal from the stream
                using (BinaryReader reader = new BinaryReader(stream))
                {
                    // Read and return the decimal from the
                    // BinaryReader/MemoryStream
                    return reader.ReadDecimal();
                }
            }
        }

        public static String Base64Encode(String src)
        {
            Byte[] bytes = Encoding.Unicode.GetBytes(src);
            return Convert.ToBase64String(bytes);
        }

        public static String Base64Decode(String src)
        {
            Byte[] bytes = Convert.FromBase64String(src);
            return Encoding.Unicode.GetString(bytes);
        }

        public static String DecimalToBase64(Decimal src)
        {
            Byte[] bytes = DecimalToBytes(src);
            return Convert.ToBase64String(bytes);
        }

        public static Decimal Base64ToDecimal(String src)
        {
            Byte[] bytes = Convert.FromBase64String(src);
            return BytesToDecimal(bytes);
        }

        public static String IntToBase64(Int32 src)
        {
            Byte[] bytes = BitConverter.GetBytes(src);
            return Convert.ToBase64String(bytes);
        }

        public static Int32 Base64ToInt(String src)
        {
            Byte[] bytes = Convert.FromBase64String(src);
            return BitConverter.ToInt32(bytes, 0);
        }

        public static String EncryptDES(String plainText, String password)
        {
            if (String.IsNullOrEmpty(plainText))
            {
                throw new ArgumentException();
            }

            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentException();
            }

            // Create a Rfc2898DeriveBytes object and then create 
            // a DES key from the password and salt (kvics.com.vn).
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(password,
                        Encoding.ASCII.GetBytes("kvics.com.vn"));

            // Get the data back from the memory stream, and into a string
            StringBuilder sb = new StringBuilder();

            try
            {
                DESCryptoServiceProvider cspDES = new DESCryptoServiceProvider();

                cspDES.IV = rfc2898.GetBytes(8);
                // Function to generate a 64 bits key.
                cspDES.Key = rfc2898.GetBytes(8);

                // Put the string into a byte array
                Byte[] plainData = Encoding.UTF8.GetBytes(plainText);

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, cspDES.CreateEncryptor(), CryptoStreamMode.Write);

                // Write the byte array into the cryptography stream
                // (It will end up in the memory stream)
                cs.Write(plainData, 0, plainData.Length);
                cs.FlushFinalBlock();

                foreach (Byte b in ms.ToArray())
                {
                    // Format as hex
                    sb.AppendFormat("{0:X2}", b);
                }
            }
            catch (Exception)
            {

            }

            return sb.ToString();
        }

        public static String DecryptDES(String cipherText, String password)
        {
            if (String.IsNullOrEmpty(cipherText))
            {
                throw new ArgumentException();
            }

            if (String.IsNullOrEmpty(password))
            {
                throw new ArgumentException();
            }

            // Create a Rfc2898DeriveBytes object and then create 
            // a DES key from the password and salt.
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(password,
                        Encoding.ASCII.GetBytes("kvics.com.vn"));

            StringBuilder sb = new StringBuilder();

            try
            {
                DESCryptoServiceProvider cspDES = new DESCryptoServiceProvider();

                cspDES.IV = rfc2898.GetBytes(8);
                // Function to generate a 64 bits key.
                cspDES.Key = rfc2898.GetBytes(8);

                MemoryStream ms = new MemoryStream();
                CryptoStream cs = new CryptoStream(ms, cspDES.CreateDecryptor(), CryptoStreamMode.Write);

                // Put the input string into the byte array
                Byte[] cipherData = new Byte[cipherText.Length / 2];
                Int32 x;

                for (Int32 i = 0; i < cipherText.Length / 2; i++)
                {
                    x = Convert.ToInt32(cipherText.Substring(i * 2, 2), 16);
                    cipherData[i] = (Byte)x;
                }

                // Flush the data through the cryptography stream into the memory stream
                cs.Write(cipherData, 0, cipherData.Length);
                cs.FlushFinalBlock();

                // Get the decrypted data back from the memory stream
                foreach (Byte b in ms.ToArray())
                {
                    sb.Append((Char)b);
                }
            }
            catch (Exception)
            {

            }

            return sb.ToString();
        }

        public static Byte[] EncryptAES(Byte[] plainData, Byte[] Key, Byte[] IV)
        {
            // Create a MemoryStream that is going to accept the encrypted bytes
            MemoryStream ms = new MemoryStream();

            // Create a symmetric algorithm.
            // We are going to use Rijndael because it is strong and available on all platforms.
            // You can use other algorithms, to do so substitute the next line with something like
            // TripleDES alg = TripleDES.Create();
            Rijndael alg = Rijndael.Create();

            // Now set the key and the IV.
            // We need the IV (Initialization Vector) because the algorithm is operating in its default
            // mode called CBC (Cipher Block Chaining). The IV is XORed with the first block (8 byte)
            // of the data before it is encrypted, and then each encrypted block is XORed with the
            // following block of plain text. This is done to make encryption more secure.
            // There is also a mode called ECB which does not need an IV, but it is much less secure.
            alg.Key = Key;
            alg.IV = IV;

            // Create a CryptoStream through which we are going to be pumping our data.
            // CryptoStreamMode.Write means that we are going to be writing data to the stream
            // and the output will be written in the MemoryStream we have provided.
            CryptoStream cs = new CryptoStream(ms, alg.CreateEncryptor(), CryptoStreamMode.Write);

            // Write the data and make it do the encryption
            cs.Write(plainData, 0, plainData.Length);

            // Close the crypto stream (or do FlushFinalBlock).
            // This will tell it that we have done our encryption and there is no more data coming in,
            // and it is now a good time to apply the padding and finalize the encryption process.
            cs.Close();

            // Now get the encrypted data from the MemoryStream.
            // Some people make a mistake of using GetBuffer() here, which is not the right way.
            Byte[] encryptedData = ms.ToArray();

            return encryptedData;
        }

        public static String EncryptAES(String plainText, String password)
        {
            // First we need to turn the input string into a byte array.
            Byte[] plainData = Encoding.Unicode.GetBytes(plainText);

            // Then, we need to turn the password into Key and IV
            // We are using salt to make it harder to guess our key using a dictionary attack -
            // trying to guess a password by enumerating all possible words.
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(password,
                        Encoding.ASCII.GetBytes("kvics.com.vn"));

            // Now get the key/IV and do the encryption using the function that accepts byte arrays.
            // Using Rfc2898DeriveBytes object we are first getting 32 bytes for the Key
            // (the default Rijndael key length is 256bit = 32bytes) and then 16 bytes for the IV.
            // IV should always be the block size, which is by default 16 bytes (128 bit) for Rijndael.
            // If you are using DES/TripleDES/RC2 the block size is 8 bytes and so should be the IV size.
            // You can also read KeySize/BlockSize properties off the algorithm to find out the sizes.
            Byte[] encryptedData = EncryptAES(plainData, rfc2898.GetBytes(32), rfc2898.GetBytes(16));

            // Now we need to turn the resulting byte array into a string.
            // A common mistake would be to use an Encoding class for that. It does not work
            // because not all byte values can be represented by characters.
            // We are going to be using Base64 encoding that is designed exactly for what we are
            // trying to do.
            return Convert.ToBase64String(encryptedData);
        }

        // Encrypt bytes into bytes using a password
        public static Byte[] EncryptAES(Byte[] plainData, String password)
        {
            // We need to turn the password into Key and IV.
            // We are using salt to make it harder to guess our key using a dictionary attack -
            // trying to guess a password by enumerating all possible words.
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(password,
                        Encoding.ASCII.GetBytes("kvics.com.vn"));

            // Now get the key/IV and do the encryption using the function that accepts byte arrays.
            // Using Rfc2898DeriveBytes object we are first getting 32 bytes for the Key
            // (the default Rijndael key length is 256bit = 32bytes) and then 16 bytes for the IV.
            // IV should always be the block size, which is by default 16 bytes (128 bit) for Rijndael.
            // If you are using DES/TripleDES/RC2 the block size is 8 bytes and so should be the IV size.
            // You can also read KeySize/BlockSize properties off the algorithm to find out the sizes.
            return EncryptAES(plainData, rfc2898.GetBytes(32), rfc2898.GetBytes(16));
        }

        // Encrypt a file into another file using a password
        public static void EncryptAES(String fileIn, String fileOut, String password)
        {
            // First we are going to open the file streams
            FileStream fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
            FileStream fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);

            // Then we are going to derive a Key and an IV from the Password and create an algorithm
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(password,
                        Encoding.ASCII.GetBytes("kvics.com.vn"));

            Rijndael alg = Rijndael.Create();
            alg.Key = rfc2898.GetBytes(32);
            alg.IV = rfc2898.GetBytes(16);

            // Now create a crypto stream through which we are going to be pumping data.
            // Our fileOut is going to be receiving the encrypted bytes.
            CryptoStream cs = new CryptoStream(fsOut, alg.CreateEncryptor(), CryptoStreamMode.Write);

            // Now will will initialize a buffer and will be processing the input file in chunks.
            // This is done to avoid reading the whole file (which can be huge) into memory.
            Int32 bufferLen = 4096;
            Byte[] buffer = new Byte[bufferLen];
            Int32 bytesRead;

            do
            {
                // read a chunk of data from the input file
                bytesRead = fsIn.Read(buffer, 0, bufferLen);

                // encrypt it
                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);

            // close everything
            cs.Close(); // this will also close the underlying fsOut stream
            fsIn.Close();
        }

        // Decrypt a byte array into a byte array using a key and an IV
        public static Byte[] DecryptAES(Byte[] cipherData, Byte[] Key, Byte[] IV)
        {
            // Create a MemoryStream that is going to accept the decrypted bytes
            MemoryStream ms = new MemoryStream();

            // Create a symmetric algorithm.
            // We are going to use Rijndael because it is strong and available on all platforms.
            // You can use other algorithms, to do so substitute the next line with something like
            // TripleDES alg = TripleDES.Create();
            Rijndael alg = Rijndael.Create();

            // Now set the key and the IV.
            // We need the IV (Initialization Vector) because the algorithm is operating in its default
            // mode called CBC (Cipher Block Chaining). The IV is XORed with the first block (8 byte)
            // of the data after it is decrypted, and then each decrypted block is XORed with the previous
            // cipher block. This is done to make encryption more secure.
            // There is also a mode called ECB which does not need an IV, but it is much less secure.
            alg.Key = Key;
            alg.IV = IV;

            // Create a CryptoStream through which we are going to be pumping our data.
            // CryptoStreamMode.Write means that we are going to be writing data to the stream
            // and the output will be written in the MemoryStream we have provided.
            CryptoStream cs = new CryptoStream(ms, alg.CreateDecryptor(), CryptoStreamMode.Write);

            // Write the data and make it do the decryption
            cs.Write(cipherData, 0, cipherData.Length);

            // Close the crypto stream (or do FlushFinalBlock).
            // This will tell it that we have done our decryption and there is no more data coming in,
            // and it is now a good time to remove the padding and finalize the decryption process.
            cs.Close();

            // Now get the decrypted data from the MemoryStream.
            // Some people make a mistake of using GetBuffer() here, which is not the right way.
            byte[] decryptedData = ms.ToArray();

            return decryptedData;
        }
 
        // Decrypt a string into a string using a password
        // Uses Decrypt(byte[], byte[], byte[])
        public static String DecryptAES(String cipherText, string password)
        {
            // First we need to turn the input string into a byte array.
            // We presume that Base64 encoding was used
            Byte[] cipherData = Convert.FromBase64String(cipherText);

            // Then, we need to turn the password into Key and IV
            // We are using salt to make it harder to guess our key using a dictionary attack -
            // trying to guess a password by enumerating all possible words.
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(password,
                        Encoding.ASCII.GetBytes("kvics.com.vn"));

            // Now get the key/IV and do the decryption using the function that accepts byte arrays.
            // Using Rfc2898DeriveBytes object we are first getting 32 bytes for the Key
            // (the default Rijndael key length is 256bit = 32bytes) and then 16 bytes for the IV.
            // IV should always be the block size, which is by default 16 bytes (128 bit) for Rijndael.
            // If you are using DES/TripleDES/RC2 the block size is 8 bytes and so should be the IV size.
            // You can also read KeySize/BlockSize properties off the algorithm to find out the sizes.
            Byte[] decryptedData = DecryptAES(cipherData, rfc2898.GetBytes(32), rfc2898.GetBytes(16));

            // Now we need to turn the resulting byte array into a string.
            // A common mistake would be to use an Encoding class for that. It does not work
            // because not all byte values can be represented by characters.
            // We are going to be using Base64 encoding that is designed exactly for what we are
            // trying to do.

            return Encoding.Unicode.GetString(decryptedData);
        }

        // Decrypt bytes into bytes using a password
        //    Uses Decrypt(byte[], byte[], byte[])
        public static Byte[] DecryptAES(Byte[] cipherData, String password)
        {
            // We need to turn the password into Key and IV.
            // We are using salt to make it harder to guess our key using a dictionary attack -
            // trying to guess a password by enumerating all possible words.
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(password,
                        Encoding.ASCII.GetBytes("kvics.com.vn"));

            // Now get the key/IV and do the Decryption using the function that accepts byte arrays.
            // Using Rfc2898DeriveBytes object we are first getting 32 bytes for the Key
            // (the default Rijndael key length is 256bit = 32bytes) and then 16 bytes for the IV.
            // IV should always be the block size, which is by default 16 bytes (128 bit) for Rijndael.
            // If you are using DES/TripleDES/RC2 the block size is 8 bytes and so should be the IV size.
            // You can also read KeySize/BlockSize properties off the algorithm to find out the sizes.
            return DecryptAES(cipherData, rfc2898.GetBytes(32), rfc2898.GetBytes(16));
        }

        // Decrypt a file into another file using a password
        public static void DecryptAES(String fileIn, String fileOut, String password)
        {
            // First we are going to open the file streams
            FileStream fsIn = new FileStream(fileIn, FileMode.Open, FileAccess.Read);
            FileStream fsOut = new FileStream(fileOut, FileMode.OpenOrCreate, FileAccess.Write);

            // Then we are going to derive a Key and an IV from the Password and create an algorithm
            Rfc2898DeriveBytes rfc2898 = new Rfc2898DeriveBytes(password,
                        Encoding.ASCII.GetBytes("kvics.com.vn"));

            Rijndael alg = Rijndael.Create();
            alg.Key = rfc2898.GetBytes(32);
            alg.IV = rfc2898.GetBytes(16);

            // Now create a crypto stream through which we are going to be pumping data.
            // Our fileOut is going to be receiving the Decrypted bytes.
            CryptoStream cs = new CryptoStream(fsOut, alg.CreateDecryptor(), CryptoStreamMode.Write);

            // Now will will initialize a buffer and will be processing the input file in chunks.
            // This is done to avoid reading the whole file (which can be huge) into memory.
            Int32 bufferLen = 4096;
            Byte[] buffer = new Byte[bufferLen];
            Int32 bytesRead;

            do
            {
                // read a chunk of data from the input file
                bytesRead = fsIn.Read(buffer, 0, bufferLen);

                // Decrypt it
                cs.Write(buffer, 0, bytesRead);
            } while (bytesRead != 0);

            // close everything
            cs.Close(); // this will also close the underlying fsOut stream
            fsIn.Close();
        }
    }
}
