using System;
using System.Collections.Generic;

public class PeriodicTable
{
    public static void Main()
    {
        SortedSet<string> chemicalElements = new SortedSet<string>();
        int inputCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputCount; i++)
        {
            string[] compound = Console.ReadLine()
                .Split(' ',StringSplitOptions.RemoveEmptyEntries);

            foreach (var element in compound)
            {
                chemicalElements.Add(element);
            }
        }

        Console.WriteLine(string.Join(" ",chemicalElements));
    }
}

