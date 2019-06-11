namespace _05.GenericCountMethodString
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

            string textToCompare = Console.ReadLine();
            int result = box.GetCountOfGreaterValue(textToCompare);
           
            Console.WriteLine(result);
        }
    }
}
