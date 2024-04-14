/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 StackCalculator
*                 This program implements a simple calculator after
*                 the reverse polish notation (RPN).
*----------------------------------------------------------
*/
#nullable disable
namespace StackCalculator.ConApp
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
            Console.WriteLine("* StackCalculator    *");
            Console.WriteLine("**********************");
            Console.WriteLine();

            // Eingabe (E)
            do
            {
                Console.Write("Rechenoperation [Enter...Exit]:  ");
                input = Console.ReadLine();
                if (input != string.Empty)
                {
                    // Verarbeitung (V)
                    double result = Parse(input);

                    // Ausgabe (A)
                    Console.WriteLine($"{input} = {result}");
                }
            } while (input != string.Empty);
        }

        private static double Parse(string input)
        {
            string[] parts = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);
            Stack stack= new Stack();

            for (int i = 0; i < parts.Length; i++)
            {
                if (parts[i] == "+")
                {
                    double b = stack.Pop();
                    double a = stack.Pop();

                    stack.Push(a + b);
                }
                else if (parts[i] == "-")
                {
                    double b = stack.Pop();
                    double a = stack.Pop();

                    stack.Push(a - b);
                }
                else if (parts[i] == "*")
                {
                    double b = stack.Pop();
                    double a = stack.Pop();

                    stack.Push(a * b);
                }
                else if (parts[i] == "/")
                {
                    double b = stack.Pop();
                    double a = stack.Pop();

                    stack.Push(a / b);
                }
                else if (double.TryParse(parts[i], out double opd))
                {
                    stack.Push(opd);
                }
            }
            return stack.Pop();
        }
    }
}
