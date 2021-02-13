using System;
using MyLibrary;

// Уравнение с самым большим по абсолютному значению корнем.

namespace LabWork_9
{
    public class EquationArray
    {
        private static readonly Random rnd = new Random(); //ДСЧ

        private readonly Equation[] array; //Массив уравнений

        public int Length { get { return array.Length; } } //Длина массива

        public Equation this[int index] //Индексатор
        {
            get
            {
                if (index >= 0 && index < array.Length) return array[index];
                else throw new IndexOutOfRangeException("Выход за границы массива"); //Если индекс вне границ массива - бросается исключение
            }
            set
            {
                if (index >= 0 && index < array.Length) array[index] = value;
                else throw new IndexOutOfRangeException("Выход за границы массива");
            }
        }

        public void Max(out Equation max) //Поиск уравнения с максимальным по модулю корнем
        {
            int mIdx = 0;

            while (mIdx < array.Length && !array[mIdx].HaveRoots) mIdx++; //Поиск первого уравнения, имеющего корни

            if (mIdx == array.Length) //Если уравнений с корнями нет
            {
                Console.WriteLine("В массиве нет уравнений, имеющих корни"); //Сообщение 
                max = null; //Ссылка на null
            }
            else //Иначе
            {
                max = array[mIdx]; //Сохраняем максимальный

                for (int i = mIdx + 1; i < array.Length; i++) //Сравнение с другими уравнениями
                    if (array[i].HaveRoots && array[i] > max) max = array[i];
            }
        }

        public EquationArray()
        {
            array = new Equation[0];
        }

        public EquationArray(int len, bool inputManually)
        {
            if (len < 0)
            {
                Console.WriteLine("Длина массива не может быть отрицательной!");
                len = Input.Integer("Введите длину массива: ", "Длина массива не может быть отрицательной!", 1, Int32.MaxValue);
            }

            array = new Equation[len];

            for (int i = 0; i < len; i++)
            {
                double a = 0, b, c;
                if (inputManually)
                {
                    a = Input.Double("Введите коэффициент А != 0: ", new double[] { 0 });
                    b = Input.Double("Введите коэффициент B: ");
                    c = Input.Double("Введите коэффициент C: ");
                }
                else
                {
                    while (a == 0) a = (rnd.NextDouble() * rnd.Next(-500, 500));
                    b = (rnd.NextDouble() * rnd.Next(-500, 500));
                    c = (rnd.NextDouble() * rnd.Next(-500, 500));
                }

                array[i] = new Equation(a, b, c);
            }
        }

        public void Show()
        {
            for (int i = 0; i < array.Length; i++)
                Console.WriteLine(array[i].ToString());
        }
    }
}
