/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 LinkedList
*                 This program implements a simple linked list.
*----------------------------------------------------------
*/
#nullable disable

namespace LinkedList.ConApp
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
            string input;
            List list= new List();

            ObjectDiagram.Create(list);

            Console.WriteLine("**********************");
            Console.WriteLine("* LinkedList         *");
            Console.WriteLine("**********************");
            Console.WriteLine();

            Console.WriteLine("Befehle:");
            Console.WriteLine("  a <value>   - Fügt ein Element am Ende der Liste ein.");
            Console.WriteLine("  i <index> <value> - Fügt ein Element an der angegebenen Position ein.");
            Console.WriteLine("  r <index>   - Entfernt das Element an der angegebenen Position.");
            Console.WriteLine("  p           - Gibt die Liste aus.");
            // Eingabe (E)
            do
            {
                Console.Write("List aktion [Enter...Exit]:  ");
                input = Console.ReadLine();
                if (input != string.Empty)
                {
                    // Verarbeitung (V)
                    Parse(input, list);
                }
            } while (input != string.Empty);
        }

        /// <summary>
        /// Parses the input string and performs operations on the provided list.
        /// </summary>
        /// <param name="input">The input string to parse.</param>
        /// <param name="list">The list to perform operations on.</param>
        private static void Parse(string input, List list)
        {
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] == "a")
                {
                    list.Add(double.Parse(parts[++i]));
                }
                else if (parts[i] == "i")
                {
                    int idx = int.Parse(parts[++i]);
                    double val = double.Parse(parts[++i]);

                    list.Insert(idx, val);
                }
                else if (parts[i] == "r")
                {
                    int idx = int.Parse(parts[++i]);

                    list.RemoveAt(idx);
                }
                else if (parts[i] == "p")
                {
                    Console.WriteLine($"Content: {list}");
                }
                ObjectDiagram.Create(list);
            }
        }
    }
}
