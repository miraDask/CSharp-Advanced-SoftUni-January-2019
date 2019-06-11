namespace _07.Tuple
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] firstInput = Console.ReadLine().Split();
            string firstPerson = $"{firstInput[0]} {firstInput[1]}";                                     
            string address = firstInput[2];
            Tuple<string, string> nameAddress = new Tuple<string, string>(firstPerson, address);
            Console.WriteLine(nameAddress);

            string[] secondInput = Console.ReadLine().Split();
            string secondPerson = secondInput[0];
            int beers = int.Parse(secondInput[1]);
            Tuple<string, int> personBeerAmount = new Tuple<string, int>(secondPerson, beers);
            Console.WriteLine(personBeerAmount);

            string[] lastInput = Console.ReadLine().Split();
            int number = int.Parse(lastInput[0]);
            double floatingPointNumber = double.Parse(lastInput[1]);
            Tuple<int, double> numbers = new Tuple<int, double>(number, floatingPointNumber);
            Console.WriteLine(numbers);
        }
    }
}
