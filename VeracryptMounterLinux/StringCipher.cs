/***
 * <VeraCryptMounter. Programm to use Truecrypt drives and containers easier.>
 * Copyright (C) <2015>  <Rafael Grothmann>
 * 
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 * 
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 * 
 * You should have received a copy of the GNU General Public License
 * along with this program.  If not, see <http://www.gnu.org/licenses/>.
 **/
using System;
using SecurityDriven.Inferno;

namespace VeracryptMounterLinux
{
    /// <summary>
    /// Encode and decode strings with aes-ctr-256.
    /// </summary>
    public static class StringCipher
    {

        // This constant is used to determine the rounds used for AES.
        private const int rounds = 50000;


        /// <summary>
        /// Encrypt string with aes-256. Retrun base 64 string with salt(chars 88).
        /// </summary>
        /// <param name="plainText">The plain text string.</param>
        /// <param name="passPhrase">The password for the encryption.</param>
        /// <returns></returns>
        public static string Encrypt(string plainText, string passPhrase)
        {
            
            //get nedded form of passphrase and plaintest
            byte[] key = Utils.SafeUTF8.GetBytes(passPhrase);
            ArraySegment<byte> plain = new ArraySegment<byte>(Utils.SafeUTF8.GetBytes(plainText));
            //generate random salt
            CryptoRandom rng = new CryptoRandom();
            byte[] rand = rng.NextBytes(64);
            ArraySegment<byte> salt = new ArraySegment<byte>(rand);
            string ssalt = Convert.ToBase64String(rand);

            byte[] output = null;
    
            output = EtM_CTR.Encrypt(key, plain, salt, rounds);

            if (output == null)
                return null;

            string sout = Convert.ToBase64String(output);

            return sout + ssalt;
        }

        /// <summary>
        /// Decrypt base64 string with salt (chars 88)
        /// </summary>
        /// <param name="cipherText">cypher text with salt at the end.</param>
        /// <param name="passPhrase">password for the decryption.</param>
        /// <returns></returns>
        public static string Decrypt(string cipherText, string passPhrase)
        {
            Console.WriteLine("DECRYPT");
            //get nedded form of passphrase and cyphertext
            byte[] key = Utils.SafeUTF8.GetBytes(passPhrase);
            string salt = cipherText.Substring(cipherText.Length - 88);
            cipherText = cipherText.Substring(0, cipherText.Length - 88);
            ArraySegment<byte> bytecyphertext = new ArraySegment<byte>(Convert.FromBase64String(cipherText));
            ArraySegment<byte> bytesalt = new ArraySegment<byte>(Convert.FromBase64String(salt));

            byte[] decout = EtM_CTR.Decrypt(key, bytecyphertext, bytesalt, rounds);

            if (decout == null)
                return null;

            return Utils.SafeUTF8.GetString(decout);
        }
    }
}