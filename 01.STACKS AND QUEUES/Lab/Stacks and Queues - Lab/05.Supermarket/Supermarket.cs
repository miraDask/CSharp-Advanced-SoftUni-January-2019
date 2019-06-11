using System;
using System.Collections.Generic;
using System.Text;

public class Supermarket
{
    public static void Main()
    {
        string input = Console.ReadLine();
        Queue<string> custumers = new Queue<string>();


        while (input != "End")
        {

            if (input == "Paid")
            {
                List<string> listOfPaidCustumers = new List<string>();

                while (custumers.Count > 0)
                {
                    listOfPaidCustumers.Add(custumers.Dequeue());
                }

                Console.WriteLine(string.Join(Environment.NewLine,listOfPaidCustumers));

            }
            else
            {
                custumers.Enqueue(input);
            }


            input = Console.ReadLine();
        }

        Console.WriteLine($"{custumers.Count} people remaining.");
    }
}

