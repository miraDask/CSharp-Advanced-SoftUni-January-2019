namespace _05.ComparingObjects
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class Person :IComparable<Person>
    {
        public Person(string name, int age, string town)
        {
            this.Name = name;
            this.Age = age;
            this.Town = town;
        }

        public string Name { get; set; }

        public int Age { get; set; }

        public string Town { get; set; }

        public int CompareTo(Person other)
        {
            var firstCompareResult = this.Name.CompareTo(other.Name);

            if (firstCompareResult == 0)
            {
                var secondCompareResult = this.Age.CompareTo(other.Age);

                if (secondCompareResult == 0)
                {
                    return this.Town.CompareTo(other.Town);
                }

                return secondCompareResult;
            }

            return firstCompareResult;
        }

        public bool isEqual(Person other)
        {
            return this.CompareTo(other) == 0;
        }
    }
}
