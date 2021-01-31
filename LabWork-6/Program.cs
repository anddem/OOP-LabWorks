using System;
using System.Collections.Generic;
using MyLibrary;

namespace LabWork_6
{
    class Program
    {
        static readonly Random rand = new Random(); //ДСЧ

        static readonly string[] examples = new string[]
        {
            @"Two before narrow not relied how except moment myself. Dejection assurance mrs led certainly. So gate at no only none open.
Betrayed at properly it of graceful on. Dinner abroad am depart ye turned hearts as me wished. Therefore allowance too perfectly
gentleman supposing man his now. Families goodness all eat out bed steepest servants. Explained the incommode sir improving
northward immediate eat. Man denoting received you sex possible you. Shew park own loud son door less yet. Boy desirous families
prepared gay reserved add ecstatic say. Replied joy age visitor nothing cottage. Mrs door paid led loud sure easy read. Hastily
at perhaps as neither or ye fertile tedious visitor. Use fine bed none call busy dull when. Quiet ought match my right by table
means. Principles up do in me favourable affronting. Twenty mother denied effect we to do on.",
            @"Far curiosity incommode now led smallness allowance. Favour bed assure son things yet. She consisted consulted elsewhere happiness
disposing household any old the. Widow downs you new shade drift hopes small. So otherwise commanded sweetness we improving. Instantly
by daughters resembled unwilling principle so middleton. Fail most room even gone her end like. Comparison dissimilar unpleasant six
compliment two unpleasing any add. Ashamed my company thought wishing colonel it prevent he in. Pretended residence are something far
engrossed old off. Procuring education on consulted assurance in do. Is sympathize he expression mr no travelling. Preference he he at
travelling in resolution. So striking at of to welcomed resolved. Northward by described up household therefore attention. Excellence
decisively nay man yet impression for contrasted remarkably.",
            @"Do so written as raising parlors spirits mr elderly. Made late in of high left hold. Carried females of up highest calling.
Limits marked led silent dining her she far.Sir but elegance marriage dwelling likewise position old pleasure men. Dissimilar
themselves simplicity no of contrasted as. Delay great day hours men. Stuff front to do allow to asked he. On on produce colonel
pointed. Just four sold need over how any. In to september suspicion determine he prevailed admitting. On adapted an as affixed
limited on. Giving cousin warmly things no spring mr be abroad. Relation breeding be as repeated strictly followed margaret. One
gravity son brought shyness waiting regular led ham. Respect forming clothes do in he. Course so piqued no an by appear. Themselves
reasonable pianoforte so motionless he as difficulty be. Abode way begin ham there power whole. Do unpleasing indulgence impossible
to conviction."
        };

        static void Main()
        {
            char[][] array = new char[0][]; //Рваный массив из char[] элементов
            int cmnd; //Команда

            do
            {
                PrintInterface(array); //Вывод интерфейса

                cmnd = Input.Integer( //Считывание команды
                    msg: "> ",
                    errMsg: "Неизвестная команда!",
                    minValue: 0, maxValue: 6);

                switch (cmnd)
                {
                    case 1: MakeArray(ref array); Output.PauseAndClear(); break; //Команда на создание массива
                    case 2: DeleteRow(ref array); Output.PauseAndClear(); break; //Команда на удаление последней строки, в которой есть три и более цифр
                    case 3: CountKeyWordsInText(); Output.PauseAndClear(); break; //Команда подсчёта ключевых слов C# в тексте
                    case 4: CountKeyWordsInText(examples[0]); Output.PauseAndClear(); break;
                    case 5: CountKeyWordsInText(examples[1]); Output.PauseAndClear(); break;
                    case 6: CountKeyWordsInText(examples[2]); Output.PauseAndClear(); break;

                    case 0: break;
                }
            } while (cmnd != 0);
        }

        static void PrintInterface(char[][] array) //Печатает меню и массив на экарн
        {
            PrintArray(array);
            PrintMenu();
        }

        static void PrintArray(char[][] array) //Печать массива
        {
            if (array.Length == 0) Console.WriteLine("Массив пуст");
            else
            {
                for (int i = 0; i < array.Length; i++)
                {
                    Console.Write($"{i + 1,2} | ");
                    foreach (char symbol in array[i]) Console.Write($"{symbol} ");
                    Console.WriteLine();
                }
            }
        }

        static void PrintMenu() //Вывод текстового меню на экран
        {
            Console.WriteLine("\n" +
                "1. Создать массив\n" +
                "2. Удалить последнюю строку,\n" +
                "   в которой есть минимум 3 цифры\n" +
                "3. Подсчитать во введённом тексте\n" +
                "   количество ключевых слов C#\n" +
                "4. Подсчитать в готовом тексте 1\n" +
                "   количество ключевых слов C#\n" +
                "5. Подсчитать в готовом тексте 2\n" +
                "   количество ключевых слов C#\n" +
                "6. Подсчитать в готовом тексте 3\n" +
                "   количество ключевых слов C#\n" +
                "0. Выход\n");
        }

        static void MakeArray(ref char[][] array) //Создание массива
        {
            int expressions = Input.Integer(
                msg: "Введите количество строк: ",
                errMsg: "Количество строк должно быть от 1 до 10 включительно!",
                minValue: 1, maxValue: 10);

            array = new char[expressions][];

            for (int i = 0; i < expressions; i++)
            {
                int len = Input.Integer(
                    msg: $"Введите количество символов в {i + 1}-ой строке: ",
                    errMsg: "Количество символов может быть от 1 до 50 включительно!",
                    minValue: 1, maxValue: 50);

                array[i] = new char[len];
            }

            FillArray(array); //Передача управления в функцию заполнения массива
        }

        static void FillArray(char[][] array) //Выбор способа заполнения массива
        {
            bool filled;

            do
            {
                filled = true;

                Console.Write("Заполнить строки вручную? Y/N: ");
                string input = Console.ReadLine();

                switch (input.ToLower())
                {
                    case "y":
                    case "н":
                        FillArrayManually(array);
                        break;
                    case "n":
                    case "т":
                        FillArrayRandomly(array);
                        break;

                    default:
                        Console.WriteLine("Неверный ввод!");
                        filled = false;
                        break;
                }
            } while (!filled);
        }

        static void FillArrayManually(char[][] array) //Ввод элементов массива вручную
        {
            Console.WriteLine("Вводите символы через пробел");
            for (int i = 0; i < array.Length; i++)
            {
                Console.WriteLine($"Строка {i + 1,2}: ");
                string[] buffer = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                while (buffer.Length < array[i].Length)
                {
                    Console.WriteLine($"Необходимо ввести не менее {array[i].Length} элементов!");
                    Console.Write("> ");
                    buffer = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                }

                for (int j = 0; j < array[i].Length; j++)
                {
                    if (buffer[j].Length != 1)
                    {
                        while (buffer[j].Length != 1)
                        {
                            Console.WriteLine($"Элемент номер {j + 1} - {buffer[j]} - не является символом!");
                            Console.Write($"Введите символ номер {j + 1}: ");
                            buffer[j] = Console.ReadLine();
                        }
                    }

                    array[i][j] = buffer[j][0];
                }

                if (buffer.Length > array[i].Length) Console.WriteLine("Введено больше символов, чем необходимо. Лишние символы не записаны.");
            }
        }

        static void FillArrayRandomly(char[][] array) //Случайное заполнение массива символами русского и латинского алфавитов, а также цифрами
        {
            Console.WriteLine("Сгенерированные символы: ");
            for (int i = 0; i < array.Length; i++)
            {
                Console.Write($"{i + 1,2} | ");
                for (int j = 0; j < array[i].Length; j++)
                {
                    array[i][j] = RandomSymbol();
                    Console.Write($"{array[i][j]} ");
                }
                Console.WriteLine();
            }
        }

        static char RandomSymbol() //Возвращает случайный символ
        {
            switch (rand.Next(5))
            {
                case 0: return (char)rand.Next('A', 'Z');
                case 1: return (char)rand.Next('a', 'z');
                case 2: return (char)rand.Next('А', 'Я');
                case 3: return (char)rand.Next('а', 'я');

                default: return (char)rand.Next('0', '9');
            }
        }

        static void DeleteRowByNumber(ref char[][] array, int num) //Удаление строки с номером num
        {
            char[][] buffer = array;
            array = new char[buffer.Length - 1][];

            for (int i = 0; i < num; i++)
                array[i] = buffer[i];
            for (int i = num + 1; i < buffer.Length; i++)
                array[i - 1] = buffer[i];
        }

        static void DeleteRow(ref char[][] array) //Поиск и удаление строки
        {
            if (array.Length == 0) Console.WriteLine("Ошибка, массив пуст!");
            else
            {
                for (int i = array.Length - 1; i >= 0; i--)
                {
                    int digits = 0;
                    for (int j = 0; j < array[i].Length && array[i].Length >= 3; j++)
                    {
                        if (Char.IsDigit(array[i][j])) digits++;

                        if (digits == 3)
                        {
                            DeleteRowByNumber(ref array, i);
                            Console.WriteLine($"Строка номер {i + 1} была удалена");
                            return;
                        }
                    }
                }

                Console.WriteLine("Строк с тремя и более цифрами внутри не найдено");
            }
        }

        static void CountKeyWordsInText() //Подсчёт ключевых слов C# в введённом тексте
        {
            Dictionary<string, int> keyWords = new Dictionary<string, int>(); //Словарь, ключевое_слово: счётчик
            string words = "abstract as base bool break byte case catch char checked class const continue decimal default delegate " +
                            "do double else enum event explicit extern false finally fixed float for foreach goto if implicit " +
                            "in int interface internal is lock long namespace new null object operator out override params " +
                            "private protected public readonly ref return sbyte sealed short sizeof stackalloc static string " +
                            "struct switch this throw true try typeof uint ulong unchecked unsafe unshort using virtual volatile void while";

            foreach (string word in words.Split(new char[] { ' ' })) keyWords.Add(word, 0);

            Console.WriteLine("Введите текст: ");
            string[] text = Console.ReadLine().Split(new char[] { ' ', ',', ':', ';', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            bool atLeastOne = false;

            foreach (string word in text)
                if (keyWords.ContainsKey(word.ToLower())) //Если такой ключ есть в словаре
                {
                    keyWords[word.ToLower()]++; //Инкремент значения по ключу
                    atLeastOne = true; //Флаг, что найдено по крайней мере одно ключевое слово
                }

            if (atLeastOne)
            {
                Console.WriteLine("В тексте встретились следующие ключевые слова: ");
                foreach (KeyValuePair<string, int> pair in keyWords)
                    if (pair.Value != 0) Console.WriteLine($"{pair.Key,10}: {pair.Value}");
            }
            else
                Console.WriteLine("В введённом тексте ключевых слов не найдено!");
        }

        static void CountKeyWordsInText(string text) //Подсчёт ключевых слов C# в готовом тексте
        {
            Dictionary<string, int> keywordsDict = new Dictionary<string, int>(); //Словарь, ключевое_слово: счётчик
            string keyWords = "abstract as base bool break byte case catch char checked class const continue decimal default delegate " +
                            "do double else enum event explicit extern false finally fixed float for foreach goto if implicit " +
                            "in int interface internal is lock long namespace new null object operator out override params " +
                            "private protected public readonly ref return sbyte sealed short sizeof stackalloc static string " +
                            "struct switch this throw true try typeof uint ulong unchecked unsafe unshort using virtual volatile void while";

            foreach (string word in keyWords.Split(new char[] { ' ' })) keywordsDict.Add(word, 0);

            Console.WriteLine("Использован готовый шаблон: ");
            Console.WriteLine(text);
            string[] words = text.Split(new char[] { ' ', ',', ':', ';', '.', '!', '?' }, StringSplitOptions.RemoveEmptyEntries);

            bool atLeastOne = false;

            foreach (string word in words)
                if (keywordsDict.ContainsKey(word.ToLower())) //Если такой ключ есть в словаре
                {
                    keywordsDict[word.ToLower()]++; //Инкремент значения по ключу
                    atLeastOne = true; //Флаг, что найдено по крайней мере одно ключевое слово
                }

            if (atLeastOne)
            {
                Console.WriteLine("В тексте встретились следующие ключевые слова: ");
                foreach (KeyValuePair<string, int> pair in keywordsDict)
                    if (pair.Value != 0) Console.WriteLine($"{pair.Key,10}: {pair.Value}");
            }
            else
                Console.WriteLine("В введённом тексте ключевых слов не найдено!");
        }

    }
}