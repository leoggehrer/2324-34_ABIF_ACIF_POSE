/*----------------------------------------------------------
 *                 HTBLA-Leonding / Class: 3ABIF/3ACIF
 *----------------------------------------------------------
 *                 Hermann Mustermann
 *----------------------------------------------------------
 *                 This program calculates a worker's wages 
 *                 depending on his hourly rate and number 
 *                 of hours. 
 *----------------------------------------------------------
 */
namespace WageCalculator.ConApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string name, input;
            double hours, pricePerHour, salary;

            Console.WriteLine("***************************************************");
            Console.WriteLine("* Der Lohnrechner für eine gerechte Entlohnung!   *");
            Console.WriteLine("***************************************************");

            // Eingabe (E)
            Console.Write("Name des Arbeiters:        ");
            name = Console.ReadLine();

            Console.Write("Anzahl der Arbeitsstunden: ");
            hours = Convert.ToDouble(Console.ReadLine());

            Console.Write("Stundenlohn:               ");
            input = Console.ReadLine();
            pricePerHour = Convert.ToDouble(input);

            // Verarbeitung (V)
            salary = hours * pricePerHour;

            // Ausgabe (A)
            Console.WriteLine();
            Console.WriteLine($"{name} hat in {hours:f} Stunden {salary} EUR verdient.");

            Console.WriteLine();
            Console.Write("Zum Beenden Eingabetaste drücken...");
            Console.ReadLine();
        }
    }
}