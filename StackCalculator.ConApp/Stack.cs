using System.ComponentModel.DataAnnotations;

namespace StackCalculator.ConApp
{
    public class Stack
    {
        #region nested class
        private class Element
        {
            public Element(double data, Element? next)
            {
                Data = data;
                Next = next;
            }
            public double Data { get; set; }
            public Element? Next { get; set; }
        }
        #endregion  nested class

        #region  fields
        private Element? head = null;
        #endregion fields

        #region  properties
        public bool IsEmpty
        {
            get
            {
                return head == null;
            }
        }
        #endregion properties

        #region constructors
        public Stack()
        {
            ObjectDiagram.Generate(this);
        }
        #endregion constructors

        #region  methods
        public void Push(double data)
        {
            string[] arra = new string[] { "Hallo", "Welt" };
            head = new Element(data, head);
            ObjectDiagram.Generate(this, arra);
        }
        public double Pop()
        {
            if (IsEmpty)
            {
                throw new InvalidOperationException("Stack is empty!");
            }
            
            Element tmp = head!;

            head = tmp.Next;
            ObjectDiagram.Generate(this);
            return tmp.Data;
        }
        #endregion methods
    }
}

