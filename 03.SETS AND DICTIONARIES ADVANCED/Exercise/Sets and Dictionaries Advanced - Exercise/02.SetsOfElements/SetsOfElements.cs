using System;
using System.Collections.Generic;
using System.Linq;

public class SetsOfElements
{
    public static void Main()
    {
        HashSet<int> firstSetOfElements = new HashSet<int>();
        HashSet<int> secondSetOfElements = new HashSet<int>();

        int[] setsLengthInfo = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries)
            .Select(int.Parse)
            .ToArray();

        for (int i = 1; i <= setsLengthInfo[0] + setsLengthInfo[1]; i++)
        {
            int element = int.Parse(Console.ReadLine());

            if (i <= setsLengthInfo[0])
            {
                firstSetOfElements.Add(element);
            }
            else
            {
                secondSetOfElements.Add(element);
            }
        }

        List<int> repeatedElements = new List<int>();

        foreach (var element in firstSetOfElements)
        {
            if (secondSetOfElements.Contains(element))
            {
                repeatedElements.Add(element);
            }
        }

        if (repeatedElements.Count > 0)
        {
            Console.WriteLine(string.Join(" ", repeatedElements));
        }
        
    }
}

