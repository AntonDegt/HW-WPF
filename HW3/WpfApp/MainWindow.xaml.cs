using System;
using System.Collections.Generic;
using System.Data;
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

namespace WpfApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Dictionary<Polygon, PointCollection> polygons = new Dictionary<Polygon, PointCollection>();

        public MainWindow()
        {
            InitializeComponent();

            foreach (UIElement uielement in canvas.Children)
            {
                Polygon polygon = uielement as Polygon;
                if (polygon != null) polygons.Add(polygon, polygon.Points.Clone());
            }
        }

        private void Window_SizeChanged(object sender, SizeChangedEventArgs e)
        {
            double delta = (Width < Height) ? Width / 100 : Height / 100;
            if (double.IsInfinity(delta) || delta == 0) return;
            foreach(UIElement uielement in canvas.Children)
            {
                Polygon polygon = uielement as Polygon;
                if (polygon == null) continue;

                PointCollection pc = new PointCollection();
                foreach(Point point in polygons[polygon])
                    pc.Add(new Point(point.X * delta, point.Y * delta));
                polygon.Points = pc;
            }

        }
    }
}
