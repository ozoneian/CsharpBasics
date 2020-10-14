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

namespace DiagramWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void YValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool success = double.TryParse(yValue.Text, out double result);
            if (success && result > 0)
            {
                yellowGraph.Width = result;
            }
        }

        private void RValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool success = double.TryParse(rValue.Text, out double result);
            if (success && result > 0)
            {
                redGraph.Width = result;
            }
        }

        private void BValue_TextChanged(object sender, TextChangedEventArgs e)
        {
            bool success = double.TryParse(bValue.Text, out double result);
            if (success && result > 0)
            {
                blueGraph.Width = result;
            }
        }

        private void YSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
           
            double temp = ySlider.Value * 75;

            yellowGraph.Width = temp;

        }

        private void rSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            double temp = rSlider.Value * 75;

            redGraph.Width = temp;

        }

        private void bSlider_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {

            double temp = bSlider.Value * 75;

            blueGraph.Width = temp;

        }
    }
}
