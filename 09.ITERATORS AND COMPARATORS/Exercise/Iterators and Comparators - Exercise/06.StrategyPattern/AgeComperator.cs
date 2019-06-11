namespace _06.StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class AgeComperator : IComparer<Person>
    {
        public int Compare(Person first, Person second)
        {
            return  first.Age.CompareTo(second.Age);
        }
    }
}
