using System;
using System.Collections.Generic;
using System.Linq;

public class ParkingLot
{
    public static void Main(string[] args)
    {

        HashSet<string> cars = new HashSet<string>();

        while (true)
        {
            string input = Console.ReadLine();

            if (input == "END")
            {
                break;
            }

            string[] carParkingData = input.Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string command = carParkingData[0];
            string carNumber = carParkingData[1];

            if (command == "IN")
            {
                cars.Add(carNumber);
            }
            else if (command == "OUT" && cars.Contains(carNumber))
            {

                cars.Remove(carNumber);

            }
        }

        if (!cars.Any())
        {
            Console.WriteLine("Parking Lot is Empty");
        }
        else
        {
            Console.WriteLine(string.Join(Environment.NewLine, cars));
        }

    }
}

