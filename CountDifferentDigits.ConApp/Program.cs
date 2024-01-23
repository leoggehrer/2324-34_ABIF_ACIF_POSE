/// <summary>
/// Represents the entry point of the program.
/// </summary>
/// <summary>
/// Represents the entry point of the program.
/// </summary>
/// <summary>
/// Represents the entry point of the program.
/// </summary>
/// <summary>
/// Represents the entry point of the program.
/// </summary>
/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Count Different Digits
*                 The program checks the entered digits (o...9) 
*                 and saves them in an array. The array is then 
*                 output and the different digits.
*----------------------------------------------------------
*/

#nullable disable
namespace CountDifferentDigits.ConApp
{
    internal class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            Console.WriteLine("Count Different Digits");
            Console.WriteLine("======================");
            Console.WriteLine();

            // Input (I)
            int[] digits = ReadDigits();

            // Processing (P)
            string output = string.Join("", digits);
            string uniqueDigits = GetUniqueDigitsString(digits);

            // Output (O)
            Console.WriteLine($"Eingegebene Ziffern im Array: {output}");
            Console.WriteLine($"Eindeutige Ziffern im Array : {uniqueDigits}");

            Console.WriteLine();
            Console.WriteLine("Beenden mit Eingabetaste... ");
            Console.ReadLine();
        }

        /// <summary>
        /// Reads a sequence of digits from the user.
        /// </summary>
        /// <returns>An array of integers representing the digits.</returns>
        public static int[] ReadDigits()
        {
            const int MAX_NUMBERS = 10;
            int[] result = new int[MAX_NUMBERS];
            int count = 1, index = 0;
            string input = string.Empty;

            while (count <= MAX_NUMBERS)
            {
                Console.Write($"{count, 2}. Ziffer [0-9] eingeben: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out result[index]))
                {
                    if (result[index] < 0 || result[index] > 9)
                    {
                        Console.WriteLine("Fehleingabe, Ziffer muss zwischen 0 und 9 liegen!");
                    }
                    else
                    {
                        count++;
                        index++;
                    }
                }
                else
                {
                    Console.WriteLine("Fehleingabe, es muss eine Ziffer zwischen 0 und 9 sein!");
                }
            }
            return result;
        }

        /// <summary>
        /// Returns a string containing unique digits from the given array.
        /// </summary>
        /// <param name="digits">An array of integers representing digits.</param>
        /// <returns>A string containing unique digits.</returns>
        public static string GetUniqueDigitsString(int[] digits)
        {
            string result = string.Empty;

            for (int i = 0; i < digits.Length; i++)
            {
                if (result.Contains(digits[i].ToString()) == false)
                {
                    result += digits[i].ToString();
                }
            }
            return result;
        }
    }
}
