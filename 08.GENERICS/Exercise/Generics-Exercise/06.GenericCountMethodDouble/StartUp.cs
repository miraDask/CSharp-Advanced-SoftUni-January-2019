namespace _06.GenericCountMethodDouble
{
    using System;
    using System.Linq;

    public class StartUp
    {
        static void Main()
        {
            Box<double> box = new Box<double>();

            int numberOfStrings = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfStrings; i++)
            {
                double input = double.Parse(Console.ReadLine());
                box.Add(input);

            }

            double numberToCompare = double.Parse(Console.ReadLine());
            int result = box.GetCountOfGreaterValue(numberToCompare);
            Console.WriteLine(result);
        }
    }
}
