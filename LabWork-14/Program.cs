using LabWork_10;
using LabWork_11;
using MyLibrary;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LabWork_14
{
    internal static class Program
    {
        private const ConsoleColor _LINQ_METHODS_RESULT = ConsoleColor.Green;
        private const ConsoleColor _LINQ_QUERIES_RESULT = ConsoleColor.DarkBlue;
        private const ConsoleColor _INFORMATION_COLOR = ConsoleColor.White;

        private static void Main(string[] args)
        {
            var list = new List<SortedDictionary<Place, Region>>();

            for (int i = 0; i < 2; i++)
            {
                var dict = new SortedDictionary<Place, Region>();
                FillDict(dict);
                list.Add(dict);
            }

            Output.Text("Это презентация работы LINQ запросов и методов расширений\n", _INFORMATION_COLOR);
            Output.Text("Результаты работы запросов LINQ выделяются таким цветом: ", _INFORMATION_COLOR); 
            Output.Text("■■■\n", _LINQ_QUERIES_RESULT);
            Output.Text("А результаты работы методов расширений таким: ", _INFORMATION_COLOR);
            Output.Text("■■■\n", _LINQ_METHODS_RESULT);
            Output.Text(Environment.NewLine);


            CountPopulation(list);

            OrderPlacesByPopulation(list, out int avgPopulation);
        }


        private static void FillDict(SortedDictionary<Place, Region> dict, int count = 30)
        {
            for (var i = 1; i <= count; i++)
            {
                var region = CreateRandomRegion();
                try
                {
                    dict.Add(region.BasePlace, region);
                }
                catch (ArgumentException)
                {
                    i--;
                }
            }
        }
        
        #region Генерация случайных элементов
        private static Place CreateRandomItem()
        {
            var type = Rand.Choice(new[] {"place", "region", "address", "city"});

            switch (type)
            {
                case "place": return CreateRandomPlace();
                case "region": return CreateRandomRegion();
                case "city": return CreateRandomCity();
                default: return CreateRandomAddress();
            }
        }

        private static Region CreateRandomRegion()
        {
            LabWork_10.Program.FillRandom(out _, out var region, out _, out _,
                out var population, out _, out _);
            return new Region(region, population);
        }

        private static Place CreateRandomPlace()
        {
            LabWork_10.Program.FillRandom(out var name, out _, out _, out _,
                out _, out _, out _);
            return new Place(name);
        }

        private static Address CreateRandomAddress()
        {
            LabWork_10.Program.FillRandom(out var name, out _, out _, out var street,
                out _, out _, out var houseNumber);
            return new Address(name, street, houseNumber);
        }

        private static City CreateRandomCity()
        {
            LabWork_10.Program.FillRandom(out var name, out _, out var city, out var street,
                out var population, out var houses, out var houseNumber);
            return new City(city, population, houses, new Address(name, street, houseNumber));
        }
        #endregion
        
        private static void CountPopulation(List<SortedDictionary<Place, Region>> places)
        {
            // Операторы выборки
            var listsToOneCollectionQuery = from dict in places
                from p in dict.Values
                group p by p.Name;

            var listsToOneCollectionMethods = places.SelectMany(
                dict => dict.Values).GroupBy(p => p.Name);

            for (int i = 0; i < listsToOneCollectionQuery.Count(); i++)
            {
                var q = listsToOneCollectionQuery.ElementAt(i);
                var l = q.Select(g => g);
                Output.Text($"{q.Count()} | {q.Key}", _LINQ_QUERIES_RESULT);
                foreach (var pair in l) Output.Text($"\n{pair} ", _LINQ_QUERIES_RESULT);
                
                var m = listsToOneCollectionMethods.ElementAt(i);
                Output.Text($"{m.Count()}\n", _LINQ_METHODS_RESULT);
            }

            Output.Text(Environment.NewLine);
        }

        private static void OrderPlacesByPopulation(List<SortedDictionary<Place, Region>> list, out int avgPopulation)
        {
            var listsToOneCollectionQuery = from dict in list
                from p in dict
                orderby p.Value.Population
                select p;

             var listsToOneCollectionMethods = list.SelectMany(
                 dict => dict.OrderBy(
                     pair => pair.Value.Population))
                 .OrderBy(pair => pair.Value.Population);

            avgPopulation = (int)listsToOneCollectionMethods.Average(p => p.Value.Population);
            int buffer = avgPopulation;

            var averageSortedMethods = listsToOneCollectionMethods.Where(p => p.Value.Population < buffer);
            var averageSordetQuery = from p in listsToOneCollectionQuery where p.Value.Population < buffer select p;

            Output.Text($"Сортировка мест по населению меньше среднего: {buffer}\n", _INFORMATION_COLOR);

            foreach (var region in averageSortedMethods)
            {
                Output.Text($"{region.Value.Population, 10} | {region.Value.Name}\n", _LINQ_QUERIES_RESULT);
            }

            foreach (var q in averageSordetQuery)
            {
                Output.Text($"{q.Value.Population, 10} | {q.Value.Name}\n", _LINQ_METHODS_RESULT);
            }

            Output.Text(Environment.NewLine);
        }
    }
}