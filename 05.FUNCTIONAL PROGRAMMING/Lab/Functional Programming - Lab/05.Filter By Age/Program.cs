namespace _05.Filter_By_Age
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Person
    {
        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        public string Name { get; set; }
        public int Age { get; set; }

    }

    public class Program
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            int numOfInputs = int.Parse(Console.ReadLine());

            for (int i = 0; i < numOfInputs; i++)
            {
                var personInfo = Console.ReadLine()
                    .Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var person = new Person(personInfo[0], int.Parse(personInfo[1]));

                people.Add(person);
            }

            string condition = Console.ReadLine();
            int age = int.Parse(Console.ReadLine());
            string format = Console.ReadLine();

            Func<Person, bool> filter = FilterByCondition(condition, age);

            Func<Person,string> printerFormatSelect = SelectPrinter(format);

            people
                .Where(filter)
                .Select(printerFormatSelect)
                .ToList()
                .ForEach(Console.WriteLine);

        }

        private static Func<Person,string> SelectPrinter(string format)
        {

            switch (format)
            {
                case "name": return x => $"{x.Name}";
                case "age": return x => $"{x.Age}";
                case "age name": return x => $"{x.Age} - {x.Name}";
                case "name age": return x => $"{x.Name} - {x.Age}";
                default: return null;
            }

        }

        private static Func<Person, bool> FilterByCondition(string condition, int age)
        {
            switch (condition)
            {
                case "younger": return x => x.Age < age;
                case "older": return x => x.Age >= age;
                default: return null;

            }
        }
    }
}
