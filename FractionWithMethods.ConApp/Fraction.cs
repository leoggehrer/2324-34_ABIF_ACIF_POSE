namespace FractionWithMethods.ConApp
{
    /// <summary>
    /// Represents a fraction with a numerator and a denominator.
    /// </summary>
    public class Fraction
    {
        #region fields
        private int _nominator = 0;
        private int _denominator = 1;
        #endregion fields

        #region properties
        /// <summary>
        /// Gets or sets the denominator of the fraction.
        /// </summary>
        public int Denominator
        {
            get { return _denominator; }
            set { _denominator = value; }
        }

        /// <summary>
        /// Gets or sets the numerator of the fraction.
        /// </summary>
        public int Nominator
        {
            get { return _nominator; }
            set { _nominator = value; }
        }
        #endregion properties

        #region constructors
        /// <summary>
        /// Initializes a new instance of the <see cref="Fraction"/> class with default values.
        /// </summary>
        public Fraction()
        {
            _nominator = 0;
            _denominator = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Fraction"/> class with the specified numerator and denominator.
        /// </summary>
        /// <param name="a">The numerator of the fraction.</param>
        /// <param name="b">The denominator of the fraction.</param>
        public Fraction(int a, int b)
        {
            _nominator = a;
            _denominator = b != 0 ? b : 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Fraction"/> class with the specified numerator and a denominator of 1.
        /// </summary>
        /// <param name="a">The numerator of the fraction.</param>
        public Fraction(int a)
        {
            _nominator = a != 0 ? a : 0;
            _denominator = 1;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Fraction"/> class with the values of another fraction.
        /// </summary>
        /// <param name="a">The fraction to copy the values from.</param>
        public Fraction(Fraction a)
        {
            _nominator = a._nominator;
            _denominator = a._denominator;
        }
        #endregion constructors

        #region methods
        /// <summary>
        /// Calculates and returns the decimal value of the fraction.
        /// </summary>
        /// <returns>The decimal value of the fraction.</returns>
        public float GetValue()
        {
            return (float)Nominator / Denominator;
        }

        /// <summary>
        /// Reduces the numerator and denominator.
        /// </summary>
        public void Shorten()
        {
            int cgd = CGD(Nominator, Denominator);

            Nominator /= cgd;
            Denominator /= cgd;
        }

        /// <summary>
        /// Adds two fractions and returns the result.
        /// </summary>
        /// <param name="a">The first fraction.</param>
        /// <param name="b">The second fraction.</param>
        /// <returns>The sum of the two fractions.</returns>
        public static Fraction Addition(Fraction a, Fraction b)
        {
            Fraction result;

            if (a.Denominator == b.Denominator)
                result = new Fraction(a.Nominator + b.Nominator, a.Denominator);
            else
                result = new Fraction((a.Nominator * b.Denominator + b.Nominator * a.Denominator), (a.Denominator * b.Denominator));
            
            int cgd = CGD(result.Nominator, result.Denominator);

            result.Denominator /= cgd;
            result.Nominator /= cgd;
            return result;
        }

        /// <summary>
        /// Subtracts one fraction from another and returns the result.
        /// </summary>
        /// <param name="a">The first fraction.</param>
        /// <param name="b">The second fraction.</param>
        /// <returns>The difference between the two fractions.</returns>
        public static Fraction Subtraction(Fraction a, Fraction b)
        {
            Fraction result;

            if (a.Denominator == b.Denominator)
                result = new Fraction(a.Nominator - b.Nominator, a.Denominator);
            else
                result = new Fraction((a.Nominator * b.Denominator - b.Nominator * a.Denominator), (a.Denominator * b.Denominator));

            int cgd = CGD(result.Nominator, result.Denominator);

            result.Denominator /= cgd;
            result.Nominator /= cgd;
            return result;
        }

        /// <summary>
        /// Multiplies two fractions and returns the result.
        /// </summary>
        /// <param name="a">The first fraction.</param>
        /// <param name="b">The second fraction.</param>
        /// <returns>The product of the two fractions.</returns>
        public static Fraction Multiplication(Fraction a, Fraction b)
        {
            Fraction result = new Fraction(a.Nominator * b.Nominator, a.Denominator * b.Denominator);

            int cgd = CGD(result.Nominator, result.Denominator);

            result.Denominator /= cgd;
            result.Nominator /= cgd;
            return result;
        }

        /// <summary>
        /// Divides one fraction by another and returns the result.
        /// </summary>
        /// <param name="a">The first fraction.</param>
        /// <param name="b">The second fraction.</param>
        /// <returns>The quotient of the two fractions.</returns>
        public static Fraction Division(Fraction a, Fraction b)
        {
            Fraction result = new Fraction(a.Nominator * b.Denominator, a.Denominator * b.Nominator);

            int cgd = CGD(result.Nominator, result.Denominator);

            result.Denominator /= cgd;
            result.Nominator /= cgd;
            return result;
        }

        /// <summary>
        /// Adds an integer to a fraction and returns the result.
        /// </summary>
        /// <param name="a">The fraction.</param>
        /// <param name="b">The integer.</param>
        /// <returns>The sum of the fraction and the integer.</returns>
        public static Fraction Addition(Fraction a, int b)
        {
            Fraction result = Addition(a, new Fraction(b));

            int cgd = CGD(result.Nominator, result.Denominator);

            result.Denominator /= cgd;
            result.Nominator /= cgd;
            return result;
        }

        /// <summary>
        /// Subtracts an integer from a fraction and returns the result.
        /// </summary>
        /// <param name="a">The fraction.</param>
        /// <param name="b">The integer.</param>
        /// <returns>The difference between the fraction and the integer.</returns>
        public static Fraction Subtraction(Fraction a, int b)
        {
            Fraction result = Subtraction(a, new Fraction(b));

            int cgd = CGD(result.Nominator, result.Denominator);

            result.Denominator /= cgd;
            result.Nominator /= cgd;
            return result;
        }
        /// <summary>
        /// Calculates the greatest common divisor (GCD) of two integers using the recursive method.
        /// </summary>
        /// <param name="a">The first integer.</param>
        /// <param name="b">The second integer.</param>
        /// <returns>The greatest common divisor of the two integers.</returns>
        public static int CGD(int a, int b)
        {
            if (b == 0)
            {
                return a;
            }
            else
            {
                return CGD(b, a % b);
            }
        }
        #endregion methods

        #region overrides
        /// <summary>
        /// Returns a string representation of the fraction.
        /// </summary>
        /// <returns>A string representation of the fraction.</returns>
        public override string ToString()
        {
            return $"{Nominator}/{Denominator}";
        }
        #endregion overrides
    }
}

