using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLibrary;

namespace Dijkstra
{
    class Graph
    {
        public List<Point> Points { get; set; } = new List<Point>();

        public int[,] Matrix { get; set; }

        public Graph(int pointsCount)
        {
            Matrix = new int[pointsCount, pointsCount]; //Выделение памяти под матрицу смежности
        }

        public void AddPath(Point start, Point stop)
        {
            if (Points.Contains(start)) throw new Exception($"Вершины {start.Name} нет в графе");
            if (Points.Contains(stop)) throw new Exception($"Вершины {stop.Name} нет в графе");
            bool newWay;
            if (!start.Relations.Contains(stop))
            {
                start.AddRelation(stop);
                newWay = true;
            }
            else newWay = Input.Bool("Данные точки уже соединены, изменить вес ребра? y/n: ", new string[] { "y", "yes", "да", "д" });
            if (newWay)
            { 
                int pathLen = Input.Integer("Введите длину пути: ", "Длина пути должна быть натуральным числом", 0, Int32.MaxValue);
                int row = Points.IndexOf(start);
                int col = Points.IndexOf(stop);

                Matrix[row, col] = pathLen;
            }
        }

        public void AddPoint(Point point)
        {
            if (Points.Contains(point)) throw new Exception("Данная вершина уже есть в графе");
            else
            {
                int[,] newMatrix = new int[Matrix.GetLength(0) + 1, Matrix.GetLength(1) + 1];

                for (int i = 0; i < Matrix.GetLength(0); i++)
                    for (int j = 0; j < Matrix.GetLength(1); j++)
                        newMatrix[i, j] = Matrix[i, j];

                Matrix = newMatrix;
            }
        }

        public void PrintMatrix()
        {
            if (Points.Count == Matrix.GetLength(1))
            {
                Output.Message("    ");
                for (int i = 1; i <= Matrix.GetLength(0); i++) Output.Message($"{i,3}");
                Output.Message("\n");
                for (int i = 0; i < Matrix.GetLength(0); i++)
                {
                    Output.Message($"{i + 1,3}|");
                    for (int j = 0; j < Matrix.GetLength(1); j++)
                        Output.Message($"{Matrix[i, j],3}");
                    Output.Message($"  - {Points.ElementAt(i).Name}\n");
                }
            }
        }

        public Point GetPointAt(int idx)
        {
            return Points.ElementAt(idx);
        }
    }
}
