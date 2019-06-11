namespace CarManufacturer
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Tire
    {
        public Tire(int year,double pressure)
        {
            this.Year = year;
            this.Pressure = pressure;
        }

        public int Year { get; set; }
        public double Pressure { get; set; }


    }
}
