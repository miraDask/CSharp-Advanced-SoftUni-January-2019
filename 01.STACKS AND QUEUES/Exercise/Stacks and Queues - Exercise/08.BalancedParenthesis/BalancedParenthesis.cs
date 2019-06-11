using System;
using System.Collections.Generic;

class BalancedParenthesis
{
    static void Main()
    {
        string input = Console.ReadLine();

        if (input.Length % 2 == 1)
        {
            Console.WriteLine("NO");
            return;
        }


        Stack<char> brackets = new Stack<char>();

        for (int i = 0; i < input.Length; i++)
        {
            char currentElement = input[i];

            if (currentElement == '{' || currentElement == '(' || currentElement == '[')
            {
                brackets.Push(currentElement);
            }
            else
            {
                char balancedBracket = GetChar(brackets.Peek());

                if (currentElement != balancedBracket)
                {
                    Console.WriteLine("NO");
                    return;
                }
                else
                {
                    brackets.Pop();
                }

            }
        }

            Console.WriteLine("YES");
    }

    private static char GetChar(char first)
    {
        char result = ' ';

        switch (first)
        {
            case '(':
                result = ')';
                break;

            case '{':
                result = '}';
                break;
            
            case '[':
                result = ']';
                break;
            
        }

        return result;
    }
}


