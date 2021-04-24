using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLibrary;
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
        private DateTime EventTime { get; } = DateTime.Now;

        public string CollectionName { get; private set; } = "";

        public string EventType { get; } = "Событие";

        public string ChangedObjectInformation { get; private set; } = "";

        public JournalEntity(string collectionName, object changedObject)
        {
            CollectionName = collectionName;
            EventType = "Событие";
            ChangedObjectInformation = changedObject.ToString();
        }

        public JournalEntity(string collectionName, string eventType, object changedObject)
        {
            CollectionName = collectionName;
            EventType = eventType;
            ChangedObjectInformation = changedObject.ToString();
        }

        public override string ToString()
        {
            return $"" +
                $"Коллекция: {CollectionName}\n" +
                $"Событие: {EventType}\n" +
                $"Время: {EventTime}\n" +
                $"Изменённый объект:\n" +
                $"{ChangedObjectInformation}";
        }

        public object Clone() => new JournalEntity(CollectionName, EventType, ChangedObjectInformation);

        public int CompareTo(object obj)
        {
            JournalEntity temp = (JournalEntity)obj;

            if (CollectionName != temp.CollectionName) return CollectionName.CompareTo(temp.CollectionName);
            if (EventType != temp.EventType) return CollectionName.CompareTo(temp.CollectionName);
            return ChangedObjectInformation.CompareTo(temp.ChangedObjectInformation);
        }
    }

    class ChangedObjectJournalEntity : JournalEntity
    {
        public ChangedObjectJournalEntity(string collectionName, object changedObject) : base(collectionName, "Изменён объект по индексу", changedObject) { }
    }

    class RemovedObjectJournalEntity : JournalEntity
    {
        public RemovedObjectJournalEntity(string collectionName, object changedObject) : base(collectionName, "Из коллекции удалён объект", changedObject) { }
    }

    class AddedObjectJournalEntity : JournalEntity
    {
        public AddedObjectJournalEntity(string collectionName, object changedObject) : base(collectionName, "В коллекцию добавлен элемент", changedObject) { }
    }

    class Journal : MyCollection<JournalEntity>
    {
        public void Add(string collectionName, string eventType, object changedObject) => Add(new JournalEntity(collectionName, eventType, changedObject));

        public void Add(ChangedObjectJournalEntity entity) => Add(entity);

        public void Add(RemovedObjectJournalEntity entity) => Add(entity);

        public void Add(AddedObjectJournalEntity entity) => Add((JournalEntity)entity);

        public override void Show()
        {
            if (First != null)
            {
                CollectionPoint<JournalEntity> cursor = First;
                while (cursor != null)
                {
                    Output.Text(cursor.Value);
                    Output.Text("--\n");
                    cursor = cursor.Next;
                }
            }
        }
    }
}
