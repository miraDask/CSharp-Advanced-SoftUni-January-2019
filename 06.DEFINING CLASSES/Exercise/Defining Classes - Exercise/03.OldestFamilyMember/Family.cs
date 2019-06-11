namespace DefiningClasses
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Text;

    public class Family
    {
        public List<Person> People { get; set; } = new List<Person>();

        public void AddMember(Person member)
        {
            People.Add(member);
        }

        public Person GetOldestMember()
        {
            Func<List<Person>, int> GetMaxAge = x => x.Select(y => y.Age).Max();

            return this.People.Find(x => x.Age == GetMaxAge(this.People));
        }
    }
}
