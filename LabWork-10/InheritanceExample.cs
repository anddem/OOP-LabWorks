using System;
using System.Linq;

using MyLibrary;

namespace LabWork_10
{
    class InheritanceExample
    {
        private static InheritanceExample singleton = null;

        private Place[] places;

        static InheritanceExample GetExampleClass()
        {
            if (singleton == null)
            {
                singleton = new InheritanceExample
                {
                    places = new Place[0]
                };
            }

            return singleton;
        }

        public static void Start()
        {
            InheritanceExample example = InheritanceExample.GetExampleClass();

            example.Run();
        }

        public void Run()
        {
            int cmd;
            do
            {
                PrintMenu();

                cmd = Input.Integer("Команда > ", "Неизвестная команда", 0, 5);

                DoAction(cmd);

                if (cmd != 0) Output.PauseAndClear();
                else Output.Clear();
            } while (cmd != 0);

            return;
        }

        #region Реализация меню
        void PrintMenu()
        {
            PrintArray();
            Console.WriteLine("" +
                "1. Заполнить массив\n" +
                "2. Вывести информацию об элементах массива\n" +
                "3. Вывести список городов\n" +
                "4. Вывести регионы с их населением\n" +
                "5. Вывести количество библиотек\n" +
                "\n" +
                "0. Выход\n");
        }

        void DoAction(int cmd)
        {
            switch (cmd)
            {
                case 1: InitPlacesArray(); return;
                case 2: PrintInformation(); return;
                case 3: PrintCitiesList(); return;
                case 4: PrintPopulationInRegions(); return;
                case 5: PrintLibrariesCount(); return;

                case 0: return;
            }
        }

        void PrintArray()
        {
            if (places.Length == 0) Console.WriteLine("Массив пуст\n");
            else
            {
                int places = 0, regions = 0, cities = 0, addresses = 0;
                foreach (Place place in this.places)
                {
                    if (place is City) cities++;
                    else if (place is Region) regions++;
                    else if (place is Address) addresses++;
                    else places++;
                }
                Console.WriteLine($"" +
                    $"В массиве {this.places.Length} элементов, из них:\n" +
                    $"{places} типа Place\n" +
                    $"{regions} типа Region\n" +
                    $"{cities} типа City\n" +
                    $"{addresses} типа Address\n"
                    );
            }
        }
        #endregion

        #region Вывод запросов
        void PrintInformation()
        {
            if (places.Length == 0)
            {
                Console.WriteLine("\nМассив пуст\n");
                return;
            }

            PrintInformationVirtual();
            PrintInformationNotVirtual();
        }

        void PrintInformationVirtual()
        {
            Console.WriteLine("Вывод с помощью виртуальных методов:");

            foreach (Place place in places)
            {
                place.PrintInformation();
                Console.WriteLine("— — —");
            }

            Console.WriteLine();
        }

        void PrintInformationNotVirtual()
        {
            Console.WriteLine("Вывод с помощью не виртуальных методов:");

            foreach (Place place in places)
            {
                place.PrintInfo();
                Console.WriteLine("— — —");
            }

            Console.WriteLine();
        }

        void PrintCitiesList()
        {
            if (places.Length == 0)
            {
                Console.WriteLine("\nМассив пуст\n");
                return;
            }
            bool haveCities = false;
            foreach (Place place in places)
            {
                if (place is City)
                {
                    haveCities = true;
                    Console.WriteLine(place.Name);
                }
            }

            if (!haveCities) Console.WriteLine("\nВ массиве нет объектов типа City\n");
        }

        void PrintPopulationInRegions()
        {
            if (places.Length == 0)
            {
                Console.WriteLine("\nМассив пуст\n");
                return;
            }

            bool haveRegions = false;
            foreach (Place place in places)
            {
                if (place is Region && !(place is City))
                {
                    haveRegions = true;
                    place.PrintInformation();
                }
            }

            if (!haveRegions) Console.WriteLine("\nВ массиве нет объектов типа Region\n");
        }

        void PrintLibrariesCount()
        {
            if (places.Length == 0)
            {
                Console.WriteLine("\nМассив пуст\n");
                return;
            }
            int count = 0;
            foreach (Place place in places)
            {
                if (place is Address address)
                    if (address.Name.ToLower() == "библиотека") count++;
            }
            Console.WriteLine($"\nБиблиотек: {count}\n");
        }
        #endregion

        #region Инициализация и ввод мест
        Place[] InitPlaces()
        {
            int len = Input.Integer("Введите количество объектов типа Place: ", "Количество мест не может быть отрицательным", 0, Int32.MaxValue);
            if (len == 0) return new Place[0];

            bool inputManually = Input.Bool("Заполнить данные вручную? да/нет: ", "да");
            string name;

            Place[] places = new Place[len];

            for (int i = 0; i < len; i++)
            {
                if (inputManually) name = Input.String($"Название {i + 1}-го места: ");
                else Program.FillRandom(out name, out _, out _, out _, out _, out _, out _);

                places[i] = new Place(name);
            }

            return places;
        }

        Place[] InitRegions()
        {
            int len = Input.Integer("Введите количество объектов типа Region: ", "Количество регионов не может быть отрицательным", 0, Int32.MaxValue);
            if (len == 0) return new Place[0];

            bool inputManually = Input.Bool("Заполнить данные вручную? да/нет: ", "да");
            string region;
            int population;

            Place[] regions = new Place[len];

            for (int i = 0; i < len; i++)
            {
                if (inputManually)
                {
                    region = Input.String($"Название {i + 1}-го региона: ");
                    population = Input.Integer($"Население региона {region}: ");
                }
                else Program.FillRandom(out _, out region, out _, out _, out population, out _, out _);

                regions[i] = new Region(region, population);
            }

            return regions;
        }

        Place[] InitCities()
        {
            int len = Input.Integer("Введите количество объектов типа City: ", "Количество городов не может быть отрицательным", 0, Int32.MaxValue);
            if (len == 0) return new Place[0];

            bool inputManually = Input.Bool("Заполнить данные вручную? да/нет: ", "да");

            string city;
            int houses, population;

            Place[] cities = new Place[len];

            for (int i = 0; i < len; i++)
            {
                if (inputManually)
                {
                    city = Input.String($"Название {i + 1}-го города: ");
                    population = Input.Integer($"Население города {city}: ");
                    houses = Input.Integer($"Количество домов в городе {city}: ");
                }
                else Program.FillRandom(out _, out _, out city, out _, out population, out houses, out _);

                cities[i] = new City(city, population, houses);
            }

            return cities;
        }

        Place[] InitAddresses()
        {
            int len = Input.Integer("Введите количество объектов типа Address: ", "Количество адресов не может быть отрицательным", 0, Int32.MaxValue);
            if (len == 0) return new Place[0];

            bool inputManually = Input.Bool("Заполнить данные вручную? да/нет: ", "да");

            string name, street;
            int houseNumber;

            Place[] addresses = new Place[len];

            for (int i = 0; i < len; i++)
            {
                if (inputManually)
                {
                    name = Input.String($"Название {i + 1}-го адреса: ");
                    street = Input.String($"Улица: ");
                    houseNumber = Input.Integer($"Дом: ");
                }
                else Program.FillRandom(out name, out _, out _, out street, out _, out _, out houseNumber);

                addresses[i] = new Address(name, street, houseNumber);
            }

            return addresses;
        }

        void InitPlacesArray()
        {
            places = new Place[0];

            places = places.Union(InitPlaces()).ToArray();
            places = places.Union(InitRegions()).ToArray();
            places = places.Union(InitCities()).ToArray();
            places = places.Union(InitAddresses()).ToArray();
        }
        #endregion
    }
}
