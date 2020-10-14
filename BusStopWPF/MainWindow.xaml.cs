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

namespace BusStopWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public BusStop[] BusStops { get; set; } = { new BusStop(20, "1"), new BusStop(160, "2"), new BusStop(300, "3"), new BusStop(440, "4"), new BusStop(580, "5") };
        public List<Passenger> Passengers { get; set; } = new List<Passenger>();
        public double PositionCanvas { get; set; } = 0;
        public int TestInt { get; set; } = 0;
        public MainWindow()
        {
            InitializeComponent();
        }
        public void MakePassenger()
        {
            Passenger passenger = new Passenger();
            Passengers.Add(passenger);

        }
       
        private void Test_Click(object sender, RoutedEventArgs e)
        {
            TestInt++;
            if (TestInt<BusStops.Length)
            {
                Canvas.SetLeft(bus, BusStops[TestInt].CanvasPos);

            }
            else
            {
                TestInt = 0;
                Canvas.SetLeft(bus, BusStops[TestInt].CanvasPos);

            }
        }
        public void HandlePassengers()
        {
            for (int p = 0; p < Passengers.Count; p++)
            {
                if (Passengers[p].GetOn == TestInt)
                {
                   // ((TestInt == 1) ? (busStopOneInfo.Text = $"bus is here passengers get on passengers get off.") : (busStopOneInfo.Text = "passengers wait"));
                }
            }
        }
    }
}
