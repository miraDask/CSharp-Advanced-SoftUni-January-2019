namespace _04.HitList
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            int targetInfoIndex = int.Parse(Console.ReadLine());

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "end transmissions")
                {
                    break;
                }

                string[] data = input.Split('=');

                string name = data[0];

                if (!people.Any(x => x.Name == name))
                {
                    people.Add(new Person(name));
                }

                var person = people.Find(x => x.Name == name);

                string[] personData = data[1].Split(';');

                foreach (var info in personData)
                {
                    string[] splitedInfo = info.Split(':');
                    string key = splitedInfo[0];
                    string value = splitedInfo[1];

                    if (!person.Data.ContainsKey(key))
                    {
                        person.Data[key] = value;
                        person.InfoIndex += key.Length + value.Length;
                    }
                    else
                    {
                        person.InfoIndex -= person.Data[key].Length;
                        person.Data[key] = value;
                        person.InfoIndex += value.Length;
                    }
                }
            }

            string[] killCommand = Console.ReadLine().Split();

            var personToKill = people.Find(x => x.Name == killCommand[1]);

            Console.WriteLine($"Info on {personToKill.Name}:");

            foreach (var kvp in personToKill.Data.OrderBy(x => x.Key))
            {
                Console.WriteLine($"---{kvp.Key}: {kvp.Value}");
            }
            Console.WriteLine($"Info index: {personToKill.InfoIndex}");

            if (personToKill.InfoIndex >= targetInfoIndex)
            {
                Console.WriteLine("Proceed");
            }
            else
            {
                int infoNeeded = targetInfoIndex - personToKill.InfoIndex;
                Console.WriteLine($"Need {infoNeeded} more info.");
            }
        }
    }

    public class Person
    {
        public Person(string name)
        {
            this.Name = name;
            this.Data = new Dictionary<string, string>();
            this.InfoIndex = 0;
        }

        public string Name { get; set; }

        public Dictionary<string, string> Data { get; set; }

        public int InfoIndex { get; set; }
    }
}
