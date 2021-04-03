using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLibrary;
using LabWork_10;

namespace LabWork_12
{
    class ListExample
    {

        public static void Run()
        {
            ListPoint list = null;
            int action;

            do
            {
                PrintInterface(list);
                action = Input.Integer(">> ");
                DoAction(action, ref list);

                if (action != 0) Output.PauseAndClear();

            } while (action != 0);
        }

        static void PrintInterface(ListPoint list)
        {
            if (list == null) Output.Error("Список не создан\n");
            else Output.Text($"Длина списка: {ListSize(list)}\n");

            Output.Text("\n" +
                "1. Создать список\n" +
                "2. Добавить в список элемент с заданным номером\n" +
                "3. Напечатать список\n" +
                "4. Удалить элемент с заданным номером\n" +
                "\n" +
                "0. Выход\n");
        }

        static void DoAction(int action, ref ListPoint list)
        {
            switch (action)
            {
                case 1: MakeList(ref list); break;
                case 2: AddElementByNumber(ref list); break;
                case 3: PrintList(list); break;
                case 4: RemoveElementByNumber(ref list); break;

                case 0: break;

                default: Output.Error("Неизвестная команда\n"); break;
            }
        }

        static void MakeList(ref ListPoint list)
        {
            int length = Input.Integer("Введите длину списка: ", "Длина должна быть натуральным числом!", 0, Int32.MaxValue);

            if (length == 0) list = null;
            else
            {
                for (int i = 1; i <= length; i++)
                {
                    if (i == 1) list = MakePoint();
                    else list.Last.Next = MakePoint();
                }
            }
        }

        static void PrintList(ListPoint begin)
        {
            if (begin == null) Output.Error("Список не создан!\n");
            else
            {
                ListPoint p = begin;
                while (p != null)
                {
                    Console.WriteLine(p.Value);
                    p = p.Next;
                }
            }
        }

        static int ListSize(ListPoint list)
        {
            int size = 0;

            ListPoint p = list;
            while (p != null)
            {
                size++;
                p = p.Next;
            }
            return size;
        }

        static ListPoint MakePoint()
        {
            string pointName = Input.String("Введите название нового элемента: ");

            return new ListPoint(pointName);
        }

        static void AddElementByNumber(ref ListPoint list)
        {
            int num = Input.Integer("Введите номер добавляемого элемента: ", $"Номер должен быть от 1 до {ListSize(list)+1}", 1, ListSize(list)+1);

            if (list == null) list = MakePoint();
            else if (num == 1)
            {
                ListPoint p = MakePoint();
                p.Next = list;
                list = p;
            }
            else
            {
                ListPoint p = list;
                for (int i = 1; i < num-1; i++) p = p.Next;
                ListPoint temp = MakePoint();
                temp.Next = p.Next;
                p.Next = temp;
            }
        }

        static void RemoveElementByNumber(ref ListPoint list)
        {
            if (list == null) Output.Error("Список не создан\n");
            else
            {
                ListPoint removed;
                int num = Input.Integer("Введите номер удаляемого элемента: ", $"Номер должен быть от 1 до {ListSize(list)}", 1, ListSize(list));
                if (num == 1)
                {
                    removed = list;
                    list = list.Next;
                }
                else
                {
                    ListPoint p = list;
                    for (int i = 1; i < num - 1; i++) p = p.Next;

                    removed = p.Next;
                    p.Next = p.Next.Next;
                }
                Output.Success($"Удалённый элемент:\n" +
                            $"{removed}\n");
            }
        }
    }
}
