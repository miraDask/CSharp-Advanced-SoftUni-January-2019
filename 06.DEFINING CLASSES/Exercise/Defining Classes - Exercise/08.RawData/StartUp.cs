namespace _08.RawData
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class StartUp
    {
        public static void Main()
        {
            List<Car> cars = new List<Car>();

            int numberOfCars = int.Parse(Console.ReadLine());

            for (int i = 0; i < numberOfCars; i++)
            {
                string[] carData = Console.ReadLine()
                    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string model = carData[0];
                int engineSpeed = int.Parse(carData[1]);
                int enginePower = int.Parse(carData[2]);
                int cargoWeight = int.Parse(carData[3]);
                string cargoType = carData[4];
                double tire1Pressure = double.Parse(carData[5]);
                int tire1Age = int.Parse(carData[6]);
                double tire2Pressure = double.Parse(carData[7]);
                int tire2Age = int.Parse(carData[8]);
                double tire3Pressure = double.Parse(carData[9]);
                int tire3Age = int.Parse(carData[10]);
                double tire4Pressure = double.Parse(carData[11]);
                int tire4Age = int.Parse(carData[12]);

                Tire tire1 = new Tire(tire1Pressure, tire1Age);
                Tire tire2 = new Tire(tire2Pressure, tire2Age);
                Tire tire3 = new Tire(tire3Pressure, tire3Age);
                Tire tire4 = new Tire(tire4Pressure, tire4Age);

                Tire[] tireSet =
                {
                    tire1,
                    tire2,
                    tire3,
                    tire4
                };

                Engine engine = new Engine(engineSpeed,enginePower);
                Cargo cargo = new Cargo(cargoWeight,cargoType);
                Car car = new Car(model, engine,cargo,tireSet);
                cars.Add(car);
            }

            string typeForSearch = Console.ReadLine();

            Func<Car, bool> carsFilter = GetFilter(cars, typeForSearch);

            cars = cars.Where(x => carsFilter(x)).ToList();

            foreach (var car in cars)
            {
                Console.WriteLine(car.Model);
            }
        }

        private static Func<Car, bool> GetFilter(List<Car> cars, string typeForSearch)
        {

            if (typeForSearch == "fragile")
            {
                return x => x.Cargo.Type == "fragile" && x.TireSet.Any(t => t.Pressure < 1);
            }
            else if (typeForSearch == "flamable")
            {
                return x => x.Cargo.Type == "flamable" && x.Engine.Power > 250;
            }

            return null;
        }
    }
}
