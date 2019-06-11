using System;
using System.Collections.Generic;

 public class TrafficJam
{
    public static void Main()
    {
        int numberOfAllowedCars = int.Parse(Console.ReadLine());

        Queue<string> carsThatWaitForPassing = new Queue<string>();

        string carData = Console.ReadLine();
        int passedCarsCounter = 0;

        while (carData != "end")
        {
            if (carData == "green")
            {
                for (int i = 0; i < numberOfAllowedCars; i++)
                {

                    if (carsThatWaitForPassing.Count > 0)
                    {
                        Console.WriteLine($"{carsThatWaitForPassing.Dequeue()} passed!");
                        passedCarsCounter++;
                    }
                }
            }
            else
            {
                carsThatWaitForPassing.Enqueue(carData);
            }

            carData = Console.ReadLine();
        }

        Console.WriteLine($"{passedCarsCounter} cars passed the crossroads.");
    }
}

