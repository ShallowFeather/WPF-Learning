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

namespace Calculator
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        double lastNum, result;
        SelectOperactor selectOperactor;
        public MainWindow()
        {
            InitializeComponent();
        }

        private void NumClick(object sender, RoutedEventArgs e)
        {
            var Btn = sender as Button;
            var Num = Int32.Parse(Btn.Content.ToString());
            if (Output.Content.ToString() == "0")
            {
                Output.Content = Num.ToString();
            }
            else
            {
                Output.Content = $"{Output.Content}{Num}";
            }
            }

        private void OperactionButton(object sender,  RoutedEventArgs e)
        {
            if (double.TryParse(Output.Content.ToString(), out lastNum)) 
            {
                Output.Content = "0";
            }

            if (sender == Multi)
                selectOperactor = SelectOperactor.Multiplication;
            if (sender == division)
                selectOperactor = SelectOperactor.Division;
            if (sender == add)
                selectOperactor = SelectOperactor.Addition;
            if (sender == Sustraction)
                selectOperactor = SelectOperactor.Sustraction;
        }
        private void AcClick(object sender, RoutedEventArgs e)
        {
            Output.Content = "0";
        }
        private void PerClick(object sender, RoutedEventArgs e)
        {
            if (double.TryParse(Output.Content.ToString(), out lastNum))
            {
                lastNum *= 0.01;
                Output.Content = lastNum.ToString();
            }
        }
        private void DotClick(object sender, RoutedEventArgs e)
        {
            if (Output.Content.ToString().Contains("."))
                return;
            Output.Content = $"{Output.Content}.";
        }
        private void EqualClick(object sender, RoutedEventArgs e)
            {
            double newNum;
            if (double.TryParse(Output.Content.ToString(), out newNum)) 
            {
                switch (selectOperactor)
                {
                    case SelectOperactor.Addition:
                        result = Math.Add(lastNum, newNum);
                        break;
                    case SelectOperactor.Sustraction:
                        result = Math.Sustraction(lastNum, newNum);
                        break;
                    case SelectOperactor.Multiplication:
                        result = Math.Multiply(lastNum, newNum);
                        break;
                    case SelectOperactor.Division:
                        result = Math.Divide(lastNum, newNum);
                        break;
                }    
                Output.Content = result.ToString();
            }
        }

        private void NegativeClick(object sender, RoutedEventArgs e)
        {
            if(double.TryParse(Output.Content.ToString(), out lastNum))
            {
                if (lastNum == 0) return;
                lastNum = lastNum * -1;
                Output.Content = lastNum.ToString();
            }
        }
    }

    public enum SelectOperactor
    {
        Addition,
        Sustraction,
        Multiplication,
        Division,
    }

    public class Math
    {
        public static double Add(double a, double b)
        {
            return a + b;
        }
        public static double Sustraction(double a, double b)
        {
            return a - b;
        }
        public static double Multiply(double a, double b)
        {
            return a * b;
        }
        public static double Divide(double a, double b)
        {
            return a / b;
        }
    }
}
