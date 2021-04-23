using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLibrary;
using LabWork_10;

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
            Place place = new Place();
            Region region = new Region();
            City city = new City();
            Address address = new Address();

            if (place is null) Output.Success("place");
            if (region is null) Output.Success("region");
            if (city is null) Output.Success("city");
            if (address is null) Output.Success("address");
        }
    }
}
