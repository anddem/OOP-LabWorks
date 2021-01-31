using System;

namespace LabWork_1
{
    class ExampleThree
    {
        public static void Run()
        {
            double A = 100, B = 0.001;

            Console.WriteLine("(a-b)^3 - (a^3 - 3 * a^2 * b)");
            Console.WriteLine("----------------------------");
            Console.WriteLine("    3 * a * b^2 - b^3\n");

            //Вычисления с точностью double
            double dT1 = Math.Pow(A - B, 3);
            double dT2 = Math.Pow(A, 3) - 3 * Math.Pow(A, 2) * B;
            double dT3 = 3 * A * Math.Pow(B, 2) - Math.Pow(B, 3);

            Console.WriteLine($"DOUBLE = {(dT1 - dT2) / dT3}");

            //Вычисления с точностью float
            float fT1 = (float)Math.Pow(A - B, 3);
            float fT2 = (float)(Math.Pow(A, 3) - 3 * (float)Math.Pow(A, 2) * B);
            float fT3 = (float)(3 * A * Math.Pow(B, 2) - Math.Pow(B, 3));

            Console.WriteLine($"FLOAT = {(fT1 - fT2) / fT3}");
        }

    }
}
