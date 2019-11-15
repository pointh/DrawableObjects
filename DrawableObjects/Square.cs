
using System.Windows;
using System.Windows.Controls;
using System.Windows.Shapes; // tady jsou základní tvary - čára, elipsa, polyline, ....
using System.Windows.Media;
using System.Diagnostics;

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

        public Square(Square s) : this(s.Position, s.Size, s.DrawSpace)
        { }

        public Square() : this(new Point(0, 0), 100, null)
        { }

        public void Draw(double scale = 1.0)
        {
            DrawSpace.Children.Remove(r);
            r = new Rectangle
            {
                Width = (int)(scale * Size),
                Height = (int)(scale * Size),
                Stroke = Brushes.Red,
            };

            // Ve WPF není absolutní pozicování elementů,
            // ale r má svůj canvas a ten se může posunovat.
            Canvas.SetLeft(r, Position.X);
            Canvas.SetTop(r, Position.Y);
            DrawSpace.Children.Add(r);
        }

        public IDrawable MoveTo(double x, double y)
        {
            Position = new Point(x, y);
            DrawSpace.Children.Remove(r);
            return new Square(new Point(x, y), this.Size, this.DrawSpace);
        }

        public IDrawable CopyTo(double x, double y)
        {
            return new Square(new Point(x,y), this.Size, this.DrawSpace);
        }

        public override string ToString()
        {
            return $"{Position.X}, {Position.Y} : {Size}x{Size}";
        }
    }
}
