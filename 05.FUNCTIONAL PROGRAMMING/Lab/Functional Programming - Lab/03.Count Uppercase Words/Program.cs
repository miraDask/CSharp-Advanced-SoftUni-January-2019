namespace _03.Count_Uppercase_Words
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            Console.ReadLine()
                .Split(" ",StringSplitOptions.RemoveEmptyEntries)
                .Where(x => char.IsUpper(x[0]) == true)
                .ToList()
                .ForEach(Console.WriteLine);
        }
    }
}
