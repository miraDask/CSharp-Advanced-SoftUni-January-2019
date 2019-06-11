using System;
using System.Collections.Generic;
using System.Linq;

public class BasicQueueOperations
{
    public static void Main()
    {
        int[] input = Console.ReadLine().Split().Select(int.Parse).ToArray();



        int[] numberSequence = Console.ReadLine().Split().Select(int.Parse).ToArray();

        Queue<int> numbers = new Queue<int>();

        int numCountToPushInStack = input[0];

        if (numberSequence.Length < numCountToPushInStack)
        {
            numCountToPushInStack = numberSequence.Length;
        }

        for (int i = 0; i < numCountToPushInStack; i++)
        {
            numbers.Enqueue(numberSequence[i]);
        }

        int numCountToPopFromStack = input[1];

        if (numCountToPopFromStack > numbers.Count)
        {
            numCountToPopFromStack = numbers.Count;
        }

        for (int i = 0; i < numCountToPopFromStack; i++)
        {
            numbers.Dequeue();
        }

        int searchedNumber = input[2];

        string output = string.Empty;

        if (numbers.Contains(searchedNumber))
        {
            output = "true";
        }
        else if (numbers.Count > 0)
        {
            output = numbers.Min().ToString();
        }
        else
        {
            output = "0";
        }

        Console.WriteLine(output);
    }
}


