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
                    ((Button)el).Click += Button_Click;
            }
        }

        const string numbers = "1234567890";
        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string str = (string)((Button)e.OriginalSource).Content;

            switch (str)
            {
                case "AC":
                    textLabel.Text = string.Empty;
                    break;

                case "=":
                    textLabel.Text = new DataTable().Compute(textLabel.Text, null).ToString();
                    break;

                case "+":
                case "-":
                case "*":
                case "/":
                    if (textLabel.Text.Length > 0)
                        if (numbers.Contains(textLabel.Text[textLabel.Text.Length - 1]))
                            textLabel.Text += str;
                    break;

                default:
                    textLabel.Text += str;
                    break;
            }
        }
    }
}
