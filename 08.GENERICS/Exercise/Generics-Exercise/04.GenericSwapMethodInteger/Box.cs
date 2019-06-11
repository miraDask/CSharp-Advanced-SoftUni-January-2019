namespace _04.GenericSwapMethodInteger
{
    using System.Collections.Generic;
    using System.Text;

    public class Box<T>
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
