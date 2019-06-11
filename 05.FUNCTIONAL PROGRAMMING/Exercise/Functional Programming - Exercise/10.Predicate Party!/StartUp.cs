namespace _10.Predicate_Party_
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<string> names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Party!")
                {
                    break;
                }

                string[] commandLine = input
                    .Split(" ", StringSplitOptions.RemoveEmptyEntries);

                string command = commandLine[0];
                string instruction = commandLine[1];
                string detailInfo = commandLine[2];

                Func<string, string, bool> predicator = GetPredicator(instruction);

                List<string> guestsToAdd = new List<string>();

                if (command == "Remove")
                {
                    names = names.Where(x => !predicator(x, detailInfo)).ToList();
                    
                }
                else if (command == "Double")
                {
                    guestsToAdd = names.Where(x => predicator(x, detailInfo)).ToList();

                    foreach (var name in guestsToAdd)
                    {
                        int index = names.IndexOf(name);

                        names.Insert(index + 1, name);
                    }
                }
            }

            Console.WriteLine(names.Any() ? $"{string.Join(", ", names)} are going to the party!" : "Nobody is going to the party!");
        }


        private static Func<string, string, bool> GetPredicator(string instruction)
        {

            switch (instruction)
            {
                case "StartsWith": return (x, y) => x.StartsWith(y);
                case "EndsWith": return (x, y) => x.EndsWith(y);
                case "Length": return (x, y) => x.Length == int.Parse(y);
                default: return null;

            }
        }
    }
}
