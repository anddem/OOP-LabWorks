﻿using System;
using MyLibrary;

namespace LabWork_10
{
    public class Program
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
            string[] regions = new string[] { "Алтайский край", "Амурская область", "Архангельская область", "Астраханская область", "Белгородская область", "Брянская область",
                                              "Владимирская область", "Волгоградская область", "Вологодская область", "Воронежская область", "г. Москва", "Еврейская автономная область",
                                              "Забайкальский край", "Ивановская область", "Иные территории, включая город и космодром Байконур", "Иркутская область",
                                              "Кабардино-Балкарская Республика", "Калининградская область", "Калужская область", "Камчатский край", "Карачаево-Черкесская Республика",
                                              "Кемеровская область - Кузбасс", "Кировская область", "Костромская область", "Краснодарский край", "Красноярский край", "Курганская область",
                                              "Курская область", "Ленинградская область", "Липецкая область", "Магаданская область", "Московская область", "Мурманская область",
                                              "Ненецкий автономный округ", "Нижегородская область", "Новгородская область", "Новосибирская область", "Омская область",
                                              "Оренбургская область", "Орловская область", "Пензенская область", "Пермский край", "Приморский край", "Псковская область",
                                              "Республика Адыгея (Адыгея)", "Республика Алтай", "Республика Башкортостан", "Республика Бурятия", "Республика Дагестан",
                                              "Республика Ингушетия", "Республика Калмыкия", "Республика Карелия", "Республика Коми", "Республика Крым", "Республика Марий Эл",
                                              "Республика Мордовия", "Республика Саха (Якутия)", "Республика Северная Осетия - Алания", "Республика Татарстан (Татарстан)",
                                              "Республика Тыва", "Республика Хакасия", "Ростовская область", "Рязанская область", "Самарская область", "Санкт-Петербург",
                                              "Саратовская область", "Сахалинская область", "Свердловская область", "Севастополь", "Смоленская область", "Ставропольский край",
                                              "Тамбовская область", "Тверская область", "Томская область", "Тульская область", "Тюменская область", "Удмуртская Республика",
                                              "Ульяновская область", "Хабаровский край", "Ханты-Мансийский автономный округ - Югра", "Челябинская область", "Чеченская Республика",
                                              "Чувашская Республика - Чувашия", "Чукотский автономный округ", "Ямало-Ненецкий автономный округ", "Ярославская область" };

            name = Rand.Choice(new string[] { "Библиотека", "Жилое здание", "Стройка", "Торговый центр", "Поликлинника", "Арт-объект", "Музей", "Учебное заведение" });
            region = Rand.Choice(regions);
            city = Rand.Choice(
                @"Абакан, Азов, Александров, Алексин, Альметьевск, Анапа, Ангарск, Анжеро-Судженск, Апатиты, Арзамас, Армавир, Арсеньев, Артем, Архангельск, Асбест, Астрахань, Ачинск, Балаково, Балахна, Балашиха,
                    Балашов, Барнаул, Батайск, Белгород, Белебей, Белово, Белогорск, Белорецк, Белореченск, Бердск, Березники, Березовский, Бийск, Биробиджан, Благовещенск, Бор, Борисоглебск, Боровичи, Братск, Брянск,
                    Бугульма, Буденновск, Бузулук, Буйнакск, Великие Луки, Великий Новгород, Верхняя Пышма, Видное, Владивосток, Владикавказ, Владимир, Волгоград, Волгодонск, Волжск, Волжский, Вологда, Вольск, Воркута, Воронеж, Воскресенск,
                    Воткинск, Всеволожск, Выборг, Выкса, Вязьма, Гатчина, Геленджик, Георгиевск, Глазов, Горно-Алтайск, Грозный, Губкин, Гудермес, Гуково, Гусь-Хрустальный, Дербент, Дзержинск, Димитровград, Дмитров, Долгопрудный,
                    Домодедово, Донской, Дубна, Евпатория, Егорьевск, Ейск, Екатеринбург, Елабуга, Елец, Ессентуки, Железногорск, Железногорск, Жигулевск, Жуковский, Заречный, Зеленогорск, Зеленодольск, Златоуст, Иваново, Ивантеевка,
                    Ижевск, Избербаш, Иркутск, Искитим, Ишим, Ишимбай, Йошкар-Ола, Казань, Калининград, Калуга, Каменск-Уральский, Каменск-Шахтинский, Камышин, Канск, Каспийск, Кемерово, Керчь, Кинешма, Кириши, Киров,
                    Кирово-Чепецк, Киселевск, Кисловодск, Клин, Клинцы, Ковров, Когалым, Коломна, Комсомольск-на-Амуре, Копейск, Королев, Кострома, Котлас, Красногорск, Краснодар, Краснокаменск, Краснокамск, Краснотурьинск, Красноярск, Кропоткин,
                    Крымск, Кстово, Кузнецк, Кумертау, Кунгур, Курган, Курск, Кызыл, Лабинск, Лениногорск, Ленинск-Кузнецкий, Лесосибирск, Липецк, Лиски, Лобня, Лысьва, Лыткарино, Люберцы, Магадан, Магнитогорск,
                    Майкоп, Махачкала, Междуреченск, Мелеуз, Миасс, Минеральные Воды, Минусинск, Михайловка, Михайловск, Мичуринск, Москва, Мурманск, Муром, Мытищи, Набережные Челны, Назарово, Назрань, Нальчик, Наро-Фоминск, Находка,
                    Невинномысск, Нерюнгри, Нефтекамск, Нефтеюганск, Нижневартовск, Нижнекамск, Нижний Новгород, Нижний Тагил, Новоалтайск, Новокузнецк, Новокуйбышевск, Новомосковск, Новороссийск, Новосибирск, Новотроицк, Новоуральск, Новочебоксарск, Новочеркасск, Новошахтинск, Новый Уренгой,
                    Ногинск, Норильск, Ноябрьск, Нягань, Обнинск, Одинцово, Озерск, Октябрьский, Омск, Орел, Оренбург, Орехово-Зуево, Орск, Павлово, Павловский Посад, Пенза, Первоуральск, Пермь, Петрозаводск, Петропавловск-Камчатский,
                    Подольск, Полевской, Прокопьевск, Прохладный, Псков, Пушкино, Пятигорск, Раменское, Ревда, Реутов, Ржев, Рославль, Россошь, Ростов-на-Дону, Рубцовск, Рыбинск, Рязань, Салават, Сальск, Самара,
                    Санкт-Петербург, Саранск, Сарапул, Саратов, Саров, Свободный, Севастополь, Северодвинск, Северск, Сергиев Посад, Серов, Серпухов, Сертолово, Сибай, Симферополь, Славянск-на-Кубани, Смоленск, Соликамск, Солнечногорск, Сосновый Бор,
                    Сочи, Ставрополь, Старый Оскол, Стерлитамак, Ступино, Сургут, Сызрань, Сыктывкар, Таганрог, Тамбов, Тверь, Тимашевск, Тихвин, Тихорецк, Тобольск, Тольятти, Томск, Троицк, Туапсе, Туймазы,
                    Тула, Тюмень, Узловая, Улан-Удэ, Ульяновск, Урус-Мартан, Усолье-Сибирское, Уссурийск, Усть-Илимск, Уфа, Ухта, Феодосия, Фрязино, Хабаровск, Ханты-Мансийск, Хасавюрт, Химки, Чайковский, Чапаевск, Чебоксары,
                    Челябинск, Черемхово, Череповец, Черкесск, Черногорск, Чехов, Чистополь, Чита, Шадринск, Шали, Шахты, Шуя, Щекино, Щелково, Электросталь, Элиста, Энгельс, Южно-Сахалинск, Юрга, Якутск"
                    .Split(new char[] {',', ' '}, StringSplitOptions.RemoveEmptyEntries));
            street = Rand.Choice(new string[] { "Ленина", "Пушкина", "Хабаровская", "Победы", "Краснознамённая", "Центральная", "Набережная", "Высокая" });
            houses = Rand.Integer(1, 10000);
            houseNumber = Rand.Integer(1, 201);
            population = Rand.Integer(100000, 15000000);
        }
    }
}