using FibonacciIterators;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FibonacciIteratorsTests
{
    public class BackwardFibonacciSequenceIteratorFacts
    {
        [Theory]
        [InlineData(3, 1)]
        [InlineData(3, 3)]
        public void HasMore_JustCreatedIterator_ReturnsTrue(int start, int end)
        {
            var calculatorMock = new Mock<IFibonacciCalculator>();

            var iterator = new BackwardFibonacciSequenceIterator(start, end, calculatorMock.Object);
            var actual = iterator.HasMore();

            Assert.True(actual);
        }

        [Fact]
        public void Constructor_WrongRange_ThrowsException()
        {
            var calculatorMock = new Mock<IFibonacciCalculator>();

            Assert.Throws<ArgumentException>(() => new BackwardFibonacciSequenceIterator(2, 3, calculatorMock.Object));
        }

        [Fact]
        public void Constructor_NullFibonacciCalculator_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new BackwardFibonacciSequenceIterator(3, 1, null));
        }

        [Fact]
        public void GetNext_ThreeNumbers_IteratesCorrectly()
        {
            var calculatorMock = new Mock<IFibonacciCalculator>();
            calculatorMock.Setup(x => x.CalculateNthNumber(3)).Returns(100);
            calculatorMock.Setup(x => x.CalculateNthNumber(4)).Returns(400);
            calculatorMock.Setup(x => x.CalculateNthNumber(5)).Returns(900);

            var iterator = new BackwardFibonacciSequenceIterator(5, 3, calculatorMock.Object);
            int n5 = iterator.GetNext();
            int n4 = iterator.GetNext();
            int n3 = iterator.GetNext();

            Assert.Equal(900, n5);
            Assert.Equal(400, n4);            
            Assert.Equal(100, n3);
            Assert.False(iterator.HasMore());
        }
    }
}
