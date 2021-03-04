using System;
using System.Collections.Generic;
using System.Globalization;
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

using TaxCalcApp.Enums;
using TaxCalcApp.Models;

namespace TaxCalcApp
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

        private void CalcTaxClick(object sender, RoutedEventArgs e)
        {
            string selectedTaxTearSlab = (comboTaxYear.SelectedItem as ComboBoxItem).Content.ToString();
            if (double.TryParse(txtAmount.Text, out double Amount) && Amount > 0)
            {
                ITaxSlab taxSlab = GetTaxSlab(selectedTaxTearSlab);
                var taxSlabRange = taxSlab.GetTaxSlabRanges();
                double calcTax = 0;
                lblTaxSegregate.Content = "Tax Segregated details: \r\n";
                do
                {
                    var taxSlabRangeItem = taxSlabRange.First(slab => Amount >= slab.LowRange && Amount <= slab.HighRange);
                    var amountToPercentage = (Amount - taxSlabRangeItem.LowRange + 1);
                    double calcPerAmount = CalcPercentageAmount(amountToPercentage, taxSlabRangeItem.Percentage);

                    string segragareAmt = string.Format(new CultureInfo("en-IN", false), "{0:n}", calcPerAmount);
                    lblTaxSegregate.Content += $"From {taxSlabRangeItem.LowRange} to {(taxSlabRangeItem.HighRange < Amount ? taxSlabRangeItem.HighRange : Amount)} ::> Rs. {segragareAmt}/- \r\n";

                    calcTax += calcPerAmount;
                    Amount -= amountToPercentage;
                } while (Amount >= 0);

                lblResultText.Content = $" Total tax for your income:";
                string convertedAmount = string.Format(new CultureInfo("en-IN", false), "{0:n}", calcTax);
                lblTaxAmount.Content = $"Rs. {convertedAmount}/-";
            }
            else
            {
                lblResultText.Content = "Please provide correct amount ;)";
                lblResultText.Foreground = Brushes.Red;
                lblTaxAmount.Content = "";

            }
        }

        private ITaxSlab GetTaxSlab(string selectedTaxTearSlab)
        {
            if (int.TryParse(selectedTaxTearSlab.Substring(0, 4), out int startYear))
            {
                switch (startYear)
                {
                    case (int)TaxYearEnum.FY2019_20: return new TaxSlab2019_2020();
                    case (int)TaxYearEnum.FY2020_21: return new TaxSlab2020_2021();
                    default: return new TaxSlab2019_2020();
                }
            }
            else
            {
                return new TaxSlab2019_2020();
            }
        }

        private double CalcPercentageAmount(double amount, int perc)
        {
            var percAmount = amount * (perc / 100f);
            return percAmount;
        }
    }
}
