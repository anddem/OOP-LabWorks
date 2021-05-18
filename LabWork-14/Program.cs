using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using LabWork_10;
using LabWork_11;
using MyLibrary;

namespace LabWork_14
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var collections = new TestCollections();

            var continentList = collections.ClsList;
            var countryDict = collections.ClsSortedDict;

            FillList(continentList);
            FillDict(countryDict);

            //PrintCollections(continentList, countryDict);

            CountObjectsByType(continentList);
        }

        private static void FillList(List<Place> list, int count = 50)
        {
            for (var i = 1; i <= count; i++) list.Add(CreateRandomItem());
        }

        private static void FillDict(SortedDictionary<Place, Region> dict, int count = 50)
        {
            for (var i = 1; i <= 20; i++)
            {
                var region = CreateRandomRegion();
                try
                {
                    dict.Add(region.BasePlace, region);
                }
                catch (ArgumentException e)
                {
                    i--;
                }
            }
        }



        private static void CountObjectsByType(List<Place> list)
        {
            var places = (from place in list where place.GetType().ToString().Contains("Place") select place)
                .Count();
            var regions = (from region in list where region.GetType().ToString().Contains("Region") select region)
                .Count();
            var cities = (from city in list where city.GetType().ToString().Contains("City") select city)
                .Count();
            var addresses = (from address in list where address.GetType().ToString().Contains("Address") select address)
                .Count();

            Output.Success($"Places: {places}\n" +
                           $"Regions: {regions}\n" +
                           $"Cities: {cities}\n" +
                           $"Addresses: {addresses}\n");
        }

        private static void PrintCollections(List<Place> list, SortedDictionary<Place, Region> dict)
        {
            PrintList(list);
            PrintDict(dict);
        }

        private static void PrintList(List<Place> list)
        {
            foreach (var place in list) Output.Text($"{place.GetType()}\n{place}\n--\n");
        }

        private static void PrintDict(SortedDictionary<Place, Region> dict)
        {
            foreach (var pair in dict)
            {
                Output.Text(pair.Key, ConsoleColor.DarkBlue);
                Output.Text($"{pair.Value}\n--\n", ConsoleColor.DarkMagenta);
            }
        }

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

        private static void CountPopulation()
    }
}