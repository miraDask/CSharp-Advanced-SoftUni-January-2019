using System;
using System.Collections.Generic;
using System.Linq;

public class CountSameValuesInArray
{
    public static void Main(string[] args)
    {
        Dictionary<double, int> countOfValues = new Dictionary<double, int>();

        double[] input = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(double.Parse)
            .ToArray();

        foreach (var element in input)
        {
            if (countOfValues.ContainsKey(element) == false)
            {
                countOfValues.Add(element,0);
            }

            countOfValues[element] += 1;
        }

        foreach (var pair in countOfValues)
        {
            Console.WriteLine($"{pair.Key} - {pair.Value} times");
        }
    }
}

