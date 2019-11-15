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
using System.Collections.ObjectModel;

namespace DrawableObjects
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        //List<IDrawable> DrawableObjects = new List<IDrawable>();
        ObservableCollection<IDrawable> DrawableObjects = new ObservableCollection<IDrawable>();
        public MainWindow()
        {
            InitializeComponent();
            DrawableObjects.Add(new Square(new Point(20.0, 30.0), 200, MainCanvas));
            DrawableObjects.Add(new Square(new Point(60.0, 78.0), 120, MainCanvas));

            // všechny prvky nemusí sdílet tentýž DataContext - každý prvek může mít svůj
            this.DataContext = DrawableObjects;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            foreach (var v in DrawableObjects)
                v.Draw();
            SizeSlider.Value = 1.0;
            SizeSlider.ValueChanged += SizeSliderValueChanged;
        }

        private void ButtonMove_Click(object sender, RoutedEventArgs e)
        {
            for (int i = 0; i < DrawableObjects.Count; i++)
            {
                IDrawable x = DrawableObjects[i].MoveTo(DrawableObjects[i].Position.X + 10, DrawableObjects[i].Position.Y + 10);
                DrawableObjects[i] = x;

                x.Draw();
            }
        }

        private void SizeSliderValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            foreach (IDrawable v in DrawableObjects)
            {
                v.Draw(e.NewValue);
            }
        }

        private void ButtonCopy_Click(object sender, RoutedEventArgs e)
        {
            List<IDrawable> newObjects = new List<IDrawable>();
            for (int i = 0; i < DrawableObjects.Count; i++)
            {
                IDrawable x = DrawableObjects[i].CopyTo(DrawableObjects[i].Position.X + 10, DrawableObjects[i].Position.Y + 10);
                newObjects.Add(x);
            }

            foreach (IDrawable v in newObjects)
            {
                DrawableObjects.Add(v);
                v.Draw();
            }
        }
    }
}
