


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
            h.RemoveBoat();
            h.GenerateBoat(10);
            DisplayDock();
            FillDockOneInfo();
            FillDockTwoInfo();
            SumStat();
            h.UpdateHarbour();


        }

        private void DisplayDock()
        {
            txbDay.Text = $"Current day: {h.Day}";
            stpDockOne.Children.Clear();
            stpDockTwo.Children.Clear();

            foreach (var item in h.DockOne)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Width = 7;
                rectangle.Height = 14;
                _ = (item is null) ? (rectangle.Fill = new SolidColorBrush(Colors.White)) : (rectangle.Fill = item.BoatColor);

                stpDockOne.Children.Add(rectangle);
            }
            foreach (var item in h.DockTwo)
            {
                Rectangle rectangle = new Rectangle();
                rectangle.Width = 7;
                rectangle.Height = 14;
                _ = (item is null) ? (rectangle.Fill = new SolidColorBrush(Colors.White)) : (rectangle.Fill = item.BoatColor);
                stpDockTwo.Children.Add(rectangle);
            }
        }
        private void FillDockOneInfo()
        {
            dgrDockOne.ItemsSource = h.BoatsInfo(h.DockOne);

        }
        private void FillDockTwoInfo()
        {
            dgrDockTwo.ItemsSource = h.BoatsInfo(h.DockTwo);

        }


        private void btnExit_Click(object sender, RoutedEventArgs e)
        {
            h.WriteDockData();
        }
        private void SumStat()
        {
            stpSum.Children.Clear();
            TextBlock t = new TextBlock();
            t.Text = h.TotalBoatTypes(h.Boats);
            stpSum.Children.Add(t);
            TextBlock t1 = new TextBlock();
            t1.Text = $"Average total Max-Speed: {Math.Round(h.TotalMaxSpeed(h.Boats) * 1.85200)} km/h";
            stpSum.Children.Add(t1);
            TextBlock t2 = new TextBlock();
            t2.Text = $"Total weight: {h.TotalWeight(h.Boats)} kg";
            stpSum.Children.Add(t2);
            TextBlock t3 = new TextBlock();
            t3.Text = $"Total boats added: {h.AddedBoats}";
            stpSum.Children.Add(t3).ToString();
            TextBlock t4 = new TextBlock();
            t4.Text = $"Total boats rejected: {h.RejectedBoats}";
            stpSum.Children.Add(t4).ToString();
            TextBlock avaliableslots1 = new TextBlock();
            avaliableslots1.Text = $"Empty slots in dock [1]: {h.EmptySlotsDock(h.DockOne) / 2}";
            stpSum.Children.Add(avaliableslots1);

            TextBlock avaliableslots2 = new TextBlock();
            avaliableslots2.Text = $"Empty slots in dock [2]: {h.EmptySlotsDock(h.DockTwo) / 2}";
            stpSum.Children.Add(avaliableslots2);

        }
    }
}
