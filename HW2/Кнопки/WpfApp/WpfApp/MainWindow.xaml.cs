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
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement el in mainRoot.Children)
            {
                if (el is Button)
                {
                    Button btn = (Button)el;
                    btn.Click += Button_Click;
                    btn.Background = Brushes.SkyBlue;
                }
            }
            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button btn = (Button)e.OriginalSource;
            if ((string)btn.Content == "")
            {
                btn.Background = Brushes.SkyBlue;
                btn.Content = " ";
            }
            else
            {
                btn.Background = Brushes.Gray;
                btn.Content = "";
            }
        }
    }
}
