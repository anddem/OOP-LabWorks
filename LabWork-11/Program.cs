using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Diagnostics;

using MyLibrary;
using LabWork_10;

namespace LabWork_11
{
    class Program
    {
        static Stopwatch timer = new Stopwatch();

        static TestCollections collections = null;

        struct SearchResult
        {
            public bool isFounded;
            public long ticks;
        }

        static void Main(string[] args)
        {
            int action;

            do
            {
                PrintInterface();
                action = Input.Integer("Введите команду: ");

                if (action != 0) DoAction(action);
            } while (action != 0);
        }

        static void PrintInterface()
        {
            if (collections == null) Output.Message("Колекции не созданы\n\n");
            else Output.Message($"Элементов в коллекциях: {collections.Count}\n\n");

            Output.Message(
                "1. Создать коллекции\n" +
                "2. Добавить элемент в коллекции\n" +
                "3. Удалить элемент из коллекции\n" +
                "4. Измерить время нахождения первого элемента\n" +
                "5. Измерить время нахождения среднего элемента\n" +
                "6. Измерить время нахождения последнего элемента\n" +
                "7. Измерить время нахождения элемента по ключу с клавиатуры\n" +
                "8. Измерить время нахождения значения в словарях\n" +
                "9. Измерить время нахождения значения в словарях с клавиатуры\n\n" +
                "0. Выход\n\n");
        }

        static void CreateCollections()
        {
            int len = Input.Integer("Введите количество элементов коллекций: ", "Число не может быть меньше 1", 1, Int32.MaxValue);

            collections = new TestCollections(len); //Создание коллекций
        }

        static void DoAction(int actionNum)
        {
            switch (actionNum)
            {
                case 1: CreateCollections();
                    break;
                case 2: AddElement();
                    break;
                case 3: RemoveElement();
                    break;
                case 4: FindFirstElement();
                    break;
                case 5: FindMiddleElement();
                    break;
                case 6: FindLastElement();
                    break;
                case 7: FindAnotherElement();
                    break;
                case 8: FindValueByNum();
                    break;
                case 9: FindAnotherValue();
                    break;


                default: Output.ErrorMessage("Неизвестная команда\n");
                    break;
            }
            Output.PauseAndClear();
        }

        #region Поиск элементов
        static void FindFirstElement()
        {
            if (collections == null || collections.Count == 0) Output.ErrorMessage("Коллекции пусты!\n");
            else
            {

                Place first = new Place(collections.ClsList.First().Name); //Запоминаем первый элемент

                Output.Message($"Поиск первого элемента:\n" +
                    $"{first}\n");

                FindElementInCollections(first, out SearchResult inClsLL, out SearchResult inStrLL, out SearchResult inClsDict, out SearchResult inStrDict);

                PrintResults(inClsLL, inStrLL, inClsDict, inStrDict);
            }
        }

        static void FindMiddleElement()
        {
            if (collections == null || collections.Count == 0) Output.ErrorMessage("Коллекции пусты!\n");
            else
            {
                int index = collections.ClsList.Count / 2;

                Place middle = new Place(collections.ClsList.ElementAt(index).Name);

                Output.Message($"Поиск среднего элемента:\n" +
                    $"{middle}\n");

                FindElementInCollections(middle, out SearchResult inClsLL, out SearchResult inStrLL, out SearchResult inClsDict, out SearchResult inStrDict);

                PrintResults(inClsLL, inStrLL, inClsDict, inStrDict);
            }
        }

        static void FindLastElement()
        {
            if (collections == null || collections.Count == 0) Output.ErrorMessage("Коллекции пусты!\n");
            else
            {
                Place last = new Place(collections.ClsList.Last().Name);

                Output.Message($"Поиск последнего элемента:\n" +
                    $"{last}\n");

                FindElementInCollections(last, out SearchResult inClsLL, out SearchResult inStrLL, out SearchResult inClsDict, out SearchResult inStrDict);

                PrintResults(inClsLL, inStrLL, inClsDict, inStrDict);
            }
        }

        static void FindAnotherElement()
        {
            if (collections == null || collections.Count == 0) Output.ErrorMessage("Коллекции пусты!\n");
            else
            {
                string name = Input.String("Введите название места для поиска в коллекции: ");
                Place place = new Place(name);

                Output.Message($"Поиск элемента, которого нет в коллекции:\n" +
                    $"{place}\n");

                FindElementInCollections(place, out SearchResult inClsLL, out SearchResult inStrLL, out SearchResult inClsDict, out SearchResult inStrDict);

                PrintResults(inClsLL, inStrLL, inClsDict, inStrDict);
            }
        }

        static void FindValueByNum()
        {
            if (collections == null || collections.Count == 0) Output.ErrorMessage("Коллекции пусты!\n");
            else
            {
                int num = Input.Integer("Введите номер искомого элемента: ", $"Введите число от 1 до {collections.Count}", 1, collections.Count);

                Place key = collections.ClsList.ElementAt(num - 1);
                Region value = collections.ClsSrotedDict[key];

                Region region = new Region(value.Name, value.Population);

                Output.Message($"Искомое значение:\n" +
                    $"{region}\n");

                if (FindValueInDict(region, out long ticks)) Output.SuccessMessage($"Элемент найден за {ticks} тиков\n");
                else Output.SuccessMessage($"Элемент не найден за {ticks} тиков\n");
            }
        }

        static void FindAnotherValue()
        {
            if (collections == null || collections.Count == 0) Output.ErrorMessage("Коллекции пусты!\n");
            else
            {
                string name = Input.String("Введите название искомого места: ");
                int population = Input.Integer("Введите население искомого места: ", "Население не может быть отрицательным", 0, Int32.MaxValue);

                Region region = new Region(name, population);

                if (FindValueInDict(region, out long ticks)) Output.SuccessMessage($"Элемент найден за {ticks} тиков\n");
                else Output.SuccessMessage($"Элемент не найден за {ticks} тиков\n");
            }
        }

        static void FindElementInCollections(Place element, out SearchResult inClsLL, out SearchResult inStrLL, out SearchResult inClsDict, out SearchResult inStrDict)
        {
            inClsLL = new SearchResult(); inStrLL = new SearchResult(); inClsDict = new SearchResult(); inStrDict = new SearchResult();

            inClsLL.isFounded = FindElementInLinkedList(element, out inClsLL.ticks);
            inStrLL.isFounded = FindElementInLinkedList(element.ToString(), out inStrLL.ticks);
            inClsDict.isFounded = FindElementInDict(element, out inClsDict.ticks);
            inStrDict.isFounded = FindElementInDict(element.ToString(), out inStrDict.ticks);
        }

        static bool FindElementInLinkedList(Place keyElement, out long ticks)
        {
            timer.Restart();
            bool result = collections.ClsList.Contains(keyElement);
            timer.Stop();
            ticks = timer.ElapsedTicks;

            return result;
        }

        static bool FindElementInLinkedList(string keyElement, out long ticks)
        {
            timer.Restart();
            bool result = collections.StrList.Contains(keyElement);
            timer.Stop();
            ticks = timer.ElapsedTicks;

            return result;
        }

        static bool FindElementInDict(Place keyElement, out long ticks)
        {
            timer.Restart();
            bool result = collections.ClsSrotedDict.ContainsKey(keyElement);
            timer.Stop();
            ticks = timer.ElapsedTicks;

            return result;
        }

        static bool FindElementInDict(string keyElement, out long ticks)
        {
            timer.Restart();
            bool result = collections.StrSortedDict.ContainsKey(keyElement);
            timer.Stop();
            ticks = timer.ElapsedTicks;

            return result;
        }

        static bool FindValueInDict(Region value, out long ticks)
        {
            timer.Restart();
            bool result = collections.ClsSrotedDict.ContainsValue(value);
            timer.Stop();
            ticks = timer.ElapsedTicks;

            return result;
        }
        #endregion

        static void PrintResults(SearchResult inClsLL, SearchResult inStrLL, SearchResult inClsDict, SearchResult inStrDict)
        {
            if (inClsLL.isFounded) Output.SuccessMessage($"List, тип ключа - класс : Элемент найден за {inClsLL.ticks} тиков\n");
            else Output.ErrorMessage($"List, тип ключа - класс : Элемент не найден за {inClsLL.ticks} тиков\n");

            if (inStrLL.isFounded) Output.SuccessMessage($"List, тип ключа - строка: Элемент найден за {inStrLL.ticks} тиков\n");
            else Output.ErrorMessage($"List, тип ключа - строка: Элемент не найден за {inStrLL.ticks} тиков\n");

            if (inClsDict.isFounded) Output.SuccessMessage($"SortedDictionary, тип ключа - класс : Элемент найден за {inClsDict.ticks} тиков\n");
            else Output.ErrorMessage($"SortedDictionary, тип ключа - класс : Элемент не найден за {inClsDict.ticks} тиков\n");

            if (inStrDict.isFounded) Output.SuccessMessage($"SortedDictionary, тип ключа - строка: Элемент найден за {inStrDict.ticks} тиков\n");
            else Output.ErrorMessage($"SortedDictionary, тип ключа - строка: Элемент не найден за {inStrDict.ticks} тиков\n");
        }

        static void AddElement()
        {
            if (collections == null) collections = new TestCollections();

            string name = Input.String("Введите название: ");
            int population = Input.Integer("Введите население: ");

            Region region = new Region(name, population);
            Place place = region.BasePlace;

            bool added = collections.AddToCollectons(region, place);

            if (!added) Output.ErrorMessage("Элемент с таким ключом уже есть в коллекциях, значение в словарях было перезаписано\n");
            else Output.SuccessMessage("Элемент добавлен\n");
        }

        static void RemoveElement()
        {
            if (collections == null || collections.Count == 0) Output.ErrorMessage("Коллекции пусты!\n");
            else
            {
                string name = Input.String("Введите название: ");

                Place key = new Place(name);

                bool removed = collections.RemoveFromCollectins(key);

                if (removed) Output.SuccessMessage("Элемент удалён\n");
                else Output.ErrorMessage("Такого элемента в коллекциях нет\n");
            }
        }
    }
}
