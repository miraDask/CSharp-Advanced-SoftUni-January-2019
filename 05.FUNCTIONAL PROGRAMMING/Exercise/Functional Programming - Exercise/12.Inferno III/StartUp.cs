namespace _12.Inferno_III
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Command
    {
        public Command(string filter, string parameter)
        {
            this.Filter = filter;
            this.Parameter = parameter;
        }

        public string Filter { get; set; }
        public string Parameter { get; set; }

    }
    public class StartUp
    {
        public static void Main()
        {
            List<Command> commands = new List<Command>();

            List<int> numSequence = Console.ReadLine()
               .Split(' ', StringSplitOptions.RemoveEmptyEntries)
               .Select(int.Parse)
               .ToList();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Forge")
                {
                    break;
                }

                string[] commandData = input.Split(';', StringSplitOptions.RemoveEmptyEntries);

                string command = commandData[0];
                string filter = commandData[1];
                string parameter = commandData[2];

                if (command == "Exclude")
                {
                    var currentCommand = new Command(filter, parameter);
                    commands.Add(currentCommand);

                }
                else if (command == "Reverse")
                {
                    if (commands.Any(x => x.Filter == filter && x.Parameter == parameter))
                    {
                        var currentCommand = commands.Find(x => x.Filter == filter
                                                    && x.Parameter == parameter);

                        commands.Remove(currentCommand);
                    }
                }
            }

            List<int> indexToRemoveAt = new List<int>();
            Func<int, bool> filterPredicat;

            for (int i = 0; i < commands.Count; i++)
            {
                var command = commands[i];

                for (int j = 0; j < numSequence.Count; j++)
                {
                    int currentNum = numSequence[j];

                    int otherNum = GetSum(numSequence, currentNum, j, command.Filter);

                    filterPredicat = x => x + otherNum == int.Parse(command.Parameter);

                    if (filterPredicat(currentNum))
                    {
                        indexToRemoveAt.Add(j);
                    }
                }
            }

            indexToRemoveAt.Reverse();

            foreach (var index in indexToRemoveAt)
            {
                numSequence.RemoveAt(index);
            }

            Console.WriteLine(string.Join(" ",numSequence));
        }

        private static int GetSum(List<int> numSequence, int currentNum, int index, string filter)
        {
            int otherNum = 0;

            switch (filter)
            {
                case "Sum Left":
                    if (index - 1 >= 0)
                    {
                       otherNum = numSequence[index - 1];
                    }
                    break;

                case "Sum Right":
                    if (index + 1 <= numSequence.Count - 1)
                    {
                        otherNum = numSequence[index + 1];
                    }

                    break;

                case "Sum Left Right":

                    if (index - 1 >= 0)
                    {
                        otherNum += numSequence[index - 1];
                    }

                    if (index + 1 <= numSequence.Count - 1)
                    {
                        otherNum += numSequence[index + 1];
                    }

                    break;
            }

            return otherNum;
        }
    }
}
