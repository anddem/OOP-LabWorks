using System.Drawing;
using System.Windows.Forms;

namespace LabWork_15
{
    class Figure
    {
        protected Brush _brush;

        protected Pen _pen; //

        public Point Coords { get; set; } //Координаты (верхний левый угол)

        public Size _Size { get; set; } // Размеры фигуры по X и Y

        public Figure()
        {
            _brush = new SolidBrush(Color.Black);
            _pen = new Pen(Color.Black, 5);
            Coords = Point.Empty;
            _Size = Size.Empty;
        }

        public Figure(Point coords, Size size, Pen pen, Brush brush)
        {
            _pen = pen;
            _brush = brush;
            Coords = coords;
            _Size = size;
        }

        public virtual void Draw(Graphics graphics) // Метод отрисовки
        {
            Rectangle rect = new Rectangle(Coords, _Size);
            graphics.FillRectangle(_brush, rect);
            graphics.DrawRectangle(_pen, rect);
        }

        public virtual void Move(int dx, int dy)
        {
            Coords = new Point(Coords.X + dx, Coords.Y + dy);
        }

        public virtual void MoveTo(Point point) => Coords = point;

        public virtual void MoveTo(int x, int y) => Coords = new Point(x, y);

        public virtual bool OutOfBounds(PictureBox canvas)
        {
            return Coords.X > canvas.Width || Coords.Y > canvas.Height || Coords.X + _Size.Width < 0 || Coords.Y + _Size.Height < 0;
        }

        public virtual void MoveWithBouncing(int dx, int dy, PictureBox canvas)
        {
            if (dx > 0) dx = Coords.X + _Size.Width + dx > canvas.Width ? -dx : dx;
            else dx = dx = Coords.X + dx < 0 ? -dx : dx;

            if (dy > 0) dy = Coords.Y + _Size.Height + dy > canvas.Height ? -dy : dy;
            else dy = dy = Coords.Y + dy < 0 ? -dy : dy;

            Move(dx, dy);
        }
    }

    class Circle : Figure
    {
        public Circle() : base() {}

        public int Radius { get; set; }

        public Circle(Point coords, int radius, Pen pen, Brush brush) : base(coords, new Size(2*radius, 2*radius), pen, brush)
        {
            Radius = radius;
        }

        public override void Draw(Graphics graphics)
        {
            var bufferPoint = new Point(Coords.X - Radius, Coords.Y - Radius);
            Rectangle rect = new Rectangle(bufferPoint, _Size);
            graphics.FillEllipse(_brush, rect);
            graphics.DrawEllipse(_pen, rect);
        }

        public override bool OutOfBounds(PictureBox canvas)
        {
            return Coords.X - Radius > canvas.Width || Coords.X + Radius < 0 || Coords.Y - Radius > canvas.Height || Coords.Y + Radius < 0;
        }
    }
}
