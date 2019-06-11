namespace _06.StrategyPattern
{
    using System;
    using System.Collections.Generic;

    public class NameComperaror : IComparer<Person>
    {
        
        public int Compare(Person first, Person second)
        {
            var compareResult = first.Name.Length.CompareTo(second.Name.Length);

            if (compareResult == 0)
            {
                return char.ToLower(first.Name[0]).CompareTo(char.ToLower(second.Name[0]));
            }

            return compareResult;
        }
    }
}
