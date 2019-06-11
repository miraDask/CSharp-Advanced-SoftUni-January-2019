namespace CarManufacturer
{
    using System;

    public class StartUp
    {
        public static void Main()
        {
            string make = Console.ReadLine();
            string model = Console.ReadLine();
            int year = int.Parse(Console.ReadLine());
            double fuelQuantity = double.Parse(Console.ReadLine());
            double fuelConsumption = double.Parse(Console.ReadLine());

            Car car = new Car();
            Car secondCar = new Car(make,model,year);
            Car lastCar = new Car(make,model,year,fuelQuantity,fuelConsumption);

            //Console.WriteLine(car.WhoAmI());
            //Console.WriteLine(secondCar.WhoAmI());
            //Console.WriteLine(lastCar.WhoAmI());
        }
    }
}