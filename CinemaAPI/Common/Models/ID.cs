using Newtonsoft.Json;
using System;

namespace Common.Models
{
    public struct ID
    {
        public int Value { get; private set; }

        public ID(int id)
        {
            Value = id > 0 ? id : throw new ArgumentException($"Invalid ID value - {id}");
        }
        public static bool operator ==(ID a, ID b)
        {
            return a.Equals(b);
        }

        public static bool operator !=(ID a, ID b)
        {
            return !(a == b);
        }
    }
}
