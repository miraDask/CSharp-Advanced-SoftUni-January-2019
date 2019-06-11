namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Engine
    {
        public Engine(int horsePower, double cubicCapacity)
        {
            this.HorsePower = horsePower;
            this.CubicCapacity = cubicCapacity;
        }

        public int HorsePower { get; set; }
        public double CubicCapacity { get; set; }

    }

    public class Tire
    {
        public Tire(int year, double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }

        public int Year { get; set; }
        public double Pressure { get; set; }


    }

    public class Car
    {
        public Car(string make,
            string model,
            int year, 
            double fuelQuantity,
            double fuelConsumption,
            Engine engine,
            Tire[] tires)
        {
            this.Make = make;
            this.Model = model;
            this.Year = year;
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.Engine = engine;
            this.Tires = tires;
        }

        public string Make { get; set; }

        public string Model { get; set; }

        public int Year { get; set; }

        public double FuelQuantity { get; set; }

        public double FuelConsumption { get; set; }

        public Engine Engine { get; set; }

        public Tire[] Tires { get; set; }

        public void Drive(double distance)
        {
            double fuelNeeded = distance * this.FuelConsumption / 100.0;

            if (this.FuelQuantity - fuelNeeded > 0)
            {
                this.FuelQuantity -= fuelNeeded;
            }
            else
            {
                Console.WriteLine("Not enough fuel to perform this trip!");
            }
        }

        public string Information()
        {
            return $"Make: {this.Make}{Environment.NewLine}" +
                    $"Model: {this.Model}{Environment.NewLine}" +
                    $"Year: {this.Year}{Environment.NewLine}" +
                    $"HorsePowers: {this.Engine.HorsePower}{Environment.NewLine}" +
                    $"FuelQuantity: {this.FuelQuantity}";

        }
    }
    public class StartUp
    {
        public static void Main()
        {
            List<Tire[]> tires = new List<Tire[]>();
            List<Engine> engines = new List<Engine>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "No more tires")
                {
                    break;
                }

                string[] tireData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                Tire[] currentTirePack = GetTirePack(tireData);

                tires.Add(currentTirePack);
            }

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Engines done")
                {
                    break;
                }

                string[] engineData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                int horsePower = int.Parse(engineData[0]);
                double cubicCapacity = double.Parse(engineData[1]);

                Engine currentEngine = new Engine(horsePower, cubicCapacity);

                engines.Add(currentEngine);
            }

            List<Car> cars = new List<Car>();

            while (true)
            {
                string input = Console.ReadLine();

                if (input == "Show special")
                {
                    break;
                }

                string[] carData = input.Split(' ', StringSplitOptions.RemoveEmptyEntries);

                string make = carData[0];
                string model = carData[1];
                int year = int.Parse(carData[2]);
                double fuelQuantity = double.Parse(carData[3]);
                double fuelConsumption = double.Parse(carData[4]);
                int engineIndex = int.Parse(carData[5]);
                int tireIndex = int.Parse(carData[6]);

                if ((engineIndex >= 0 && engineIndex <= engines.Count - 1)
                   && (tireIndex >= 0 && tireIndex <= tires.Count - 1))
                {

                    Engine engine = engines[engineIndex];
                    Tire[] tireSet = tires[tireIndex];
                    Car currentCar = new Car(make, model, year, fuelQuantity, fuelConsumption, engine, tireSet);
                    cars.Add(currentCar);
                }
            }

            List<Car> specialCars = cars
                .Where(x => x.Year >= 2017
                       && x.Engine.HorsePower > 330
                       && x.Tires.Select(y => y.Pressure).Sum() >=9 && x.Tires.Select(y => y.Pressure).Sum() <= 10).ToList();

            foreach (var car in specialCars)
            {
                car.Drive(20);
                Console.WriteLine(car.Information());
            }
        }

        private static Tire[] GetTirePack(string[] tireData)
        {
            Tire[] tirePack = new Tire[4];
            int indexInTirePack = 0;

            for (int i = 0; i < tireData.Length - 1; i += 2)
            {
                int year = int.Parse(tireData[i]);
                double pressure = double.Parse(tireData[i + 1]);

                tirePack[indexInTirePack] = new Tire(year, pressure);
                indexInTirePack++;
            }

            return tirePack;
        }
    }
}
