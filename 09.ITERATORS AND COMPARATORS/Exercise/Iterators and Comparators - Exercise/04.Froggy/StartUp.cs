namespace _04.Froggy
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<int> elements = Console.ReadLine().Split(", ").Select(int.Parse).ToList();

            Lake<int> lake = new Lake<int>(elements);

            Console.WriteLine(string.Join(", ",lake));
        }
    }
}
