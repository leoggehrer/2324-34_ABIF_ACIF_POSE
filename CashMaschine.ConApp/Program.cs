/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 CashMachine
*                 This program simulates the withdrawal 
*                 process and is defined as follows:
*                     + The correct PIN is entered and is the one to be withdrawn
*                       Amount of money available (in the ATM and on the account), so will
*                       the amount paid out.
*                     + If the PIN is incorrect, it will be requested again. At the third
*                       If the PIN is entered incorrectly, the card will be retained and it is
*                       no withdrawal possible.
*                     + If the requested amount is not available, the customer will
*                       Asked to choose a different amount.
*----------------------------------------------------------
*/

#nullable disable

namespace CashMachine.ConApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            const int MAX_INCORRECT_ENTRIES = 3;
            const int DEFINED_PIN = 4711;
            const double COVER_FRAME = 1000;
            string input;
            bool userPinCorrect;
            int machineBalance = 20000;
            int userPin, userBalance = 1000;
            int numberOfInvalidPins = 0;
            int amount;

            Console.WriteLine();
            Console.WriteLine("**********************************");
            Console.WriteLine("         CASH MASHINE             ");
            Console.WriteLine("**********************************");

            do
            {
                // Eingabe (E)
                Console.WriteLine();
                Console.Write("Bitte geben Sie ihren 4 stelligen PIN-Code ein: ");
                input = Console.ReadLine();
                userPin = Convert.ToInt32(input);

                if (userPin != DEFINED_PIN)
                {
                    userPinCorrect = false;
                    numberOfInvalidPins++;
                    Console.WriteLine($"Sie haben {numberOfInvalidPins} mal einen falschen PIN eingegeben.");
                }
                else
                {
                    userPinCorrect = true;
                    numberOfInvalidPins = 0;
                }
            } while (numberOfInvalidPins < MAX_INCORRECT_ENTRIES && userPinCorrect == false);


            if (numberOfInvalidPins >= MAX_INCORRECT_ENTRIES)
            {
                Console.WriteLine();
                Console.WriteLine("Sie haben Ihren PIN zu oft eingegeben!");
                Console.WriteLine(" => Ihre Karte wird eingezogen!");
            }
            else if (userPinCorrect)
            {
                double maxAmount = Math.Min(machineBalance, userBalance + COVER_FRAME);

                // Ausgabe (A)
                Console.WriteLine($"Ihr Kontostand:                 {userBalance} EUR");
                Console.WriteLine($"Ihr Überziehungsrahmen:         {COVER_FRAME} EUR");
                Console.WriteLine("-----------------------------------------------------");
                Console.WriteLine($"maximaler Betrag                {maxAmount} EUR");
                Console.WriteLine();
                Console.Write("Geben Sie den Betrag ein, den Sie abheben wollen: ");

                // Verarbeitung (V)
                input = Console.ReadLine();
                amount = Convert.ToInt32(input);
                if (amount <= 0 || amount > maxAmount)
                {
                    Console.WriteLine("Ungültiger Betrag - bitte versuchen Sie es erneut!");
                    Console.WriteLine();
                    Console.Write("Geben Sie den Betrag ein, den Sie abheben wollen: ");
                    input = Console.ReadLine();
                    amount = Convert.ToInt32(input);
                }

                if (amount > 0 && amount <= maxAmount)
                {
                    Console.Write($"Soll der Betrag {amount:f2} EUR abgehoben werden [j/n]?: ");
                    input = Console.ReadLine();

                    if (input.ToLower() == "j")
                    {
                        userBalance = userBalance - amount;

                        Console.WriteLine($"Auszahlung des Betrages {amount:f2} EUR");
                        Console.WriteLine($"Ihr neuer Kontostand: {userBalance:f2} EUR");
                    }
                }
                else
                {
                    Console.WriteLine("Die Abhebung wurde ohne Auszahlung beendet!");
                }
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();

        }
    }
}