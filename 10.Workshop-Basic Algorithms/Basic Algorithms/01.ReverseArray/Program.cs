namespace _01.ReverseArray
{
    using System;
    using System.Linq;

    public class Program
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine().Split().Select(int.Parse).ToArray();
            int last = numbers.Length - 1;

            PrintInReveresedOrder(numbers, last);
            Console.WriteLine();
        }

        private static void PrintInReveresedOrder(int[] numbers, int last)
        {
            if (last < 0)
            {
                return;
            }

            Console.Write(numbers[last] + " ");
            last--;
            PrintInReveresedOrder(numbers, last);
        }
    }
}
