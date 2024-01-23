/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 DigitFilter
*                 The program filters all vocals from an 
*                 input text and outputs them.
*----------------------------------------------------------
*/
#nullable disable

namespace VocalFilterWithMethod.ConApp
{
    /// <summary>
    /// Represents the entry point of the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            string input, output = string.Empty;

            Console.WriteLine("***************************************************");
            Console.WriteLine("* Vocal Filter with Method                        *");
            Console.WriteLine("***************************************************");
            Console.WriteLine();

            // Eingabe (E)
            Console.Write("Eingabetext: ");
            input = Console.ReadLine();

            // Verarbeitung (V)
            output = FilterVocals(input);

            // Ausgabe (A)
            Console.WriteLine($"Ausgabetext: {output}");

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }

        /// <summary>
        /// Filters out the vowels from the input string and returns the result.
        /// </summary>
        /// <param name="input">The input string to filter.</param>
        /// <returns>The filtered string without vowels.</returns>
        public static string FilterVocals(string input)
        {
            string result = string.Empty;

            for (int i = 0; i < input.Length; i++)
            {
                char chr = char.ToLower(input[i]);

                if (chr == 'a' || chr == 'e' || chr == 'i' || chr == 'o' || chr == 'u')
                {
                    if (result.Contains(input[i]) == false)
                    {
                        result += input[i];
                    }
                }
            }
            return result;
        }
    }
}