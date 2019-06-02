using System;
using System.Collections.Generic;
using Newtonsoft.Json;

namespace Common.Models
{
    public class DateRange : ValueObject
    {
        public DateRange(string from, string to)
        {
             DateTime _from;
             DateTime _to;
            if (DateTime.TryParse(from, out _from) && DateTime.TryParse(to, out _to))
            {
                if (_to < _from)
                    throw new ArgumentException($"Invalid ranges values: {from}, {to} ");

                From = _from;
                To = _to;
            }
            else
            {
                throw new ArgumentException($"Can`t parse one of the values: {from}, {to} ");
            }
        }


        [JsonConstructor]
        public DateRange(DateTime from, DateTime to)
        {
            if (to< from)
                throw new ArgumentException($"Invalid ranges values: {from}, {to} ");
            From = from;
            To = to;
        }

        public DateTime From { get; set; }

        public DateTime To { get; set; }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return From;
            yield return To;
        }
    }
}
