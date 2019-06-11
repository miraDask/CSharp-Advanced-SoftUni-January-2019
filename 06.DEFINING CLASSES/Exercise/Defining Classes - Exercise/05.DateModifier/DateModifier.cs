namespace _05.DateModifier
{
    using System;

    public class DateModifier
    {
        public DateModifier(string firstDate, string secondDate)
        {
            this.FirstDate = firstDate;
            this.SecondDate = secondDate;
        }

        public string FirstDate { get; set; }
        public string SecondDate { get; set; }

        public int CalculatesTheDifference()
        { 
            DateTime firsTime = DateTime.Parse(FirstDate);
            DateTime secondTime = DateTime.Parse(SecondDate);

            return Math.Abs((int)(firsTime - secondTime).TotalDays);

        }
    }
}
