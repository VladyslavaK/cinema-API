using Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain
{
    public class Cinema
    {
        public ID CinemaID { get; set; }
        public string Name { get; set; }
        public int OpenYear { get; set; }
        public string Address { get; set; }
        public List<Hall> Halls { get; set; }
        public List<Movie> Movies { get; set; }
    }
}
