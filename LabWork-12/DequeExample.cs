using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLibrary;
using LabWork_10;

namespace LabWork_12
{
    class DequeExample
    {
        public static void Run()
        {
            DequeElement list = null;
            int action;

            do
            {
                PrintMenu(list);
                action = Input.Integer(">> ");
                DoAction(action, ref list);

                if (action != 0) Output.PauseAndClear();
            } while (action != 0);
        }

        static void PrintMenu(DequeElement list)
        {
            if (list == null) Output.Error("Список пуст\n");
            else Output.Text($"Длина списка: {list.Length}\n");

            Output.Text("\n" +
                "1. Создать список\n" +
                "2. Напечатать список\n" +
                "3. Создать элемент и добавить его в начало\n" +
                "4. Создать элемент и добавить его в конец\n" +
                "5. Удалить первый элемент\n" +
                "6. Удалить последний элемент\n" +
                "7. Удалить элементы с чётными номерами\n" +
                "\n" +
                "0. Выход\n" +
                "\n");
        }

        static void DoAction(int action, ref DequeElement list)
        {
            switch (action)
            {
                case 1:
                    MakeList(ref list);
                    break;
                case 2:
                    PrintList(list);
                    break;
                case 3:
                    CreateElementAndAddToStart(ref list);
                    break;
                case 4:
                    CreateElementAndAddToEnd(ref list);
                    break;
                case 5:
                    RemoveFirstElement(ref list);
                    break;
                case 6:
                    RemoveLastElement(ref list);
                    break;
                case 7:
                    RemoveElementsWithEvenNumbers(list);
                    break;

                case 0: break;

                default:
                    Output.Error("Неизвестная команда\n");
                    break;
            }
        }

        static void MakeList(ref DequeElement list) //Создание списка
        {
            int length = Input.Integer("Введите длину списка: ", "Длина списка не может быть отрицательной!", 0, Int32.MaxValue);

            if (length == 0)
            {
                list = null;
                return;
            }

            for (int i = 1; i <= length; i++)
            {
                DequeElement newElement = MakeNewElement($"Введите название {i}-го элемента: ");
                if (i == 1) list = newElement;
                else
                {
                    bool addToStart = Input.Bool($"Добавить элемент {i} в начало (f) или в конец (l)? ", new string[] { "f", "a" });

                    AddElement(ref list, newElement, addToStart);
                }
            }
        }

        static void PrintList(DequeElement list) //Печать списка
        {
            if (list == null) Output.Error("Список не создан\n");
            else
            {
                DequeElement iter = list.First;
                while (iter != null)
                {
                    Output.Text($"{iter.Value}\n");
                    iter = iter.Next;
                }
            }
        }

        static DequeElement MakeNewElement(string inviteMsg = "Введите название нового элемента: ") //Создание элемента
        {
            string newElementName = Input.String(inviteMsg);

            return new DequeElement(new Place(newElementName));
        }

        #region Добавление элементов
        static void AddElement(ref DequeElement list, DequeElement newElement, bool addToStart) //Добавление элемента
        {
            if (addToStart) AddElementToStart(ref list, newElement);
            else AddElementToEnd(ref list, newElement);
        }

        static void AddElementToStart(ref DequeElement list, DequeElement newElement) //Добавление элемента в начало списка
        {
            if (list == null) list = newElement;
            else
            {
                newElement.Next = list;
                list.Prev = newElement;
                list = newElement;
            }
        }

        static void AddElementToEnd(ref DequeElement list, DequeElement newElement) //Добавление элемента в конец списка
        {
            if (list == null) list = newElement;
            else
            {
                DequeElement iter = list.Last;
                newElement.Prev = iter;
                iter.Next = newElement;
            }
        }

        static void CreateElementAndAddToStart(ref DequeElement list) => AddElementToStart(ref list, MakeNewElement());

        static void CreateElementAndAddToEnd(ref DequeElement list) => AddElementToEnd(ref list, MakeNewElement());
        #endregion

        #region Удаление элементов
        static void RemoveElementsWithEvenNumbers(DequeElement list)
        {
            if (list == null) Output.Error("Список не существует\n");
            else
            {
                int len = list.Length;
                if (len == 1) Output.Text("В списке один элемент, он не будет удалён т.к. его номер нечётный\n");
                else
                {
                    DequeElement iter = list.Last;

                    if (len % 2 == 0)
                    {
                        iter = iter.Prev;
                        iter.Next = null;
                        len--;
                    }

                    for (int i = len; i != 1; i -= 2)
                    {
                        RemoveElement(iter.Prev);

                        iter = iter.Prev;
                    }
                }
            }
        }

        static void RemoveElement(DequeElement element) //Удаление элемента
        {
            if (element.Next != null) element.Next.Prev = element.Prev;
            if (element.Prev != null) element.Prev.Next = element.Next;
        }

        static void RemoveFirstElement(ref DequeElement list) //Удаление первого элемента
        {
            if (list == null) Output.Error("Список не создан\n");
            else
            {
                if (list.Next != null) list.Next.Prev = null;
                list = list.Next;
            }
        }

        static void RemoveLastElement(ref DequeElement list)
        {
            if (list == null) Output.Error("Список не создан\n");
            else if (list.Last.Prev == null) RemoveFirstElement(ref list);
            else RemoveElement(list.Last);
        }
        #endregion
    }
}
