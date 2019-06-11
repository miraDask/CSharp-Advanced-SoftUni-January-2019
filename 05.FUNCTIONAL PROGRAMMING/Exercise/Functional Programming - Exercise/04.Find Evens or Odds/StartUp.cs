namespace _04.Find_Evens_or_Odds
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] range = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int start = range[0];
            int end = range[1];

            string type = Console.ReadLine();

            Predicate<int> filter = x => type == "odd" ? x % 2 != 0 : x % 2 == 0;

            List<int> numbers = new List<int>();

            for (int i = start; i <= end; i++)
            {
                numbers.Add(i);
            }

            Action<List<int>> printNumbers = x => Console.WriteLine(string.Join(' ', x.Where(y => filter(y))));

            printNumbers(numbers);
        }
    }
}
