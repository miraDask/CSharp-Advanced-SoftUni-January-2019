namespace _01.Sort_Even_Numbers
{
    using System;
    using System.Linq;

    public class SortEvenNumbers
    {
        public static void Main()
        {
            var result = Console.ReadLine()
                .Split(
                    new char[] { ',', ' ' }
                    , StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .Where(x => x % 2 == 0)
               .OrderBy(x => x)
               .ToList();

            Console.WriteLine(string.Join(", ", result));

        }
    }
}
