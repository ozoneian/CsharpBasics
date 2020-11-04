


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

namespace DockWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        Harbour h = new Harbour();

        public MainWindow()
        {
            h.ReadDockData();

            InitializeComponent();

           



        }

        private void NewDayButton_Click(object sender, RoutedEventArgs e)
        {
            h.UpdateHarbour();
            h.RemoveBoat();
            h.GenerateBoat(10);
            DisplayDock();
            DockOneInfo();
            DockTwoInfo();
        }
     
        private void DisplayDock()
        {
            stpDockOne.Children.Clear();
            stpDockTwo.Children.Clear();

            foreach (var item in h.DockOne)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Width = 5;
                rectangle.Height = 10;
                _ = (item is null) ? (rectangle.Fill = new SolidColorBrush(Colors.White)) : (rectangle.Fill = item.BoatColor);

                stpDockOne.Children.Add(rectangle);
            }
            foreach (var item in h.DockTwo)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Width = 5;
                rectangle.Height = 10;
                _ = (item is null) ? (rectangle.Fill = new SolidColorBrush(Colors.White)) : (rectangle.Fill = item.BoatColor);
                stpDockTwo.Children.Add(rectangle);
            }
        }
        private void DockOneInfo()
        {
            dgrDockOne.ItemsSource = h.BoatsInfo(h.DockOne);

        }
        private void DockTwoInfo()
        {
            dgrDockTwo.ItemsSource = h.BoatsInfo(h.DockTwo);

        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            h.WriteDockData();
        }
    }
}
