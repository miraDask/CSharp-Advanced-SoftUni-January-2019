namespace _10.CarSalesman
{
    using System;
    using System.Collections.Generic;

    public class StartUp
    {
        public static void Main()
        {
            List<Engine> engines = new List<Engine>();

            int engineCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < engineCount; i++)
            {
                string[] engineData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Engine currentEngine = GetEngine(engineData);
                engines.Add(currentEngine);
            }

            List<Car> cars = new List<Car>();

            int carsCount = int.Parse(Console.ReadLine());

            for (int i = 0; i < carsCount; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Car currentCar = GetCar(engines, carData);
                cars.Add(currentCar);
            }

            Console.WriteLine(string.Join("",cars));
        }
        
        private static Car GetCar(List<Engine> engines, string[] carData)
        {
            string carModel = carData[0];
            string engineModel = carData[1];

            var engine = engines.Find(x => x.Model == engineModel);

            if (carData.Length == 2)
            {
                return new Car(carModel, engine);
            }
            else if (carData.Length == 3)
            {
                try
                {
                    int displacement = int.Parse(carData[2]);
                    return new Car(carModel, engine, displacement);
                }
                catch (Exception)
                {
                    return new Car(carModel, engine, carData[2]);
                }
            }
            else if (carData.Length == 4)
            {
                try
                {
                    int displacement = int.Parse(carData[2]);
                    return new Car(carModel, engine, displacement, carData[3]);
                }
                catch (Exception)
                {
                    return new Car(carModel, engine, int.Parse(carData[3]), carData[2]);
                }
            }

            return null;
        }

        private static Engine GetEngine(string[] engineData)
        {
            string engineModel = engineData[0];
            int enginePower = int.Parse(engineData[1]);

            if (engineData.Length == 2)
            {
                return new Engine(engineModel, enginePower);
            }
            else if (engineData.Length == 3)
            {
                try
                {
                    int weight = int.Parse(engineData[2]);
                    return new Engine(engineModel, enginePower, weight);
                }
                catch (Exception)
                {
                    return new Engine(engineModel, enginePower, engineData[2]);
                }
            }
            else if (engineData.Length == 4)
            {
                try
                {
                    int weight = int.Parse(engineData[2]);
                    return new Engine(engineModel, enginePower, weight, engineData[3]);
                }
                catch (Exception)
                {
                    return new Engine(engineModel, enginePower, int.Parse(engineData[3]), engineData[2]);
                }
            }

            return null;
        }
    }
}
