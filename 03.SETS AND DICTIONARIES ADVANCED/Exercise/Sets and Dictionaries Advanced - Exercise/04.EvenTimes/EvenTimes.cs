using System;
using System.Collections.Generic;
using System.Linq;

public class EvenTimes
{
    public static void Main()
    {
        Dictionary<int, int> numbersReg = new Dictionary<int, int>();

        int inputCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputCount; i++)
        {
            int currentNumber = int.Parse(Console.ReadLine());

            if (!numbersReg.ContainsKey(currentNumber))
            {
                numbersReg[currentNumber] = 0;
            }

            numbersReg[currentNumber]++;

        }

        foreach (var kvp in numbersReg)
        {
            if (kvp.Value % 2 == 0)
            {
                Console.WriteLine(kvp.Key);
            }
        }

    }
}

