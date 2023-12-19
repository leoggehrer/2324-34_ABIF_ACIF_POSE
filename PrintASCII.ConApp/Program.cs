/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 PrintASCII
*                 This program outputs all ASCII characters 
*                 in the range 32 to 127.
*----------------------------------------------------------
*/
#nullable disable
namespace PrintASCII.ConApp
{
    /// <summary>
    /// Represents the entry point of the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The entry point for the application.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            const int FIRST_ASCII = 32;
            const int LAST_ASCII = 127;

            //Eingabe (E)
            Console.WriteLine("***************************************************");
            Console.WriteLine("* ASCII - Tabelle                                 *");
            Console.WriteLine("***************************************************");
            Console.WriteLine();

            //Verarbeitung (V) und Ausgabe (A)
            for (int idx = FIRST_ASCII; idx <= LAST_ASCII; idx++)
            {
                char printChar = Convert.ToChar(FIRST_ASCII + idx);
                string output = $"Zeichen: {printChar} Code: {idx,4} (dec) {idx.ToString("X4")} (hex)";

                Console.WriteLine(output);
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
