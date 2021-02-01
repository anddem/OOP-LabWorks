using System;
using System.Collections;
using System.Linq;

using MyLibrary;

namespace LabWork_10
{
    class InterfaceExample
    {
        private static InterfaceExample singleton = null;

        private IExecutable[] executables;

        public static InterfaceExample GetExample()
        {
            if (singleton == null)
            {
                singleton = new InterfaceExample()
                {
                    executables = new IExecutable[0]
                };
            }

            return singleton;
        }

        public static void Start()
        {
            InterfaceExample example = InterfaceExample.GetExample();

            example.Run();
        }

        public void Run()
        {
            int cmd;

            do
            {
                PrintMenu();

                cmd = Input.Integer("Команда > ", "Неизвестная команда", 0, 5);

                DoOperation(cmd);

                if (cmd != 0) Output.PauseAndClear();
                else Output.Clear();
            } while (cmd != 0);
        }

        #region Реализация меню
        void PrintMenu()
        {
            PrintArray();

            Console.WriteLine("" +
                "1. Создать массив типа IExecutable\n" +
                "2. Просмотр массива, демонстрация метода PrintInformation\n" +
                "3. Сортировка массива с помощью IComparable\n" +
                "4. Сортировка и поиск в массиве с помощью ICompare\n" +
                "5. Клонировать элемент с помощью IClonable\n" +
                "\n" +
                "0. Выход");
        }

        void PrintArray()
        {
            if (executables.Length == 0)
            {
                Console.WriteLine("Массив пуст\n");
            }
            else
            {
                int i = 1;
                foreach (IExecutable elem in executables)
                    Console.WriteLine($"{i++,2}. {elem.Name}");
                Console.WriteLine();
            }
        }

        void DoOperation(int cmd)
        {
            switch (cmd)
            {
                case 1: InitArray(); return;
                case 2: PrintInformation(); return;
                case 3: Sort(); return;
                case 4: SortAndFind(); return;
                case 5: CloneElement(); return;
                case 0: return;
            }
        }
        #endregion

        #region Инициализация массива
        IExecutable[] InitPlaces()
        {
            int len = Input.Integer("Введите количество объектов типа Place: ", "Количество мест не может быть отрицательным", 0, Int32.MaxValue);
            if (len == 0) return new IExecutable[0];

            bool inputManually = Input.Bool("Заполнить данные вручную? да/нет: ", "да");
            string name;

            IExecutable[] places = new IExecutable[len];

            for (int i = 0; i < len; i++)
            {
                if (inputManually) name = Input.String($"Название {i + 1}-го места: ");
                else Program.FillRandom(out name, out _, out _, out _, out _, out _, out _);

                places[i] = new Place(name);
            }

            return places;
        }

        IExecutable[] InitRegions()
        {
            int len = Input.Integer("Введите количество объектов типа Region: ", "Количество регионов не может быть отрицательным", 0, Int32.MaxValue);
            if (len == 0) return new IExecutable[0];

            bool inputManually = Input.Bool("Заполнить данные вручную? да/нет: ", "да");
            string region;
            int population;

            IExecutable[] regions = new IExecutable[len];

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

        IExecutable[] InitCities()
        {
            int len = Input.Integer("Введите количество объектов типа City: ", "Количество городов не может быть отрицательным", 0, Int32.MaxValue);
            if (len == 0) return new IExecutable[0];

            bool inputManually = Input.Bool("Заполнить данные вручную? да/нет: ", "да");

            string city;
            int houses, population;

            IExecutable[] cities = new IExecutable[len];

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

        IExecutable[] InitAddresses()
        {
            int len = Input.Integer("Введите количество объектов типа Address: ", "Количество адресов не может быть отрицательным", 0, Int32.MaxValue);
            if (len == 0) return new IExecutable[0];

            bool inputManually = Input.Bool("Заполнить данные вручную? да/нет: ", "да");

            string name, street;
            int houseNumber;

            IExecutable[] addresses = new IExecutable[len];

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

        void InitArray()
        {
            executables = new IExecutable[0];

            executables = executables.Union(InitPlaces()).ToArray();
            executables = executables.Union(InitRegions()).ToArray();
            executables = executables.Union(InitCities()).ToArray();
            executables = executables.Union(InitAddresses()).ToArray();
        }
        #endregion

        #region Работа с массивом
        void PrintInformation()
        {
            if (executables.Length == 0) Console.WriteLine("\nМассив пуст\n");
            else
            {
                int i = 1;
                foreach (IExecutable elem in executables)
                {
                    Console.WriteLine($"-- {i++,2} --");
                    elem.PrintInformation();
                }
            }
        }

        void Sort()
        {
            if (executables.Length == 0) Console.WriteLine("\nМассив пуст\n");
            else
            {
                SortArrayIComparable();
                Console.WriteLine("Массив был отсортирован по алфавиту Я-А");
            }
        }

        void SortArrayIComparable() => Array.Sort(executables);

        void SortAndFind()
        {
            if (executables.Length == 0) Console.WriteLine("\nМассив пуст\n");
            else
            {
                SearchInArray();
                SortArrayIComparer();
                Console.WriteLine("Массив был отсортирован по алфавиту А-Я");
            }
        }

        void SearchInArray()
        {
            string name = Input.String("Введите искомое название: ");

            int num = 0;
            bool isFound = false;

            foreach (IExecutable elem in executables)
            {
                num++;
                if (elem.Name == name)
                {
                    isFound = true;
                    Console.WriteLine($"Найдено совпадение, номер {num}");
                }
            }

            if (!isFound) Console.WriteLine($"Совпадений с названием {name} не найдено");
        }

        void SortArrayIComparer() => Array.Sort(executables, new SortByName());

        #endregion

        void CloneElement()
        {
            if (executables.Length == 0) Console.WriteLine("\nМассив пуст\n");
            else
            {
                Address clonableAdr = new Address("exmp", "Пушкина", 17);

                City exmp = new City("Для клонирования", 100, 100, clonableAdr);
                City sCopy = (City)exmp.ShallowCopy();
                City dCopy = (City)exmp.Clone();

                Console.WriteLine("Изначальные адреса: ");
                Console.WriteLine("exmp: "); exmp.CopyAddress.PrintInformation();
                Console.WriteLine("sCopy: "); sCopy.CopyAddress.PrintInformation();
                Console.WriteLine("dCopy: "); dCopy.CopyAddress.PrintInformation();

                exmp.CopyAddress.Name = Input.String("Введите новое имя для адреса: ");

                Console.WriteLine("\nПосле изменения адреса: ");
                Console.WriteLine("exmp: "); exmp.CopyAddress.PrintInformation();
                Console.WriteLine("sCopy: "); sCopy.CopyAddress.PrintInformation();
                Console.WriteLine("dCopy: "); dCopy.CopyAddress.PrintInformation();
            }
        }
    }

    public class SortByName : IComparer
    {
        public int Compare(object x, object y)
        {
            IExecutable ie1 = (IExecutable)x;
            IExecutable ie2 = (IExecutable)y;

            return String.Compare(ie1.Name, ie2.Name);
        }
    }
}
