using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabWork_10;

namespace LabWork_13
{
    public class CollectionHandlerEventArgs : EventArgs
    {
        public string CollectionName { get; set; } = "";
        public string EventType { get; set; } = "";
        public object ChangedObject { get; set; } = null;

        public CollectionHandlerEventArgs(string collectionName, string eventType, object changedObject)
        {
            EventType = eventType;
            CollectionName = collectionName;
            ChangedObject = changedObject;
        }

        public override string ToString()
        {
            return EventType.ToString();
        }
    }
}
