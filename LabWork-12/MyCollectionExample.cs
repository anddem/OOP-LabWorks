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
                    CreateElementsAndAddToStack(stack);
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
            else if (stack.Contains(CreateElement())) Output.Success("Этот элемент есть в стеке\n");
            else Output.Error("Элемента в стеке нет\n");
        }

        static void RemoveElementFromKeyboard(MyCollection<Place> stack)
        {
            if (stack.Count == 0) Output.Error("Стек пуст\n");
            else
            {
                Place element = CreateElement();
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

        static void PrintStack(MyCollection<Place> stack)
        {
            if (stack.Count == 0) Output.Error("Стек пуст\n");
            else
                foreach (Place place in stack)
                {
                    Output.Text($"Тип: {place.GetType()}\n" +
                        $"{place}\n" +
                        $"---\n");
                }

        }

        #region Создание элементов
        static void CreateElementsAndAddToStack(MyCollection<Place> stack)
        {
            Place[] elements = CreateElementsArray();

            stack.Add(elements);
        }

        static Place[] CreateElementsArray()
        {
            int count = Input.Integer("Введите количество добавляемых элементов: ", "Количество должно быть больше нуля", 1, Int32.MaxValue);
            Place[] elements = new Place[count];
            int elemNum = 0;
            while (elemNum != count)
            {
                elements[elemNum] = CreateElement();
                if (elements[elemNum++] is null) elemNum--;
            }

            return elements;
        }

        static Place CreateElement()
        {
            string elementType = Input.String("Введите тип элемента: Place, Region, City или Address: ");
            return MakeElementByType(elementType);
        }

        static Place MakeElementByType(string elementType)
        {
            switch(elementType)
            {
                case "Place": return MakePlace();
                case "Region": return MakeRegion();
                case "City": return MakeCity();
                case "Address": return MakeAddress();

                default:
                    Output.Error("Неизвестный тип элемента!\n");
                    return null;
            }
        }

        static Place MakePlace()
        {
            string placeName = Input.String("Введите название места: ");
            return new Place(placeName);
        }
        
        static Region MakeRegion()
        {
            string regionName = Input.String("Введите название региона: ");
            int population = Input.Integer("Введите население региона: ", "Население не может быть отрицательным", 0, Int32.MaxValue);

            return new Region(regionName, population);
        }

        static City MakeCity()
        {
            string cityName = Input.String("Введите название города: ");
            int population = Input.Integer("Введите население города: ", "Население не может быть отрицательным", 0, Int32.MaxValue);
            int houses = Input.Integer("Введите количество домов в городе: ", "Количество домов не может быть отрицательным", 0, Int32.MaxValue);

            return new City(cityName, population, houses, MakeAddress());
        }

        static Address MakeAddress()
        {
            string placeName = Input.String("Введите название места: ");
            string street = Input.String("Введите улицу: ");
            int houseNum = Input.Integer("Введите номер дома: ", "Номер должен быть больше 0", 1, Int32.MaxValue);

            return new Address(placeName, street, houseNum);
        }
        #endregion
    }
}
