using System;

namespace LabWork_4
{
    class Program
    {
        static Random rnd = new Random();

        static void Main(string[] args)
        {
            int command;
            int[] array = new int[0];

            do
            {
                PrintNotEmptyArray(array);

                Console.WriteLine(
                    "1. Создание массива\n" +
                    "2. Удаление элементов с чётными индексами\n" +
                    "3. Добавление элементов в конец массива\n" +
                    "4. Поменять местами минимальный и максимальный элементы\n" +
                    "5. Найти первый отрицательный элемент\n" +
                    "6. Сортировка массива");
                if (CheckSort(array, sortOrderDesc: false, out bool isSorted)) Console.WriteLine("7. Бинарный поиск");
                Console.WriteLine("\n0. Выход\n");

                if (isSorted)
                    command = InputInteger(
                        msg: "> ",
                        errMsg: "Неизвестная команда..",
                        min: 0, max: 7);
                else
                    command = InputInteger(
                        msg: "> ",
                        errMsg: "Неизвестная команда..",
                        min: 0, max: 6);

                switch (command)
                {
                    case 1: MakeArray(ref array); ClearScreen(); break;
                    case 2: DeleteEvenIndexes(ref array); ClearScreen(); break;
                    case 3: AddElementsToEnd(ref array); ClearScreen(); break;
                    case 4: SwapMinMax(array); ClearScreen(); break;
                    case 5: FindFirstNegative(array); ClearScreen(); break;
                    case 6: SortArray(array); ClearScreen(); break;
                    case 7: BSAskTarget(array); ClearScreen(); break;
                }
            } while (command != 0);
        }

        static void ClearScreen()
        { //Функция очистки экрана
            Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
            Console.ReadKey(true);
            Console.Clear();
        }

        static int InputInteger(string msg, string errMsg = "", int min = 0, int max = 100)
        { //Функция ввода числа
            int input = 0;
            bool ok;

            do
            {
                try
                {
                    Console.Write(msg);
                    input = Convert.ToInt32(Console.ReadLine());

                    if (input >= min && input <= max) ok = true; //Проверка на попадание в диапазон разрешённых значений
                    else
                    {
                        Console.WriteLine(errMsg);
                        ok = false;
                    }
                }
                catch (FormatException)
                {
                    Console.WriteLine("Неверный формат ввода!");
                    ok = false;
                }
            } while (!ok);

            return input;
        }

        static bool ChooseOneOfTwo(string msg, params string[] validValues)
        { //Функция выбора из двух вариантов
            bool result = true;
            bool ok = false;

            do
            {
                Console.Write(msg);
                string buf = Console.ReadLine();

                foreach (string value in validValues) //Проверка на попадание в диапазон разрешённых значений
                    ok = buf == value || ok;

                if (!ok) Console.WriteLine($"Ошибка! Допустимые значения: {validValues[0]}, {validValues[1]}");
                else result = buf == validValues[0];
            } while (!ok);

            return result;
        }

        static void PrintNotEmptyArray(int[] array)
        {
            if (array.Length != 0)
            {
                Console.WriteLine("Массив:");
                PrintArray(array);
                Console.WriteLine($"\nДлина массива: {array.Length}\n");
            }
        }

        static void PrintArray(int[] arr)
        { //Функция печати массива
            foreach (int elem in arr)
                Console.Write($"{elem,4} ");
        }

        static void CopyArray(int[] oldArray, int[] newArray)
        { //Копирование одного массива в другой
            for (int i = 0; i < oldArray.Length && i < newArray.Length; i++)
                newArray[i] = oldArray[i];
        }

        static void FillArrayRandomly(int[] array, int startIndex, int stopIndex)
        { //Заполнение массива с помощью ДСЧ
            for (int i = startIndex; i != stopIndex; i++)
                array[i] = rnd.Next(-500, 500);
        }

        static void FillArrayManually(int[] array, int startIndex, int stopIndex)
        { //Ручное заполнение массива
            for (int i = startIndex; i != stopIndex; i++)
                array[i] = InputInteger(msg: $"Элемент {i + 1} из {array.Length}: ", min: -500, max: 500);
        }

        static void MakeArray(ref int[] array)
        { //Создание массива
            int oldLen = array.Length;
            int newLen = InputInteger(
                msg: "Введите длину нового массива: ",
                errMsg: $"Длина массива должна быть в пределах от 1 до 100",
                min: 1, max: 100);

            bool saveOldArray = false;
            if (oldLen != 0)
                saveOldArray = ChooseOneOfTwo(
                    msg: "Сохранить элементы старого массива? Y/N: ",
                    validValues: new string[] { "Y", "N" });

            bool inputManually = ChooseOneOfTwo(
                msg: "Ввести новые элементы вручную? Y/N: ",
                validValues: new string[] { "Y", "N" });

            if (saveOldArray)
            {
                int[] tempArray = array;
                array = new int[newLen];

                CopyArray(tempArray, array);
            }
            else
            {
                array = new int[newLen];
                oldLen = 0;
            }

            if (inputManually) FillArrayManually(array: array, startIndex: oldLen, stopIndex: newLen);
            else FillArrayRandomly(array: array, startIndex: oldLen, stopIndex: newLen);
        }

        static void DeleteEvenIndexes(ref int[] array)
        {
            if (array.Length == 0) //Если массив пуст - сообщение об ошибке
                Console.WriteLine("Ошибка, массив пуст!");
            else
            {
                int[] buffer = new int[(array.Length + 1) / 2];

                for (int i = 0; i < buffer.Length; i++)
                    buffer[i] = array[2 * i]; //Переписываем только элементы с нечётными номерами

                array = buffer;
            }
        }

        static void AddElementsToEnd(ref int[] array)
        {
            if (array.Length == 0) //Если массив пуст - предложение создать новый массив
            {
                bool createNewArray = ChooseOneOfTwo(
                    msg: "Массив пуст. Создать новый массив? Y/N: ",
                    validValues: new string[] { "Y", "N" });

                if (createNewArray) MakeArray(ref array);
            }
            else
            {
                int howMuchElements = InputInteger(
                    msg: "Сколько элементов добавить? ",
                    errMsg: "Количество новых элементов должно быть от 1 до 100",
                    min: 1, max: 100);

                bool inputManually = ChooseOneOfTwo(
                    msg: "Ввести новые элементы вручную? Y/N: ",
                    validValues: new string[] { "Y", "N" });

                int[] buffer = array;
                array = new int[buffer.Length + howMuchElements]; //Пересоздаём старый на большее количество элементов
                CopyArray(buffer, array);

                //Добавление элементов
                if (inputManually) //Заполнение массива в зависимости от выбора пользователя
                    FillArrayManually(array, buffer.Length, array.Length);
                else
                    FillArrayRandomly(array, buffer.Length, array.Length);
            }
        }

        static void FindMinMaxIndexes(int[] array, out int minIdx, out int maxIdx)
        {
            if (array[0] < array[1]) //Первые два элемента становятся max и min в зависимости от значений
                (minIdx, maxIdx) = (0, 1);
            else
                (minIdx, maxIdx) = (1, 0);

            for (int i = 2; i < array.Length; i++) //Остальные сравниваются с ними
            {
                if (array[i] < array[minIdx]) minIdx = i;
                else if (array[i] > array[maxIdx]) maxIdx = i;
            }
        }

        static void SwapMinMax(int[] array)
        {
            switch (array.Length)
            {
                case 0: //Если массив пуст - сообщение об ошибке
                    Console.WriteLine("Ошибка, массив пуст!");
                    break;
                case 1: //Если массив из одного элемента - сообщение об ошибке
                    Console.WriteLine("Ошибка, в массиве всего один элемент!");
                    break;
                default:
                    FindMinMaxIndexes(array, out int minI, out int maxI);
                    Swap(ref array[minI], ref array[maxI]);
                    break;
            }
        }

        static void FindFirstNegative(int[] array)
        {
            if (array.Length == 0) //Если массив пуст - сообщение об ошибке
                Console.WriteLine("Ошибка, массив пуст!");
            else
            {
                int i = 0;
                while (i < array.Length && array[i] >= 0) i++;

                if (i != array.Length) Console.WriteLine($"Первый отрицательный элемент: {array[i]}, сравнений: {i + 1}");
                else Console.WriteLine("Отрицательных элементов нет!");
            }
        }

        static bool CheckSort(int[] array, bool sortOrderDesc, out bool isSorted)
        {
            isSorted = array.Length > 0; //Изначальное состояние - есть ли в массиве элементы

            for (int i = 0; i < array.Length - 1 && isSorted; i++)
            {
                if (sortOrderDesc)  //Проверяем порядок элементов в зависимости от выбранного порядка сортировки
                    isSorted = array[i] >= array[i + 1];
                else
                    isSorted = array[i] <= array[i + 1];
            }

            return isSorted;
        }

        static void Swap(ref int a, ref int b)
        {
            int temp = a;
            a = b;
            b = temp;
        }

        static void SortArray(int[] array)
        {
            if (array.Length == 0) //Если массив пуст - ошибка
                Console.WriteLine("Ошибка, массив пуст!");
            else
            { //Иначе вопрос про порядок сортировки
                bool sortOrderDesc = ChooseOneOfTwo(
                    msg: "Сортировать по убыванию или по возрастанию? DESC/ASC: ",
                    validValues: new string[] { "DESC", "ASC" });

                //И вызов соответствующей функции
                if (sortOrderDesc) SortArrayDesc(array);
                else SortArrayAsc(array);
            }
        }

        static void SortArrayDesc(int[] array)
        {
            bool isSorted; //Отсортирован ли массив
            int check = 0;
            do
            {
                CheckSort(array: array, sortOrderDesc: true, isSorted: out isSorted); //Проверка, отсортирован ли на данном этапе массив
                if (!isSorted) //если нет
                {
                    for (int i = check + 1; i < array.Length; i++) //Проходим по массиву
                        if (array[check] < array[i]) //Если нашлись элементы не по возрастанию
                            Swap(ref array[check], ref array[i]); //Меняем их местами
                }
                check++;
            } while (!isSorted);
        }

        static void SortArrayAsc(int[] array)
        {
            bool isSorted; //Отсортирован ли массив
            int check = 0;
            do
            {
                CheckSort(array: array, sortOrderDesc: false, isSorted: out isSorted); //Проверяем, отсортирован ли массив на данный момент
                if (!isSorted) //Если нет
                {
                    for (int i = check; i < array.Length; i++) //Проходим по массиву до отсортированной части в конце
                    {
                        if (array[check] > array[i]) //Если находим элементы не по убыванию - меняем их местами
                            Swap(ref array[check], ref array[i]);
                    }
                    check++;
                }
            } while (!isSorted); //Цикл продолжается пока массив не отсортирован
        }

        static void BSAskTarget(int[] array)
        {
            int target = InputInteger(
                msg: "Введите искомое значение: ",
                min: Int32.MinValue, max: Int32.MaxValue);

            BinarySearch(array: array, left: 0, right: array.Length - 1, target: target);
        }

        static void BinarySearch(int[] array, int left, int right, int target, int attempt = 1)
        { //Бинарный поиск
            if (right == left) //Если индексы сошлись на одном элементе
            {
                if (array[left] == target) //Проверка, найден ли элемент
                    Console.WriteLine($"Элемент {target} найден. Сравнений: {attempt}. Номер: {left + 1}");
                else
                    Console.WriteLine($"Элемента {target} нет в массиве");
            }
            else if (right - left == 1) //Если индексы стоят рядом
            { //Проверяем каждый индекс на совпадение
                if (array[left] == target)
                    Console.WriteLine($"Элемент {target} найден. Сравнений: {attempt}. Номер: {left + 1}");
                else if (array[right] == target)
                    Console.WriteLine($"Элемент {target} найден. Сравнений: {attempt}. Номер: {right + 1}");
                else
                    Console.WriteLine($"Элемента {target} нет в массиве");
            }
            else
            {
                int pivot = (right + left) / 2; //Делим массив пополам

                if (target == array[pivot]) //Если искомый элемент найден сразу
                    Console.WriteLine($"Элемент {target} найден. Сравнений: {attempt}. Номер: {pivot + 1}");
                else if (target < array[pivot]) //Если искомый элемент меньше элемента в опорной точке
                    //Рассматриваем левую половину массива - подмассив [start, pivot]
                    BinarySearch(array, left: left, right: pivot, target: target, attempt: attempt + 1);
                else //Иначе рассматриваем правую половину массива - подмассив [piivot, stop]
                    BinarySearch(array, left: pivot, right: right, target: target, attempt: attempt + 1);
            }
        }
    }
}
