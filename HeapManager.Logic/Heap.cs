namespace HeapManager.Logic
{
    /// <summary>
    /// Represents a heap data structure that manages memory blocks.
    /// </summary>
    public class Heap
    {
        #region fields
        private int _size;
        private Block? _first = null;
        #endregion fields

        #region embedded classes
        /// <summary>
        /// Represents a block of memory in the heap.
        /// </summary>
        private class Block
        {
            /// <summary>
            /// Gets or sets the starting address of the block.
            /// </summary>
            public int Address { get; set; }

            /// <summary>
            /// Gets or sets the size of the block.
            /// </summary>
            public int Size { get; set; }

            /// <summary>
            /// Gets or sets the reference to the next block in the heap.
            /// </summary>
            public Block? Next { get; set; }
        }
        #endregion embedded classes

        /// <summary>
        /// Initializes a new instance of the <see cref="Heap"/> class with the specified size.
        /// </summary>
        /// <param name="size">The size of the heap.</param>
        public Heap(int size)
        {
            _size = Math.Max(0, size);
        }

        /// <summary>
        /// Gets the number of blocks in the heap.
        /// </summary>
        public int Blocks
        {
            get
            {
                int result = 0;
                int lastAddress = 0;
                Block? prv = null;
                Block? cur = _first;

                while (cur != null)
                {
                    result += lastAddress == cur.Address ? 1 : 2;
                    lastAddress = cur.Address + cur.Size;

                    prv = cur;
                    cur = cur.Next;
                }

                if (lastAddress < _size)
                {
                    result++;
                }
                return result;
            }
        }

        /// <summary>
        /// Gets the total size of the used blocks in the heap.
        /// </summary>
        private int UsedSize
        {
            get
            {
                int result = 0;
                Block? run = _first;

                while (run != null)
                {
                    result += run.Size;
                    run = run.Next;
                }

                return result;
            }
        }

        /// <summary>
        /// Allocates a block of memory of the specified size in the heap.
        /// </summary>
        /// <param name="size">The size of the memory block to allocate.</param>
        /// <returns>The address of the allocated memory block, or -1 if allocation fails.</returns>
        public int GetMem(int size)
        {
            int result = -1;

            if (_first == null)
            {
                if (size >= 0 && size <= _size)
                {
                    _first = new Block { Address = 0, Size = size };
                    result = 0;
                }
            }
            else if (UsedSize + size <= _size)
            {
                Block? prv = _first;
                Block? cur = _first.Next;
                Block? ins = null;
                int bestSize = _size;
                int diffSize = _first.Address - 0;

                if (diffSize >= size)
                {
                    bestSize = diffSize;
                }

                while (cur != null)
                {
                    diffSize = cur.Address - (prv.Address + prv.Size);

                    if (diffSize >= size && diffSize < bestSize)
                    {
                        bestSize = diffSize;
                        ins = prv;
                    }
                    prv = cur;
                    cur = cur.Next;
                }

                diffSize = _size - (prv.Address + prv.Size);
                if (diffSize >= size && diffSize < bestSize)
                {
                    bestSize = diffSize;
                    ins = prv;
                }

                if (ins == null)
                {
                    _first = new Block { Address = 0, Size = size, Next = _first };
                    result = _first.Address;
                }
                else
                {
                    ins.Next = new Block { Address = ins.Address + ins.Size, Size = size, Next = ins.Next };
                    result = ins.Next.Address;
                }
            }
            return result;
        }

        /// <summary>
        /// Frees the memory block with the specified address.
        /// </summary>
        /// <param name="address">The address of the memory block to free.</param>
        /// <returns><c>true</c> if the memory block was successfully freed; otherwise, <c>false</c>.</returns>
        public bool FreeMem(int address)
        {
            bool result = false;

            if (_first != null && _first.Address == address)
            {
                _first = _first.Next;
                result = true;
            }
            else
            {
                Block? prv = _first;
                Block? cur = _first?.Next;

                while (cur != null && result == false)
                {
                    if (cur.Address == address)
                    {
                        prv!.Next = cur.Next;
                        result = true;
                    }
                    else
                    {
                        prv = cur;
                        cur = cur.Next;
                    }
                }
            }
            return result;
        }
    }
}

