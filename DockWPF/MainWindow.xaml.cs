


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
        public MainWindow()
        {
            InitializeComponent();
            Harbour h = new Harbour();
            h.RunHarbour();

           

            Boat[] dockedBoats = new Boat[32*2];
            Boat[] dockedTwoBoats = new Boat[32*2];

            SailBoat s = new SailBoat();
            Array.Fill(dockedBoats, s, 4, s.Slots);

            for (int i = 0; i < dockedBoats.Length; i++)
            {
                if (dockedBoats[i]==null)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = 5;
                    rectangle.Height = 5;
                    rectangle.Stroke = new SolidColorBrush(Colors.Black);
                    rectangle.Fill = new SolidColorBrush(Colors.Red);
                    stpShowRectangles.Children.Add(rectangle);
                }
                else if (dockedBoats[i]==s)
                {
                    Rectangle rectangle = new Rectangle();
                    rectangle.Width = 5;
                    rectangle.Height = 5;
                    rectangle.Stroke = new SolidColorBrush(Colors.Black);
                    rectangle.Fill = new SolidColorBrush(Colors.Yellow);
                    stpShowRectangles.Children.Add(rectangle);
                }
                
            }

        }

        private void NewDayButton_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
