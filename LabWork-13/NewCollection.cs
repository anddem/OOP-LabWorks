using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabWork_12;

namespace LabWork_13
{
    class NewCollection<T> : MyCollection<T> where T: ICloneable, IComparable
    {
    }
}
