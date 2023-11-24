/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 ShoppingCart
*                 The program creates an invoice for online 
*                 purchases. The contents of the shopping 
*                 cart can consist of the following products:
*                   Net selling price,
*                   a number of pieces and
*                   a gift option.
*----------------------------------------------------------
*/

#nullable disable

namespace ShoppingCart.ConApp
{
    /// <summary>
    /// Represents a program for shopping cart.
    /// </summary>
    // ... rest of the code ...
    internal class Program
    {
        /// <summary>
        /// Main method that executes the shopping cart program.
        /// </summary>
        /// <param name="args">Command line arguments</param>
        static void Main(string[] args)
        {
            const double DELIVERI_COST = 5.90;
            string input = string.Empty, giftOption, location;
            int idx = 0, numberOfPieces;
            double nettoPrice, sumNettoPrice, sumNettoPriceAll = 0, sumGift = 0, sumGiftAll = 0;
            double sumGrossPriceAll, sumTaxAll, sumDeliveryCost = 0;

            Console.WriteLine("===========================================");
            Console.WriteLine(" Shopping Cart                             ");
            Console.WriteLine("===========================================");
            Console.WriteLine();

            while (input.ToLower() != "n")
            {
                // Eingabe (E)
                Console.WriteLine($"Eingabe von Produkt Nr. {++idx}");
                Console.Write("Netto-Stückpreis: ");
                input = Console.ReadLine();
                nettoPrice = Convert.ToDouble(input);

                Console.Write("Stückzahl:        ");
                input = Console.ReadLine();
                numberOfPieces = Convert.ToInt32(input);

                Console.Write("Geschenkoption ((j)a / (n)ein)? : ");
                giftOption = Console.ReadLine();

                // Verarbeitung (V)
                sumGift = 0;
                sumNettoPrice = nettoPrice * numberOfPieces;
                if (giftOption.ToLower() == "j")
                {
                    sumGift = numberOfPieces * 2.50;
                }
                sumNettoPriceAll += sumNettoPrice;
                sumGiftAll += sumGift;

                // Ausgabe (A)
                Console.WriteLine($"=> Nettopreis = {sumNettoPrice + sumGift,2:f2} EUR");
                if (sumGift > 0)
                {
                    Console.WriteLine($"=> zuzügl. Geschenkoption = {sumGift} EUR");
                }

                Console.Write("Ein weiteres Produkt eingeben ((j)a / (n)ein) ");
                input = Console.ReadLine();
                Console.WriteLine();
                idx++;
            }

            // Ausgabe (A)
            Console.Write("Lieferung nach de oder at? ");
            location = Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("===========================================");
            Console.WriteLine("Ihre Einkaufsrechnung                      ");
            Console.WriteLine("===========================================");
            Console.WriteLine();
            Console.Write("Nettopreis gesamt: ");
            Console.WriteLine($"{sumNettoPriceAll + sumGift,20:f2} EUR");

            if (sumNettoPriceAll < 29)
            {
                sumDeliveryCost = DELIVERI_COST;
                Console.Write("Versandkosten:     ");
                Console.WriteLine($"{sumDeliveryCost,20:f2} EUR");
            }

            if (location.ToLower() == "de")
            {
                sumGrossPriceAll = (sumNettoPriceAll + sumGiftAll) * 1.19;
                sumTaxAll = sumGrossPriceAll - sumNettoPriceAll - sumGiftAll;
            }
            else
            {
                sumGrossPriceAll = (sumNettoPriceAll + sumGiftAll) * 1.20;
                sumTaxAll = sumGrossPriceAll - sumNettoPriceAll - sumGiftAll;
            }

            Console.Write("Gesamtpreis:       ");
            Console.WriteLine($"{sumGrossPriceAll + sumDeliveryCost,20:f2} EUR");
            Console.WriteLine("===========================================");

            if (location.ToLower() == "at")
            {
                Console.Write("Darin enthalten sind 20,00 % MWSt. ");
                Console.WriteLine($"{sumTaxAll:f2} EUR");
            }
            else
            {
                Console.Write("Darin enthalten sind 19,00 % MWSt. ");
                Console.WriteLine($"{sumTaxAll:f2} EUR");
            }

            Console.WriteLine();
            Console.WriteLine("Press any key to exit: ");
            Console.ReadKey();
        }
    }
}