using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace _12.Google
{
    public class Person
    {
        public Person(string name)
        {
            Name = name;
        }

        public string Name { get; set; }

        public Company Company { get; set; } = null;

        public Car Car { get; set; } = null;

        public List<FamilyMember> Parents { get; set; } = new List<FamilyMember>();

        public List<FamilyMember> Children { get; set; } = new List<FamilyMember>();

        public List<Pokemon> Pokemons { get; set; } = new List<Pokemon>();


        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();

            stringBuilder.AppendLine($"{this.Name}");
            stringBuilder.AppendLine($"Company:");

            if (this.Company != null)
            {
                stringBuilder.AppendLine($"{this.Company.Name} {this.Company.Department} {this.Company.Salary:F2}");
            }

            stringBuilder.AppendLine($"Car:");

            if (this.Car != null)
            {
                stringBuilder.AppendLine($"{this.Car.Model} {this.Car.Speed}");
            }

            stringBuilder.AppendLine($"Pokemon:");

            if (this.Pokemons.Any())
            {
                foreach (var pokemon in this.Pokemons)
                {
                    stringBuilder.AppendLine($"{pokemon.Name} {pokemon.Type}");
                }
            }

            stringBuilder.AppendLine("Parents:");

            if (this.Parents.Any())
            {
                foreach (var parent in this.Parents)
                {
                    stringBuilder.AppendLine($"{parent.Name} {parent.BirthDay}");
                }
            }

            stringBuilder.AppendLine("Children:");

            if (this.Children.Any())
            {
                foreach (var child in this.Children)
                {
                    stringBuilder.AppendLine($"{child.Name} {child.BirthDay}");
                }
            }

            return stringBuilder.ToString().TrimEnd();
        }
    }
}


