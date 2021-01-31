using System;
using MyLibrary;

namespace LabWork_1
{
    class ExampleTwo
    {
        public static void Run()
        {
            double x = Input.Double("Введите координату X: ");
            double y = Input.Double("Введите координату Y: ");

            bool inArea = (x >= 0 && (x * x + y * y <= 1));

            Console.WriteLine($"Попадание точки с координатами ({x}, {y}) в зону: {inArea}");
        }

    }
}
