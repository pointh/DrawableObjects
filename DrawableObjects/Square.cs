using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes;
using System.Windows.Media;

namespace DrawableObjects
{
    class Square : IDrawable
    {
        public Point Position { get; set; }
        public Canvas DrawSpace { get; set; }

        public int Size { get; set; }

        public void Draw(double scale = 1.0)
        {
            Rectangle r = new Rectangle
            {
                Name = "r",
                Width = (int)(scale*Size),
                Height = (int)(scale*Size),
                Stroke = Brushes.Red,
            };

            Canvas.SetLeft(r, Position.X);
            Canvas.SetTop(r, Position.Y);
            DrawSpace.Children.Add(r);
        }

        public void ReDraw(double scale = 1.0)
        {
            DrawSpace.Children.RemoveAt(0);
            Draw(scale);
        }

        public Square(Point positon, int size, Canvas canvas)
        {
            Size = size;
            Position = positon;
            DrawSpace = canvas;
        }
    }
}
