using System;


namespace LabWork_3
{
    class Program
    {
        static void Main(string[] args)
        {
            double eps = 1e-4; //Заданная точность
            double a = 0.1, b = 1; //Границы вычислений, [a, b]
            double k = 10; //Количество вычисляемых точек
            double step = (b - a) / k; //Шаг между точками
            int N = 25; //Количество членов для суммы ряда

            for (double x = a; x <= b; x += step)
            {
                double y = Function(x); //Значение функции в точке x

                double sumN = FindSumN(N, x); //Сумма N членов ряда
                double sumE = FindSumE(eps, x); //Сумма сленов ряда больших eps

                Console.WriteLine($"    X = {Math.Round(x, 3),4}  Y = {y,5}  sumN = {Math.Round(sumN, 3),5}  sumE = {Math.Round(sumE, 3),5}");
            }
        }

        static double Function(double x) //Функция в условии
        {
            double result = Math.Pow(Math.E, (x * Math.Cos(Math.PI / 4))) * Math.Cos(x * Math.Sin(Math.PI / 4)); //Вычисление значения

            return Math.Round(result, 3); //Вернёт вычисленное значение с округлением до трёх знаков после запятой
        }

        static double FindSumN(int N, double x)
        {
            double prev = 1, sumN = 1;

            for (int i = 1; i <= N; i++)
            {
                double cos = Math.Cos(i * Math.PI / 4);
                double curr = prev * (x / i); //Вычисление текущего значения исходя из предыдущего
                sumN += curr * cos; //Суммирование текущего к предыдущим
                prev = curr; //Текущее значение становится предыдущим для следующих вычислений
            }

            return sumN;
        }

        static double FindSumE(double eps, double x)
        {
            double prev = 1, sumE = 1, curr = 1;

            for (int i = 1; Math.Abs(curr) >= eps; i++)
            {
                double cos = Math.Cos(i * Math.PI / 4);
                curr = prev * (x / i); //Вычисление текущего значения исходя из предыдущего
                sumE += curr * cos; //Суммирование текущего к предыдущим
                prev = curr; //Текущее значение становится предыдущим для следующих вычислений
            }

            return sumE;
        }
    }
}
