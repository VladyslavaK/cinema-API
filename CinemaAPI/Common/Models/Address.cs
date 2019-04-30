using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Models
{
    public class Address : ValueObject
    {
        public string Street { get; private set; }
        public string City { get; private set; }
        public int? Building { get; private set; }
        private Address() { }
        public Address(string street, string city, int building)
        {
            Street = street;
            City = city;
            Building = building;
        }

        protected override IEnumerable<object> GetEqualityComponents()
        {
            yield return Street;
            yield return City;
            yield return Building;
        }

    }
}
