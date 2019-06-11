namespace _07.Tuple
{
    public class Tuple<T,U>
    {
        public Tuple(T unit1, U unit2)
        {
            this.Unit1 = unit1;
            this.Unit2 = unit2;
        }

        public T Unit1 { get; set; }

        public U Unit2 { get; set; }

        public override string ToString()
        {
            string result = $"{this.Unit1} -> {this.Unit2}";

            return result.ToString();
        }
    }
}
