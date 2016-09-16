using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class CalculatorEngine
    {
        public string DisplayedNumber { get; set; }
        public List<string> NumericalBattleGround { get; set; }
        public List<double> Operands { get; set; } 
        public List<string> Operators { get; set; }
        public double Total { get; set; }
        public string lastEntry { get; set; }
        public bool calculate { get; set; }
        MathLayer mathLayer = new MathLayer();

        public CalculatorEngine()
        {
            InitializeCalculator();
        }

        public void InitializeCalculator ()
        {
            NumericalBattleGround = new List<string>();
            Operands = new List<double>();
            Operators = new List<string>();
            DisplayedNumber = "";
            calculate = false;
        }

        public double ComputeCalculation()
        {
            int operatorsLength = Operators.Count();
            int operandsLength = Operands.Count();

            switch (Operators[operatorsLength - 1])
            {
                case "+":
                    return doAddition(Operands[operandsLength - 2], Operands[operandsLength - 1]);

                case "-":
                    return doSubtraction(Operands[operandsLength - 2], Operands[operandsLength - 1]);

                case "*":
                    return doMultiplication(Operands[operandsLength - 2], Operands[operandsLength - 1]);

                case "/":
                    return doDivision(Operands[operandsLength - 2], Operands[operandsLength - 1]);

                //case "=":
                //    doEquals();
                //    break;
                default:
                    return -1;

            }
        }

        public void onNumberAdded()
        {
            lastEntry = NumericalBattleGround[NumericalBattleGround.Count() - 1];
            string operand;
            if (ContainsOperator(lastEntry))
            {
                Operators.Add(lastEntry);
                NumericalBattleGround.Remove(lastEntry);
                operand = string.Join("", NumericalBattleGround.ToArray());
                NumericalBattleGround.RemoveRange(0, NumericalBattleGround.Count());
                Operands.Add(Convert.ToDouble(operand));
                DisplayedNumber = operand.ToString();
                if (calculate)
                {
                    ComputeCalculation();
                    lastEntry = Total.ToString();
                }
                calculate = true;
            }
            else
            {
                DisplayedNumber += lastEntry;
            }
            
        }

        public void AddToNumericalBattleGround (string userInput)
        {
            NumericalBattleGround.Add(userInput);
            onNumberAdded();
        }


        //public string getLastEntry(string type)
        //{
        //    if(ContainsOperator(type))
        //    {
        //        lastEntry = Operators[Operands.Count() - 1].ToString();
        //        return lastEntry;
        //    }
        //    lastEntry = Operands[Operands.Count() - 1].ToString();
        //    return lastEntry;
        //}
            
        //public void AddToList(string operand)
        //{
        //    Operands.Add(Convert.ToDouble(operand));
        //}
        public double doAddition(double FirstNumber, double SecondNumber)
        {
            Total = mathLayer.Add(FirstNumber, SecondNumber);
            return Total;
        }
        public double doSubtraction(double FirstNumber, double SecondNumber)
        {
            Total = mathLayer.Subtract(FirstNumber, SecondNumber);
            return Total;
        }
        public double doDivision(double FirstNumber, double SecondNumber)
        {
            Total = mathLayer.Divide(FirstNumber, SecondNumber);
            return Total;
        }
        public double doMultiplication(double FirstNumber, double SecondNumber)
        {
            Total = mathLayer.Multiply(FirstNumber, SecondNumber);
            return Total;
        }
        //public void doEquals()
        //{


        //}
        public bool ContainsNumber(string lastEntry)
        {
            try
            {
                Convert.ToDouble(lastEntry);

                return true;
            }
            catch
            {
                return false;
            }
        }

        public bool ContainsOperator(string MathOperator)
        {
            List<string> validOperators = new List<string> { "+", "-", "/", "*" };
            return validOperators.Contains(MathOperator);

        }
    }
}
