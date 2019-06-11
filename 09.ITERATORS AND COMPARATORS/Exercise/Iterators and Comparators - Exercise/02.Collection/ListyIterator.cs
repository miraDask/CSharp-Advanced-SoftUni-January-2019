namespace _02.Collection
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class ListyIterator<T>: IEnumerable<T>
    {
        private int index;
        private List<T> collection;
        public ListyIterator(List<T> values)
        {
            this.collection = values;
            this.index = 0;
        }



        public bool HasNext()
        {
            if (index + 1 < this.collection.Count)
            {
                return true;
            }

            return false;
        }

        public bool Move()
        {
            if (HasNext())
            {
                index++;
                return true;
            }

            return false;
        }

        public string Print()
        {
            
            if (this.collection.Count == 0)
            {
                return "Invalid Operation!";
            }
            else
            {
                return this.collection[this.index].ToString();
            }
        }

        public string PrintAll()
        {
            string result = string.Empty;

            foreach (var item in collection)
            {
                result += item + " ";
            }

            return result;
        }

        public IEnumerator<T> GetEnumerator()
        {
            foreach (var item in collection)
            {
                yield return item;
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}
