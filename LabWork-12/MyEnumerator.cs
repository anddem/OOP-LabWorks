using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_12
{
    class MyEnumerator<T> : IEnumerator<T> where T: ICloneable, IComparable

    {
        CollectionPoint<T> Begin { get; set; } = default;

        CollectionPoint<T> Current { get; set; } = default;

        T IEnumerator<T>.Current => Current.Value;

        object IEnumerator.Current => Current;

        public MyEnumerator(MyCollection<T> collection) => Current = Begin = collection.First;

        public void Dispose() { }

        public bool MoveNext()
        {
            if (Current.Next == null)
            {
                Reset();
                return false;
            }
            else
            {
                Current = Current.Next;
                return true;
            }
        }

        public void Reset() => Current = Begin;
    }
}
