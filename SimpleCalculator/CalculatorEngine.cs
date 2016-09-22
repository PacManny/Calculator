using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SimpleCalculator
{
    class CalculatorEngine
    {
        public string DisplayedNumber { get; set; }
        public List<string> DataList { get; set; }
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
            DataList = new List<string>();
            Operands = new List<double>();
            Operators = new List<string>();
            DisplayedNumber = "0";
            inputData = null;
            calculate = false;
            Total = 0;
            lastOperator = null;
        }

        public void OnDataAdded()
        {
            inputData += DataList[DataList.Count() - 1];
            string operand;

            if (ContainsOperator(inputData[inputData.Count() - 1].ToString()))
            {

                lastOperator = inputData[inputData.Count() - 1].ToString();
                DataList.Remove(inputData[inputData.Count() - 1].ToString());
                inputData = "";
                operand = string.Join("", DataList.ToArray());
                DataList.RemoveRange(0, DataList.Count());
                try
                {
                    Operands.Add(Convert.ToDouble(operand));
                }
                catch
                {

                }
                DisplayedNumber = Operands[Operands.Count() - 1].ToString();
                ComputeCalculation();
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
            if (inputData == "C")
            {
                InitializeCalculator();
            }

        }

        private void ComputeCalculation()
        {
            if (calculate)
            {

                GetVaildCalculation();
                Operands.RemoveRange(1, Operands.Count() - 1);
                Operands.Add(Total);

                DisplayedNumber = Total.ToString();
                calculate = false;
            }
        }
      
        public void Motor (string userInput)
        {
            DataList.Add(userInput);
            OnDataAdded();
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
        public double GetVaildCalculation()
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
                    return GetVaildCalculation();
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
            List<string> validOperators = new List<string> { "+", "-", "/", "*", "=" };
            return validOperators.Contains(MathOperator);

        }

    }
}
