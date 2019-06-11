namespace _01.Action_Print
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Action<string[]> printNames = x => Console.WriteLine(string.Join(Environment.NewLine, x));

            printNames(names);
        }
    }
}
