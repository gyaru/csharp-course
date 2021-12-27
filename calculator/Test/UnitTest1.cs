using System;
using Xunit;
using static calculator.Calculator;

namespace Test
{
    public class CalculatorTest
    {
        [Fact]
        public void TestAddition()
        {
            Assert.Equal(4, Addition(2, 2));
        }

        [Fact]
        public void TestSubtraction()
        {
            Assert.Equal(4, Subtraction(6, 2));
        }

        [Fact]
        public void TestDivision()
        {
            Assert.Equal(8, Division(16, 2));
        }

        [Fact]
        public void TestMultiplication()
        {
            Assert.Equal(8, Multiplication(4, 2));
        }

        [Fact]
        public void TestDivideByZero()
        {
            Assert.Equal(0, Division(0, 5));
        }
    }
}