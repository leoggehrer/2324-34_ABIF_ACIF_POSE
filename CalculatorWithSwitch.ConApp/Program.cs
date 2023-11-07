/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 CalculatorWithSwitch
*                 This program returns the result of 2 floating
*                 point numbers. The arithmetic operations
*                 are +, -, * or /. The selection is
*                 evaluated using the switch statement.
*----------------------------------------------------------
*/

#nullable disable

namespace CalculatorWithSwitch.ConApp
{
    /// <summary>
    /// Represents the Program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main method of the program that acts as a calculator with switch
        /// </summary>
        /// <param name="args">An array of string arguments passed to the method</param>
        static void Main(string[] args)
        {
            string input, operation;
            double left, right, result;
            
            Console.WriteLine("CalculatorWithSwitch");
            Console.WriteLine("====================");
            Console.WriteLine();
            
            // Eingabe (E)
            Console.Write("Eingabe Zahl 1: ");
            input = Console.ReadLine();
            left = Convert.ToDouble(input);
            
            Console.Write("Eingabe Zahl 2: ");
            input = Console.ReadLine();
            right = Convert.ToDouble(input);
            
            Console.Write("Eingabe Operation [+, -, *, /]: ");
            operation = Console.ReadLine();
            
            // Verarbeitung (V)
            switch (operation)
            {
                case "+":
                result = left + right;
                break;
                case "-":
                result = left - right;
                break;
                case "*":
                result = left * right;
                break;
                case "/":
                result = left / right;
                break;
                default:
                result = 0;
                break;
            }
            // Ausgabe (A)
            Console.WriteLine();
            
            if (operation == "+" || operation == "-" || operation == "*" || operation == "/")
            {
                Console.WriteLine($"{left,10:f}");
                Console.WriteLine($"{operation}{right,9:f}");
                Console.WriteLine("----------");
                Console.WriteLine($"{result,10:f}");
            }
            else
            {
                Console.WriteLine("Ungültige Operation!");
            }
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
