namespace IteratorsAndComparators
{
    using System;
    using System.Collections.Generic;

    public class Book : IComparable<Book>
    {
        public Book(string title, int year, params string[] authors)
        {
            this.Title = title;
            this.Year = year;
            this.Authors = new List<string>(authors);
        }

        public string Title { get; set; }

        public int Year { get; set; }

        public List<string> Authors { get; private set; }

        public int CompareTo(Book other)
        {
            int compareResult = this.Year.CompareTo(other.Year);

            if (compareResult == 0)
            {
                return this.Title.CompareTo(other.Title);
            }

            return compareResult;
        }

        public override string ToString()
        {
            return $"{this.Title} - {this.Year}";
        }
    }
}
