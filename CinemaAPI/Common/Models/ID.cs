using System;

namespace Common
{
    public class ID
    {
        public int Value { get; private set; }

        public ID(int id)
        {
            Value = Validated(id) ? id : throw new Exception($"Invalid ID value - {id}");
        }

        private bool Validated(int value)
        {
            return value > 0;
        }
    }
}
