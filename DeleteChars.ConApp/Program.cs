/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 DeleteChars
*                 Extracts specified characters from any text.
*----------------------------------------------------------
*/

#nullable disable
namespace DeleteChars.ConApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputText, eliminatorText, outputText;

            Console.WriteLine("Delete Chars!");
            Console.WriteLine("=============");

            // Input (I)
            outputText = string.Empty;
            Console.WriteLine();
            Console.Write("Eingabetext....: ");
            inputText = Console.ReadLine();
            if (inputText != "")
            {
                Console.Write("Eliminatortext..: ");
                eliminatorText = Console.ReadLine();

                // Process (P)
                for (int i = 0; i < inputText.Length; i++)
                {
                    bool contains = false;

                    for (int j = 0; j < eliminatorText.Length && contains == false; j++)
                    {
                        if (inputText[i] == eliminatorText[j])
                        {
                            contains = true;
                        }
                    }
                    if (contains == false)
                    {
                        outputText = outputText + inputText[i];
                    }
                }

                // Output (O)
                Console.WriteLine();
                Console.WriteLine($"Ausgabetext....: {outputText}");

                Console.Write("Weiter mit beliebiger Taste ...");
                Console.ReadKey();
            }
        }
    }
}
