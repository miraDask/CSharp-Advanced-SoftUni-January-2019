namespace _02.Knights_of_Honor
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> printNames = x => Console.WriteLine(string.Join(Environment.NewLine,x));

            printNames(names.Select(x => $"Sir {x}").ToArray());
        }
    }
}
