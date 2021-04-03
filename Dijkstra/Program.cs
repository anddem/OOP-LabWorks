using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLibrary;

namespace Dijkstra
{
    class Program
    {
        static string[] menu = new string[]
        {
            "1. Создать граф",
            "2. Добавить в граф точку",
            "3. Добавить в граф путь",
            "4. Алгоритм Дейкстры для вершины"
        };

        static Graph graph = null;
        static void Main(string[] args)
        {
            int action;
            do
            {
                PrintMenu();
                action = Input.Integer("Введите команду: ");

                DoAction(action);

                if (action != 0) Output.PauseAndClear();

            } while (action != 0);
        }

        static void PrintMenu()
        {
            if (graph != null) graph.PrintMatrix();
            Output.Array(menu, "\n");
        }

        static void DoAction(int action)
        {
            switch (action)
            {
                case 1: CreateGraph(); break;
                case 2: AddPointIntoGraph(); break;
                case 3: break;
                case 4: break;

                case 0: break;

                default: Output.ErrorMessage("Неизвестная команда\n"); break;
            }
        }

        static void CreateGraph()
        {
            int len = Input.Integer("Введите число вершин в графе: ", "Число вершин должно быть положительным", 0, Int32.MaxValue);
            graph = new Graph(0);

            for (int i = 0; i < len; i++) AddPointIntoGraph();
        }

        static void AddPointIntoGraph()
        {
            string name = Input.String("Введите название точки: ");
            Point point = new Point(name);

            graph.AddPoint(point);
        }
    }
}
