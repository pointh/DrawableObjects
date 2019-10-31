using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace DrawableObjects
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Square s, t;
        public MainWindow()
        {
            InitializeComponent();
            s = new Square(new Point(20.0, 30.0), 200, MainCanvas);
            t = new Square(new Point(60.0, 78.0), 120, MainCanvas);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            s.Draw();
            t.Draw();
            SizeSlider.Value = 1.0;
            SizeSlider.ValueChanged += SizeSliderValueChanged;
        }

        private void ButtonMove_Click(object sender, RoutedEventArgs e)
        {
            s.MoveTo(s.Position.X+10, s.Position.Y+10);
            t.MoveTo(t.Position.X + 20, t.Position.Y + 6);
            s.ReDraw();
            t.ReDraw();
        }

        private void SizeSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            s.ReDraw(e.NewValue);
            t.ReDraw(e.NewValue);
        }
    }
}
