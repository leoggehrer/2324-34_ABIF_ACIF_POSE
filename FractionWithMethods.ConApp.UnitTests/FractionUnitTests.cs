using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FractionWithMethods.ConApp.Tests
{
    [TestClass()]
    public class FractionUnitTests
    {
        [TestMethod]
        public void DefaultConstructor_SetsDefaultValues()
        {
            Fraction fraction = new Fraction();

            Assert.AreEqual(0, fraction.Nominator);
            Assert.AreEqual(1, fraction.Denominator);
        }

        [TestMethod]
        public void Constructor_WithCustomValues_PositiveIntegers()
        {
            Fraction fraction = new Fraction(2, 3);

            Assert.AreEqual(2, fraction.Nominator);
            Assert.AreEqual(3, fraction.Denominator);
        }

        [TestMethod]
        public void Constructor_WithCustomValues_NegativeIntegers()
        {
            Fraction fraction = new Fraction(-5, -7);

            Assert.AreEqual(-5, fraction.Nominator);
            Assert.AreEqual(-7, fraction.Denominator);
        }

        [TestMethod]
        public void Constructor_WithZeroNominator()
        {
            Fraction fraction = new Fraction(0, 8);

            Assert.AreEqual(0, fraction.Nominator);
            Assert.AreEqual(8, fraction.Denominator);
        }

        [TestMethod]
        public void Constructor_WithZeroDenominator()
        {
            Fraction fraction = new Fraction(3, 0);

            Assert.AreEqual(3, fraction.Nominator);
            Assert.AreEqual(1, fraction.Denominator);
        }

        [TestMethod]
        public void Constructor_WithNegativeDenominator()
        {
            Fraction fraction = new Fraction(2, -4);

            Assert.AreEqual(2, fraction.Nominator);
            Assert.AreEqual(-4, fraction.Denominator);
        }

        [TestMethod]
        public void Constructor_WithNegativeNominator()
        {
            Fraction fraction = new Fraction(-5, 3);

            Assert.AreEqual(-5, fraction.Nominator);
            Assert.AreEqual(3, fraction.Denominator);
        }

        [TestMethod]
        public void Constructor_WithBothNegative()
        {
            Fraction fraction = new Fraction(-4, -6);

            Assert.AreEqual(-4, fraction.Nominator);
            Assert.AreEqual(-6, fraction.Denominator);
        }

        [TestMethod]
        public void Constructor_WithSameValues()
        {
            Fraction fraction = new Fraction(4, 4);

            Assert.AreEqual(4, fraction.Nominator);
            Assert.AreEqual(4, fraction.Denominator);
        }

        [TestMethod]
        public void Constructor_WithLargeValues()
        {
            Fraction fraction = new Fraction(int.MaxValue, int.MaxValue);

            Assert.AreEqual(int.MaxValue, fraction.Nominator);
            Assert.AreEqual(int.MaxValue, fraction.Denominator);
        }
    }
}