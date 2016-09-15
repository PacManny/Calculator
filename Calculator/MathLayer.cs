using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Calculator
{
    class MathLayer
    {
        public double Add(double FirstNumber, double SecondNumber)
        {
            return FirstNumber + SecondNumber;
        }
        public double Subtract(double FirstNumber, double SecondNumber)
        {
            return FirstNumber - SecondNumber;
        }
        public double Divide(double FirstNumber, double SecondNumber)
        {
            return FirstNumber / SecondNumber;
        }
        public double Multiply(double FirstNumber, double SecondNumber)
        {
            return FirstNumber * SecondNumber;
        }
        public double Percent(double Number)
        {
            return (Number / 100) * Number;
        }
        public double SquareRoot(double Number)
        {
            
            return Math.Sqrt(Number);
        }
    }
}
