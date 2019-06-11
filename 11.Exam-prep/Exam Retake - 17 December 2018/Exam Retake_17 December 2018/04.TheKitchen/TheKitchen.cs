namespace _04.TheKitchen
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class TheKitchen
    {
        public static void Main()
        {
            int[] knivesSequence = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            int[] forksSequence = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToArray();

            Stack<int> knives = new Stack<int>(knivesSequence);
            Queue<int> forks = new Queue<int>(forksSequence);

            List<int> sets = new List<int>();

            while (knives.Any() && forks.Any())
            {
                int knife = knives.Peek();
                int fork = forks.Peek();

                if (knife == fork)
                {
                    forks.Dequeue();
                    knife = knives.Pop();
                    knife++;
                    knives.Push(knife);
                }
                else if (knife > fork)
                {
                    int currentSet = knives.Pop() + forks.Dequeue();
                    sets.Add(currentSet);

                }
                else
                {
                    knives.Pop();
                }
            }

            int biggestSet = sets.Max();

            Console.WriteLine($"The biggest set is: {biggestSet}" +
                $"{Environment.NewLine}{string.Join(" ",sets)}");
            
        }
    }
}
