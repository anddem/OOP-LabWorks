using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLibrary;
using LabWork_12;

namespace LabWork_13
{
    public class JournalEntity : ICloneable, IComparable
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

        public virtual void Show() => Output.Text(ToString());
    }

    public class ChangedObjectJournalEntity : JournalEntity
    {
        public ChangedObjectJournalEntity(string collectionName, object changedObject) : base(collectionName, "Изменён объект по индексу", changedObject) { }

        public override void Show() => Output.Text(ToString(), ConsoleColor.DarkYellow);
    }

    public class RemovedObjectJournalEntity : JournalEntity
    {
        public RemovedObjectJournalEntity(string collectionName, object changedObject) : base(collectionName, "Из коллекции удалён объект", changedObject) { }

        public override void Show() => Output.Error(ToString()); 
    }

    public class AddedObjectJournalEntity : JournalEntity
    {
        public AddedObjectJournalEntity(string collectionName, object changedObject) : base(collectionName, "В коллекцию добавлен элемент", changedObject) { }
        public override void Show() =>  Output.Success(ToString());
    }

    public class Journal : MyCollection<JournalEntity>
    {
        public string Name { get; set; } = "";

        public Journal(string name) => Name = name;

        public void Add(string collectionName, string eventType, object changedObject) => Add(new JournalEntity(collectionName, eventType, changedObject));
        public void AddChanged(string collectionName, object changedObject) => Add(new ChangedObjectJournalEntity(collectionName, changedObject));
        public void AddRemoved(string collectionName, object changedObject) => Add(new RemovedObjectJournalEntity(collectionName, changedObject));
        public void AddAdded(string collectionName, object changedObject) => Add(new AddedObjectJournalEntity(collectionName, changedObject));
        public override void Show()
        {
            if (First != null)
            {
                Output.Text($"{Name}\n", ConsoleColor.White);
                CollectionPoint<JournalEntity> cursor = First;
                while (cursor != null)
                {
                    cursor.Value.Show();
                    Output.Text("\n--\n", ConsoleColor.White);
                    cursor = cursor.Next;
                }
            }
        }

        public void CollectionCountChanged(object source, CollectionHandlerEventArgs args)
        {
            if (args.EventType == "remove") AddRemoved(args.CollectionName, args.ChangedObject);
            else if (args.EventType == "add") AddAdded(args.CollectionName, args.ChangedObject);
            else Add(args.CollectionName, args.EventType, args.ChangedObject);
        }

        public void CollectionReferenceChanged(object source, CollectionHandlerEventArgs args)
        {
            if (args.EventType == "changed") AddChanged(args.CollectionName, args.ChangedObject);
            else Add(args.CollectionName, args.EventType, args.ChangedObject);
        }
    }
}
