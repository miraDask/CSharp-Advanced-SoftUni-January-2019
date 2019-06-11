using System;
using System.Collections.Generic;

public class TruckTour
{
    public static void Main()
    {
        int pumpsCount = int.Parse(Console.ReadLine());
        Queue<string> pumps = new Queue<string>();
        Queue<string> tempQueue = new Queue<string>();

        for (int i = 0; i < pumpsCount; i++)
        {
            pumps.Enqueue(Console.ReadLine());


        }

        int indexOfStartPump = 0;
        int petrolInTank = 0;

        while (pumps.Count > 0)
        {
            
            string[] currentPump = pumps.Peek().Split();
            int petrolAmount = int.Parse(currentPump[0]);
            int kmToNextPump = int.Parse(currentPump[1]);

            petrolInTank += petrolAmount;

            if (kmToNextPump > petrolInTank)
            {
                if (tempQueue.Count > 0)
                {
                    foreach (var pump in tempQueue)
                    {
                        pumps.Enqueue(pump);
                        indexOfStartPump++;
                    }

                    tempQueue.Clear();
                }
                pumps.Enqueue(pumps.Dequeue());
                petrolInTank = 0;
                indexOfStartPump++;
            }
            else
            {
                tempQueue.Enqueue(pumps.Dequeue());
                petrolInTank -= kmToNextPump;
                
            }

            
        }

        Console.WriteLine(indexOfStartPump);
    }
}

