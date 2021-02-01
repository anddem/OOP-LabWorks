using System;
using MyLibrary;

namespace LabWork_5
{
    class Program
    {
        static Random rnd = new Random();

        static string[] menu = new string[]
                {
                    "1. Создать одномерный массив\n",
                    "2. Создать матрицу\n",
                    "3. Создать рваный массив\n",
                    "4. Удалить N элементов с номера K в одномерном массиве\n",
                    "5. Добавить столбец в начало матрицы\n",
                    "6. Добавить в матрицу строку с номером К\n",
                    "7. Удалить из рваного массива строки в диапазоне [K1..K2]\n\n",
                    "0. Выход\n\n"
                };

        static void Main(string[] args)
        {
            int command;
            int[] simpArray = new int[0];
            int[,] matrix = new int[0, 0];
            int[][] jagArray = new int[0][];

            do
            {
                PrintNotEmptyArray(simpArray);
                PrintNotEmptyArray(matrix);
                PrintNotEmptyArray(jagArray);

                PrintMenu();

                command = Input.Integer(
                    msg: "> ",
                    errMsg: "Неизвестная команда..",
                    minValue: 0, maxValue: menu.Length - 1);

                switch (command)
                {
                    case 1: MakeArray(ref simpArray); ClearScreen(); break;
                    case 2: MakeArray(ref matrix); ClearScreen(); break;
                    case 3: MakeArray(ref jagArray); ClearScreen(); break;
                    case 4: DeleteSomeElements(ref simpArray); ClearScreen(); break;
                    case 5: AddColumn(ref matrix); ClearScreen(); break;
                    case 6: AddRow(ref matrix); ClearScreen(); break;
                    case 7: DeleteSomeRows(ref jagArray); ClearScreen(); break;

                    case 0: break;
                }
            } while (command != 0);
        }

        static void ClearScreen()
        {
            Console.WriteLine("Нажмите любую клавишу чтобы продолжить...");
            Console.ReadKey(true);
            Console.Clear();
        }

        static void PrintMenu()
        {
            foreach (string item in menu)
                Console.Write(item);
        }


        /* РАБОТА С ОДНОМЕРНЫМ МАССИВОМ */
        static void PrintNotEmptyArray(int[] array)
        {
            if (array.Length != 0)
            {
                Console.WriteLine($"Одномерный массив, длина = {array.Length}:");
                PrintArray(array);
            }
            else Console.WriteLine("Одномерный массив пуст");
            Console.WriteLine('\n');
        }

        static void PrintArray(int[] array)
        {
            foreach (int elem in array)
                Console.Write($"{elem,4} ");
        }

        static void CopyArray(int[] oldArray, int[] newArray)
        {
            for (int i = 0; i < newArray.Length && i < oldArray.Length; i++)
                newArray[i] = oldArray[i];
        }

        static void FillArrayRandomly(int[] array, int startIndex = 0)
        {
            for (int i = startIndex; i < array.Length; i++)
                array[i] = rnd.Next(-500, 501);
        }

        static void FillArrayManually(int[] array, int startIndex = 0)
        {
            for (int i = startIndex; i < array.Length; i++)
                array[i] = Input.Integer(
                    msg: $"Элемент {i + 1} из {array.Length}: ");
        }

        static void MakeArray(ref int[] array)
        {
            bool saveOldArray = false;
            int[] buffer = new int[0];
            if (array.Length != 0)
            {
                saveOldArray = ChooseOneOfTwo(
                    msg: "Сохранить старый массив? Y/N: ",
                    new string[] { "Y", "N" });
            }

            int len = Input.Integer(
                msg: "Введите длину массива: ",
                errMsg: "Длина массива должна быть в диапазоне от 1 до 100!",
                minValue: 1, maxValue: 100);

            bool inputManually = ChooseOneOfTwo(
                msg: "Ввести новые элементы вручную? Y/N: ",
                new string[] { "Y", "N" });

            if (saveOldArray)
            {
                if (array.Length == len) return;

                buffer = new int[array.Length];
                CopyArray(array, buffer);
                array = new int[len];
                CopyArray(buffer, array);

                if (buffer.Length > len) return;
            }
            else array = new int[len];

            if (inputManually) FillArrayManually(array, buffer.Length);
            else FillArrayRandomly(array: array, startIndex: buffer.Length);
        }

        static void DeleteSomeElements(ref int[] array)
        {
            if (array.Length == 0)
            {
                Console.WriteLine("Ошибка, массив пуст!");
                return;
            }

            int N = Input.Integer(
                msg: "Количество удаляемых элементов: ",
                errMsg: $"Значение должно быть в пределах от 1 до {array.Length}",
                minValue: 1, maxValue: array.Length);

            int K = Input.Integer(
                msg: "Номер, с которого удалять элементы: ",
                errMsg: $"Номер должен быть в пределах от 1 до {array.Length - N + 1}",
                minValue: 1, maxValue: array.Length - N + 1);

            int[] buffer = new int[array.Length - N];

            for (int i = 0; i < K - 1; i++)
                buffer[i] = array[i];

            for (int i = N + K - 1; i < array.Length; i++)
                buffer[i - N] = array[i];

            array = new int[buffer.Length];
            CopyArray(buffer, array);
        }


        /* РАБОТА С ДВУМЕРНЫМ МАССИВОМ */
        static void PrintNotEmptyArray(int[,] array)
        {
            if (array.Length != 0)
            {
                Console.WriteLine($"Матрица {array.GetLength(0)}x{array.GetLength(1)}:");
                PrintArray(array);
            }
            else Console.WriteLine("Двумерный массив пуст");
            Console.WriteLine('\n');
        }

        static void PrintArray(int[,] array)
        {
            for (int i = 0; i < array.GetLength(0); i++)
            {
                for (int j = 0; j < array.GetLength(1); j++)
                    Console.Write($"{array[i, j],4} ");
                Console.WriteLine();
            }
        }

        static void CopyArray(int[,] oldArray, int[,] newArray)
        {
            for (int i = 0; i < oldArray.GetLength(0) && i < newArray.GetLength(0); i++)
                for (int j = 0; j < oldArray.GetLength(1) && j < newArray.GetLength(1); j++)
                    newArray[i, j] = oldArray[i, j];
        }

        static void FillArrayRandomly(int[,] array, int sRow = 0, int sCol = 0)
        {
            for (int c = sCol; c < array.GetLength(1); c++)
                for (int r = 0; r < sRow && r < array.GetLength(0); r++)
                    array[r, c] = rnd.Next(-500, 501);

            for (int r = sRow; r < array.GetLength(0); r++)
                for (int c = 0; c < array.GetLength(1); c++)
                    array[r, c] = rnd.Next(-500, 501);
        }

        static void FillArrayManually(int[,] array, int sRow = 0, int sCol = 0)
        {
            for (int c = sCol; c < array.GetLength(1); c++)
                for (int r = 0; r < sRow && r < array.GetLength(0); r++)
                    array[r, c] = Input.Integer(msg: $"Элемент ({r + 1}, {c + 1}): ");

            for (int r = sRow; r < array.GetLength(0); r++)
                for (int c = 0; c < array.GetLength(1); c++)
                    array[r, c] = Input.Integer(msg: $"Элемент ({r + 1}, {c + 1}): ");
        }

        static void MakeArray(ref int[,] array)
        {
            bool saveOldArray = false;
            int[,] buffer = new int[0, 0];
            if (array.Length != 0)
            {
                saveOldArray = ChooseOneOfTwo(
                    msg: "Сохранить старый массив? Y/N: ",
                    new string[] { "Y", "N" });
            }

            int rows = Input.Integer(
                msg: "Введите количество строк массива: ",
                errMsg: "Значение должно быть в диапазоне от 1 до 100!",
                minValue: 1, maxValue: 100);

            int cols = Input.Integer(
                msg: "Введите количество столбцов массива: ",
                errMsg: "Значение должно быть в диапазоне от 1 до 100!",
                minValue: 1, maxValue: 100);

            if (saveOldArray)
            {
                if (array.GetLength(0) == rows && array.GetLength(1) == cols) return;

                buffer = new int[array.GetLength(0), array.GetLength(1)];
                CopyArray(array, buffer);
                array = new int[rows, cols];
                CopyArray(buffer, array);

                if (buffer.GetLength(0) >= rows && buffer.GetLength(1) >= cols) return;
            }
            else array = new int[rows, cols];

            bool inputManually = ChooseOneOfTwo(
                msg: "Ввести новые элементы вручную? Y/N: ",
                new string[] { "Y", "N" });

            if (inputManually) FillArrayManually(array, buffer.GetLength(0), buffer.GetLength(1));
            else FillArrayRandomly(array, buffer.GetLength(0), buffer.GetLength(1));
        }

        static void AddColumn(ref int[,] array)
        {
            if (array.Length == 0) Console.WriteLine("Ошибка, массив пуст!");
            else
            {
                int[,] buffer = new int[array.GetLength(0), array.GetLength(1) + 1];

                bool inputManually = ChooseOneOfTwo(
                    msg: "Ввести новые элементы вручную? Y/N: ",
                    validValues: new string[] { "Y", "N" });

                for (int r = 0; r < buffer.GetLength(0); r++)
                    for (int c = 0; c < buffer.GetLength(1); c++)
                        if (c == 0 && inputManually)
                            buffer[r, c] = Input.Integer(
                                msg: $"Элемент ({r + 1}, {c + 1}): ",
                                errMsg: "Значение должно быть в пределах [-500, 500]",
                                minValue: -500, maxValue: 500);
                        else if (c == 0 && !inputManually)
                            buffer[r, c] = rnd.Next(-500, 501);
                        else buffer[r, c] = array[r, c - 1];

                array = buffer;
            }
        }

        static void AddRow(ref int[,] array)
        {
            if (array.Length == 0) Console.WriteLine("Ошибка, массив пуст!");
            else
            {
                int newRowNum = Input.Integer(
                    msg: "Введите номер новой строки: ",
                    errMsg: $"Номер строки должен быть от 1 до {array.GetLength(0) + 1}!",
                    minValue: 1, maxValue: array.GetLength(0) + 1);

                int[,] buffer = new int[array.GetLength(0) + 1, array.GetLength(1)];

                for (int r = 0; r < newRowNum - 1; r++)
                    for (int c = 0; c < array.GetLength(1); c++)
                        buffer[r, c] = array[r, c];
                bool inputManually = ChooseOneOfTwo(
                    msg: "Ввести новые элементы вручную? Y/N: ",
                    validValues: new string[] { "Y", "N" });

                for (int c = 0; c < array.GetLength(1); c++)
                    if (inputManually)
                        buffer[newRowNum - 1, c] = Input.Integer(
                                                   msg: $"Элемент ({newRowNum}, {c + 1}): ",
                                                   errMsg: "Элемент должен быть в диапазоне от -500 до 500",
                                                   minValue: -500, maxValue: 500);
                    else
                        buffer[newRowNum - 1, c] = rnd.Next(-500, 501);

                for (int r = newRowNum; r < buffer.GetLength(0); r++)
                    for (int c = 0; c < buffer.GetLength(1); c++)
                        buffer[r, c] = array[r - 1, c];

                array = buffer;
            }
        }


        /* РАБОТА С РВАНЫМ МАССИВОМ */
        static void PrintNotEmptyArray(int[][] array)
        {
            if (array.Length != 0)
            {
                Console.WriteLine($"Рваный массив, строк: {array.Length}");
                PrintArray(array);
            }
            else Console.WriteLine("Рваный массив пуст");
            Console.WriteLine('\n');
        }

        static void PrintArray(int[][] array)
        {
            for (int r = 0; r < array.Length; r++)
            {
                Console.Write($"{r + 1,2} | ");
                foreach (int elem in array[r]) Console.Write($"{elem,4} ");
                Console.WriteLine();
            }
        }

        static void CopyArray(int[][] oldArray, int[][] newArray)
        {
            for (int r = 0; r < oldArray.Length && r < newArray.Length; r++)
            {
                for (int c = 0; c < oldArray[r].Length && c < newArray[r].Length; c++)
                    newArray[r][c] = oldArray[r][c];
            }
        }

        static void MakeArray(ref int[][] array)
        {
            bool saveOldArray = false;
            int[][] buffer = new int[0][];

            if (array.Length != 0)
            {
                saveOldArray = ChooseOneOfTwo(
                    msg: "Сохранить старый массив? Y/N: ",
                    validValues: new string[] { "Y", "N" });
            }

            int rows = Input.Integer(
                msg: "Введите количество строк нового массива: ",
                errMsg: "Значение должно быть в диапазоне от 1 до 100",
                minValue: 1, maxValue: 100);

            if (saveOldArray)
            {
                buffer = new int[array.Length][];
                for (int i = 0; i < buffer.Length; i++) buffer[i] = new int[array[i].Length];
                CopyArray(array, buffer);
            }
            array = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                int cols = Input.Integer(
                    msg: $"Введите количество элементов в строке {i + 1}: ",
                    errMsg: "Значение должно быть в диапазоне от 1 до 100]",
                    minValue: 1, maxValue: 100);
                array[i] = new int[cols];
            }

            if (saveOldArray) CopyArray(buffer, array);

            bool inputManually = ChooseOneOfTwo(
                msg: "Ввести новые элементы вручную? Y/N: ",
                validValues: new string[] { "Y", "N" });

            for (int i = 0; i < array.Length; i++)
            {
                if (inputManually) Console.WriteLine($"Строка {i + 1} из {array.Length}");
                try
                {
                    if (inputManually) FillArrayManually(array[i], buffer[i].Length);
                    else FillArrayRandomly(array[i], buffer[i].Length);
                }
                catch (IndexOutOfRangeException)
                {
                    if (inputManually) FillArrayManually(array[i]);
                    else FillArrayRandomly(array[i]);
                }
            }
        }

        static void DeleteSomeRows(ref int[][] array)
        {
            if (array.Length == 0) Console.WriteLine("Ошибка, массив пуст!");
            else
            {
                int startRow = Input.Integer(
                    msg: "Введите строку К1: ",
                    errMsg: $"Значение должно быть в пределах от 1 до {array.Length}!",
                    minValue: 1, maxValue: array.Length);

                int stopRow = Input.Integer(
                    msg: "Введите строку K2: ",
                    errMsg: $"Значение должно быть в пределах от {startRow + 1} до {array.Length}!",
                    minValue: startRow + 1, maxValue: array.Length);

                int[][] buffer = new int[array.Length - (stopRow - startRow + 1)][];

                for (int i = 0; i < startRow - 1; i++)
                {
                    buffer[i] = new int[array[i].Length];
                    CopyArray(array[i], buffer[i]);
                }

                for (int i = stopRow; i < array.Length; i++)
                {
                    buffer[i - stopRow + startRow - 1] = new int[array[i].Length];
                    CopyArray(array[i], buffer[i - stopRow + startRow - 1]);
                }

                array = buffer;
            }
        }


        /* ФУНКЦИИ ВВОДА */
        static bool ChooseOneOfTwo(string msg, params string[] validValues)
        {
            bool result = true;
            bool ok = false;

            do
            {
                Console.Write(msg);
                string buf = Console.ReadLine();

                foreach (string value in validValues)
                    ok = value.ToLower() == buf.ToLower() || ok;

                if (!ok)
                    Console.WriteLine($"Ошибка! Допустимые значения: {validValues[0]}, {validValues[1]}");
                else
                    result = buf.ToLower() == validValues[0].ToLower();
            } while (!ok);

            return result;
        }
    }
}
