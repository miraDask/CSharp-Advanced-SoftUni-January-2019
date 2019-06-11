using System;
using System.Collections.Generic;

public class MatchingBrackets
{
    public static void Main()
    {
        string input = Console.ReadLine();
        Stack<int> brackets = new Stack<int>();

        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] == '(')
            {
                brackets.Push(i);
            }
            else if (input[i] == ')')
            {
                int startIndex = brackets.Pop();
                int endIndex = i;
                string result = string.Empty;

                for (int y = startIndex; y <= endIndex; y++)
                {
                    result += input[y];
                }

                Console.WriteLine(result);
            }
        }
    }
}


