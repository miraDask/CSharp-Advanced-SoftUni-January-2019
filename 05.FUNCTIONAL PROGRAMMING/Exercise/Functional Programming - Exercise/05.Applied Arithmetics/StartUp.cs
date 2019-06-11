namespace _05.Applied_Arithmetics
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> numbers = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToList();

            while (true)
            {
                string command = Console.ReadLine();

                if (command == "end")
                {
                    break;
                }

                if (command != "print")
                {
                    Func<int, int> selectOperation = SelectOperation(command);
                    numbers = numbers.Select(selectOperation).ToList();
                }
                else
                {
                    Console.WriteLine(string.Join(' ', numbers));
                }
            }
        }

        private static Func<int, int> SelectOperation(string command)
        {
            switch (command)
            {
                case "add": return x => x + 1;
                case "multiply": return x => x * 2;
                case "subtract": return x => x - 1;
                default: return null;
            }
        }
    }
}
