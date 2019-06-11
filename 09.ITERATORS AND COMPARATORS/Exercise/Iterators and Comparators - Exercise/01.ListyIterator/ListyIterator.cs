namespace _01.ListyIterator
{
    using System;
    using System.Collections;
    using System.Collections.Generic;
    using System.Text;

    public class ListyIterator<T>
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

        public void Print()
        {
            if (this.collection.Count == 0)
            {
                Console.WriteLine("Invalid Operation!");
            }
            else
            {
                Console.WriteLine(this.collection[this.index]);
            }
        }

        public void END()
        {
            return;
        }
    }
}
