using System;
using MyLibrary;

namespace LabWork_1
{
    class ExampleOne
    {
        public static void Run()
        {
            int m = Input.Integer("Введите M: ");
            int n = Input.Integer("Введите N: ");

            Console.WriteLine($"--m-n++ = {--m - n++}");
            Console.WriteLine($"M, N = {m}, {n}\n");

            Console.WriteLine($"m*m < n++: {m * m < n++}");
            Console.WriteLine($"M, N = {m}, {n}\n");

            Console.WriteLine($"n-- > ++m: {n-- > ++m}");
            Console.WriteLine($"M, N = {m}, {n}\n");

            double x = Input.Double("Введите X: ");
            Console.WriteLine($"tg(x) - (5-x)^4 = {Math.Tan(x)} - {Math.Pow(5 - x, 4)} = {Math.Tan(x) - Math.Pow(5 - x, 4)}");
        }
    }
}
