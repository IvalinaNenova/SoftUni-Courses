using System;

namespace DefiningClasses
{
    public class DateModifier
    {
        private TimeSpan _difference = new TimeSpan();

        public TimeSpan GetDifference(string date1, string date2)
        {
            DateTime firstDate = DateTime.Parse(date1);
            DateTime secondDate = DateTime.Parse(date2);
            _difference = firstDate - secondDate;

           return _difference.Duration();
        }
    }
}
