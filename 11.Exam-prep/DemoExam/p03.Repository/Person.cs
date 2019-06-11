namespace Repository
{
    using System;

    public class Person : IComparable<Person>
    {
        public Person(string name, int age, DateTime birthdate)
        {
            this.Name = name;
            this.Age = age;
            this.Birthdate = birthdate;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public DateTime Birthdate { get; set; }

        public int CompareTo(Person other)
        {
            var nameComparisson = this.Name.CompareTo(other.Name);

            if (nameComparisson == 0)
            {
                var ageResult = this.Age.CompareTo(other.Age);

                if (ageResult == 0)
                {
                    return this.Birthdate.CompareTo(other.Birthdate);
                }
            }

            return nameComparisson;
        }
    }
}
