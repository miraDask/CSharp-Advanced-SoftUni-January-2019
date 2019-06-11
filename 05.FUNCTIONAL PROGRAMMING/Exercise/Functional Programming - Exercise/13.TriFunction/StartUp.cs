namespace _13.TriFunction
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            int symbolsLimit = int.Parse(Console.ReadLine());

            string[] names = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries);

            Func<string, char[]> stringToCharArrayFunc = x => x.ToCharArray();
            Func<char, int> castFunc = y => (int)y;
            Func<string, bool> resultFunc = x => stringToCharArrayFunc(x)
                 .Select(castFunc)
                 .Sum() >= symbolsLimit;

            string resultName = names.FirstOrDefault(resultFunc);

            if (resultName != null)
            {
                Console.WriteLine(resultName);
            }
        }
    }
}
