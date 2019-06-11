namespace BoxOfT
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Box<T>
    {
        public Box()
        {
            this.Collection = new List<T>();
        }

        public List<T> Collection { get; set; }

        public int Count { get; private set; }

        public void Add(T element)
        {
            this.Collection.Add(element);
            this.Count++;
        }

        public T Remove()
        {
            var removedElement = Collection.Last();
            this.Collection.RemoveAt(this.Collection.Count - 1);
            this.Count--;

            return removedElement;
        }

        public override string ToString()
        {
            string result = string.Empty;

            foreach (var item in this.Collection)
            {
                result += item + " ";
            }
            return result.ToString().TrimEnd();
        }
    }
}
