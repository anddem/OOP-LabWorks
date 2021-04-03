using LabWork_10;

namespace LabWork_12
{
    class TreePoint
    {
        public Region Value { get; set; } = null; //Значение элемента

        public TreePoint Left { get; set; } = null; //Левое поддерево

        public TreePoint Right { get; set; } = null; //Правое поддерево

        public TreePoint Min { get => Left != null ? Left.Min : this; } //Минимум в поддереве

        public int Height { get; set; } = 1; //высота поддерева 

        public TreePoint(Region value) => Value = value; //Конструктор

        public TreePoint(string name, int population) => Value = new Region(name, population); //Конструкток

        public static bool operator >(TreePoint left, TreePoint right) => left.Value > right.Value;

        public static bool operator <(TreePoint left, TreePoint right) => left.Value < right.Value;

        public override bool Equals(object obj)
        {
            if (this.GetType() != obj.GetType()) return false;

            TreePoint tmp = (TreePoint)obj;

            return Value == tmp.Value && Left == tmp.Left && Right == tmp.Right;
        }

        public override string ToString()
        {
            return Value.ToString();
        }
    }
}
