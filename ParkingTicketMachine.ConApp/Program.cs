/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 ParkingTicketMachine
*                 The program creates parking tickets according 
*                 to the following requirements:
*                 In order to be allowed to park in the city 
*                 center of Linz, a parking ticket must first 
*                 be purchased from a machine beforehand.
*                 One hour of parking costs exactly one euro. 
*                 The minimum parking time is 30 minutes and the 
*                 maximum parking time is set at 90 minutes. 
*                 In contrast to the coffee machine the parking 
*                 ticket machine does not give change.
*----------------------------------------------------------
*/
#nullable disable

namespace ParkingTicketMachine.ConApp
{
    /// <summary>
    /// Represents the main program class for a number guessing game.
    /// </summary>
    internal class Program
    {
        private static int[] _coins = new int[] { 5, 10, 20, 50, 100, 200 };
        private const int _minTimeInMinutes = 30;
        private const int _maxTimeInMinutes = 90;
        private const int _minPaymentInCents = 50;
        private const int _maxPaymentInCents = 150;
        private const double _costPerMinute = 30 / 50.0;

        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            int payment = 0;

            Console.WriteLine("Parkschein Automat");
            Console.WriteLine("==================");
            Console.WriteLine();

            PrintHeader();
            payment = ReadParkingPayment();
            PrintTicket(payment);

            Console.WriteLine();
            Console.WriteLine("Programm beenden mit Eingabetaste...");
            Console.ReadLine();
        }

        /// <summary>
        /// Prints the program header.
        /// </summary>
        private static void PrintHeader()
        {
            Console.WriteLine($"Parkscheinautomat mit Mindestparkdauer {_minTimeInMinutes} Minuten und Höchstparkdauer {_maxTimeInMinutes} Minuten");
            Console.WriteLine("Tarif pro Stunde: 1 Euro");
            Console.WriteLine($"Zulässige Münzen: {string.Join(", ", _coins)} Cent");
            Console.WriteLine("Parkschein drucken mit d oder D");
        }

        /// <summary>
        /// Reads the parking payment from the user.
        /// </summary>
        /// <returns>The total payment in cents.</returns>
        private static int ReadParkingPayment()
        {
            int result = 0;
            bool exit = false;
            string input;

            do
            {
                Console.Write($"Parkzeit bisher: {(result >= _minPaymentInCents ? ToHoursFormat(ToMinutes(result)) : "00:00")}, Einwurf bisher: {result} Cent,  d für Ticket, Einwurf in Cent: ");
                input = Console.ReadLine();
                if (input.ToLower() == "d")
                {
                    if (result < _minPaymentInCents)
                    {
                        Console.Write($"Mindesteinwurf {_minPaymentInCents} Cent, bisher haben Sie {result} eingeworfen");
                    }
                    else
                    {
                        exit = true;
                    }
                }
                else if (int.TryParse(input, out int coin))
                {
                    if (_coins.Contains(coin))
                    {
                        result += coin;
                    }
                    else
                    {
                        Console.WriteLine($"'{coin}' ist ein ungültiger Wert!");
                    }
                }
            } while (exit == false && result < _maxPaymentInCents);
            return result;
        }

        /// <summary>
        /// Prints a ticket with information about payment and parking duration.
        /// </summary>
        /// <param name="paymentInCents">The payment amount in cents.</param>
        private static void PrintTicket(int paymentInCents)
        {
            Console.WriteLine("Ticket ausgeben:");
            if (paymentInCents > _maxPaymentInCents)
            {
                Console.WriteLine($"Danke für Ihre Spende von {paymentInCents - _maxPaymentInCents} Cent");
            }
            int minutes = ToMinutes(Math.Min(paymentInCents, _maxPaymentInCents));

            Console.WriteLine($"Sie dürfen {ToHoursFormat(minutes)} Stunden parken");
        }
        /// <summary>
        /// Converts the given amount in cents to minutes based on the cost per minute.
        /// </summary>
        /// <param name="throwInCents">The amount in cents to be converted to minutes.</param>
        /// <returns>The equivalent amount in minutes.</returns>
        private static int ToMinutes(int throwInCents)
        {
            return (int)(_costPerMinute * throwInCents);
        }
        /// <summary>
        /// Converts the given number of minutes to a formatted string representation in hours format (HH:mm).
        /// </summary>
        /// <param name="minutes">The number of minutes to be converted.</param>
        /// <returns>A string representing the given number of minutes in hours format (HH:mm).</returns>
        private static string ToHoursFormat(int minutes)
        {
            return $"{minutes / 60:D2}:{minutes % 60:D2}";
        }
    }
}
