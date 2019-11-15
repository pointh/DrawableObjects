
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes; // tady jsou základní tvary - čára, elipsa, polyline, ....
using System.Windows.Media;
using System.Diagnostics;

namespace DrawableObjects
{
    public class Circle : IDrawable
    {
        public Point Position { get; set; }

        public Canvas DrawSpace { get; }

        public int Size { get; }

        private Ellipse e;


        public Circle(Point positon, int size, Canvas canvas)
        {
            Size = size;
            Position = positon;
            DrawSpace = canvas;
            // Nekresli mimo hranice kreslicí plochy
            DrawSpace.ClipToBounds = true;
        }

        public Circle(Circle s) : this(s.Position, s.Size, s.DrawSpace)
        { }

        public Circle() : this(new Point(0, 0), 100, null)
        { }

        public void Draw(double scale = 1.0)
        {
            DrawSpace.Children.Remove(e);
            e = new Ellipse
            {
                Width = (int)(scale * Size),
                Height = (int)(scale * Size),
                Stroke = Brushes.Green,
            };

            // Ve WPF není absolutní pozicování elementů,
            // ale r má svůj canvas a ten se může posunovat.
            Canvas.SetLeft(e, Position.X);
            Canvas.SetTop(e, Position.Y);
            DrawSpace.Children.Add(e);
        }

        public IDrawable MoveTo(double x, double y)
        {
            Position = new Point(x, y);
            DrawSpace.Children.Remove(e);
            return new Circle(new Point(x, y), this.Size, this.DrawSpace);
        }

        public IDrawable CopyTo(double x, double y)
        {
            return new Circle(new Point(x, y), this.Size, this.DrawSpace);
        }

        public override string ToString()
        {
            return $"{Position.X}, {Position.Y} : {Size}x{Size}";
        }
    }
}

