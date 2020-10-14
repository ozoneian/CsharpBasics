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

namespace CurrencyConverterWPF
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public List<Country> Countries { get; set; } = new List<Country>();
        public MainWindow()
        {
            CreateCountry();
            InitializeComponent();
        }
        public void CreateCountry()
        {
            
            Countries.Add(new Country(1.87206, "ZAR"));
            Countries.Add(new Country(0.157970, "AUD"));
            Countries.Add(new Country(8.30251, "INR"));
            Countries.Add(new Country(0.0874022, "GBP"));
            Countries.Add(new Country(0.113245, "USD"));
        }

        private void convertButton_Click(object sender, RoutedEventArgs e)
        {
            conversionsListBox.Items.Clear();
            bool success = double.TryParse(amountToConvert.Text, out double result);
            if (success)
            {
                foreach (var c in Countries)
                {
                    conversionsListBox.Items.Add($"{c.CurrencyCode}: {result * c.CurrencyRate}");
                }
            }
        }

        private void amount_TextBox_Focus(object sender, RoutedEventArgs e)
        {
            amountToConvert.Text = "";
        }
    }
    public class Country
    {
        public double CurrencyRate { get; set; }
        public string CurrencyCode { get; set; }

        public Country(double currencyRate, string currencyCode)
        {
            CurrencyRate = currencyRate;
            CurrencyCode = currencyCode;
        }
    }
}
