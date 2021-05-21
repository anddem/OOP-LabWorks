using System;
using System.Collections.Generic;
using System.Drawing;
using System.Threading;
using System.Windows.Forms;
using MyLibrary;

namespace LabWork_15
{
    public partial class Form1 : Form
    {
        private int _radius; // Выбранный пользователем радиус шара
        private int _circlesCount; // Количество шаров на холсте

        private readonly Dictionary<int, ThreadPriority> _priorities = new Dictionary<int, ThreadPriority>()
        {
            {0, ThreadPriority.Lowest},
            {1, ThreadPriority.BelowNormal},
            {2, ThreadPriority.Normal},
            {3, ThreadPriority.AboveNormal},
            {4, ThreadPriority.Highest}
        }; // Словарь для удобного выбора приоритета процесса

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e) //При загрузке формы обнуляется счётчик
        {
            _circlesCount = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (_radius == 0) errorLabel.Text = "Радиус не может быть нулевым";
            else
            {
                Circle circle = CreateCircle();

                _circlesCount++;

                StartThread(circle);
            }
        }

        private Circle CreateCircle()
        {
            Brush brush = new SolidBrush(fillColorPicker.BackColor);
            Pen pen = new Pen(borderColorPicker.BackColor, 2);
            Point coords = new Point(Rand.Integer(canvas.Width), Rand.Integer(canvas.Height));

            return new Circle(coords, _radius, pen, brush);
        }

        private void StartThread(Figure figure)
        {
            var priority = priorityPicker.SelectedIndex == -1
                ? _priorities[0]
                : _priorities[priorityPicker.SelectedIndex];

            new Thread(() =>
                {
                    Action action = () => figuresOnPictureBoxLabel.Text = $"Фигур на поле: {_circlesCount}"; 


                    if (InvokeRequired) Invoke(action);
                    else action();

                    using (Graphics g = canvas.CreateGraphics())
                    {
                        while (!figure.OutOfBounds(canvas))
                        {
                            int dx = Rand.Integer(-10, 10);
                            int dy = Rand.Integer(-10, 10);
                            figure.Move(dx, dy);
                            figure.Draw(g);
                            Thread.Sleep((int)Math.Truncate(1.0 * redrawSpeed.Maximum / redrawSpeed.Value));
                            g.Clear(canvas.BackColor);
                            Thread.Sleep(0);
                        }
                    }

                    _circlesCount--;

                    if (InvokeRequired) Invoke(action);
                    else action();
                })
                { Priority = priority }.Start();
        }

        private void TextBoxToInt(object sender, EventArgs e) // Обработка введённого в TextBox текста
        {
            TextBox textBox = sender as TextBox;
            try
            {
                int textBoxInput = Convert.ToInt32(textBox.Text);
                errorLabel.Text = textBoxInput <= 0 ? "Радиус не может быть отрицательным или нулевым" : "";
                _radius = textBoxInput <= 0 ? 0 : textBoxInput;
            }
            catch (FormatException)
            {
                errorLabel.Text = string.IsNullOrWhiteSpace(textBox.Text) ? "" : "Введите число";
                _radius = 0;
            }
        }

        private void colorPicker_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.Cancel) return;
            borderColorPicker.BackColor = colorDialog1.Color;
        }

        private void fillColorPicker_Click(object sender, EventArgs e)
        {
            if (this.colorDialog1.ShowDialog() == DialogResult.Cancel) return;
            fillColorPicker.BackColor = colorDialog1.Color;
        }
    }
}
