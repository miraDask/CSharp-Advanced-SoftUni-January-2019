namespace _07.SpeedRacing
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Car
    {
        public Car(string model, double fuelAmount, double fuelConsumption)
        {
            Model = model;
            FuelAmount = fuelAmount;
            FuelConsumption = fuelConsumption;
            DistanceTraveled = 0;
        }

        public string Model { get; set; }
        public double FuelAmount { get; set; }
        public double FuelConsumption { get; set; }// For 1 km
        public double DistanceTraveled { get; set; }

        public void Drive(int kmToDrive)
        {
            double fuelNeeded = kmToDrive * this.FuelConsumption;

            if (this.FuelAmount >= fuelNeeded)
            {
                this.DistanceTraveled += kmToDrive;
                this.FuelAmount -= fuelNeeded;
            }
            else
            {
                throw new ArgumentException();
            }
        }
    }
}
