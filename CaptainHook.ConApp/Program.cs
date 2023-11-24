/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Käpt'n Hook
*                 This program solves the puzzle from captain Hook.
*----------------------------------------------------------
*/
#nullable disable

namespace CaptainHook.ConApp
{
    /// <summary>
    /// Represents the main program class.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The main entry point for the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            const int PARAMS_PRODUCT = 32118;
            const int MAX_AGE = 100;
            int children;
            int age;
            int shipLength;

            Console.WriteLine("Käpt'n Hooks Rätsel");
            Console.WriteLine("===================");
            Console.WriteLine();

            // Eingabe (E)
            children = 4;       // Söhne und Töchter >= 4
            age = children + 1; // aelter als seine die Anzahl seiner Kinder
            shipLength = 1;     // muss > 0 sein

            // Verarbeitung (V)
            while (children * age * shipLength != PARAMS_PRODUCT && children < MAX_AGE)
            {
                children++;
                age = children;
                do
                {
                    age++;  // aelter als seine die Anzahl seiner Kinder
                    shipLength = PARAMS_PRODUCT / (children * age);
                } while (children * age * shipLength != PARAMS_PRODUCT && age < MAX_AGE);
            }

            // Ausgabe (A)
            if (children * age * shipLength == PARAMS_PRODUCT)
            {  // Loesung gefunden
                Console.WriteLine();
                Console.WriteLine($"Die Lösung des Rätsels:");
                Console.WriteLine($"Anzahl der Kinder:     {children}");
                Console.WriteLine($"Alter des Kapitains:   {age}");
                Console.WriteLine($"Schiffslänge in Meter: {shipLength}");
            }
            else
            {
                Console.WriteLine();
                Console.WriteLine($"Es gibt keine Lösung für das Produkt der Parameter von {PARAMS_PRODUCT}!");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
