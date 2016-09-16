using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Text;
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
            Display.Text = "0";
            //this.CalculatorView = new CalculatorControlViewModel();
        }
        CalculatorEngine XamlCalculatorEngine = new CalculatorEngine();
        //public CalculatorControlViewModel CalculatorView { get; set; }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            Button calculatorButton = (Button)sender;
            XamlCalculatorEngine.AddToNumericalBattleGround(calculatorButton.Content.ToString());
            Display.Text = XamlCalculatorEngine.DisplayedNumber;



            //if (ContainsNumber(lastEntry))
            //{
            //    OperandString.Append(lastEntry);
            //    DefaultNumber += OperandString;
            //    Display.Text = OperandString.ToString();
            //}
            //else if (ContainsOperator(lastEntry))
            //{

            //    CalculatorEngine.Operators.Add(lastEntry);
            //    if (calculate)
            //    {
            //        if (ThatButton == thisButton)
            //        {
            //            CalculatorEngine.OperandToList(DefaultNumber);
            //            DefaultNumber = "";
            //        }
            //        Display.Text = CalculatorEngine.ComputeCalculation().ToString();
            //        DefaultNumber = "";
            //        calculate = false;
            //    }
            //    else
            //    {
            //        CalculatorEngine.OperandToList(OperandString);
            //        calculate = true;
            //    }
            //    OperandString = "";
            //    ThatButton = thisButton;



            //}
            //else
            //{
            //    OperationsDisplay.Text = lastEntry;
            //}
        }

        
    }
}

