namespace _03.Custom_Min_Function
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] numSequence = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            Func<int[], int> MinNumberFinder = x => x.Min();

            Console.WriteLine(MinNumberFinder(numSequence));
        }
    }
}
