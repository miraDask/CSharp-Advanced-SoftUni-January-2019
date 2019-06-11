using System;
using System.Collections.Generic;
using System.Linq;

class Crossroads
{
    static void Main(string[] args)
    {
        int greenLightDuration = int.Parse(Console.ReadLine());
        int freeWindowDuration = int.Parse(Console.ReadLine());

        Queue<string> cars = new Queue<string>();
        int carCount = 0;

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "END")
            {
                break;
            }

            if (input != "green")
            {

                cars.Enqueue(input);
            }
            else
            {
                if (cars.Any() == false)
                {
                    continue;
                }

                int timeLeft = greenLightDuration;

                while (timeLeft > 0)
                {
                    string currentCar = cars.Peek();

                    if (timeLeft >= currentCar.Length)
                    {
                        cars.Dequeue();
                        carCount++;
                        timeLeft -= currentCar.Length;

                        if (cars.Any() == false)
                        {
                            break;
                        }
                    }
                    else
                    {
                        currentCar = currentCar.Substring(timeLeft, currentCar.Length - timeLeft);

                        if (currentCar.Length <= freeWindowDuration)
                        {
                            cars.Dequeue();
                            carCount++;
                            break;
                        }
                        else
                        {
                            Console.WriteLine($"A crash happened!{Environment.NewLine}{cars.Peek()} was hit at {currentCar[freeWindowDuration]}.");
                            return;
                        }
                    }
                }

            }
        }

        string result = $"Everyone is safe.{Environment.NewLine}{carCount} total cars passed the crossroads.";
        Console.WriteLine(result);


    }
}

