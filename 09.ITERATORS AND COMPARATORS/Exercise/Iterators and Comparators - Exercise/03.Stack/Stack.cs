namespace _03.Stack
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class Stack<T> : IEnumerable<T>
    {
        private List<T> stack;
        private int count;

        public Stack(params T[] elements)
        {
            this.stack = new List<T>(elements);
            this.Count = elements.Length;
        }

        public int Count
        {
            get
            {
                return this.stack.Count;
            }
            set => this.count = value;

        }

        public void Push(params T[] elements)
        {
            foreach (var element in elements)
            {
                this.stack.Add(element);
                this.Count++;
            }
        }

        public void Pop()
        {
            this.stack.RemoveAt(this.stack.Count - 1);
            this.Count--;
        }

        public IEnumerator<T> GetEnumerator()
        {
            for (int i = this.stack.Count - 1; i >= 0; i--)
            {
                yield return this.stack[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            for (int i = this.stack.Count - 1; i >= 0; i--)
            {
                result.AppendLine(this.stack[i].ToString());
            }

            return result.ToString().TrimEnd();
        }
    }
}
