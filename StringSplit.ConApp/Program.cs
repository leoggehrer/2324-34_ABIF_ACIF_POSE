/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 StringSplit
*                 A program that reads any text and another 
*                 character “split” from the user. Then 
*                 split the entered text according to each 
*                 occurrence of the “Split” character 
*                 in the text.
*----------------------------------------------------------
*/
#nullable disable
namespace StringSplit.ConApp
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
            string input, splitText;

            Console.WriteLine("***************************************************");
            Console.WriteLine("* StringSplit - Ein einfacher Textsplit           *");
            Console.WriteLine("***************************************************");
            Console.WriteLine();

            // Eingabe (E)
            Console.Write("Eingabetext:  ");
            input = Console.ReadLine();

            do
            {
                Console.Write("Splitzeichen: ");
                splitText = Console.ReadLine();
            } while (splitText.Length != 1);

            // Verarbeitung (V) Ausgabe (A)
            Console.WriteLine("*** Ausgabetext ***");
            for(int i = 0; i < input.Length; i++)
            {
                if (input[i] == splitText[0])
                {
                    Console.WriteLine();
                }
                else
                {
                    Console.Write(input[i]);
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
