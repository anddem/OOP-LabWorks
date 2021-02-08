using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLibrary;

namespace LabWork_11
{
    class Program
    {
        static void Main(string[] args)
        {
            int len = Input.Integer("Введите количество элементов коллекций: ", "Число не может быть меньше 1", 1, Int32.MaxValue);

            TestCollections collection = new TestCollections(len);

            
        }

        static void CheckCollectionLen(int len, TestCollections collection)
        {
            int collectionLen = collection.ClsLinkedList.Count;

            if (collectionLen < len)
            {
                Output.Message($"При инициализации коллекции были использованы повторяющиеся ключи, не добавлено {len - collectionLen} элементов\n");
                bool addNew = Input.Bool("Добавить недостающие элементы в коллекцию? Y/N: ", new string[] { "y", "yes", "да", "lf", "l", "д" });

                if (addNew) collection.InitCollectionsManually(len - collectionLen);
            }
        }
    }
}
