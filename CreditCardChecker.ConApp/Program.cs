/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 CreditCardChecker
*                 This program checks the number of a credit card.
*----------------------------------------------------------
*/
#nullable disable
namespace CreditCardChecker.ConApp
{
    /// <summary>
    /// Represents the entry point of the program.
    /// </summary>
    internal class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            string input, cardNumber = string.Empty;
            int idx;
            int sum = 0;
            int digit, diff;
            int evenSum = 0, oddSum = 0;
            bool valid = true;

            Console.WriteLine("***************************************************");
            Console.WriteLine("* Kreditkarten-Prüfer                             *");
            Console.WriteLine("***************************************************");
            Console.WriteLine();

            // Eingabe (E)
            Console.Write("Geben Sie Ihre 16-stellige Kreditkartennummer ein: ");
            input = Console.ReadLine();
            for (int i = 0; i < input.Length; i++)
            {
                if (char.IsWhiteSpace(input[i]) == false)
                {
                    cardNumber += input[i];
                }
            }

            valid = cardNumber.Length == 16;
            idx = 0;

            // Verarbeitung (V)
            while (valid && idx < cardNumber.Length)
            {
                valid = char.IsDigit(cardNumber[idx++]);
            }

            idx = 0;
            while (valid && idx < cardNumber.Length - 1)
            {
                digit = (cardNumber[idx] - '0') * 2;
                evenSum = digit > 9 ? evenSum + digit % 10 + (digit / 10 % 10)
                                    : evenSum + digit;
                idx = idx + 2;
            }

            idx = 1;
            while (valid && idx < cardNumber.Length - 1)
            {
                oddSum = oddSum + (cardNumber[idx] - '0');
                idx = idx + 2;
            }

            if (valid)
            {
                sum = evenSum + oddSum;
                diff = (10 - sum % 10) % 10;
                valid = diff == cardNumber[cardNumber.Length - 1] - '0';
            }

            // Ausgabe (A)
            Console.WriteLine();
            if (valid)
            {
                Console.WriteLine($"Die Kreditkartennummer '{input}' ist gültig.");
            }
            else
            {
                Console.WriteLine($"Die Kreditkartennummer '{input}' ist ungültig.");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}
