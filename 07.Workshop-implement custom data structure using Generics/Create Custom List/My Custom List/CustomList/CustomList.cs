namespace CustomList
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class CustomList<T>
    {
        private const int InitialCapacity = 2;

        public CustomList()
        {
            this.Values = new T[InitialCapacity];
        }

        public T[] Values { get; set; }
        public int Count { get; private set; }

        public T this[int index]
        {
            get
            {
                ValidateIndex(index);
                return this.Values[index];
            }
            set
            {
                ValidateIndex(index);
                this.Values[index] = value;
            }
        }

        public void Add(T element)
        {
            int indexToAddAt = Count;

            if (indexToAddAt >= this.Values.Length)
            {
                this.ReSize();
            }

            if (this.Count == 0)
            {
                this.Values[0] = element;
            }
            else
            {
                this.Values[this.Count] = element;
            }

            this.Count++;

        }

        public void Swap(int firstIndex, int secondIndex)
        {
            ValidateIndex(firstIndex);
            ValidateIndex(secondIndex);

            var temp = this.Values[firstIndex];
            this.Values[firstIndex] = this.Values[secondIndex];
            this.Values[secondIndex] = temp;
        }

        public bool Contains(object element)
        {
            for (int i = 0; i < Count; i++)
            {
                if (element.Equals(this.Values[i]))
                {
                    return true;
                }
            }

            return false;
        }

        public void Insert(int index, T element)
        {
            ValidateIndex(index);

            if (Count == this.Values.Length)
            {
                this.ReSize();
            }
            this.ShiftRight(index);
            this.Values[index] = element;

            Count++;
        }

        public T RemoveAt(int indexToRemoveElementAt)
        {
            ValidateIndex(indexToRemoveElementAt);

            var elementToRemove = this.Values[indexToRemoveElementAt];

            this.Shift(indexToRemoveElementAt);
            Shrink();
            Count--;

            if (this.Count <= this.Values.Length / 4)
            {
                Shrink();
            }

            return elementToRemove;
        }

        public void Shrink()
        {
            var temp = new T[this.Values.Length / 2];

            for (int i = 0; i < this.Count -1; i++)
            {
                temp[i] = this.Values[i];
            }

            this.Values = temp;
        }

        public void ShiftRight(int index)
        {
            for (int i = Count; i > index; i--)
            {
                this.Values[i] = this.Values[i - 1];
            }
        }

        public void Shift(int indexToRemoveElementAt)
        {
            for (int i = indexToRemoveElementAt; i < this.Count - 1; i++)
            {
                this.Values[i] = this.Values[i + 1];
            }
        }

        public void ReSize()
        {
            T[] temp = new T[this.Values.Length * 2];

            for (int i = 0; i < this.Values.Length; i++)
            {
                temp[i] = this.Values[i];
            }

            this.Values = temp;
        }

        public void ValidateIndex(int index)
        {
            if (index < 0 || index >= this.Count)
            {
                throw new IndexOutOfRangeException();
            }
        }

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var item in this.Values)
            {
                result.Append(item + " ");
            }
            result.AppendLine();

            return result.ToString().TrimEnd();
        }
    }
}
