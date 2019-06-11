using System;
using System.Collections.Generic;

public class UniqueUsernames
{
    public static void Main()
    {
        HashSet<string> users = new HashSet<string>();

        int inputCount = int.Parse(Console.ReadLine());

        for (int i = 0; i < inputCount; i++)
        {
            users.Add(Console.ReadLine());
        }

        Console.WriteLine(string.Join(Environment.NewLine,users));
    }
}

