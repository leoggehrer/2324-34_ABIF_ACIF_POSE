/*----------------------------------------------------------
*                 HTBLA-Leonding / Class: 3ABIF/3ACIF
*----------------------------------------------------------
*                 Hermann Mustermann
*----------------------------------------------------------
*                 Fraction with operators
*----------------------------------------------------------
*/
#nullable disable
namespace FractionWithOperators.ConApp
{
    internal class Program
    {
        /// <summary>
        /// The entry point of the program.
        /// </summary>
        /// <param name="args">The command-line arguments.</param>
        static void Main(string[] args)
        {
            // Eingabe (E)
            Console.WriteLine("***************************************");
            Console.WriteLine("* Fraction with operators             *");
            Console.WriteLine("***************************************");

            Fraction a = new Fraction();        // Zähler:0, Nenner: 1
            Fraction b = new Fraction(6, 4);    // Zähler:6, Nenner: 4
            Fraction c = new Fraction(5);       // Zähler:5, Nenner: 1
            Fraction d = new Fraction(b);       // Zähler:6, Nenner: 4
            Fraction e = new Fraction(3, 0);    // Zähler:3, Nenner: 1, d.h. Nenner 0 ist nicht erlaubt
            Fraction f, g, h, i, j, k, l, m, n, o, p, q, s;

            
            Console.WriteLine($"Bruch a: {a} ... Wert von a: {a.GetValue()}");
            Console.WriteLine($"Bruch b: {b} ... Wert von a: {b.GetValue()}");
            Console.WriteLine($"Bruch c: {c} ... Wert von a: {c.GetValue()}");
            Console.WriteLine($"Bruch d: {d} ... Wert von a: {d.GetValue()}");
            Console.WriteLine($"Bruch e: {e} ... Wert von a: {e.GetValue()}");


            s = a + 3;  // Fraction.Addition(a, 3);
            f = b + d;  // Fraction.Addition(b, d);
            g = c + e;  // Fraction.Addition(c, e);
            h = f + g;  // Fraction.Addition(f, g);
            Console.WriteLine();
            Console.WriteLine($"Addition von Bruch {b} und {d} = {f.ToString()} ... Wert vom Bruch = {f.GetValue()}");
            Console.WriteLine($"Addition von Bruch {c} und {e} = {g.ToString()} ... Wert vom Bruch = {g.GetValue()}");
            Console.WriteLine($"Addition von Bruch {f} und {g} = {h.ToString()} ... Wert vom Bruch = {h.GetValue()}");
            Console.WriteLine($"Addition von Bruch {a} und {3} = {s.ToString()} ... Wert vom Bruch = {s.GetValue()}");


            i = b - d;  // Fraction.Subtraction(b, d);
            j = c - e;  // Fraction.Subtraction(c, e);
            k = f - g;  // Fraction.Subtraction(f, g);
            Console.WriteLine();
            Console.WriteLine($"Subtraktion von Bruch {b} und {d} = {i.ToString()} ... Wert vom Bruch = {i.GetValue()}");
            Console.WriteLine($"Subtraktion von Bruch {c} und {e} = {j.ToString()} ... Wert vom Bruch = {j.GetValue()}");
            Console.WriteLine($"Subtraktion von Bruch {f} und {g} = {k.ToString()} ... Wert vom Bruch = {k.GetValue()}");


            l = b / d;  // Fraction.Division(b, d);
            m = c / e;  // Fraction.Division(c, e);
            n = f / g;  // Fraction.Division(f, g);
            Console.WriteLine();
            Console.WriteLine($"Division von Bruch {b} und {d} = {l.ToString()} ... Wert vom Bruch = {l.GetValue()}");
            Console.WriteLine($"Division von Bruch {c} und {e} = {m.ToString()} ... Wert vom Bruch = {m.GetValue()}");
            Console.WriteLine($"Division von Bruch {f} und {g} = {n.ToString()} ... Wert vom Bruch = {n.GetValue()}");


            o = b * d;  // Fraction.Multiplication(b, d);
            p = c * e;  // Fraction.Multiplication(c, e);
            q = f * g;  // Fraction.Multiplication(f, g);
            Console.WriteLine();
            Console.WriteLine($"Multiplikation von Bruch {b} und {d} = {o.ToString()} ... Wert vom Bruch = {o.GetValue()}");
            Console.WriteLine($"Multiplikation von Bruch {c} und {e} = {p.ToString()} ... Wert vom Bruch = {p.GetValue()}");
            Console.WriteLine($"Multiplikation von Bruch {f} und {g} = {q.ToString()} ... Wert vom Bruch = {q.GetValue()}");

            Console.WriteLine();
            Console.WriteLine("Press enter to exit: ");
            Console.ReadLine();
        }
    }
}
