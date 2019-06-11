namespace _02.NestedLoops
{
    using System;

    public class Program
    {
        public static int[] numbers;

        public static void Main()
        {
            
            int n = int.Parse(Console.ReadLine());

            numbers = new int[n];
            int counter = 0;

            PrintNumber(n,counter);
        }

        private static void PrintNumber(int n, int counter)
        {
            if (counter >= n)
            {
                Console.WriteLine(string.Join(" ", numbers));
                return;
            }

            for (int i = 1; i <= n; i++)
            {
                numbers[counter] = i;
                PrintNumber(n, counter + 1);
            }

        }
    }
}
