namespace _03.GenericSwapMethodString
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            Box<string> box = new Box<string>();

            int numberOfStrings = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStrings; i++)
            {
                string input = Console.ReadLine();
                box.Add(input);

            }

            int[] elementsToSwat = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();

            box.Swap<string>(elementsToSwat[0],elementsToSwat[1]);

            Console.WriteLine(box);
        }
    }
}
