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
            var collections = new TestCollections();

            var continentList = collections.ClsList;
            var countryDict = collections.ClsSortedDict;

            FillList(continentList);
            FillDict(countryDict);

            Output.Text("Это презентация работы LINQ запросов и методов расширений\n", _INFORMATION_COLOR);
            Output.Text("Результаты работы запросов LINQ выделяются таким цветом: ", _INFORMATION_COLOR); 
            Output.Text("■■■\n", _LINQ_QUERIES_RESULT);
            Output.Text("А результаты работы методов расширений таким: ", _INFORMATION_COLOR);
            Output.Text("■■■\n", _LINQ_METHODS_RESULT);
            Output.Text(Environment.NewLine);

            CountObjectsByType(continentList); // Счётчик, группировка

            CountPopulation(continentList); // Агрегация

            CountBuildingTypes(continentList); // Счётчик, группировка

            OrderPlacesByPopulation(continentList, out int avgPopulation); // Сортировка по населению, агрегация

            PrintCitiesWithPopulationMoreThanAverage(continentList, avgPopulation); // Выборка данных
        }

        private static void FillList(List<Place> list, int count = 50)
        {
            for (var i = 1; i <= count; i++) list.Add(CreateRandomItem());
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

        private static void CountObjectsByType(List<Place> places)
        {
            var queryGroups = (from place in places group place by place.GetType()).ToDictionary(g => g.Key);
            var methodsGroups = places.GroupBy(g => g.GetType()).ToDictionary(g => g.Key);

            Output.Text("Подсчёт количества сгенерированных элементов по типам\n", _INFORMATION_COLOR);
            Output.Text($"{"   Тип объекта    ",18} | Количество\n" +
                        $"{new string('—', 32)}\n", _INFORMATION_COLOR);

            foreach (var key in queryGroups.Keys)
            {
                Output.Text($"{key,-18} |  ", _INFORMATION_COLOR);
                Output.Text($"{queryGroups[key].Count(),2}", _LINQ_QUERIES_RESULT);
                Output.Text(" |  ", _INFORMATION_COLOR);
                Output.Text($"{methodsGroups[key].Count(),2}\n", _LINQ_METHODS_RESULT);
            }

            Output.Text(Environment.NewLine);
        }

        private static void CountPopulation(List<Place> places)
        {
            // Операторы выборки
            var pop1 = (from place in places
                where place is Region && !(place is City)
                select place).Sum(place => (place as Region)?.Population ?? 0);

            // Методы расширения
            var pop2 = places.Where(place => place is Region && !(place is City)).Sum(place => (place as Region)?.Population ?? 0);

            Output.Text("Население в регионах:\n", _INFORMATION_COLOR);
            Output.Text($"{pop1}", _LINQ_QUERIES_RESULT);
            Output.Text(" | ", _INFORMATION_COLOR);
            Output.Text($"{pop2}\n", _LINQ_METHODS_RESULT);

            Output.Text(Environment.NewLine);
        }

        private static void CountBuildingTypes(List<Place> places)
        {
            var queryGroup = (from place in places
                where place is Address
                group place by (place as Address)?.Name).ToDictionary(group => group.Key);

            var methodsGroups = places.Where(place => place is Address).GroupBy(place => (place as Address)?.Name)
                .ToDictionary(group => group.Key);

            Output.Text("Подсчёт зданий определённого типа\n", _INFORMATION_COLOR);
            Output.Text($"{"    Тип здания    ",18} | Количество\n" +
                        $"{new string('—', 32)}\n", _INFORMATION_COLOR);

            foreach (var key in queryGroup.Keys)
            {
                Output.Text($"{key,-18} |  ", _INFORMATION_COLOR);
                Output.Text($"{queryGroup[key].Count(),2}", _LINQ_QUERIES_RESULT);
                Output.Text(" |  ", _INFORMATION_COLOR);
                Output.Text($"{methodsGroups[key].Count(),2}\n", _LINQ_METHODS_RESULT);
            }

            Output.Text(Environment.NewLine);
        }

        private static void OrderPlacesByPopulation(List<Place> places, out int avgPopulation)
        {
            var queryOrdering = (from place in places orderby (place as Region)?.Population ?? 0 descending select place).ToList();

            var methodsOrdering = places.OrderByDescending(place => (place as Region)?.Population ?? 0).ToList();

            avgPopulation = (int)places.Where(place => place is Region).Average(place => (place as Region)?.Population);

            Output.Text("Сортировка мест по населению\n", _INFORMATION_COLOR);
            Output.Text(" №| Название места\n", _INFORMATION_COLOR);

            for (int i = 0; i < queryOrdering.Count(); i++)
            {
                Output.Text($"{i + 1, 2}: ", _INFORMATION_COLOR);
                Output.Text($"{queryOrdering.ElementAt(i).Name, -40}", _LINQ_QUERIES_RESULT);
                Output.Text(" | ", _INFORMATION_COLOR);
                Output.Text($"{methodsOrdering.ElementAt(i).Name, -40}", _LINQ_METHODS_RESULT);
                Output.Text($" | Equal Objects: {queryOrdering.ElementAt(i).Equals(methodsOrdering.ElementAt(i))}", _INFORMATION_COLOR);
                Output.Text($" | {(methodsOrdering.ElementAt(i) as Region)?.Population}\n", _INFORMATION_COLOR);
            }

            Output.Text(Environment.NewLine);
        }

        private static void PrintCitiesWithPopulationMoreThanAverage(List<Place> places, int avgPopulation)
        {
            var querySelect = (from place in places
                where (place as Region)?.Population > avgPopulation
                orderby (place as Region)?.Population descending
                select place).ToList();

            var methodsSelect = places.Where(place => (place as Region)?.Population > avgPopulation)
                .OrderByDescending(place => (place as Region)?.Population).ToList();

            Output.Text($"Регионы и города с населением, больше среднего ({avgPopulation})\n", _INFORMATION_COLOR);
            Output.Text($"{new string('—', 32)}\n", _INFORMATION_COLOR);

            for (int i = 0; i < querySelect.Count(); i++)
            {
                Output.Text($"{querySelect.ElementAt(i).Name,-40}", _LINQ_QUERIES_RESULT);
                Output.Text(" | ", _INFORMATION_COLOR);
                Output.Text($"{methodsSelect.ElementAt(i).Name}\n", _LINQ_METHODS_RESULT);
            }

            Output.Text(Environment.NewLine);
        }
    }
}