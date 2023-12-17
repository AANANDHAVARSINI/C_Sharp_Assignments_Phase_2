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

namespace CalculatorApp
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNumber, result;
        SelectedOperator selectedOperator;
        public MainWindow()
        {
            InitializeComponent();
            resultLabel.Content = "0";
            acButton.Click += AcButton_Click;
            negativeButton.Click += NegativeButton_Click;
            percentageButton.Click += PercentageButton_Click;

        }
        public void EqualButton_Click(object sender, RoutedEventArgs e)
        {
            double newValue = 0;
            if(double.TryParse(resultLabel.Content.ToString(), out newValue))
            {
                switch (selectedOperator)
                {
                    case SelectedOperator.Addition:
                        result = SimpleMath.Add(lastNumber, newValue);
                        break;
                    case SelectedOperator.Subtraction:
                        result = SimpleMath.Subtraction(lastNumber, newValue);
                        break;
                    case SelectedOperator.Multiplication:
                        result = SimpleMath.Multiplication(lastNumber, newValue);
                        break;
                    case SelectedOperator.Division:
                        result = SimpleMath.Division(lastNumber, newValue);
                        break;
                }
            }
            resultLabel.Content = result.ToString();
        }

        private void FullStopButton_Click(object sender, RoutedEventArgs e)
        {
            if(resultLabel.Content.ToString().Contains("."))
            {
            }
            else
            {
                resultLabel.Content += ".";
            }
        }
        private void PercentageButton_Click(object sender, RoutedEventArgs e)
        {
            double tempNumber;
            if (double.TryParse(resultLabel.Content.ToString(), out tempNumber))
            {
                tempNumber = tempNumber / 100;
                if(lastNumber != 0)
                {
                    tempNumber *= lastNumber;
                }
                resultLabel.Content = tempNumber.ToString();
            }
        }

        private void NegativeButton_Click(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                lastNumber = lastNumber * -1;
                resultLabel.Content = lastNumber.ToString();
            }
        }

        private void NumberButton_Click(object sender, RoutedEventArgs e)
        {
            int selectedNumber = int.Parse((string)(sender as Button).Content);

            if (resultLabel.Content.ToString() == "0")
            {
                resultLabel.Content = $"{selectedNumber}";
            }
            else
            {
                resultLabel.Content = $"{resultLabel.Content}{selectedNumber}";
            }
        }
        public void OperationButton_Click(object sender, EventArgs e)
        {
            if (double.TryParse(resultLabel.Content.ToString(), out lastNumber))
            {
                resultLabel.Content = "0";
            }
            if (sender == addButton)
            {
                selectedOperator = SelectedOperator.Addition;
            }
            if (sender == multiplicationButton)
            {
                selectedOperator = SelectedOperator.Multiplication;
            }
            if (sender == subtractionButton)
            {
                selectedOperator = SelectedOperator.Subtraction;
            }
            if (sender == divisionButton)
            {
                selectedOperator = SelectedOperator.Division;
            }
        }

        private void AcButton_Click(object sender, RoutedEventArgs e)
        {
            resultLabel.Content = "0";
            result = 0;
            lastNumber = 0;
        }
        public enum SelectedOperator
        {
            Addition,
            Subtraction,
            Multiplication,
            Division,
        }
        
        public class SimpleMath
        {
            public static double Add(double x, double y)
            {
                return x + y;
            }
            public static double Subtraction(double x, double y)
            {
                return x - y;
            }

            public static double Multiplication(double x, double y)
            {
                return x * y;
            }
            
            public static double Division(double x, double y)
            {
                if(y == 0)
                {
                    MessageBox.Show("Divide by 0 is not possible","Wrong Input",MessageBoxButton.OK, MessageBoxImage.Error);
                    return 0;
                }

                return x / y;
            }
        }
    }
}
