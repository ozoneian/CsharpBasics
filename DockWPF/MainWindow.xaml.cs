


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
            InitializeComponent();
           

            h.ReadDockData();
            h.GenerateBoat(10);
            DisplayDock();

            h.WriteDockData();

        }

        private void NewDayButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
        private void DisplayDock()
        {
            for (int i = 0; i < h.DockOne.Length; i++)
            {
                if (h.DockOne[i] == null)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = 5;
                    rectangle.Height = 10;
                    rectangle.Fill = new SolidColorBrush(Colors.White);
                    stpDockOne.Children.Add(rectangle);
                }
                else if (h.DockOne[i].GetType().Name == "SailBoat")
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = 5;
                    rectangle.Height = 10;
                    rectangle.Fill = new SolidColorBrush(Colors.Yellow);
                    stpDockOne.Children.Add(rectangle);
                }
                else if (h.DockOne[i].GetType().Name == "RowingBoat")
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = 5;
                    rectangle.Height = 10;
                    rectangle.Fill = new SolidColorBrush(Colors.Blue);
                    stpDockOne.Children.Add(rectangle);
                }
                else if (h.DockOne[i].GetType().Name == "PowerBoat")
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = 5;
                    rectangle.Height = 10;
                    rectangle.Fill = new SolidColorBrush(Colors.Green);
                    stpDockOne.Children.Add(rectangle);
                }
                else if (h.DockOne[i].GetType().Name == "Catamaran")
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = 5;
                    rectangle.Height = 10;
                    rectangle.Fill = new SolidColorBrush(Colors.Purple);
                    stpDockOne.Children.Add(rectangle);
                }
                else if (h.DockOne[i].GetType().Name == "CargoShip")
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = 5;
                    rectangle.Height = 10;
                    rectangle.Fill = new SolidColorBrush(Colors.Red);
                    stpDockOne.Children.Add(rectangle);
                }

            }
            for (int i = 0; i < h.DockTwo.Length; i++)
            {
                if (h.DockTwo[i] == null)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = 5;
                    rectangle.Height = 10;
                    rectangle.Fill = new SolidColorBrush(Colors.White);
                    stpDockTwo.Children.Add(rectangle);
                }
                else if (h.DockTwo[i].GetType().Name == "SailBoat")
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = 5;
                    rectangle.Height = 10;
                    rectangle.Fill = new SolidColorBrush(Colors.Yellow);
                    stpDockTwo.Children.Add(rectangle);
                }
                else if (h.DockTwo[i].GetType().Name == "RowingBoat")
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = 5;
                    rectangle.Height = 10;
                    rectangle.Fill = new SolidColorBrush(Colors.Blue);
                    stpDockTwo.Children.Add(rectangle);
                }
                else if (h.DockTwo[i].GetType().Name == "PowerBoat")
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = 5;
                    rectangle.Height = 10;
                    rectangle.Fill = new SolidColorBrush(Colors.Green);
                    stpDockTwo.Children.Add(rectangle);
                }
                else if (h.DockTwo[i].GetType().Name == "Catamaran")
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = 5;
                    rectangle.Height = 10;
                    rectangle.Fill = new SolidColorBrush(Colors.Purple);
                    stpDockTwo.Children.Add(rectangle);
                }
                else if (h.DockTwo[i].GetType().Name == "CargoShip")
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = 5;
                    rectangle.Height = 10;
                    rectangle.Fill = new SolidColorBrush(Colors.Red);
                    stpDockTwo.Children.Add(rectangle);
                }

            }
        }
    }
}
