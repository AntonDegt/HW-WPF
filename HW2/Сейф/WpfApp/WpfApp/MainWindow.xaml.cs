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
        bool close = true;
        public MainWindow()
        {
            InitializeComponent();

            foreach(UIElement el in mainRoot.Children)
            {
                if (el is Button)
                    ((Button)el).Click += Button_Click;
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;

            switch (str)
            {
                case "C":
                    textLabel.Text = "";
                    break;

                case "OK":
                    if (textLabel.Text == "0000")
                    {
                        textLabel.Text = "OPEN!";
                        close = false;
                    }
                    else
                        textLabel.Text = "";
                    break;

                default:
                    if (close)
                        textLabel.Text += str;
                    break;
            }
        }
    }
}
