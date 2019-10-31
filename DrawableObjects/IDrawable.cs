using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace DrawableObjects
{
    interface IDrawable
    {
        Point Position { get; set; }
        Canvas DrawSpace { get; set; }
        void Draw(double scale);
    }
}
