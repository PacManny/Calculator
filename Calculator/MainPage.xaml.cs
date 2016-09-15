using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace Calculator
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        public MainPage()
        {
            this.InitializeComponent();
            //this.CalculatorView = new CalculatorControlViewModel();
            CalculatorEngine.Operands = new List<double>();
            CalculatorEngine.Operators = new List<string>();
        }
        //public CalculatorControlViewModel CalculatorView { get; set; }
        Engine CalculatorEngine = new Engine();
 
// making changes to the Modelview
e        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string operandString;
            double operandDouble;
            int lastIndexedOperand;
            string lastIndexedOperator;
            Button ThisButton = (Button)sender;
            operandString = ThisButton.Content.ToString();
            try
            {
                operandDouble = Convert.ToDouble(operandString);
                CalculatorEngine.Operands.Add(operandDouble);
            }
            catch


            lastIndexedOperator = CalculatorEngine.Operators.Add(operandString);
            if (ContainsOperator(CalculatorEngine.Operators[]))
                {

                }

            }


            lastIndexedOperand = CalculatorEngine.Operands.Count() - 1;
            Display.Text += CalculatorEngine.Operands[lastIndexedOperand];
     

            
    }
        public void Equals()
        {
            Displayed = "";
            SecondSavedOperand = input;
            OperationsDisplay.Text = string.Empty;
            if (CalculatorEngine.flag)
            {
                FirstSavedOperand = CalculatorEngine.Total.ToString();
                CalculatorEngine.doCalculation(FirstSavedOperand, SecondSavedOperand);
                Display.Text = CalculatorEngine.Total.ToString();

            }
            else {
                CalculatorEngine.doCalculation(FirstSavedOperand, SecondSavedOperand);
                Display.Text = CalculatorEngine.Total.ToString();
                CalculatorEngine.flag = true;
            }

        }

        public bool ContainsOperator(string MathOperator)
        {
            List<string> validOperators = new List<string> { "+", "-", "/", "*", "=" };
            return validOperators.Contains(MathOperator);

        }

        //  private void ButtonAdd_Click(object sender, RoutedEventArgs e)
        //  {
        //      input = this.Display.Text;
        //      FirstSavedOperand = input;
        //      CalculatorEngine.SavedOperator = "+";
        //      Displayed += input + " + ";
        //      OperationsDisplay.Text = Displayed;
        //      input = string.Empty;
        //  }

        //  private void ButtonSubtract_Click(object sender, RoutedEventArgs e)
        //  {
        //      input = this.Display.Text;
        //      FirstSavedOperand = input;
        //      CalculatorEngine.SavedOperator = "-";
        //      Displayed += input + " - ";
        //      OperationsDisplay.Text = Displayed;
        //      input = string.Empty;
        //  }

        //  private void ButtonMultiply_Click(object sender, RoutedEventArgs e)
        //  {
        //      input = this.Display.Text;
        //      FirstSavedOperand = input;
        //      CalculatorEngine.SavedOperator = "x";
        //      Displayed += input + " x ";
        //      OperationsDisplay.Text = Displayed;
        //      input = string.Empty;
        //  }

        //  private void ButtonDivide_Click(object sender, RoutedEventArgs e)
        //  {
        //      input = this.Display.Text;
        //      FirstSavedOperand = input;
        //      CalculatorEngine.SavedOperator = "+";
        //      Displayed += input + " + ";
        //      OperationsDisplay.Text = Displayed;
        //      input = string.Empty;
        //  }

        //  private void ButtonNegate_Click(object sender, RoutedEventArgs e)
        //  {
        //      if (input.Contains("-"))
        //      {
        //          input = input.TrimStart('-');
        //      }
        //      else {
        //          FirstSavedOperand = input;
        //          input = "-" + input;
        //      }
        //      Display.Text = input;
        //  }

        //  private void ButtonBack_Click(object sender, RoutedEventArgs e)
        //  {
        //      int index = input.Count();
        //      try
        //      {
        //          input = input.Remove(index - 1, 1);
        //      }
        //      catch
        //      {
        //          input = "0";
        //      }
        //      Display.Text = input;
        //  }

        //  private void ButtonClear_Click(object sender, RoutedEventArgs e)
        //  {
        //      CalculatorEngine.flag = false;
        //      OperationsDisplay.Text = "";
        //      input = "";
        //      Display.Text = "0";
        //      CalculatorEngine.Total = 0.0;
        //      CalculatorEngine.SavedOperator = "";
        //      Displayed = "";
        //  }

        //  private void ButtonClearEntry_Click(object sender, RoutedEventArgs e)
        //  {
        //      input = "";
        //      Display.Text = "0";
        //  }
    }
}
