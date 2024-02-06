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
        private static int[] _coins = new int[] {5, 10, 20, 50, 100, 200 };
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
        /// 
        /// </summary>
        private static void PrintHeader()
        {
            Console.WriteLine($"Parkscheinautomat mit Mindestparkdauer {_minTimeInMinutes} Minuten und Höchstparkdauer {_maxTimeInMinutes} Minuten");
            Console.WriteLine("Tarif pro Stunde: 1 Euro");
            Console.WriteLine($"Zulässige Münzen: {string.Join(", ", _coins)} Cent");
            Console.WriteLine("Parkschein drucken mit d oder D");
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        private static int ReadParkingPayment()
        {
            int result = 0;
            string input = string.Empty;

            do
            {
                Console.Write($"Parkzeit bisher: {ToHoursFormat(ToMinutes(result))}, Einwurf bisher: {result} Cent,  d für Ticket, Einwurf in Cent: ");
                input = Console.ReadLine();
                if (input.ToLower() == "d" && result < _minPaymentInCents)
                {
                    Console.Write($"Mindesteinwurf {_minPaymentInCents} Cent, bisher haben Sie {result} eingeworfen");
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
            } while (input.ToLower() == "d" && result >= _minPaymentInCents || result < _maxPaymentInCents);
            return result;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="paymentInCents"></param>
        private static void PrintTicket(int paymentInCents)
        {
            Console.WriteLine("Ticket ausgeben:");
            if (paymentInCents > _maxPaymentInCents)
            {
                Console.WriteLine($"Danke für Ihre Spende von {_maxPaymentInCents - paymentInCents} Cent");
            }
            Console.WriteLine($"Sie dürfen {ToHoursFormat(Math.Min(paymentInCents, _maxPaymentInCents))} Stunden parken");
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="throwInCents"></param>
        /// <returns></returns>
        private static int ToMinutes(int throwInCents)
        {
            return (int)(_costPerMinute * throwInCents);
        }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="minutes"></param>
        /// <returns></returns>
        private static string ToHoursFormat(int minutes)
        {
            return $"{minutes / 60:D2}:{minutes % 60:D2}";
        }
    }
}
