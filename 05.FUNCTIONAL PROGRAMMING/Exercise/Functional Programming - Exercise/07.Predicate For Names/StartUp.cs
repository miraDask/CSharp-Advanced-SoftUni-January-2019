namespace _07.Predicate_For_Names
{
    using System;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {

            int length = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(' ', StringSplitOptions.RemoveEmptyEntries);

            Func<string, bool> namePredicat = x => x.Length <= length;

            names = names.Where(x => namePredicat(x)).ToArray();

            Console.WriteLine(string.Join(Environment.NewLine, names));
        }
    }
}
