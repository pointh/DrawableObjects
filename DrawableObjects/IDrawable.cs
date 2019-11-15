using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DrawableObjects
{
    public interface IDrawable
    {
        Point Position { get; set; }
        Canvas DrawSpace { get; }
        void Draw(double scale = 1.0);
        IDrawable MoveTo(double x, double y);
        IDrawable CopyTo(double x, double y);
    }
}
