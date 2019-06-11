using System;
using System.Collections.Generic;
using System.Linq;

public class FashionBoutique
{
    public static void Main()
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Stack<int> clothsPile = new Stack<int>(input);

        int ragCapacity = int.Parse(Console.ReadLine());

        int ragCount = 1;

        int clothsValueSum = 0;

        if (ragCapacity == 0)
        {
            Console.WriteLine(0);
        }

        while (clothsPile.Count > 0)
        {
            int currentClothsValue = clothsPile.Peek();
           
            if (clothsValueSum + currentClothsValue <= ragCapacity)
            {
                clothsValueSum += currentClothsValue;
                clothsPile.Pop();
                
            }
            else 
            {
                ragCount++;
                clothsValueSum = 0;
            }
        }

        Console.WriteLine(ragCount);
    }
}

