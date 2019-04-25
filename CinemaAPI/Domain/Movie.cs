using Common;
using System;

namespace Domain
{
    public class Movie
    {
        public ID MovieID { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
        public string Director { get; set; }
        public DateRange AtTheBoxOffice { get; set; }
    }
}
