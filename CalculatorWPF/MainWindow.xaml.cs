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

namespace CalculatorWPF
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

        private void Mult_Click(object sender, RoutedEventArgs e)
        {
            bool success = double.TryParse(numberOne.Text, out double resultOne);
            bool success2 = double.TryParse(numberTwo.Text, out double resultTwo);

            if (success && success2)
            {
                displayCalcResult.Items.Add($"{resultOne} * {resultTwo} = {resultOne * resultTwo}");
            }
        }
        private void Div_Click(object sender, RoutedEventArgs e)
        {
            bool success = double.TryParse(numberOne.Text, out double resultOne);
            bool success2 = double.TryParse(numberTwo.Text, out double resultTwo);

            if (success && success2 && resultOne!=0 && resultTwo!=0)
            {
                displayCalcResult.Items.Add($"{resultOne} / {resultTwo} = {resultOne / resultTwo}");
            }
        }
        private void Add_Click(object sender, RoutedEventArgs e)
        {
            bool success = double.TryParse(numberOne.Text, out double resultOne);
            bool success2 = double.TryParse(numberTwo.Text, out double resultTwo);

            if (success && success2)
            {
                displayCalcResult.Items.Add($"{resultOne} + {resultTwo} = {resultOne + resultTwo}");
            }
        }
        private void Sub_Click(object sender, RoutedEventArgs e)
        {
            bool success = double.TryParse(numberOne.Text, out double resultOne);
            bool success2 = double.TryParse(numberTwo.Text, out double resultTwo);

            if (success && success2)
            {
                displayCalcResult.Items.Add($"{resultOne} - {resultTwo} = {resultOne - resultTwo}");
            }
        }
        private void NumberTwo_GotFocus(object sender, RoutedEventArgs e)
        {
            numberTwo.Text = "";
        }

        private void NumberOne_GotFocus(object sender, RoutedEventArgs e)
        {
            numberOne.Text = "";

        }
    }
}
