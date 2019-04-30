using System;
using System.Collections.Generic;
using System.Text;

namespace Common
{
    public class DateRange 
    {
        public DateRange(string from, string to)
        {
             DateTime _from;
             DateTime _to;
            if (DateTime.TryParse(from, out _from) && DateTime.TryParse(to, out _to))
            {
                From = _from;
                To = _to;
            }
            else
            {
                throw new ArgumentException($"Invalid ranges values: {from}, {to} ");
            }
        }

        public DateRange(DateTime from, DateTime to)
        {
            From = from;
            To = to;
        }

        public DateTime From { get; set; }

        public DateTime To { get; set; }
    }
}
