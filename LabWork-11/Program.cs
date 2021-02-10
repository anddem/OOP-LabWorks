using System;
using System.Collections.Generic;
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

        static TestCollections collections;

        struct SearchResult
        {
            public bool isFounded;
            public long ticks;
        }

        static void Main(string[] args)
        {
            int len = Input.Integer("Введите количество элементов коллекций: ", "Число не может быть меньше 1", 1, Int32.MaxValue);

            collections = new TestCollections(len); //Создание коллекций

            collections.PrintCollections();

            FindElements();

            AddElement();
        }

        #region Поиск элементов
        static void FindElements()
        {
            FindFirstElement();

            FindMiddleElement();

            FindLastElement();

            FindAnotherElement();
        }

        static void FindFirstElement()
        {
            Place first = new Place(collections.ClsLinkedList.First.Value.Name); //Запоминаем первый элемент

            Output.Message($"Поиск первого элемента:\n{first}");

            FindElementInCollections(first, out SearchResult inClsLL, out SearchResult inStrLL, out SearchResult inClsDict, out SearchResult inStrDict);

            PrintResults(inClsLL, inStrLL, inClsDict, inStrDict);
        }

        static void FindMiddleElement()
        {
            int index = collections.ClsLinkedList.Count / 2;

            Place middle = new Place(collections.ClsLinkedList.ElementAt(index).Name);

            Output.Message($"Поиск среднего элемента:\n{middle}");

            FindElementInCollections(middle, out SearchResult inClsLL, out SearchResult inStrLL, out SearchResult inClsDict, out SearchResult inStrDict);

            PrintResults(inClsLL, inStrLL, inClsDict, inStrDict);
        }

        static void FindLastElement()
        {
            Place last = new Place(collections.ClsLinkedList.Last.Value.Name);

            Output.Message($"Поиск последнего элемента:\n{last}");

            FindElementInCollections(last, out SearchResult inClsLL, out SearchResult inStrLL, out SearchResult inClsDict, out SearchResult inStrDict);

            PrintResults(inClsLL, inStrLL, inClsDict, inStrDict);
        }

        static void FindAnotherElement()
        {
            string name = Input.String("Введите название места для поиска в коллекции: ");
            Place place = new Place(name);

            Output.Message($"Поиск элемента, которого нет в коллекции:\n{place}");

            FindElementInCollections(place, out SearchResult inClsLL, out SearchResult inStrLL, out SearchResult inClsDict, out SearchResult inStrDict);

            PrintResults(inClsLL, inStrLL, inClsDict, inStrDict);
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
            bool result = collections.ClsLinkedList.Contains(keyElement);
            timer.Stop();
            ticks = timer.ElapsedTicks;

            return result;
        }

        static bool FindElementInLinkedList(string keyElement, out long ticks)
        {
            timer.Restart();
            bool result = collections.StrLinkedList.Contains(keyElement);
            timer.Stop();
            ticks = timer.ElapsedTicks;

            return result;
        }

        static bool FindElementInDict(Place keyElement, out long ticks)
        {
            timer.Restart();
            bool result = collections.ClsDict.ContainsKey(keyElement);
            timer.Stop();
            ticks = timer.ElapsedTicks;

            return result;
        }

        static bool FindElementInDict(string keyElement, out long ticks)
        {
            timer.Restart();
            bool result = collections.StrDict.ContainsKey(keyElement);
            timer.Stop();
            ticks = timer.ElapsedTicks;

            return result;
        }
        #endregion

        static void PrintResults(SearchResult inClsLL, SearchResult inStrLL, SearchResult inClsDict, SearchResult inStrDict)
        {
            if (inClsLL.isFounded) Output.SuccessMessage($"LinkedList, тип ключа - класс : Элемент найден за {inClsLL.ticks} тиков");
            else Output.ErrorMessage($"LinkedList, тип ключа - класс : Элемент не найден за {inClsLL.ticks} тиков");

            if (inStrLL.isFounded) Output.SuccessMessage($"LinkedList, тип ключа - строка: Элемент найден за {inStrLL.ticks} тиков");
            else Output.ErrorMessage($"LinkedList, тип ключа - строка: Элемент не найден за {inStrLL.ticks} тиков");

            if (inClsDict.isFounded) Output.SuccessMessage($"Dictionary, тип ключа - класс : Элемент найден за {inClsDict.ticks} тиков");
            else Output.ErrorMessage($"Dictionary, тип ключа - класс : Элемент не найден за {inClsDict.ticks} тиков");

            if (inStrDict.isFounded) Output.SuccessMessage($"Dictionary, тип ключа - строка: Элемент найден за {inStrDict.ticks} тиков");
            else Output.ErrorMessage($"Dictionary, тип ключа - строка: Элемент не найден за {inStrDict.ticks} тиков");
        }

        static void AddElement()
        {
            bool notAdded;
            do
            {
                string name = Input.String("Введите название: ");
                int population = Input.Integer("Введите население города: ");

                Region region = new Region(name, population);
                Place place = region.BasePlace;

                notAdded = collections.AddToCollectons(region, place);

                if (notAdded) Output.ErrorMessage("Элемент с таким ключом уже есть в коллекциях");

            } while (notAdded);

            Output.SuccessMessage("Элемент добавлен");
        }
    }
}
