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
namespace UPNCalculator.ConApp
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

            Console.WriteLine("********************");
            Console.WriteLine("* UPNCalculator    *");
            Console.WriteLine("********************");
            Console.WriteLine();

            // Eingabe (E)
            do
            {
                Console.Write("Arithmetic operation (form 3 5 + 2 *) [Enter...Exit]:  ");
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

        /// <summary>
        /// Parses a string input and evaluates it as a Reverse Polish Notation (RPN) expression.
        /// </summary>
        /// <param name="input">The string input representing the RPN expression.</param>
        /// <returns>The result of the evaluated RPN expression.</returns>
        public static double Parse(string input)
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
