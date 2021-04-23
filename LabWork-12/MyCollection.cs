using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabWork_12
{
    public class MyCollection<T> : IEnumerable<T>, ICollection<T>, ICloneable where T : ICloneable, IComparable
    {
        public int Count { get; private set; } = 0;

        public bool IsReadOnly => throw new NotImplementedException();

        public CollectionPoint<T> First { get; private set; } = default;

        public CollectionPoint<T> Last { get; private set; } = default;

        public MyCollection() { }

        public MyCollection(MyCollection<T> collection)
        {
            foreach (var el in collection) Add((T)el.Clone());
        }

        #region Добавление и удаление элементов
        public void Add(T value)
        {
            if (First is null) First = Last = new CollectionPoint<T>(value);
            else
            {
                CollectionPoint<T> current = First;
                while (current.Next != null) current = current.Next;

                current.Next = new CollectionPoint<T>(value);
                current.Next.Prev = current;
                Last = current.Next;
            }
            Count++;
        }

        public void Add(T[] values)
        {
            for (int i = 0; i < values.Length; i++) Add(values[i]);
        }

        public T Remove()
        {
            if (First == null) return default;
            else
            {
                CollectionPoint<T> current = Last;

                if (Count == 1) Last = First = null;
                else
                {
                    Last = current.Prev;
                    current.Prev.Next = null;
                    current.Prev = null;
                }

                Count--;
                return current.Value;
            }
        }

        public T[] Remove(int count)
        {
            T[] popped = new T[count < Count ? count : Count];

            for (int i = 0; i < Count && i < count; i++) popped[i] = Remove();

            return popped;
        }
        #endregion

        public void Clear()
        {
            First = Last = null;
            Count = 0;
        }

        public IEnumerator<T> GetEnumerator()
        {
            CollectionPoint<T> current = Last;
            while (current != null)
            {
                yield return current.Value;
                current = current.Prev;
            }
        }

        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();

        public object Clone()
        {
            MyCollection<T> tmp = new MyCollection<T>();

            foreach (var el in this) tmp.Add((T)el.Clone());

            return tmp;
        }

        public bool Contains(T item)
        {
            foreach (T element in this)
                if (item.Equals(element)) return true;

            return false;
        }

        public void CopyTo(T[] array, int arrayIndex)
        {
            int i = arrayIndex;

            foreach (T element in this)
            {
                if (i == array.Length) break;
                array[i++] = (T)element.Clone();
            }
        }

        public bool Remove(T item)
        {
            if (First == null) return false;
            else
            {
                if (Count == 1 && First.Value.Equals(item)) Remove();
                else
                {
                    CollectionPoint<T> cursor = First;
                    while (cursor != null && !cursor.Value.Equals(item)) cursor = cursor.Next;
                    if (cursor == null) return false;
                    if (cursor.Next != null) cursor.Next.Prev = cursor.Prev;
                    if (cursor.Prev != null) cursor.Prev.Next = cursor.Next;
                    Count--;
                }
                return true;
            }
        }
    }
}
