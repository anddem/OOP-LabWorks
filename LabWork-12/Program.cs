using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLibrary;

namespace LabWork_12
{
    class Program
    {
        static void Main(string[] args)
        {
            int action;

            do
            {
                Output.Text("1. Односвязный список\n" +
                    "2. Двусвязный список\n" +
                    "3. Бинарное дерево\n" +
                    "4. Коллекция\n" +
                    "\n" +
                    "0. Выход\n");

                action = Input.Integer(">> ");

                DoAction(action);

                if (action != 0) Output.PauseAndClear();
            } while (action != 0);
        }

        static void DoAction(int action)
        {
            switch (action)
            {
                case 1:
                    Output.Clear();
                    ListExample.Run();
                    break;
                case 2:
                    Output.Clear();
                    DequeExample.Run();
                    break;
                case 3:
                    Output.Clear();
                    TreeExample.Run();
                    break;
                case 4:
                    Output.Clear();
                    MyCollectionExample.Run();
                    break;
                case 1337:
                    Experiment();
                    break;

                case 0: break;

                default:
                    Output.Error("Неизвестная команда\n");
                    break;
            }
        }

        static void Experiment()
        {
            TreePoint[] points = new TreePoint[] {
                new TreePoint("1", 1),
                new TreePoint("1", 2),
                new TreePoint("1", 0),
                new TreePoint("2", 1)
            };

            for (int i = 0; i < 4; i++)
            {
                for (int j = 0; j < 4; j++)
                {
                    char res;
                    if (points[i] > points[j]) res = '>';
                    else if (points[i] < points[j]) res = '<';
                    else res = '=';
                    Console.Write($"{res} ");
                }
                Console.WriteLine();
            }
        }
    }
}
