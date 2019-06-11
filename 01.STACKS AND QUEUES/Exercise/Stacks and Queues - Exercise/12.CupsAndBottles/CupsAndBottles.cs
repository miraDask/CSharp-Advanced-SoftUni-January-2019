using System;
using System.Collections.Generic;
using System.Linq;

public class CupsAndBottles
{
    public static void Main()
    {
        int[] cupSequence = Console.ReadLine().Split().Select(int.Parse).ToArray();
        int[] bottleSequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Queue<int> cups = new Queue<int>(cupSequence);
        Stack<int> bottles = new Stack<int>(bottleSequence);

        int wastedLittersOfWater = 0;
        int currentCupValue = cups.Peek();

        while (cups.Any() && bottles.Any())
        {
            int currentBottleValue = bottles.Pop();


            if (currentBottleValue >= currentCupValue)
            {
                wastedLittersOfWater += (currentBottleValue - currentCupValue);
                cups.Dequeue();

                if (cups.Any())
                {
                    currentCupValue = cups.Peek();
                }
            }
            else
            {
                currentCupValue -= currentBottleValue;
            }
        }

        if (cups.Any() == false || (cups.Any() == false && bottles.Any() == false))
        {
            Console.WriteLine($"Bottles: {string.Join(" ",bottles)}{Environment.NewLine}Wasted litters of water: {wastedLittersOfWater}");
        }
        else if (bottles.Any() == false)
        {
            Console.WriteLine($"Cups: {string.Join(" ", cups)}{Environment.NewLine}Wasted litters of water: {wastedLittersOfWater}");

        }
    }
}

