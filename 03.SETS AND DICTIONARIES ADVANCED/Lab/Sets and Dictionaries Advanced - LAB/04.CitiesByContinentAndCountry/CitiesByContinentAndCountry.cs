using System;
using System.Collections.Generic;
using System.Linq;

public class Country
{
    public Country(string name)
    {
        this.Name = name;
        this.Cities = new List<string>();
    }

    public string Name { get; set; }
    public List<string> Cities { get; set; }
}

public class CitiesByContinentAndCountry
{
    public static void Main()
    {
        // continents -> country
        Dictionary<string, List<Country>> continents = new Dictionary<string, List<Country>>();

        int numOfInputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < numOfInputs; i++)
        {
            string[] input = Console.ReadLine().Split();

            string continent = input[0];
            string country = input[1];
            string city = input[2];

            if (!continents.ContainsKey(continent))
            {
                continents.Add(continent, new List<Country>());
            }
            var countries = continents[continent];

            if (!countries.Any(c => c.Name == country))
            {
                countries.Add(new Country(country));
            }

            
                var currentCountry = countries.Find(c => c.Name == country);
                currentCountry.Cities.Add(city);
            
        }

        foreach (var continentKvp in continents)
        {
            Console.WriteLine($"{continentKvp.Key}:");

            foreach (var element in continentKvp.Value)
            {
                Console.WriteLine($"{element.Name} -> {string.Join(", ", element.Cities)}");
            }
        }
    }
}
