namespace _12.Google
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Person> people = new List<Person>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] personData = input.Split(' ',StringSplitOptions.RemoveEmptyEntries);

                string name = personData[0];
                string typeOfData = personData[1];
                Person currentPerson;

                if (!people.Any(x => x.Name == name))
                {
                   currentPerson  = new Person(name);
                    people.Add(currentPerson);

                }

                currentPerson = people.Find(x => x.Name == name);

                switch (typeOfData)
                {
                    case "car":
                        string type = personData[2];
                        int speed = int.Parse(personData[3]);
                        currentPerson.Car = new Car(type, speed);
                        break;

                    case "company":
                        string companyName = personData[2];
                        string department = personData[3];
                        double salary = double.Parse(personData[4]);
                        currentPerson.Company =  new Company(companyName, department, salary);
                        break;

                    case "pokemon":
                        string pokemonName = personData[2];
                        string pokemonType = personData[3];
                        currentPerson.Pokemons.Add(new Pokemon(pokemonName, pokemonType));
                        break;

                    case "parents":
                        string parentName = personData[2];
                        string parentBirthday = personData[3];
                        currentPerson.Parents.Add(new FamilyMember(parentName, parentBirthday));
                        break;
                    case "children":
                        string childName = personData[2];
                        string childBirthday = personData[3];
                        currentPerson.Children.Add(new FamilyMember(childName, childBirthday));
                        break;
                }
            }

            string nameOfSearchedPerson = Console.ReadLine();

            Person searchedPerson = people.Find(x => x.Name == nameOfSearchedPerson);

            Console.WriteLine(string.Join("", searchedPerson));
        }
    }
}
