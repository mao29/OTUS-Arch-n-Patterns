using FibonacciIterators;
using Moq;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace FibonacciIteratorsTests
{
    public class ForwardFibonacciSequenceIteratorFacts
    {
        [Theory]
        [InlineData(1, 3)]
        [InlineData(3, 3)]
        public void HasMore_JustCreatedIterator_ReturnsTrue(int start, int end)
        {
            var calculatorMock = new Mock<IFibonacciCalculator>();

            var iterator = new ForwardFibonacciSequenceIterator(start, end, calculatorMock.Object);
            var actual = iterator.HasMore();

            Assert.True(actual);
        }

        [Fact]
        public void Constructor_WrongRange_ThrowsException()
        {
            var calculatorMock = new Mock<IFibonacciCalculator>();

            Assert.Throws<ArgumentException>(() => new ForwardFibonacciSequenceIterator(3, 2, calculatorMock.Object));
        }

        [Fact]
        public void Constructor_NullFibonacciCalculator_ThrowsException()
        {
            Assert.Throws<ArgumentNullException>(() => new ForwardFibonacciSequenceIterator(1, 3, null));
        }

        [Fact]
        public void GetNext_ThreeNumbers_IteratesCorrectly()
        {
            var calculatorMock = new Mock<IFibonacciCalculator>();
            calculatorMock.Setup(x => x.CalculateNthNumber(3)).Returns(100);
            calculatorMock.Setup(x => x.CalculateNthNumber(4)).Returns(400);
            calculatorMock.Setup(x => x.CalculateNthNumber(5)).Returns(900);

            var iterator = new ForwardFibonacciSequenceIterator(3, 5, calculatorMock.Object);
            int n3 = iterator.GetNext();
            int n4 = iterator.GetNext();
            int n5 = iterator.GetNext();

            Assert.Equal(100, n3);
            Assert.Equal(400, n4);
            Assert.Equal(900, n5);
            Assert.False(iterator.HasMore());
        }
    }
}
