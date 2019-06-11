using System;
using System.Collections.Generic;

public class RecordUniqueNames
{
    public static void Main()
    {
        HashSet<string> names = new HashSet<string>();

        int numOfInputs = int.Parse(Console.ReadLine());

        for (int i = 0; i < numOfInputs; i++)
        {
            string name = Console.ReadLine();

            names.Add(name);
        }

        Console.WriteLine(string.Join(Environment.NewLine,names));
    }
}
