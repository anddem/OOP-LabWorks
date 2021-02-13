using System;
using MyLibrary;

namespace LabWork_9
{
    class Program
    {
        static void Main(string[] args)
        {

            CreatingObjectsExample();

            EquationArrayExample();
        }

        static void CreatingObjectsExample()
        {
            Console.WriteLine("CreatingObjectsExample демонстрирует разичные спсобы создания объекта класса");

            Equation eq1 = new Equation();
            Equation eq2 = new Equation(5, -7.5, -12.5);

            double a = Input.Double("Введите коэффициент А: ");
            double b = Input.Double("Введите коэффициент B: ");
            double c = Input.Double("Введите коэффициент C: ");

            Equation eq3 = new Equation(a, b, c);

            Console.WriteLine($"Всего создано уравнений: {Equation.Count}\n");

            PrintEquations(new Equation[] { eq1, eq2, eq3 });

            Console.WriteLine("Нажмите любую клавишу чтобы продолжить");
            Console.ReadKey(true);

            MethodsOverrideExample(new Equation[] { eq1, eq2, eq3 });
        }

        static void MethodsOverrideExample(Equation[] eqs)
        {
            Console.WriteLine("MethodsOverrideExample демонстрирует перегрузку методов");

            int a = Input.Integer("К какому уравнению применить инкремент? ", $"Доступно {eqs.Length} уравнения!", 1, eqs.Length);
            Console.WriteLine($"До инкремента:\n" +
                $"{eqs[a - 1]++}\n" +
                $"После:\n" +
                $"{eqs[a - 1]}\n");

            a = Input.Integer("К какому уравнению применить декремент? ", $"Доступно {eqs.Length} уравнения!", 1, eqs.Length);
            Console.WriteLine($"До декремента:\n" +
                $"{eqs[a - 1]--}\n" +
                $"После:\n" +
                $"{eqs[a - 1]}\n");

            a = Input.Integer("Какое уравнение вывести с преобразованием в double? ", $"Доступно {eqs.Length} уравнения!", 1, eqs.Length);
            double root = eqs[a - 1];
            Console.WriteLine(root);

            a = Input.Integer("Какое уравнение вывести с преобразованием в bool? ", $"Доступно {eqs.Length} уравнения!", 1, eqs.Length);
            Console.WriteLine($"eq{a} имеет корни: {(bool)eqs[a - 1]}");

            Console.WriteLine($"Сравнение уравнений:\n" +
                $"1 = 2: {eqs[0] == eqs[1]}\n" +
                $"2 = 3: {eqs[1] == eqs[2]}\n" +
                $"1 = 3: {eqs[0] == eqs[2]}\n");

            Console.WriteLine("Нажмите любую клавишу чтобы продолжить");
            Console.ReadKey(true);
            Console.Clear();
        }

        static void EquationArrayExample()
        {
            Console.WriteLine("EquationArrayExample демонстрирует класс EquationArray (массив уравнений) и его методы");
            Console.WriteLine("Первый объект генерируется автоматически, второй заполняется вручную");

            EquationArray eqa1 = new EquationArray(5, inputManually: false); //Заполнение ДСЧ
            EquationArray eqa2 = new EquationArray(3, inputManually: true); //Заполнение вручную

            Console.WriteLine("eqa1 сгенерирован ДСЧ, вывод с помощью индексации: ");
            for (int i = 0; i < eqa1.Length; i++)
                Console.WriteLine(eqa1[i].ToString());

            Console.WriteLine("\nВывод eqa2");
            eqa2.Show();

            eqa2.Max(out Equation max1);

            //FindMax(eqa1, out Equation max2);

            Console.WriteLine("В eqa2 максимальным по модулю корнем обладает уравнение:");
            Console.WriteLine(max1.ToString());
        }

        static public void FindMax(EquationArray array, out Equation max) //Поиск уравнения с максимальным по модулю корнем
        {
            int mIdx = 0;

            while (mIdx < array.Length && !array[mIdx].HaveRoots) mIdx++; //Поиск

            if (mIdx == array.Length)
            {
                Console.WriteLine("В массиве нет уравнений, имеющих корни, возвращено первое уравнение");
                max = null;
            }
            else
            {
                max = array[mIdx];

                for (int i = mIdx + 1; i < array.Length; i++)
                    if (array[i].HaveRoots && array[i] > max) max = array[i];
            }
        }

        static void PrintEquations(Equation[] eqs)
        {
            for (int i = 0; i < eqs.Length; i++)
                Console.WriteLine($"Уравнение eq{i + 1}:\n" +
                    $"{eqs[i]}, корни: {eqs[i].FirstRoot}, {eqs[i].SecondRoot}");
        }
    }
}