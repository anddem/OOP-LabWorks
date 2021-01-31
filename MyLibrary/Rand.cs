using System;

namespace MyLibrary
{
    public static class Rand
    {
        private static readonly Random rand = new Random();

        /// <summary>
        /// Возвращает неотрицаетельное случайное целое число
        /// </summary>
        /// <returns>32-разрядное число со знаком, которое больше или равно 0 и меньше чем Int32.MaxValue</returns>
        public static int Integer() => rand.Next();

        /// <summary>
        /// Возвращает неотрицаетельное случайное целое число
        /// </summary>
        /// <param name="maxValue">Верхний предел генерации</param>
        /// <returns>32-разрядное число со знаком, которое больше или равно 0 и меньше чем maxValue</returns>
        public static int Integer(int maxValue) => rand.Next(maxValue);

        /// <summary>
        /// Возвращает неотрицаетельное случайное целое число
        /// </summary>
        /// <param name="minValue">Нижний предел генерации</param>
        /// <param name="maxValue">Верхний предел генерации</param>
        /// <returns>32-разрядное число со знаком, которое больше или равно minValue и меньше чем maxValue</returns>
        public static int Integer(int minValue, int maxValue) => rand.Next(minValue, maxValue);

        /// <summary>
        /// Возвращает случайный элемент из переданного массива
        /// </summary>
        /// <param name="array">Массив для выбора</param>
        /// <returns>Случайный элемент массива array</returns>
        public static T Choice<T>(T[] array)
        {
            int choice = Integer(array.Length);

            return array[choice];
        }

        /// <summary>
        /// Возвращает случайный элемент из переданного массива
        /// </summary>
        /// <param name="array"> Массив для выбора </param>
        /// <returns> Случайный элемент типа string </returns>
        public static string Choice(string[] array) => Choice<string>(array);

        /// <summary>
        /// Возвращает случайный элемент из переданного массива
        /// </summary>
        /// <param name="array"> Массив для выбора </param>
        /// <returns> Случайный элемент типа int </returns>
        public static int Choice(int[] array) => Choice<int>(array);

        /// <summary>
        /// Возвращает случайный элемент из переданного массива
        /// </summary>
        /// <param name="array"> Массив для выбора </param>
        /// <returns> Случайный элемент типа float </returns>
        public static float Choice(float[] array) => Choice<float>(array);

        /// <summary>
        /// Возвращает случайный элемент из переданного массива
        /// </summary>
        /// <param name="array"> Массив для выбора </param>
        /// <returns> Случайный элемент типа double </returns>
        public static double Choice(double[] array) => Choice<double>(array);

        /// <summary>
        /// Возвращает случайный элемент из переданного массива
        /// </summary>
        /// <param name="array"> Массив для выбора </param>
        /// <returns> Случайный элемент типа char </returns>
        public static char Choice(char[] array) => Choice<char>(array);
    }
}
