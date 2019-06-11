namespace IteratorsAndComparators
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class BookComparator : IComparer<Book>
    {
        public int Compare(Book first, Book other)
        {
            int result = first.Title.CompareTo(other.Title);

            if (result == 0)
            {
                return other.Year.CompareTo(first.Year);
            }

            return result;
        }
    }
}
