using System;
using System.Collections.Generic;
using System.Linq;


public class SimpleCalculator
{
    public static void Main(string[] args)
    {
        string[] input = Console.ReadLine().Split();

        Stack<int> numbers = new Stack<int>();

        int firstNum = int.Parse(input[0]);

        numbers.Push(firstNum);

        string @operator = string.Empty;


        for (int i = 1; i < input.Length; i++)
        {
            if (i % 2 == 1)
            {
                @operator = input[i];
            }
            else
            {

                int currentNum = int.Parse(input[i]);
                int prevNum = numbers.Peek();
                int newNum = GetNum(@operator, currentNum, prevNum);
                numbers.Push(newNum);
            }
        }

        Console.WriteLine(numbers.Peek());
    }

    private static int GetNum(string @operator, int currentNum, int prevNum)
    {
        if (@operator == "+")
        {
            return currentNum + prevNum;
        }
        else
        {
            return Math.Abs(currentNum - prevNum);
        }
    }
}

