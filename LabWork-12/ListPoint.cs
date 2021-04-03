using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabWork_10;

namespace LabWork_12
{
    class ListPoint
    {
        public Place Value { get; set; } = null;

        public ListPoint Next { get; set; } = null;

        public ListPoint Last
        {
            get
            {
                if (Next == null) return this;
                else return Next.Last;
            }
        }

        public ListPoint(Place value) => Value = value;

        public ListPoint(string name) => Value = new Place(name);

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
