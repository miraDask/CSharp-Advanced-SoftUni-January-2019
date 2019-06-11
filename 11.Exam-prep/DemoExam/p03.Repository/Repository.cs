namespace Repository
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public class Repository
    {
        private int count;

        public Repository()
        {
            this.Data = new Dictionary<int, Person>();
            this.Id = 0;
        }

        public int Id { get; set; }

        public Dictionary<int, Person> Data { get; set; }

        public int Count
        {
            get
            {
                return this.count = this.Data.Count;
            }
        }

        public void Add(Person person)
        {

            if (!this.Data.Any(x => x.Value.Name == person.Name
            && x.Value.Age == person.Age
            && x.Value.Birthdate == person.Birthdate))
            {
                this.Data[this.Id] = person;
                this.Id++;
            }
        }

        public Person Get(int id)
        {
            if (this.Data.ContainsKey(id))
            {
                return this.Data[id];
            }
            else
            {
                throw new ArgumentException();
            }
        }

        public bool Update(int id, Person newPerson)
        {
            if (!this.Data.ContainsKey(id))
            {
                return false;
            }
            else
            {
                this.Data[id] = newPerson;
                return true;
            }
        }

        public bool Delete(int id)
        {
            if (!this.Data.ContainsKey(id))
            {
                return false;
            }
            else
            {
                this.Data.Remove(id);
                return true;
            }
        }
    }
}
