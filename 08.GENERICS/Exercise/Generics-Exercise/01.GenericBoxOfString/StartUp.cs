namespace _01.GenericBoxOfString
{
    using System;

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

            Console.WriteLine(box);
        }
    }
}
