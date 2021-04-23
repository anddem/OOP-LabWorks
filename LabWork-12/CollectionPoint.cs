using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_12
{
    public class CollectionPoint<T>
    {
        public T Value { get; set; } = default;

        public CollectionPoint<T> Next { get; set; } = default;

        public CollectionPoint<T> Prev { get; set; } = default;

        public CollectionPoint(T value) => Value = value;

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
