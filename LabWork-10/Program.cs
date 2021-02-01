using System;
using MyLibrary;

namespace LabWork_10
{
    class Program
    {
        static void Main(string[] args)
        {
            int cmd;
            do
            {
                PrintMenu();

                cmd = Input.Integer("Команда > ", "Неизвестная команда", 0, 2);

                DoAction(cmd);
            } while (cmd != 0);
        }

        static void PrintMenu() => Console.WriteLine("1. Демонстрация наследования\n2. Демонстрация интерфейса\n\n0. Выход\n");

        static void DoAction(int cmd)
        {
            switch (cmd)
            {
                case 1: Output.Clear(); InheritanceExample.Start(); break;
                case 2: Output.Clear(); InterfaceExample.Start(); break;

                case 0: return;
            }
        }

        public static void FillRandom(out string name, out string region, out string city, out string street, out int population, out int houses, out int houseNumber)
        {
            name = Rand.Choice(new string[] { "Библиотека", "Жилое здание", "Стройка", "Торговый центр", "Поликлинника", "Арт-объект", "Музей", "Учебное заведение" });
            region = Rand.Choice(new string[] { "Пермский край", "Московская область", "Ленинградская область" });
            city = Rand.Choice(new string[] { "Пермь", "Москва", "Санкт-Петербург", "Березники", "Нытва", "Красновишерск", "Балашиха", "Дубна", "Сясьтрой", "Тихвин", "Тосно", "Выборг" });
            street = Rand.Choice(new string[] { "Ленина", "Пушкина", "Хабаровская", "Победы", "Краснозамённая", "Центральная", "Набережная", "Высокая" });
            houses = Rand.Integer(1, 10000);
            houseNumber = Rand.Integer(1, 201);
            population = Rand.Integer(100000, 15000000);
        }
    }
}