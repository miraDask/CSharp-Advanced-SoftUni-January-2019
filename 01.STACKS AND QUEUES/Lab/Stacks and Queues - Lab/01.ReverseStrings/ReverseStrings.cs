using System;
using System.Collections.Generic;
using System.Linq;

public class ReverseStrings
{
    static void Main()
    {
        string input = Console.ReadLine();

        Stack<char> text = new Stack<char>(input);

        Console.WriteLine(string.Join("", text));
    }


}


