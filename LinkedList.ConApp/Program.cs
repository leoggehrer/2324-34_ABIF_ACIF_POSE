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

            Console.WriteLine("**********************");
            Console.WriteLine("* LinkedList         *");
            Console.WriteLine("**********************");
            Console.WriteLine();

            // Eingabe (E)
            do
            {
                Console.Write("List aktion [Enter...Exit]:  ");
                input = Console.ReadLine();
                if (input != string.Empty)
                {
                    // Verarbeitung (V)
                    Parse(input);
                }
            } while (input != string.Empty);
        }

        private static void Parse(string input)
        {
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            List list= new List();
            ObjectDiagram.Generate(list);

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
                ObjectDiagram.Generate(list);
            }
            list.Clear();
            ObjectDiagram.Generate(list);
        }
    }
}
