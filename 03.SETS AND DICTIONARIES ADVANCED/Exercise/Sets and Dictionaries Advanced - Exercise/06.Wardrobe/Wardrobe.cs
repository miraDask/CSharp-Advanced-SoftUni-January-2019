using System;
using System.Collections.Generic;

public class Wardrobe
{
    public static void Main()
    {
        // color => cloth -> count
        var clothsReg = new Dictionary<string, Dictionary<string, int>>();

        int inputCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputCount; i++)
        {
            string[] input = Console.ReadLine()
                .Split(" -> "
                ,StringSplitOptions.RemoveEmptyEntries);

            string color = input[0];

            if (!clothsReg.ContainsKey(color))
            {
                clothsReg[color] = new Dictionary<string, int>();
            }

            var currentColor = clothsReg[color];

            string[] clothsData = input[1]
                .Split(',' , StringSplitOptions.RemoveEmptyEntries);

            for (int j = 0; j < clothsData.Length; j++)
            {

                string cloth = clothsData[j];

                if (!currentColor.ContainsKey(cloth))
                {
                    currentColor[cloth] = 0;
                }

                 currentColor[cloth]++;
            }
        }

        string[] searchedData = Console.ReadLine()
            .Split(' ', StringSplitOptions.RemoveEmptyEntries);

        string colorNeeded = searchedData[0];
        string clothNeeded = searchedData[1];
        

        foreach (var colorKvp in clothsReg)
        {
            string color = colorKvp.Key;
            var cloths = colorKvp.Value;
          
            Console.WriteLine($"{color} clothes:");

            foreach (var clothsKvp in cloths)
            {
                string currentCloth = clothsKvp.Key;
                int count = clothsKvp.Value;

                if (color == colorNeeded && currentCloth == clothNeeded)
                {
                    Console.WriteLine($"* {currentCloth} - {count} (found!)");
                }
                else
                {
                    Console.WriteLine($"* {currentCloth} - {count}");
                }
            }
        }
    }
}

