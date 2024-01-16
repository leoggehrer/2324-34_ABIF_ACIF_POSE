/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 StringSearch
*                 Searches for a substring in a character string.
*----------------------------------------------------------
*/

#nullable disable
namespace StringSearch.ConApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string inputText, searchText;
            int index = -1;

            Console.WriteLine("String Search!");
            Console.WriteLine("==============");

            // Input (I)
            Console.WriteLine();
            Console.Write("Eingabetext....: ");
            inputText = Console.ReadLine();
            if (inputText != "")
            {
                Console.Write("Suchtext.......: ");
                searchText = Console.ReadLine();

                // Process (P)
                for (int i = 0; index == -1 && searchText.Length > 0 && i <= inputText.Length - searchText.Length; i++)
                {
                    int j = 0;
                    bool check = true;

                    while (check && j < searchText.Length)
                    {
                        check = char.ToLower(inputText[i + j]) == char.ToLower(searchText[j++]);
                    }

                    index = check ? i : index;
                }

                // Output (O)
                if (index >= 0)
                {
                    Console.WriteLine();
                    Console.WriteLine($"Der Suchtext wurde an der Position {index} gefunden.");
                }
                else
                {
                    Console.WriteLine();
                    Console.WriteLine($"Der Suchtext wurde nicht gefunden.");
                }

                Console.Write("Weiter mit Enter...");
                Console.ReadLine();
            }
        }
    }
}
