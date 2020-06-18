using FibonacciIterators;
using System;
using Xunit;

namespace FibonacciIteratorsTests
{
    public class FibonacciCalculatorFacts
    {
        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(10, 55)]
        [InlineData(20, 6765)]
        public void BinetCalculator_Works(int n, int nthNumber)
        {
            var calculator = new BinetFibonacciCalculator();

            var actual = calculator.CalculateNthNumber(n);

            Assert.Equal(nthNumber, actual);
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(2, 1)]
        [InlineData(3, 2)]
        [InlineData(4, 3)]
        [InlineData(10, 55)]
        [InlineData(20, 6765)]
        public void RecursiveCalculator_Works(int n, int nthNumber)
        {
            var calculator = new RecursiveFibonacciCalculator();

            var actual = calculator.CalculateNthNumber(n);

            Assert.Equal(nthNumber, actual);
        }
    }
}
