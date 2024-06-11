using PlantUML.Logic.Extensions;

namespace HeapManager.Logic.UnitTests
{
    [TestClass]
    public class HeapUnitTest
    {
        #region helpers
        public static (string Name, string SubPath) GetSolutionItemDataFromPath(string path, string itemExtension)
        {
            var itemName = string.Empty;
            var subPath = path.StartsWith(Path.DirectorySeparatorChar) ? Path.DirectorySeparatorChar.ToString() : string.Empty;
            var itemsEnumerator = path.Split(Path.DirectorySeparatorChar, StringSplitOptions.RemoveEmptyEntries)
                                      .GetEnumerator();

            while (itemName.IsNullOrEmpty() && itemsEnumerator.MoveNext())
            {
                subPath = Path.Combine(subPath, itemsEnumerator.Current.ToString()!);

                var filePath = Path.Combine(subPath, $"{itemsEnumerator.Current}{itemExtension}");

                if (File.Exists(filePath))
                {
                    itemName = itemsEnumerator.Current.ToString() ?? string.Empty;
                }
            }
            return (itemName, subPath);
        }
        #endregion helpers

        #region class initialization
        [ClassInitialize]
        public static void ClassInitialize(TestContext testContext)
        {
            var currentPath = Directory.GetCurrentDirectory();
            var unitTestsPath = GetSolutionItemDataFromPath(currentPath, ".csproj").SubPath;

            ObjectDiagram.DiagramPath = Path.Combine(unitTestsPath, "diagrams");

            if (Directory.Exists(ObjectDiagram.DiagramPath) == false)
            {
                Directory.CreateDirectory(ObjectDiagram.DiagramPath);
            }
        }

        [ClassCleanup]
        public static void ClassCleanup()
        {
        }
        #endregion class initialization

        #region properties
        public TestContext? TestContext { get; set; }

        #endregion properties

        #region test initialization
        [TestInitialize]
        public void TestInitialize()
        {
            ObjectDiagram.FileName = TestContext!.TestName!;
        }

        [TestCleanup]
        public void TestCleanup()
        {
        }
        #endregion test initialization

        [TestMethod]
        public void Constructor_ValidSize_SetsSize()
        {
            // Arrange
            int size = 1000;

            // Act
            var heap = new Heap(size);
            ObjectDiagram.Create(heap);

            // Assert
            Assert.AreEqual(1, heap.Blocks); // Initially, there should be one block representing the whole heap
        }

        [TestMethod]
        public void Constructor_InvalidSize_SetsDefaultSize()
        {
            // Arrange
            int size = -1;

            // Act
            var heap = new Heap(size);
            ObjectDiagram.Create(heap);
            int blockCount = heap.Blocks;

            // Assert
            Assert.AreEqual(0, blockCount); // One block representing the whole heap
        }

        [TestMethod]
        public void Blocks_EmptyHeap_ReturnsOneBlock()
        {
            // Arrange
            var heap = new Heap(1000);

            ObjectDiagram.Create(heap);

            // Act
            int blockCount = heap.Blocks;

            // Assert
            Assert.AreEqual(1, blockCount);
        }

        [TestMethod]
        public void Blocks_OneAllocatedBlock_ReturnsTwoBlocks()
        {
            // Arrange
            var heap = new Heap(1000);

            ObjectDiagram.Create(heap);

            // Act
            int address = heap.GetMem(100);
            ObjectDiagram.Create(heap);
            int blockCount = heap.Blocks;

            // Assert
            Assert.AreEqual(2, blockCount); // One allocated block + one free block
        }

        [TestMethod]
        public void Blocks_MultipleAllocatedBlocks_ReturnsCorrectBlockCount()
        {
            // Arrange
            var heap = new Heap(1000);

            ObjectDiagram.Create(heap);

            // Act
            int address1 = heap.GetMem(100);
            ObjectDiagram.Create(heap);
            int address2 = heap.GetMem(200);
            ObjectDiagram.Create(heap);
            int blockCount = heap.Blocks;

            // Assert
            Assert.AreEqual(3, blockCount); // Two allocated blocks + one free block
        }

        [TestMethod]
        public void GetMem_AllocatesMemory_ReturnsAddress()
        {
            // Arrange
            var heap = new Heap(1000);

            ObjectDiagram.Create(heap);

            // Act
            int address = heap.GetMem(100);
            ObjectDiagram.Create(heap);

            // Assert
            Assert.AreEqual(0, address);
        }

        [TestMethod]
        public void GetMem_NoSpaceAvailable_ReturnsMinusOne()
        {
            // Arrange
            var heap = new Heap(100);

            ObjectDiagram.Create(heap);

            // Act
            int address1 = heap.GetMem(100);
            ObjectDiagram.Create(heap);
            int address2 = heap.GetMem(1);
            ObjectDiagram.Create(heap);

            // Assert
            Assert.AreEqual(-1, address2);
        }

        [TestMethod]
        public void GetMem_ExactFit_ReturnsAddress()
        {
            // Arrange
            var heap = new Heap(100);

            ObjectDiagram.Create(heap);

            // Act
            int address1 = heap.GetMem(50);
            ObjectDiagram.Create(heap);
            int address2 = heap.GetMem(50);
            ObjectDiagram.Create(heap);

            // Assert
            Assert.AreEqual(0, address1);
            Assert.AreEqual(50, address2);
        }

        [TestMethod]
        public void FreeMem_ValidAddress_FreesMemory()
        {
            // Arrange
            var heap = new Heap(1000);
            int address = heap.GetMem(100);

            ObjectDiagram.Create(heap);

            // Act
            bool result = heap.FreeMem(address);
            ObjectDiagram.Create(heap);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(1, heap.Blocks); // All memory should be free
        }

        [TestMethod]
        public void FreeMem_InvalidAddress_ReturnsFalse()
        {
            // Arrange
            var heap = new Heap(1000);

            ObjectDiagram.Create(heap);

            // Act
            bool result = heap.FreeMem(100);
            ObjectDiagram.Create(heap);

            // Assert
            Assert.IsFalse(result);
        }

        [TestMethod]
        public void FreeMem_MiddleBlock_FreesMemory()
        {
            // Arrange
            var heap = new Heap(1000);
            int address1 = heap.GetMem(100);
            int address2 = heap.GetMem(200);

            ObjectDiagram.Create(heap);

            // Act
            bool result = heap.FreeMem(address1);
            ObjectDiagram.Create(heap);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(3, heap.Blocks); // One allocated block + two free blocks
        }

        [TestMethod]
        public void GetMem_AfterFreeingBlock_ReusesFreedBlock()
        {
            // Arrange
            var heap = new Heap(1000);
            int address1 = heap.GetMem(100);

            ObjectDiagram.Create(heap);

            // Act
            bool result = heap.FreeMem(address1);
            ObjectDiagram.Create(heap);

            // Act
            int address2 = heap.GetMem(100);
            ObjectDiagram.Create(heap);

            // Assert
            Assert.IsTrue(result);
            Assert.AreEqual(0, address2); // The address should be reused
        }

        [TestMethod]
        public void GetMem_SplitBlockCorrectly()
        {
            // Arrange
            var heap = new Heap(1000);
            heap.GetMem(100);

            // Act
            int address = heap.GetMem(50);

            // Assert
            Assert.AreEqual(100, address);
            Assert.AreEqual(3, heap.Blocks); // Two allocated blocks + one free block
        }

        [TestMethod]
        public void GetMem_BestFitAllocation()
        {
            // Arrange
            var heap = new Heap(1000);
            int address1 = heap.GetMem(100); // Allocate 100
            int address2 = heap.GetMem(200); // Allocate 200

            ObjectDiagram.Create(heap);

            heap.FreeMem(address1); // Free the first block
            ObjectDiagram.Create(heap);

            // Act
            int address3 = heap.GetMem(50); // This should fit into the freed 100 block
            ObjectDiagram.Create(heap);
            // Assert
            Assert.AreEqual(0, address3); // Address should be the first block

            // Act
            int address4 = heap.GetMem(25); // This should fit into the freed 50 block
            ObjectDiagram.Create(heap);
            // Assert
            Assert.AreEqual(address3 + 50, address4); // Address should be the second block

            // Act
            int address5 = heap.GetMem(20); // This should fit into the freed 25 block
            ObjectDiagram.Create(heap);
            // Assert
            Assert.AreEqual(address4 + 25, address5); // Address should be the third block

            // Act
            int address6 = heap.GetMem(5); // This should fit into the freed 5 block
            ObjectDiagram.Create(heap);
            // Assert
            Assert.AreEqual(address5 + 20, address6); // Address should be the fourth block

            // Act
            int address7 = heap.GetMem(5); // This should allocated a new block
            ObjectDiagram.Create(heap);
            // Assert
            Assert.AreEqual(address2 + 200, address7); // Address should be the fourth block
        }

        [TestMethod]
        public void GetMem_WorstFitAllocation()
        {
            // Arrange
            var heap = new Heap(1000);
            int address1 = heap.GetMem(100); // Allocate 100
            int address2 = heap.GetMem(200); // Allocate 200

            ObjectDiagram.Create(heap);

            heap.FreeMem(address2); // Free the first block
            ObjectDiagram.Create(heap);

            // Act
            int address3 = heap.GetMem(150); // This should fit into the remaining space
            ObjectDiagram.Create(heap);

            // Assert
            Assert.AreEqual(address2, address3); // Address should be after the 200 block
        }

        [TestMethod]
        public void GetMem_ReallocationAfterMultipleFrees()
        {
            // Arrange
            var heap = new Heap(1000);
            int address1 = heap.GetMem(100);
            int address2 = heap.GetMem(200);

            ObjectDiagram.Create(heap);
            heap.FreeMem(address2);
            ObjectDiagram.Create(heap);
            heap.FreeMem(address1);
            ObjectDiagram.Create(heap);

            // Act
            int address = heap.GetMem(50);
            ObjectDiagram.Create(heap);

            // Assert
            Assert.AreEqual(0, address); // Should reuse the first freed block
        }

        [TestMethod]
        public void FreeMem_AllBlocksFreedCorrectly()
        {
            // Arrange
            var heap = new Heap(1000);
            int address1 = heap.GetMem(100);
            int address2 = heap.GetMem(200);
            int address3 = heap.GetMem(300);

            ObjectDiagram.Create(heap);

            // Act
            heap.FreeMem(address1);
            ObjectDiagram.Create(heap);
            heap.FreeMem(address2);
            ObjectDiagram.Create(heap);
            heap.FreeMem(address3);
            ObjectDiagram.Create(heap);

            // Assert
            Assert.AreEqual(1, heap.Blocks); // All memory should be free
        }

        [TestMethod]
        public void GetMem_FragmentsHeapBlocksCorrectly()
        {
            // Arrange
            var heap = new Heap(1000);
            int address1 = heap.GetMem(100); // Allocate 100
            int address2 = heap.GetMem(200); // Allocate 200
            int address3 = heap.GetMem(300); // Allocate 300

            ObjectDiagram.Create(heap);

            // Act
            bool result1 = heap.FreeMem(address1); // Free first block
            ObjectDiagram.Create(heap);
            Assert.IsTrue(result1);

            bool result2 = heap.FreeMem(address3); // Free third block
            ObjectDiagram.Create(heap);
            Assert.IsTrue(result2);

            // Assert
            Assert.AreEqual(3, heap.Blocks); // Two free blocks + one allocated block
        }

        [TestMethod]
        public void GetMem_FragmentsHeapGetMemCorrectly()
        {
            var heap = new Heap(1000);
            int address1 = heap.GetMem(20);
            int address2 = heap.GetMem(20);
            int address3 = heap.GetMem(20);
            int address4 = heap.GetMem(20);
            int address5 = heap.GetMem(20);

            ObjectDiagram.Create(heap);

            // Act
            bool result5 = heap.FreeMem(address5);

            ObjectDiagram.Create(heap);
            Assert.IsTrue(result5);

            bool result3 = heap.FreeMem(address3);

            ObjectDiagram.Create(heap);
            Assert.IsTrue(result3);

            int address6 = heap.GetMem(10);
            Assert.AreEqual(address6, address3);
        }

        [TestMethod]
        public void FreeMem_DoesNotAffectOtherBlocks()
        {
            // Arrange
            var heap = new Heap(1000);
            int address1 = heap.GetMem(100);
            int address2 = heap.GetMem(200);
            int address3 = heap.GetMem(300);

            ObjectDiagram.Create(heap);

            // Act
            heap.FreeMem(address2);
            ObjectDiagram.Create(heap);

            // Assert#
            int address4 = heap.GetMem(100); // Should reuse the second block
            ObjectDiagram.Create(heap);
            Assert.AreEqual(address2, address4);

            int address5 = heap.GetMem(100); // Should reuse the second block
            ObjectDiagram.Create(heap);
            Assert.AreEqual(address2 + 100, address5);

            int address6 = heap.GetMem(100); // Should allocated a new block
            ObjectDiagram.Create(heap);
            Assert.AreEqual(address3 + 300, address6);

            int address7 = heap.GetMem(200); // Should allocated a new block
            ObjectDiagram.Create(heap);
            Assert.AreEqual(address6 + 100, address7);
        }

        [TestMethod]
        public void FreeMem_HandlesMultipleFreesCorrectly()
        {
            // Arrange
            var heap = new Heap(1000);
            int address1 = heap.GetMem(100);
            int address2 = heap.GetMem(200);
            int address3 = heap.GetMem(300);

            // Act
            heap.FreeMem(address1);
            heap.FreeMem(address2);
            heap.FreeMem(address3);
            int address4 = heap.GetMem(50);

            // Assert
            Assert.AreEqual(0, address4); // Should reuse the first freed block
        }
    }
}