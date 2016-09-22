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
        public string lastOperator { get; set; }
        public double Total { get; set; }
        public string inputData { get; set; }
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
            inputData = "";
            calculate = false;
        }

        public void onNumberAdded()
        {
            inputData += NumericalBattleGround[NumericalBattleGround.Count() - 1];
            string operand;

            if (ContainsOperator(inputData[inputData.Count() - 1].ToString()))
            {

                lastOperator = inputData[inputData.Count() - 1].ToString();
                NumericalBattleGround.Remove(inputData[inputData.Count() - 1].ToString());
                inputData = "";
                operand = string.Join("", NumericalBattleGround.ToArray());
                NumericalBattleGround.RemoveRange(0, NumericalBattleGround.Count());
                try
                {
                    Operands.Add(Convert.ToDouble(operand));
                }
                catch
                {

                }
                DisplayedNumber = Operands[Operands.Count() - 1].ToString();
                CalculateOperation();
            }
            if (ContainsNumber(inputData))
            {
                DisplayedNumber = inputData;
                if (lastOperator != null)
                {
                    Operators.Add(lastOperator);
                    calculate = true;
                    lastOperator = null;
                }
            }
            if(inputData == "C")
            {
                ClearCalculator();
            }
        }

        private void CalculateOperation()
        {
            if (calculate || lastOperator == "=")
            {

                ComputeCalculation();
                Operands.RemoveRange(1, Operands.Count() - 1);
                Operands.Add(Total);

                DisplayedNumber = Total.ToString();
                calculate = false;
            }
        }
      
        public void AddToNumericalBattleGround (string userInput)
        {
            NumericalBattleGround.Add(userInput);
            onNumberAdded();
        }

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
        public void doEquals()
        {


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

                case "=":
                    Operators.Remove("=");
                    return ComputeCalculation();
                default:
                    return Operands[Operands.Count() - 1];

            }
        }
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
            List<string> validOperators = new List<string> { "+", "-", "/", "*", "="};
            return validOperators.Contains(MathOperator);

        }
        public void ClearCalculator()
        {
            NumericalBattleGround = new List<string>();
            Operands = new List<double>();
            Operators = new List<string>();
            DisplayedNumber = "0";
            inputData = "";
            calculate = false;
            Total = 0;

        }
    }
}
