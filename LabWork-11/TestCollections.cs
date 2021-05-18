using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabWork_10;
using MyLibrary;

namespace LabWork_11
{
    public class TestCollections
    {
        List<Place> clsList;
        List<string> strList;

        SortedDictionary<Place, Region> clsSrotedDict;
        SortedDictionary<string, Region> strSortedDict;

        public List<Place> ClsList
        {
            get => clsList;
        }

        public List<string> StrList
        {
            get => strList;
        }

        public SortedDictionary<Place, Region> ClsSortedDict
        {
            get => clsSrotedDict;
        }

        public SortedDictionary<string, Region> StrSortedDict
        {
            get => strSortedDict;
        }

        public int Count
        {
            get => ClsList.Count;
        }

        public TestCollections() => CreateCollections();

        public TestCollections(int len)
        {
            bool initManually = Input.Bool("Заполнить коллекции вручную? Y/N: ", new string[] { "да", "yes", "y" });

            CreateCollections();

            InitCollections(len, initManually);
        }

        void CreateCollections()
        {
            clsList = new List<Place>();
            strList = new List<string>();

            clsSrotedDict = new SortedDictionary<Place, Region>();
            strSortedDict = new SortedDictionary<string, Region>();
        }

        void InitCollections(int len, bool initManually)
        {
            if (initManually) InitCollectionsManually(len);
            else InitCollectionsRandomly(len);
        }

        void InitCollectionsRandomly(int count)
        {
            for (int i = 1; i <= count; i++)
            {
                string name = $"Случайное название номер {i}";
                int population = Rand.Integer(0, Int32.MaxValue);

                Region region = new Region(name, population);
                Place bPlace = region.BasePlace;

                AddToCollectons(region, bPlace);
            }
        }

        void InitCollectionsManually(int count)
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

        public bool AddToCollectons(Region region, Place bPlace)
        {
            string strName = bPlace.ToString();
            bool added;

            if (clsList.Contains(bPlace))
            {
                clsSrotedDict[bPlace] = region;
                strSortedDict[strName] = region;

                added = false;
            }
            else
            {
                clsList.Add(bPlace);
                strList.Add(strName);
                clsSrotedDict.Add(bPlace, region);
                strSortedDict.Add(strName, region);

                added = true;
            }

            return added;
        }

        public void PrintCollections()
        {
            foreach (Place key in clsList)
                Console.WriteLine($"Ключ: {key}\n" +
                    $"Значение: {clsSrotedDict[key]}\n");
        }

        public bool RemoveFromCollectins(Place key)
        {
            if (clsList.Contains(key))
            {
                clsList.Remove(key);
                strList.Remove(key.ToString());

                clsSrotedDict.Remove(key);
                strSortedDict.Remove(key.ToString());
                return true;
            }
            return false;
        }
    }
}
