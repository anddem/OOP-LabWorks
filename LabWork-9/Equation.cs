using System;
using MyLibrary;

/*
 Вычисление корней квадратного уравнения. Результат должен быть типа double.

 Унарные операции:
 ++ увеличивает коэффициенты уравнения на 1;
 --  уменьшает коэффициенты уравнения на 1.

 Операции приведения типа:
 double (неявная) – результатом является один из корней уравнения, если корни существуют и 0 в противном случае.
 bool (явная) – результатом является true, если корни существуют и false в противном случае;

 Бинарные операции
 == Uravnenie t1, Uravnenie t2 - уравнения равны, если равны их коэффициенты;
 != Uravnenie t1, Uravnenie t2 - треугольники не равны, если не равны их коэффициенты.
*/

namespace LabWork_9
{
    public class Equation
    {
        private double a, b, c; //коэффициенты уравнения

        static public int Count //Статическое автосвойство, подсчёт созданных объектов класса
        {
            get;
            private set;
        } = 0;

        /* Свойства для получения коэффициентов */
        public double A
        {
            get { return a; }
            set
            {
                if (value != 0) a = value;
                else
                {
                    Console.WriteLine("Коэффициент А не может быть равен нулю, будет установлено значение 1");
                    a = 1;
                }
                InitRoots(); //Вычисление корней происходит при установке коэффициентов
            }
        }

        public double B
        {
            get { return b; }
            set { b = value; InitRoots(); }
        }

        public double C
        {
            get { return c; }
            set { c = value; InitRoots(); }
        }

        public bool HaveRoots { get; private set; } //Есть ли корни у уравнения

        /* Автосвойства -- корни уравнения */
        public double FirstRoot { get; private set; }

        public double SecondRoot { get; private set; }

        private void InitRoots() //Метод, вычисляющий корни уравнения
        {
            double d = (B * B) - (4 * A * C); //Дискриминант

            if (d < 0) //Если дискриминант отрицательный
            {
                HaveRoots = false; //Корней нет
                FirstRoot = SecondRoot = 0;
            }
            else //Иначе
            {
                HaveRoots = true; //Корни есть
                if (d == 0)
                    FirstRoot = SecondRoot = -(B / (2 * A));
                else
                {
                    FirstRoot = (-B + Math.Sqrt(d)) / (2 * A);
                    SecondRoot = (-B - Math.Sqrt(d)) / (2 * A);
                }
            }
        }

        #region Конструкторы и деструктор
        public Equation() //Конструктор по умолчанию
        {
            //Коэффициенты 1 0 0
            A = 1;
            B = C = 0;
            FirstRoot = SecondRoot = 0; //Корни 0 0
            HaveRoots = true; //Корни есть

            Count++; //Увеличение количества созданных объектов на 1
        }

        public Equation(double a, double b, double c) //Конструктор с параметрами
        {
            while (a == 0) a = Input.Integer("Коэффициент А не может быть равен нулю! > ");

            (A, B, C) = (a, b, c);

            InitRoots();

            Count++;
        }

        ~Equation()
        {
            Count--;
        }
        #endregion

        #region Методы получения корней 
        public bool Roots(out double fRoot, out double sRoot)
        {
            (fRoot, sRoot) = (FirstRoot, SecondRoot);

            return HaveRoots;
        }

        public static bool Roots(Equation eq, out double fRoot, out double sRoot)
        {
            (fRoot, sRoot) = (eq.FirstRoot, eq.SecondRoot);

            return eq.HaveRoots;
        }
        #endregion

        #region Перегрузка унарных операций
        public static Equation operator ++(Equation eq)
        {
            if (eq.A + 1 == 0)
            {
                Console.WriteLine("Нельзя применить инкремент, коэффициент А не должен быть равен нулю");
                return eq;
            }
            else
            {
                Equation eq2 = new Equation(eq.A + 1, eq.B + 1, eq.C + 1);
                return eq2;
            }
        }

        public static Equation operator --(Equation eq)
        {
            if (eq.A - 1 == 0)
            {
                Console.WriteLine("Нельзя применить декремент, коэффициент А не должен быть равен нулю");
                return eq;
            }
            else
            {
                Equation eq2 = new Equation(eq.A - 1, eq.B - 1, eq.C - 1);
                return eq2;
            }
        }
        #endregion

        #region Перегрузка бинарных операций
        public static bool operator ==(Equation eq1, Equation eq2)
        {
            return (eq1.A == eq2.A && eq1.B == eq2.B && eq1.C == eq2.C);
        }

        public static bool operator !=(Equation eq1, Equation eq2)
        {
            return !(eq1 == eq2);
        }

        public static bool operator >(Equation eq1, Equation eq2)
        {
            return (
                Math.Abs(eq1.FirstRoot) > Math.Abs(eq2.FirstRoot) ||
                Math.Abs(eq1.FirstRoot) > Math.Abs(eq2.SecondRoot) ||
                Math.Abs(eq1.SecondRoot) > Math.Abs(eq2.FirstRoot) ||
                Math.Abs(eq1.SecondRoot) > Math.Abs(eq2.SecondRoot)
                );
        }

        public static bool operator <(Equation eq1, Equation eq2)
        {
            return (
                Math.Abs(eq1.FirstRoot) < Math.Abs(eq2.FirstRoot) ||
                Math.Abs(eq1.FirstRoot) < Math.Abs(eq2.SecondRoot) ||
                Math.Abs(eq1.SecondRoot) < Math.Abs(eq2.FirstRoot) ||
                Math.Abs(eq1.SecondRoot) < Math.Abs(eq2.SecondRoot)
                );
        }
        #endregion

        #region Перегрузка методов сравнения для тестирования 
        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType()) return false;

            Equation eq = (Equation)obj;

            return eq == this;
        }

        public override int GetHashCode()
        {
            string eq = $"{A}{B}{C}{FirstRoot}{SecondRoot}";

            return eq.GetHashCode();
        }
        #endregion

        #region Перегрузка операций приведения типа
        public static implicit operator double(Equation eq)
        {
            return eq.FirstRoot;
        }

        public static explicit operator bool(Equation eq)
        {
            return eq.HaveRoots;
        }
        #endregion

        public override string ToString()
        {
            return $"a ={Math.Round(A, 2),5}\n" +
                $"b ={Math.Round(B, 2),5}\n" +
                $"c ={Math.Round(C, 2),5}\n" +
                $"Roots: {HaveRoots}";
        }
    }
}