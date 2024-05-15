using System.ComponentModel.DataAnnotations;

namespace UPNCalculator.ConApp
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
            head = new Element(data, head);
            ObjectDiagram.Generate(this);
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

