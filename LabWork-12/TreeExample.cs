using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using MyLibrary;

namespace LabWork_12
{
    public class TreeExample
    {
        public static void Run()
        {
            TreePoint tree = null;

            for (int i = 1; i <= 7; i++)
                tree = InsertPoint(tree, MakeTreePoint());

            PrintTree(tree);
        }

        static void PrintTree(TreePoint point, int shift = 0)
        {
            if (point != null)
            {
                PrintTree(point.Left, shift+3);
                Output.Text(GenerateShiftedText(point, shift));
                PrintTree(point.Right, shift+3);
            }
        }

        static string GenerateShiftedText(TreePoint point, int shift)
        {
            string[] tempStr = point.ToString().Split(new char[] { '\n' });

            string result = "";
            for (int i = 0; i < tempStr.Length; i++)
                result += $"{new string(' ', shift)}{tempStr[i]}\n";

            return result;
        }

        static TreePoint MakeTreePoint()
        {
            string name = Input.String("Введите название нового элемента: ");
            int population = Input.Integer("Введите население нового элемента: ");

            return new TreePoint(name, population);
        }

        static int BF(TreePoint point)
        {
            int lHeight = point.Left != null ? point.Left.Height : 0,
                pHeight = point.Right != null ? point.Right.Height : 0;

            return pHeight - lHeight;
        }

        static void OverHeight(TreePoint point) //Пересчёт высот деревьев
        {
            int lHeight = point.Left != null ? point.Left.Height : 0,
                pHeight = point.Right != null ? point.Right.Height : 0;

            point.Height = (lHeight > pHeight ? pHeight : lHeight) + 1;
        }

        static TreePoint RightRotation(TreePoint point) //Малый правый поворот
        {
            TreePoint temp = point.Left;
            point.Left = temp.Right;
            temp.Right = point;

            OverHeight(point);
            OverHeight(temp);

            return temp;
        }

        static TreePoint LeftRotation(TreePoint point) //Малый левый поворот
        {
            TreePoint temp = point.Right;
            point.Right = temp.Left;
            temp.Left = point;

            OverHeight(point);
            OverHeight(temp);

            return temp;
        }

        static TreePoint BalanceTree(TreePoint tree)
        {
            OverHeight(tree);
            if (BF(tree) == 2)
            {
                if (BF(tree.Right) < 0)
                    tree.Right = RightRotation(tree.Right);
                return LeftRotation(tree);
            }
            if (BF(tree) == -2)
            {
                if (BF(tree.Left) > 0)
                    tree.Left = LeftRotation(tree.Left);
                return RightRotation(tree);
            }
            return tree;
        }

        static TreePoint InsertPoint(TreePoint current, TreePoint point)
        {
            if (current == null) return point;
            if (point < current) current.Left = InsertPoint(current.Left, point);
            else current.Right = InsertPoint(current.Right, point);

            return BalanceTree(current);
        }

        static TreePoint DeletePoint(TreePoint current, TreePoint point)
        {
            if (current == null) return null;
            if (point < current) current.Left = DeletePoint(current.Left, point);
            else if (point > current) current.Right = DeletePoint(current.Right, point);
            else
            {
                TreePoint left = current.Left,
                          right = current.Right;

                if (left == null) return left;

                TreePoint min = right.Min;
                min.Right = DeleteMinPoint(right);

                min.Left = left;

                return BalanceTree(min);
            }
            return BalanceTree(current);
        }
        
        static TreePoint DeleteMinPoint(TreePoint current)
        {
            if (current.Left == null) return current.Right;
            current.Left = DeleteMinPoint(current.Left);
            return BalanceTree(current);
        }
    }
}
