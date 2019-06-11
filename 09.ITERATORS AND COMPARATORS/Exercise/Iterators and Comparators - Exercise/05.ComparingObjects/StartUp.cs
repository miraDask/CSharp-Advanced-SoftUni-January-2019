namespace _05.ComparingObjects
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            while (true)
            {
              

                string input = Console.ReadLine();

                if (input == "END")
                {
                    break;
                }

                string[] personData = input.Split();

                string name = personData[0];
                int age = int.Parse(personData[1]);
                string town = personData[2];

                people.Add(new Person(name,age,town));
            }

            int positionOfPersonOfComparisson = int.Parse(Console.ReadLine());

            var personToCompare = people[positionOfPersonOfComparisson - 1];

            int equalPeopleCount = 0;
            int unEqualPeopleCount = 0;
            

            foreach (var person in people)
            {
                if (personToCompare.isEqual(person))
                {
                    equalPeopleCount++;
                }
                else
                {
                    unEqualPeopleCount++;
                }
            }

            if (equalPeopleCount == 1)
            {
                Console.WriteLine("No matches");
            }
            else
            {
                Console.WriteLine($"{equalPeopleCount} {unEqualPeopleCount} {people.Count}");
            }
        }
    }
}
