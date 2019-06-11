using System;
using System.Collections.Generic;

public class CountSymbols
{
    public static void Main()
    {
        SortedDictionary<char, int> charsReg = new SortedDictionary<char, int>();

        string input = Console.ReadLine();

        for (int i = 0; i < input.Length; i++)
        {
            char currentChar = input[i];

            if (!charsReg.ContainsKey(currentChar))
            {
                charsReg[currentChar] = 0;
            }

            charsReg[currentChar]++;

        }


        foreach (var kvp in charsReg)
        {
            Console.WriteLine($"{kvp.Key}: {kvp.Value} time/s");
        }
    }
}

