using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabWork_12;

namespace LabWork_13
{
    public delegate void CollectionHandler(object source, CollectionHandlerEventArgs args);
    public class NewCollection<T> : MyCollection<T> where T: ICloneable, IComparable
    {
        public NewCollection(string name) => Name = name;

        public string Name { get; set; } = "";

        public override T this[int index]
        {
            get => base[index];
            set
            {
                OnCollectionReferenceChanged(this, new CollectionHandlerEventArgs(Name, "changed", this[index]));
                base[index] = value;
            }
        }

        public event CollectionHandler CollectionCountChanged;
        public virtual void OnCollectionCountChanged(object source, CollectionHandlerEventArgs args) => CollectionCountChanged?.Invoke(source, args);

        public event CollectionHandler CollectionReferenceChanged;
        public virtual void OnCollectionReferenceChanged(object source, CollectionHandlerEventArgs args) => CollectionReferenceChanged?.Invoke(source, args);

        public override bool Remove(T item)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(this.Name, "remove", item));
            return base.Remove(item);
        }

        public override void Add(T value)
        {
            OnCollectionCountChanged(this, new CollectionHandlerEventArgs(this.Name, "add", value));
            base.Add(value);
        }
    }
}
