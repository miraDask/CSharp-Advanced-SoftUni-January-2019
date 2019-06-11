namespace _06.GenericCountMethodDouble
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Box<T> where T : IComparable<T>
    {

        public List<T> Value { get; set; } = new List<T>();
        public int Count => this.Value.Count;

        public void Swap<U>(int firstIndex, int secondIndex)
        {
            var temp = this.Value[firstIndex];
            this.Value[firstIndex] = this.Value[secondIndex];
            this.Value[secondIndex] = temp;
        }

        public void Add(T element)
        {
            this.Value.Add(element);
        }

        public int GetCountOfGreaterValue(T element)
        {
            int count = 0;

            foreach (var item in this.Value)
            {
                if (item.CompareTo(element) > 0)
                {
                    count++;
                }
            }

            return count;
        }


        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            foreach (var item in this.Value)
            {
                result.AppendLine($"{item.GetType()}: {item}");
            }

            return result.ToString().TrimEnd();
        }
    }
}
