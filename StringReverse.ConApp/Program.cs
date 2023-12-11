/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 StringReverse
*                 This program receives a text from the user, 
*                 converts it and outputs it to the console.
*----------------------------------------------------------
*/
#nullable disable
namespace StringReverse.ConApp
{
    internal class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            string input;
            string reverse = string.Empty;

            // Eingabe (E)
            Console.WriteLine("String Reverse");
            Console.WriteLine("==============");
            Console.WriteLine();

            Console.Write("Eingabe: ");
            input = Console.ReadLine();

            // Verarbeitung (V)
            for (int i = input.Length - 1; i >= 0; i--)
            {
                reverse = reverse + input[i];
            }

            // Ausgabe (A)
            Console.WriteLine(reverse);

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
