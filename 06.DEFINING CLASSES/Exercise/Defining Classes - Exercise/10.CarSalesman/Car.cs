using System.Text;

namespace _10.CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine, int weight, string color)
        {
            this.Model = model;
            this.Engine = engine;
            this.Weight = weight;
            this.Color = color;
        }

        public Car(string model, Engine engine, int weight)
            : this(model, engine,weight, "n/a")
        {
        }

        public Car(string model, Engine engine, string color)
            : this(model, engine, -1 ,color)
        {
        }

        public Car(string model, Engine engine)
            : this(model, engine,-1, "n/a")
        {
        }

        public string Model { get; set; }
        
        public Engine Engine { get; set; }

        public int Weight { get; set; } 

        public string Color { get; set; }

        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            string displacementToString = this.Engine.Displacement == -1 ? "n/a" : this.Engine.Displacement.ToString();
            string weightToString = this.Weight == -1 ? "n/a" : this.Weight.ToString();

            stringBuilder.AppendLine($"{this.Model}:");
            stringBuilder.AppendLine($"  {this.Engine.Model}:");
            stringBuilder.AppendLine($"    Power: {this.Engine.Power}");
            stringBuilder.AppendLine($"    Displacement: {displacementToString}");
            stringBuilder.AppendLine($"    Efficiency: {this.Engine.Efficiency}");
            stringBuilder.AppendLine($"  Weight: {weightToString}");
            stringBuilder.AppendLine($"  Color: {this.Color}");
           
            return stringBuilder.ToString();
        }
    }
}
