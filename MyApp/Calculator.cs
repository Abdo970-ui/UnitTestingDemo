using System;
using System.Collections.Generic;
using System.Text;
namespace MyApp
{
    public class Calculator
    {
        public int Add(int a, int b) => a + b;
        public int Subtract(int a, int b) => a - b;
        public int Divide(int a, int b)
        {
            if (b == 0)
                throw new DivideByZeroException("Cannot divide by zero");
            return a / b;
        }

        public bool IsEven(int number) => number % 2 == 0;
        public int Multiply(int a, int b) => a * b;

    }
}
