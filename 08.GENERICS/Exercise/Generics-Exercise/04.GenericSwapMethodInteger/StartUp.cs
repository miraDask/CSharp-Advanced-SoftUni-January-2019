namespace _04.GenericSwapMethodInteger
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            Box<int> box = new Box<int>();

            int numberOfStrings = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStrings; i++)
            {
                int input = int.Parse(Console.ReadLine());
                box.Add(input);

            }

            int[] elementsToSwat = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            box.Swap<string>(elementsToSwat[0], elementsToSwat[1]);

            Console.WriteLine(box);
        }
    }
}
