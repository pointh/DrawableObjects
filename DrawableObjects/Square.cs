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
    public class Square : IDrawable
    {
        public Point Position { get; set; }
        public Canvas DrawSpace { get; }

        public int Size { get; }

        private Rectangle r;

        public Square(Point positon, int size, Canvas canvas)
        {
            Size = size;
            Position = positon;
            DrawSpace = canvas;
            // Nekresli mimo hranice kreslicí plochy
            DrawSpace.ClipToBounds = true;
        }

        public Square() : this(new Point(0, 0), 100, null)
        { }

        public void Draw(double scale = 1.0)
        {
            r = new Rectangle
            {
                Width = (int)(scale*Size),
                Height = (int)(scale*Size),
                Stroke = Brushes.Red,
            };

            // Ve WPF není absolutní pozicování elementů,
            // ale r má svůj canvas a ten se může posunovat.
            Canvas.SetLeft(r, Position.X);
            Canvas.SetTop(r, Position.Y);
            DrawSpace.Children.Add(r);
        }

        public void ReDraw(double scale = 1.0)
        {
            // Zruš aktuální projení mezi kreslicí plochou
            // a starým Rectangle, GC se postará o zbytek
            // (žádná reference na r)
            DrawSpace.Children.Remove(r);

            // Vytvoř a vykresli nový Rectangle
            Draw(scale);
        }

        public void MoveTo(double x, double y)
        {
            Position = new Point(x, y);
        }

        public override string ToString()
        {
            return $"{Size}x{Size}";
        }
    }
}
