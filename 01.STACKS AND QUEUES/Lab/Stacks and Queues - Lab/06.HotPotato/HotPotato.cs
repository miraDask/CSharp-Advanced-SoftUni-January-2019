using System;
using System.Collections.Generic;


public class HotPotato
{
    public static void Main()
    {
        string[] names = Console.ReadLine().Split();
        int number = int.Parse(Console.ReadLine());
        Queue<string> participants = new Queue<string>(names);


        int count = 0;

        while (participants.Count > 1)
        {
            count++;

            if (count % number == 0)
            {
                Console.WriteLine($"Removed {participants.Dequeue()}");
            }
            else
            {
                string currentParticipant = participants.Dequeue();
                participants.Enqueue(currentParticipant);
            }
        }
        
        Console.WriteLine($"Last is {participants.Peek()}");
    }
}

