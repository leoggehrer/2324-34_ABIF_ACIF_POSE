namespace LinkedList.ConApp
{
    public partial class List {
        private class Node {
            public double Value { get; set; }
            public Node? Prev { get; set; }
            public Node? Next { get; set; }
        }

        #region Fields
        private Node? _head;
        #endregion Fields

        #region  Indexer
        /// <summary>
        /// Gets or sets the value at the specified index.
        /// </summary>
        /// <param name="index">The zero-based index of the element to get or set.</param>
        /// <returns>The value at the specified index.</returns>
        /// <exception cref="IndexOutOfRangeException">Thrown when the index is less than 0 or greater than or equal to the count of elements in the linked list.</exception>
        public double this[int index]
        {
            get
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException(nameof(index));
                }

                Node? run = _head;

                for (int i = 0; i < index; i++)
                {
                    run = run!.Next;
                }

                return run!.Value;
            }
            set
            {
                if (index < 0 || index >= Count)
                {
                    throw new IndexOutOfRangeException(nameof(index));
                }

                Node? run = _head;

                for (int i = 0; i < index; i++)
                {
                    run = run!.Next;
                }

                run!.Value = value;
            }
        }
        #endregion Indexer

        #region Properties
        /// <summary>
        /// Gets the number of elements in the linked list.
        /// </summary>
        public int Count
        {
            get
            {
                int count = 0;
                Node? run = _head;

                while (run != null)
                {
                    count++;
                    run = run.Next;
                }

                return count;
            }
        }
        #endregion Properties

        #region methods
        public void Clear()
        {
            _head = null;
        }
        /// <summary>
        /// Adds a new node with the specified value to the end of the linked list.
        /// </summary>
        /// <param name="value">The value to be added.</param>
        public void Add(double value)
        {
            Node? newNode = new Node { Value = value };

            if (_head == null)
            {
                _head = newNode;
            }
            else
            {
                Node? run = _head;

                while (run?.Next != null)
                {
                    run = run.Next;
                }

                run!.Next = newNode;
                newNode.Prev = run;
            }
        }
        /// <summary>
        /// Removes the element at the specified index from the linked list.
        /// </summary>
        /// <param name="index">The zero-based index of the element to remove.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown when the index is less than zero or greater than or equal to the number of elements in the linked list.</exception>
        public void RemoveAt(int index)
        {
            if (index < 0 || index >= Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            Node? run = _head;

            for (int i = 0; i < index; i++)
            {
                run = run!.Next;
            }

            if (run!.Prev != null)
            {
                run.Prev.Next = run.Next;
            }
            else
            {
                _head = run.Next;
            }

            if (run.Next != null)
            {
                run.Next.Prev = run.Prev;
            }
        }
        /// <summary>
        /// Inserts a new node with the specified value at the specified index in the linked list.
        /// </summary>
        /// <param name="index">The zero-based index at which the new node should be inserted.</param>
        /// <param name="value">The value to be inserted in the new node.</param>
        /// <exception cref="IndexOutOfRangeException">Thrown when the index is less than zero or greater than the number of elements in the linked list.</exception>
        public void Insert(int index, double value)
        {
            if (index < 0 || index > Count)
            {
                throw new IndexOutOfRangeException(nameof(index));
            }

            Node? newNode = new Node { Value = value };

            if (index == 0)
            {
                newNode.Next = _head;
                _head = newNode;
            }
            else
            {
                Node? run = _head;

                for (int i = 0; i < index - 1; i++)
                {
                    run = run!.Next;
                }

                newNode.Next = run!.Next;
                newNode.Prev = run;
                run.Next = newNode;

                if (newNode.Next != null)
                {
                    newNode.Next.Prev = newNode;
                }
            }
        }
        #endregion methods
    }
}
