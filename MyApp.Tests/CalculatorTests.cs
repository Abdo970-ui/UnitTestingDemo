using System;
using System.Collections.Generic;
using System.Text;

namespace MyApp.Tests
{
    public class CalculatorTests
    {
        [Fact]
        public void Add_TwoNumbers_ReturnsSum()
        {
            // Arrange
            var calc = new Calculator();

            // Act
            var result = calc.Add(2, 3);

            // Assert
            Assert.Equal(5, result);
        }
        [Fact]
        public void Subtract_TwoNumbers_ReturnsDifference()
        {
           var calc = new Calculator();
            Assert.Equal(1, calc.Subtract(3, 2));
        }
        [Theory]
        [InlineData(4, true)]
        [InlineData(7, false)]
        [InlineData(0, true)]
        public void IsEven_ReturnsCorrectResult(int number, bool expected)
        {
            var calc = new Calculator();

            Assert.Equal(expected, calc.IsEven(number));
        }

        [Fact]
        public void Divide_ByZero_ThrowsException()
        {
            var calc = new Calculator();

            Assert.Throws<DivideByZeroException>(() => calc.Divide(10, 0));
        }

        [Fact]
        public void Multiply_TwoNumbers_ReturnsProduct()
        {
            var calc = new Calculator();

            Assert.Equal(6, calc.Multiply(2, 3));
        }
    }
}
