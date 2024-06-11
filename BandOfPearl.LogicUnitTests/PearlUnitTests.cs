using BandOfPearl.Logic;

namespace TestProjectPearl
{
    /// <summary>
    ///This is a test class for PearlTest and is intended
    ///to contain all PearlTest Unit Tests
    ///</summary>
    [TestClass()]
    public class PearlTest
    {

        [TestMethod()]
        public void P01_ConstructorSimple()
        {
            Pearl pearl = new Pearl("Red", 1.7);
            Assert.AreEqual("Red", pearl.Color);
            Assert.AreEqual(1.7, pearl.Weight);
        }

        [TestMethod()]
        public void P02_ConstructorFailure()
        {
            Pearl pearl = new Pearl("Yellow", -10);
            Assert.AreEqual("Unknown", pearl.Color);
            Assert.AreEqual(0, pearl.Weight);
        }

        [TestMethod()]
        public void P03_ConstructorNullFailure()
        {
            Pearl pearl = new Pearl(null, -10);
            Assert.AreEqual("Unknown", pearl.Color);
            Assert.AreEqual(0, pearl.Weight);
        }
    }
}
