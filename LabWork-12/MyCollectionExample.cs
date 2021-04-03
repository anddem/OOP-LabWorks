using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using LabWork_10;
using MyLibrary;

namespace LabWork_12
{
    class MyCollectionExample
    {
        public static void Run()
        {
            MyCollection<Place> stack = new MyCollection<Place>();
            int cmd;

            do
            {
                PrintMenu(stack);

                cmd = Input.Integer("> ");
                DoAction(cmd, stack);
            } while (cmd != 0);
        }

        static void PrintMenu(MyCollection<Place> stack)
        {
            if (stack.Count == 0) Output.Error("Стек пуст\n");
            else Output.Text($"Элементов в стеке: {stack.Count}\n");

            Output.Text("\n" +
                "1. Добавить элементы в стек\n" +
                "2. Напечатать элементы стека\n" +
                "3. Удалить верхний элемент из стека\n" +
                "4. Удалить из стека элемент, введённый с клавиатуры\n" +
                "5. Поиск элемента в стеке\n" +
                "6. Очистка стека\n" +
                "\n" +
                "0. Выход\n\n");
        }

        static void DoAction(int cmd, MyCollection<Place> stack)
        {
            switch (cmd)
            {
                case 1:
                    CreateElementAndAddToStack(stack);
                    break;
                case 2:
                    PrintStack(stack);
                    break;
                case 3:
                    PopElementFromStack(stack);
                    break;
                case 4:
                    RemoveElementFromKeyboard(stack);
                    break;
                case 5:
                    SearchInStack(stack);
                    break;
                case 6:
                    ClearStack(stack);
                    break;
                case 0:
                    break;

                default:
                    Output.Error("Неизвестная команда\n");
                    break;
            }
            if (cmd != 0) Output.PauseAndClear();
        }

        static void SearchInStack(MyCollection<Place> stack)
        {
            if (stack == null) Output.Error("Стек не создан\n");
            else if (stack.Contains(MakePlace())) Output.Success("Этот элемент есть в стеке\n");
            else Output.Error("Элемента в стеке нет");
        }

        static void RemoveElementFromKeyboard(MyCollection<Place> stack)
        {
            if (stack.Count == 0) Output.Error("Стек пуст\n");
            else
            {
                Place element = MakePlace();
                if (stack.Remove(element)) Output.Success("Элемент удалён\n");
                else Output.Error("Элемента нет в стеке\n");
            }
        }

        static void ClearStack(MyCollection<Place> stack) => stack.Clear();

        static void PopElementFromStack(MyCollection<Place> stack)
        {
            if (stack.Count == 0) Output.Error("Стек пуст\n");
            else stack.Remove();
        }

        static void CreateElementAndAddToStack(MyCollection<Place> stack)
        {
            Place element = MakePlace();
            stack.Add(element);
        }

        static void PrintStack(MyCollection<Place> stack)
        {
            if (stack.Count == 0) Output.Error("Стек пуст\n");
            else foreach (Place place in stack) Output.Text(place);

        }

        static Place MakePlace()
        {
            string placeName = Input.String("Введите название места: ");

            return new Place(placeName);
        }
    }
}
