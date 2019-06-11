namespace _02.GenericBoxOfInteger
{
    using System;

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

            Console.WriteLine(box);
        }
    }
}
