/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Calculator
*                 A program that masters the four basic
*                 arithmetic operations (+, -, *, /) for
*                 the data type double.
*----------------------------------------------------------
*/

#nullable disable

namespace SimpleCalculator.ConApp
{
    /// <summary>
    /// Represents a simple calculator program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// This method takes user input for left and right operands, performs the selected arithmetic operation on them,
        /// and outputs the result.
        /// </summary>
        /// <param name="args">An array of command-line arguments.</param>
        static void Main(string[] args)
        {
            string input, output;
            string operation;
            double leftOpd, rightOpd, result;
            
            Console.WriteLine("Einfacher Rechner");
            Console.WriteLine("=================");
            
            // Eingabe (E)
            Console.Write("Linker Operand [double]: ");
            input = Console.ReadLine();
            leftOpd = Convert.ToDouble(input);
            
            Console.Write("Operation [+ - * /]: ");
            operation = Console.ReadLine();
            
            Console.Write("Rechter Operand [double]: ");
            input = Console.ReadLine();
            rightOpd = Convert.ToDouble(input);
            
            // Verarbeitung (V)
            if (operation == "+")
            {
                result = leftOpd + rightOpd;
                output = ($"Ergebnis von {leftOpd} + {rightOpd} = {result}");
            }
            else if (operation == "-")
            {
                result = leftOpd - rightOpd;
                output = ($"Ergebnis von {leftOpd} - {rightOpd} = {result}");
            }
            else if (operation == "*")
            {
                result = leftOpd * rightOpd;
                output = ($"Ergebnis von {leftOpd} * {rightOpd} = {result}");
            }
            else if (operation == "/")
            {
                result = leftOpd / rightOpd;
                output = ($"Ergebnis von {leftOpd} / {rightOpd} = {result}");
            }
            else
            {
                output = "Ungültige Eingabe!";
            }
            
            // Ausgabe (A)
            Console.WriteLine(output);
            Console.WriteLine("Beenden mit der Eingabetaste");
            
            Console.ReadLine();
        }
    }
}
