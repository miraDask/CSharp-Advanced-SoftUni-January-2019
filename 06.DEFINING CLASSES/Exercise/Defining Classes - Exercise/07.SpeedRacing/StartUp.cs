namespace _07.SpeedRacing
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();

            int numberOfCarsToTrack = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCarsToTrack; i++)
            {
                string[] carData = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carData[0];
                double fuelAmount = double.Parse(carData[1]);
                double fuelConsumption = double.Parse(carData[2]);

                Car car = new Car(model,fuelAmount,fuelConsumption);
                cars.Add(car);

            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "End")
                {
                    break;
                }

                string[] carToDriveData = input
                    .Split(' ',StringSplitOptions.RemoveEmptyEntries);

                string carModel = carToDriveData[1];
                int kmToDrive = int.Parse(carToDriveData[2]);

                Car currentCar = cars.Find(x => x.Model == carModel);

                try
                {
                    currentCar.Drive(kmToDrive);
                }
                catch (ArgumentException)
                {
                    Console.WriteLine("Insufficient fuel for the drive");
                }
            }

            foreach (var car in cars)
            {
                Console.WriteLine($"{car.Model} {car.FuelAmount:F2} {car.DistanceTraveled}");
            }
        }
    }
}
