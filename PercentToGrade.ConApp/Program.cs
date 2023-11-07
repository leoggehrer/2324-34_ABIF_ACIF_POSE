/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 PercentToGrade
*                 This program maps a percentage value
*                 into a grade from 1 to 5.
*----------------------------------------------------------
*/

#nullable disable
namespace PercentToGrade.ConApp
{
    /// <summary>
    /// Represents the main class of the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// This method converts a given percent value to a corresponding grade.
        /// </summary>
        /// <param name="args">Command line arguments.</param>
        static void Main(string[] args)
        {
            string input;
            double percentValue;
            int grade;
            
            Console.WriteLine("Prozent --> Noten");
            Console.WriteLine("=================");
            Console.WriteLine();
            
            // Eingabe (E)
            Console.Write("Eingabe Prozentwert: ");
            input = Console.ReadLine();
            percentValue = Convert.ToDouble(input);
            
            // Verarbeitung (V)
            if (percentValue >= 88)
            {
                grade = 1;
            }
            else if (percentValue > 75)
            {
                grade = 2;
            }
            else if (percentValue >= 63)
            {
                grade = 3;
            }
            else if (percentValue >= 50)
            {
                grade = 4;
            }
            else if (percentValue >= 0)
            {
                grade = 5;
            }
            else
            {
                grade = -1;
            }
            
            // Ausgabe (A)
            Console.WriteLine();
            if (grade == -1)
            {
                Console.WriteLine("Ungültige Eingabe!");
            }
            else
            {
                Console.WriteLine($"Note = {grade, 3}");
            }
            
            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
