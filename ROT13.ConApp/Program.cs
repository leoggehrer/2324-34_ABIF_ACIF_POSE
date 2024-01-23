/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 ROT13
*                 This program encrypts and decrypts any 
*                 text using the ROT13 method.
*----------------------------------------------------------
*/
#nullable disable

namespace ROT13.ConApp
{
    /// <summary>
    /// Represents a program for calculating the total amount of money in a piggy bank.
    /// </summary>
    class Program
    {
        /// <summary>
        /// Main method for the "Sparschwein - Meine Bank, meine Zukunft" program.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        /// <returns>Void</returns>
        static void Main(string[] args)
        {
            string input, encrypted, decrypted;

            Console.WriteLine("***************************************************");
            Console.WriteLine("* Einfache Verschlüsselung nach ROT13             *");
            Console.WriteLine("***************************************************");
            Console.WriteLine();

            // Input (I)
            Console.Write("Zu verschlüsselnden Text: ");
            input = Console.ReadLine();
            // Process (P)
            encrypted = Encrypt(input);
            // Output (O)
            Console.WriteLine($"Verschlüsselter Text: {encrypted}");
            // Process (P)
            decrypted = Decrypt(encrypted);
            // Output (O)
            Console.WriteLine($"Entschlüsselter Text: {decrypted}");

            Console.WriteLine();
            Console.Write("Press enter to exit...");
            Console.ReadLine();
        }

        /// <summary>
        /// Decrypts the given encrypted string.
        /// </summary>
        /// <param name="encrypted">The encrypted string to be decrypted.</param>
        /// <returns>The decrypted string.</returns>
        private static string Decrypt(string encrypted)
        {
            return Encrypt(encrypted);
        }

        /// <summary>
        /// Encrypts a given input string using the ROT13 algorithm.
        /// </summary>
        /// <param name="input">The string to be encrypted.</param>
        /// <returns>The encrypted string.</returns>
        private static string Encrypt(string input)
        {
            string result = string.Empty;

            // Process (P)
            for (int i = 0; i < input.Length; i++)
            {
                char chr = char.ToLower(input[i]);

                if (chr >= 'a' && chr <= 'm')
                {
                    chr = Convert.ToChar(input[i] + 13);
                }
                else if (chr >= 'n' && chr <= 'z')
                {
                    chr = Convert.ToChar(input[i] - 13);
                }
                result += chr;
            }
            return result;
        }
    }
}