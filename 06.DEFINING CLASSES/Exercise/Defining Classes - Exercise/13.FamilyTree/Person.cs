namespace _13.FamilyTree
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Person
    {
        public Person()
        {
        }

        public Person(string name, string birthday)
        {
            Name = name;
            Birthday = birthday;

        }

        public string Name { get; set; }

        public string Birthday { get; set; }

        public List<Person> Parents { get; set; } = new List<Person>();

        public List<Person> Children { get; set; } = new List<Person>();

        public override string ToString()
        {
            StringBuilder result = new StringBuilder();

            result.AppendLine($"{this.Name} {this.Birthday}");
            result.AppendLine($"Parents:");

            if (this.Parents.Any())
            {
                foreach (var parent in Parents)
                {
                    result.AppendLine($"{parent.Name} {parent.Birthday}");
                }
            }

            result.AppendLine($"Children:");

            if (this.Children.Any())
            {
                foreach (var child in Children)
                {
                    result.AppendLine($"{child.Name} {child.Birthday}");
                }
            }

            return result.ToString().TrimEnd();
        }
    }
}
