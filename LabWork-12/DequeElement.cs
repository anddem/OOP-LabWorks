using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabWork_10;

namespace LabWork_12
{
    class DequeElement
    {
        public DequeElement Prev { get; set; } = null;

        public DequeElement Next { get; set; } = null;

        public Place Value { get; set; } = null;

        public DequeElement(Place value) => Value = value;

        public DequeElement(string name) => Value = new Place(name);

        public DequeElement Last
        {
            get
            {
                if (Next == null) return this;
                else return Next.Last;
            }
        }

        public DequeElement First
        {
            get
            {
                if (Prev == null) return this;
                else return Prev.First;
            }
        }

        public int Length
        {
            get
            {
                DequeElement iter = First;
                int length = 1;

                while (iter.Next != null)
                {
                    length++;
                    iter = iter.Next;
                }

                return length;
            }
        }
    }
}
