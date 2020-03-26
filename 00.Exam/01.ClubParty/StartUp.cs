namespace _01.ClubParty
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int capacity = int.Parse(Console.ReadLine());
            string[] sequence = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            var peopleList = new List<int>();
            var hallsQueue = new Queue<char>();
            var sequenceStack = new Stack<string>(sequence);

            while (sequenceStack.Any())
            {
                var element = sequenceStack.Pop();

                try
                {
                    var people = int.Parse(element);
                    if (!hallsQueue.Any())
                    {
                        continue;
                    }

                    if (peopleList.Sum() + people <= capacity)
                    {
                        peopleList.Add(people);
                    }
                    else
                    {
                        var hall = hallsQueue.Dequeue();

                        Console.WriteLine($"{hall} -> {string.Join(", ", peopleList)}");
                        if (hallsQueue.Any())
                        {
                            peopleList = new List<int>() { people };
                        }
                        else
                        {
                            peopleList = new List<int>();
                        }
                    }
                }
                catch (Exception)
                {
                    var symbol = char.Parse(element);
                    hallsQueue.Enqueue(symbol);
                }
            }
        }
    }
}
