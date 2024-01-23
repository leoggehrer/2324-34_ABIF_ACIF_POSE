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
                Console.Write($"{count}. Ziffer [0-9] eingeben: ");
                input = Console.ReadLine();
                if (int.TryParse(input, out result[index]))
                {
                    count++;
                    index++;
                }
                else
                {
                    Console.WriteLine("Fehleingabe, Ziffer muss zwischen 0 und 9 liegen!");
                }
            }
            return result;
        }

        public static string GetUniqueDigitsString(int[] digits)
        {
            string result = string.Empty;

            for (int i = 0, i < digits.length; i++)
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
