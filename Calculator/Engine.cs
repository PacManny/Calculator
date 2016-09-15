using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class Engine
    {
        public List<double> Operands { get; set; }
        public List<string> Operators { get; set; }
        public double Total { get; set; }

        MathLayer mathLayer = new MathLayer();
       
        public void doCalculation(double FirstSavedOperand, double SecondSavedOperand, string SavedOperator)
        {

            switch (SavedOperator)
            {
                case "+":
                    doAddition(FirstSavedOperand, SecondSavedOperand);
                    break;
                case "-":
                    doSubtraction(FirstSavedOperand, SecondSavedOperand);
                    break;
                case "x":
                    doMultiplication(FirstSavedOperand, SecondSavedOperand);
                    break;
                case "/":
                    doDivision(FirstSavedOperand, SecondSavedOperand);
                    break;
                default:
                    break;

            }

        }
        public void doAddition(double FirstNumber, double SecondNumber)
        {
            Total = mathLayer.Add(FirstNumber, SecondNumber);

        }
        public void doSubtraction(double FirstNumber, double SecondNumber)
        {
            Total = mathLayer.Subtract(FirstNumber, SecondNumber);
        }
        public void doDivision(double FirstNumber, double SecondNumber)
        {
            Total = mathLayer.Divide(FirstNumber, SecondNumber);
        }
        public void doMultiplication(double FirstNumber, double SecondNumber)
        {
            Total = mathLayer.Multiply(FirstNumber, SecondNumber);
        }

    }
}
