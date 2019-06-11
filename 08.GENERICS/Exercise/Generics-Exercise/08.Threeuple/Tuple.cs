namespace _08.Threeuple
{
    public class Tuple<T, U , Y>
    {
        public Tuple(T unit1, U unit2, Y unit3)
        {
            this.Unit1 = unit1;
            this.Unit2 = unit2;
            this.Unit3 = unit3;
        }

        public T Unit1 { get; set; }

        public U Unit2 { get; set; }

        public Y Unit3 { get; set; }

        public override string ToString()
        {
            string result = $"{this.Unit1} -> {this.Unit2} -> {this.Unit3}";

            return result.ToString();
        }
    }
}
