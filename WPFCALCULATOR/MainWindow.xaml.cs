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

namespace WPFCALCULATOR
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
        double number = 0;
        private string operation = "";
        private bool operationClicked = false;
        private void InsertNumber(object sender, RoutedEventArgs e)
        {
            Button pressedButton = (Button)sender;

            if (resultTextBlock.Text == "0" || operationClicked)
            {
                resultTextBlock.Text = pressedButton.Content.ToString();
            }
            else
            {
                resultTextBlock.Text += pressedButton.Content.ToString();
            }

            operationClicked = false;

        }
        private void Operation(object sender, RoutedEventArgs e)
        {
            Button button = (Button)sender;
            if (number != 0)
            {

                Equals(this, null); 
                operationClicked = true;
                operation = button.Content.ToString();
            }
            else
            {
                number = Double.Parse(resultTextBlock.Text);
                operation = button.Content.ToString();
                operationClicked = true;
            }
        }
        private void Equals(object sender, RoutedEventArgs e)
        {

            switch (operation)
            {
                case "+":
                    resultTextBlock.Text = (number + Double.Parse(resultTextBlock.Text)).ToString();
                    break;
                case "-":
                    resultTextBlock.Text = (number - Double.Parse(resultTextBlock.Text)).ToString();
                    break;
                case "*":
                    resultTextBlock.Text = (number * Double.Parse(resultTextBlock.Text)).ToString();
                    break;
                case "/":
                    if (Double.Parse(resultTextBlock.Text) != 0)
                        resultTextBlock.Text = (number / Double.Parse(resultTextBlock.Text)).ToString();
                    else
                        MessageBox.Show("Cant divide by zero");
                    break;
                case "%":
                    resultTextBlock.Text = (number / 100* (Double.Parse(resultTextBlock.Text))).ToString();
                    break;
            }
            number = Double.Parse(resultTextBlock.Text);
            operationClicked = false;
            operation = "";
        }
        private void CeClicked(object sender, RoutedEventArgs e)
        {
            resultTextBlock.Text = "0";
        }

        private void Clicked(object sender, RoutedEventArgs e)
        {
            resultTextBlock.Text = "0";
            number = 0;
        }
        private void InsertDot(object sender, RoutedEventArgs e)
        {

            if (resultTextBlock.Text == "0")
            {
                resultTextBlock.Text = "0.";
            }
            else if (!resultTextBlock.Text.Contains(","))
            {
                resultTextBlock.Text += ".";
            }
        }

        private void Sqrt_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(resultTextBlock.Text.ToString()))
            {
                var result = Convert.ToDouble(resultTextBlock.Text.ToString());
                resultTextBlock.Text = Math.Sqrt(result).ToString();
            }
        }

        private void Square_Click(object sender, RoutedEventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(resultTextBlock.Text.ToString()))
            {
                var result = Convert.ToDouble(resultTextBlock.Text.ToString());
                resultTextBlock.Text = Math.Pow(result, 2).ToString();
            }
        }

        private void btnDeleteOne_Click(object sender, RoutedEventArgs e)
        {
            if (double.Parse(resultTextBlock.Text) == 0) {}
            else
            {
                resultTextBlock.Text = resultTextBlock.Text.Remove(resultTextBlock.Text.Length - 1);
                if (resultTextBlock.Text.Length == 0)
                {
                    resultTextBlock.Text = "0";
                }
            }
        }

        private void btnPlusMinus_Click(object sender, RoutedEventArgs e)
        {
            if (resultTextBlock.Text.StartsWith("-"))
            {
                resultTextBlock.Text = resultTextBlock.Text.Substring(1);
            }
            else if(!string.IsNullOrEmpty(resultTextBlock.Text) && decimal.Parse(resultTextBlock.Text) != 0)
            {
                resultTextBlock.Text = "-" + resultTextBlock.Text;
            }
            
        }
    }
}
