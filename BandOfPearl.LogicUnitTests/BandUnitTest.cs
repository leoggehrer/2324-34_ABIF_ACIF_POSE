using BandOfPearl.Logic;

namespace BandOfPearl.LogicUnitTests
{
    [TestClass]
    public class BandUnitTest
    {
        /// <summary>
        ///This is a test class for PearlNecklaceTest and is intended
        ///to contain all PearlNecklaceTest Unit Tests
        ///</summary>
        [TestClass()]
        public class BandTest
        {
            #region Additional test attributes
            // 
            //You can use the following additional attributes as you write your tests:
            //
            //Use ClassInitialize to run code before running the first test in the class
            //[ClassInitialize()]
            //public static void MyClassInitialize(TestContext testContext)
            //{
            //}
            //
            //Use ClassCleanup to run code after all tests in a class have run
            //[ClassCleanup()]
            //public static void MyClassCleanup()
            //{
            //}
            //
            //Use TestInitialize to run code before running each test
            //[TestInitialize()]
            //public void MyTestInitialize()
            //{
            //}
            //
            //Use TestCleanup to run code after each test has run
            //[TestCleanup()]
            //public void MyTestCleanup()
            //{
            //}
            //
            #endregion


            [TestMethod()]
            public void B01_Constructor()
            {
                Band band = new Band();
                Assert.AreEqual(0, band.Count);
            }


            [TestMethod()]
            public void B02_AddOne()
            {
                Band band = new Band();
                band.AddPearl(new Pearl("Red", 1.5));
                Assert.AreEqual(1, band.Count);
            }

            [TestMethod()]
            public void B03_AddOneGetAtPosition()
            {
                Band band = new Band();
                Pearl pearl = new Pearl("Red", 1.5);
                band.AddPearl(pearl);
                Pearl getPearl = band.GetPearlAtPosition(0);
                Assert.AreSame(pearl, getPearl);
            }

            [TestMethod()]
            public void B04_AddOneGetColor()
            {
                Band band = new Band();
                Pearl pearl = new Pearl("Red", 1.5);
                band.AddPearl(pearl);
                int count = band.GetNumberOfColoredPearls("Red");
                Assert.AreEqual(1, count);
                count = band.GetNumberOfColoredPearls("Blue");
                Assert.AreEqual(0, count);
            }

            [TestMethod()]
            public void B05_AddManyGetColor()
            {
                Band band = new Band();
                Pearl pearl = new Pearl("Red", 1.5);
                band.AddPearl(pearl);
                band.AddPearl(new Pearl("Blue", 2));
                band.AddPearl(new Pearl("Blue", 3));
                band.AddPearl(new Pearl("Red", 4.0));
                band.AddPearl(new Pearl("Green", 5.1));
                band.AddPearl(new Pearl("Blue", 6));
                band.AddPearl(new Pearl("Red", 7));
                int count = band.GetNumberOfColoredPearls("Red");
                Assert.AreEqual(3, count);
                count = band.GetNumberOfColoredPearls("Blue");
                Assert.AreEqual(3, count);
                count = band.GetNumberOfColoredPearls("Green");
                Assert.AreEqual(1, count);
            }

            [TestMethod()]
            public void B06_AddManyGetAtPosition()
            {
                Band band = new Band();
                Pearl pearl = new Pearl("Red", 1.5);
                band.AddPearl(pearl);
                band.AddPearl(new Pearl("Blue", 2));
                band.AddPearl(new Pearl("Blue", 3));
                band.AddPearl(new Pearl("Red", 4.0));
                band.AddPearl(new Pearl("Green", 5.1));
                band.AddPearl(new Pearl("Blue", 6));
                band.AddPearl(new Pearl("Red", 7));
                Assert.AreEqual(7, band.Count);
                Pearl getPearl = band.GetPearlAtPosition(0);
                Assert.AreEqual("Red", getPearl.Color);
                getPearl = band.GetPearlAtPosition(4);
                Assert.AreEqual("Blue", getPearl.Color);
                getPearl = band.GetPearlAtPosition(6);
                Assert.AreSame(pearl, getPearl);
            }

            [TestMethod()]
            public void B07_AddManyGetFailure()
            {
                Band band = new Band();
                Pearl pearl = new Pearl("Red", 1.5);
                band.AddPearl(pearl);
                band.AddPearl(new Pearl("Blue", 2));
                band.AddPearl(new Pearl("Blue", 3));
                band.AddPearl(new Pearl("Red", 4.0));
                band.AddPearl(new Pearl("Green", 5.1));
                band.AddPearl(new Pearl("Blue", 6));
                band.AddPearl(new Pearl("Red", 7));
                Assert.AreEqual(7, band.Count);
                Pearl getPearl = band.GetPearlAtPosition(7);
                Assert.IsNull(getPearl);
                getPearl = band.GetPearlAtPosition(-1);
                Assert.IsNull(getPearl);
                int count = band.GetNumberOfColoredPearls(null);
                Assert.AreEqual(0, count);
                band.AddPearl(null);
                Assert.AreEqual(7, band.Count);
            }
        }
    }
}