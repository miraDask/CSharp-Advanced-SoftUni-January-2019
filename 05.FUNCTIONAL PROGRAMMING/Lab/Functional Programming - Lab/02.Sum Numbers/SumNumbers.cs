namespace _02.Sum_Numbers
{
    using System;
    using System.Linq;

    public class SumNumbers
    {
        public static void Main()
        {
            var numSequence = Console.ReadLine()
                .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Console.WriteLine($"{numSequence.Length}{Environment.NewLine}{numSequence.Sum()}");
        }
    }
}
