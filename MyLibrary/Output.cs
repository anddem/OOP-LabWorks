using System;

namespace MyLibrary
{
    public static class Output
    {
        public static void Clear() => Console.Clear();

        /// <summary>
        /// Делает паузу при выводе, после нажатия кнопки очищает консоль
        /// </summary>
        /// <param name="msg">Предложение ввода</param>
        public static void PauseAndClear(string msg = "Нажмите любую клавишу для продолжения...")
        {
            Text(msg);
            Console.ReadKey(true);
            Clear();
        }

        /// <summary>
        /// Печатает массив элементов типа int
        /// </summary>
        /// <param name="array"> Выводимый массив. </param>
        /// <param name="sep"> Разделитель между элементами массива. </param>
        /// <param name="end"> Символ, который выводится в конце. </param>
        public static void Array(int[] array, string sep = " ", string end = "\n") => Array<int>(array, sep, end);

        /// <summary>
        /// Печатает массив элементов типа char
        /// </summary>
        /// <param name="array"> Выводимый массив. </param>
        /// <param name="sep"> Разделитель между элементами массива. </param>
        /// <param name="end"> Символ, который выводится в конце. </param>
        public static void Array(char[] array, string sep = " ", string end = "\n") => Array<char>(array, sep, end);

        /// <summary>
        /// Печатает массив элементов типа double
        /// </summary>
        /// <param name="array"> Выводимый массив. </param>
        /// <param name="sep"> Разделитель между элементами массива. </param>
        /// <param name="end"> Символ, который выводится в конце. </param>
        public static void Array(double[] array, string sep = " ", string end = "\n") => Array<double>(array, sep, end);

        /// <summary>
        /// Печатает массив элементов типа float
        /// </summary>
        /// <param name="array"> Выводимый массив. </param>
        /// <param name="sep"> Разделитель между элементами массива. </param>
        /// <param name="end"> Символ, который выводится в конце. </param>
        public static void Array(float[] array, string sep = " ", string end = "\n") => Array<float>(array, sep, end);

        ///<summary>
        ///Печатает одномерный массив в консоли
        ///</summary>
        /// <param name="array"> Выводимый массив.</param>
        /// <param name="sep"> Разделитель между элементами массива.</param>
        /// <param name="end"> Символ, который выведется в конце.</param>
        public static void Array<T>(T[] array, string sep = " ", string end = "\n")
        { //Шаблон метода, работает с любыми одномерными массивами
            if (array.Length != 0)
            {
                Console.Write(array[0]); //Вывод первого элемента
                for (int i = 1; i < array.Length; i++)
                    Console.Write($"{sep}{array[i]}"); //Вывод остальных с заданным разделителем
                Console.Write(end); //Вывод завершающего символа, например, перевода строки
            }
        }

        ///<summary>
        /// Печатает двумерный массив в консоли
        ///</summary>
        /// <param name="array"> Выводимый массив.</param>
        /// <param name="sep"> Разделитель между элементами массива.</param>
        /// <param name="rEnd">Разделитель между строками массива.</param>
        /// <param name="end"> Символ, который выведется в конце.</param>
        public static void Array<T>(T[,] array, string sep = " ", string rEnd = "\n", string end = "\n")
        { //Шалон метода
            if (array.Length != 0)
            {
                for (int i = 0; i < array.GetLength(0); i++) //Получение количества строк
                {
                    Console.Write(array[i, 0]); //Вывод первого элемента в строке
                    for (int j = 1; j < array.GetLength(1); j++)
                        Console.Write($"{sep}{array[i, j]}"); //Вывод оставшихся элементов с заданным разделителем
                    Console.Write(rEnd); //Вывод разделителя строк
                }
                Console.Write(end); //Вывод завершающего символа
            }
        }

        public static void Text(string msg, ConsoleColor textColor = ConsoleColor.Cyan)
        {
            ConsoleColor fColor = Console.ForegroundColor;
            Console.ForegroundColor = textColor;
            Console.Write(msg);
            Console.ForegroundColor = fColor;
        }

        public static void Text(object obj, ConsoleColor textColor = ConsoleColor.Cyan) => Text(obj.ToString()+"\n", textColor);

        public static void Success(string msg) => Text(msg, ConsoleColor.Green);

        public static void Success(object obj) => Success(obj.ToString() + "\n");

        public static void Error(string msg) => Text(msg, ConsoleColor.Red);

        public static void Error(object obj) => Error(obj.ToString() + "\n");
    }
}
