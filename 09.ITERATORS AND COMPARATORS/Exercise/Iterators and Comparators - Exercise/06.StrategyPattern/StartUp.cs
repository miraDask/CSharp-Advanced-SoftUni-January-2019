namespace _06.StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            SortedSet<Person> peopleByName = new SortedSet<Person>(new NameComperaror());
            SortedSet<Person> peopleByAge = new SortedSet<Person>(new AgeComperator());

            int inputCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < inputCount; i++)
            {
                string[] personData = Console.ReadLine().Split(" ",StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                int age = int.Parse(personData[1]);

                peopleByName.Add(new Person(name, age));
                peopleByAge.Add(new Person(name, age));

            }

            Console.WriteLine(string.Join(Environment.NewLine,peopleByName));
            Console.WriteLine(string.Join(Environment.NewLine,peopleByAge));
        }
    }
}
