namespace _08.Threeuple
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string[] firstInput = Console.ReadLine().Split();
            string firstPerson = $"{firstInput[0]} {firstInput[1]}";
            string address = firstInput[2];
            string town = firstInput[3];
            Tuple<string, string, string> nameAddress = new Tuple<string, string, string>(firstPerson, address, town);
            Console.WriteLine(nameAddress);

            string[] secondInput = Console.ReadLine().Split();
            string secondPerson = secondInput[0];
            int beers = int.Parse(secondInput[1]);
            string drunkOrNot = secondInput[2];
            bool isDrunk = drunkOrNot.ToLower() == "drunk";
            Tuple<string, int, bool> personBeerAmount = new Tuple<string, int, bool>(secondPerson, beers, isDrunk);
            Console.WriteLine(personBeerAmount);

            string[] lastInput = Console.ReadLine().Split();
            string thirdPerson = lastInput[0];
            double floatingPointNumber = double.Parse(lastInput[1]);
            string bankName = lastInput[2];
            Tuple<string, double, string> numbers = new Tuple<string, double, string>(thirdPerson, floatingPointNumber, bankName);
            Console.WriteLine(numbers);
        }
    }
}
