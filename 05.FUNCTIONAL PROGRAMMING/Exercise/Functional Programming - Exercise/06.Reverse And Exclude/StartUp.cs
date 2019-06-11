namespace _06.Reverse_And_Exclude
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int[] numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int divisor = int.Parse(Console.ReadLine());

            Action<int[]> reverseSequence = x => Array.Reverse(x);

            Func<int,bool> numberPredicat = x => x % divisor != 0;

            numbers = numbers
                .Where(x => numberPredicat(x))
                .ToArray();

            reverseSequence(numbers);

            Console.WriteLine(string.Join(' ', numbers));
            
        }
    }
}
