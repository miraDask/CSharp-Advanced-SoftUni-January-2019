namespace _08.Custom_Comparator
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int, int, int> sortFunc = (x, y) => x.CompareTo(y);
            Action<int[], int[]> print = (x, y) => Console.WriteLine($"{string.Join(" ", x)} {string.Join(" ", y)}");

            int[] oddNums = numbers.Where(x => Math.Abs(x) % 2 == 1).ToArray();
            int[] evenNums = numbers.Where(x => Math.Abs(x) % 2 == 0).ToArray();

            Array.Sort(oddNums, new Comparison<int>(sortFunc));
            Array.Sort(evenNums, new Comparison<int>(sortFunc));

            print(evenNums, oddNums);
        }
    }
}
