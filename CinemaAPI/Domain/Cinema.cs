using Common;
using Common.Models;
using Newtonsoft.Json;
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
        public Address CinemaAddress { get; set; }
        public List<Hall> Halls { get; set; }
    }
}
