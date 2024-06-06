namespace HeapManager.Logic
{
    public class Heap
    {
        private int[] memory;
        private int blocks;
        private int blockSize;

        public int Blocks
        {
            get { return blocks; }
        }

        public Heap(int size)
        {
            memory = new int[size];
            blocks = 1;
            blockSize = size;
            memory[0] = size;
        }

        public int GetMem(int size)
        {
            if (size > blockSize)
                return -1;

            int adr = 0;
            while (adr < memory.Length)
            {
                if (memory[adr] >= size)
                {
                    if (memory[adr] > size)
                    {
                        memory[adr + size] = memory[adr] - size;
                        memory[adr] = size;
                        blocks++;
                    }
                    return adr;
                }
                adr += memory[adr] + 1;
            }
            return -1;
        }

        public bool FreeMem(int adr)
        {
            if (adr < 0 || adr >= memory.Length)
                return false;

            if (memory[adr] == 0)
                return false;

            memory[adr] = memory[adr + memory[adr]];
            blocks--;
            return true;
        }
    }
}

