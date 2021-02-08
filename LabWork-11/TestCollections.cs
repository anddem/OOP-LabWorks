using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabWork_10;
using MyLibrary;

namespace LabWork_11
{
    class TestCollections
    {
        LinkedList<Place> clsLinkedList;
        LinkedList<string> strLinkedList;

        Dictionary<Place, Region> clsDict;
        Dictionary<string, Region> strDict;

        public LinkedList<Place> ClsLinkedList
        {
            get => clsLinkedList;
        }

        public LinkedList<string> StrLinkedList
        {
            get => strLinkedList;
        }

        public Dictionary<Place, Region> ClsDict
        {
            get => clsDict;
        }

        public Dictionary<string, Region> StrDict
        {
            get => strDict;
        }

        public TestCollections(int len)
        {
            bool initManually = Input.Bool("Заполнить коллекции вручную? Y/N: ", new string[] { "да", "yes", "y" });

            CreateCollections(len);

            InitCollections(len, initManually);
        }

        void CreateCollections(int len)
        {
            clsLinkedList = new LinkedList<Place>();
            strLinkedList = new LinkedList<string>();

            clsDict = new Dictionary<Place, Region>();
            strDict = new Dictionary<string, Region>();
        }

        void InitCollections(int len, bool initManually)
        {
            if (initManually) InitCollectionsManually(len);
            else InitCollectionsRandomly(len);
        }

        public void InitCollectionsRandomly(int count)
        {

            for (int i = 1; i <= count; i++)
            {
                LabWork_10.Program.FillRandom(out string _, out string name, out _, out _, out int population, out _, out _);

                Region region = new Region(name, population);
                Place bPlace = region.BasePlace;

                AddToCollectons(region, bPlace);
            }
        }

        public void InitCollectionsManually(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                string name = Input.String("Введите название места: ");
                int population = Input.Integer("Введите население места: ", "Население не может быть отрицательным!", 0, Int32.MaxValue);

                Region region = new Region(name, population);
                Place bPlace = region.BasePlace;

                AddToCollectons(region, bPlace);
            }
        }

        public void AddToCollectons(Region region, Place bPlace)
        {
            string strName = bPlace.ToString();

            if (!clsLinkedList.Contains(bPlace)) clsLinkedList.AddLast(bPlace);

            if (!strLinkedList.Contains(strName)) strLinkedList.AddLast(strName);

            if (!clsDict.ContainsKey(bPlace)) clsDict.Add(bPlace, region);
            else clsDict[bPlace] = region;

            if (!strDict.ContainsKey(strName)) strDict.Add(strName, region);
            else strDict[strName] = region;
        }

        public void PrintCollections()
        {
            foreach (Place key in clsDict.Keys)
                Console.WriteLine($"Ключ: {key}\n" +
                    $"Значение: {clsDict[key]}\n");
        }
    }
}
