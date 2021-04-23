using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabWork_12;

namespace LabWork_13
{
    /*
        открытое автореализуемое свойство типа string с названием коллекции, в которой произошло событие; 
        открытое автореализуемое свойство типа string с информацией о типе изменений в коллекции; 
        открытое автореализуемое свойство типа string c данными объекта, с которым связаны изменения в коллекции; 
        конструктор для инициализации полей класса; 
        перегруженную версию метода string ToString(). 
        всех элементах массива. 
*/
    class JournalEntity : ICloneable, IComparable
    {
        public string CollectionName { get; private set; } = "";

        public string EventType { get; private set; } = "";

        public string ChangedObjectInforation { get; private set; } = "";

        public JournalEntity(string collectionName, string eventType, object changedObject)
        {
            CollectionName = collectionName;
            EventType = eventType;
            ChangedObjectInforation = changedObject.ToString();
        }

        JournalEntity(string collectionName, string eventType, string changedObjectInformation)
        {
            CollectionName = collectionName;
            EventType = eventType;
            ChangedObjectInforation = changedObjectInformation;
        }

        public override string ToString()
        {
            return $"" +
                $"Коллекция: {CollectionName}\n" +
                $"Событие: {EventType}\n" +
                $"Изменённый объект: {ChangedObjectInforation}";
        }

        public object Clone() => new JournalEntity(CollectionName, EventType, ChangedObjectInforation);

        public int CompareTo(object obj)
        {
            JournalEntity temp = (JournalEntity)obj;

            if (CollectionName != temp.CollectionName) return CollectionName.CompareTo(temp.CollectionName);
            if (EventType != temp.EventType) return CollectionName.CompareTo(temp.CollectionName);
            return ChangedObjectInforation.CompareTo(temp.ChangedObjectInforation);
        }
    }
    class Journal : MyCollection<JournalEntity> { }
}
