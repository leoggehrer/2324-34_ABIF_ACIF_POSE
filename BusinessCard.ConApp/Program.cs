/*----------------------------------------------------------
 *                 HTBLA-Leonding / Class: 3ABIF/3ACIF
 *----------------------------------------------------------
 *                 Hermann Mustermann
 *----------------------------------------------------------
 *                 You enter 3 terms via the console. Write 
 *                 a program that does all 6 possible
 *                 Outputs combinations of these 3 terms.
 *----------------------------------------------------------
 */
using System;
namespace BusinessCard.ConApp
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Visitenkarte");

            string username, adress;

            //Eingabe (E)
            Console.Write("Write your name:   ");
            username = Console.ReadLine();

            Console.Write("write your adress: ");
            adress = Console.ReadLine();

            //Verarbeitung (V)

            //Ausgabe (A)
            Console.WriteLine();
            Console.WriteLine("****************************************");
            Console.Write($"* {username,-37}");
            Console.WriteLine("*");
            Console.WriteLine("****************************************");
            Console.Write($"* {adress,-37}");
            Console.WriteLine("*");
            Console.WriteLine("****************************************");
        }
    }
}