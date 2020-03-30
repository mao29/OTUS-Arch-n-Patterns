using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CustomString.Tests
{
    /// <summary>
    /// Класс с тестами <see cref="LogarithmicArrayResizer{T}"/>.
    /// </summary>
    public class LogarithmicArrayResizerFacts
    {
        [Fact]
        public void CanDecreaseArray_NegativeLength_ThrowsArgumentOutOfRangeException()
        {
            var resizer = new LogarithmicArrayResizer<object>();
            Assert.Throws<ArgumentOutOfRangeException>("arrayLength", () => resizer.CanDecreaseArray(-5, 2));
        }

        [Fact]
        public void CanDecreaseArray_SaturationGreaterThanLength_ThrowsArgumentOutOfRangeException()
        {
            var resizer = new LogarithmicArrayResizer<object>();
            Assert.Throws<ArgumentOutOfRangeException>("currentSaturation", () => resizer.CanDecreaseArray(2, 3));
        }

        [Fact]
        public void CanDecreaseArray_LengthEqualsMinSize_False()
        {
            var resizer = new LogarithmicArrayResizer<object>();
            Assert.False(resizer.CanDecreaseArray(resizer.MinSize, 1));
        }

        [Fact]
        public void CanDecreaseArray_LengthLessThanMinSize_False()
        {
            var resizer = new LogarithmicArrayResizer<object>();
            Assert.False(resizer.CanDecreaseArray(resizer.MinSize - 1, 1));
        }

        [Theory]
        [InlineData(20, 11)]
        [InlineData(20, 20)]
        [InlineData(20, 15)]
        public void CanDecreaseArray_SaturationGreaterThanHalfLength_False(int arrayLength, int currentSaturation)
        {
            var resizer = new LogarithmicArrayResizer<object>();
            Assert.False(resizer.CanDecreaseArray(arrayLength, currentSaturation));
        }

        [Theory]
        [InlineData(20, -1)]
        [InlineData(20, 10)]
        [InlineData(20, 5)]
        public void CanDecreaseArray_SaturationLessThanHalfLength_True(int arrayLength, int currentSaturation)
        {
            var resizer = new LogarithmicArrayResizer<object>();
            Assert.True(resizer.CanDecreaseArray(arrayLength, currentSaturation));
        }

        [Fact]
        public void CanIncreaseArray_NegativeLength_ThrowsArgumentOutOfRangeException()
        {
            var resizer = new LogarithmicArrayResizer<object>();
            Assert.Throws<ArgumentOutOfRangeException>("arrayLength", () => resizer.CanIncreaseArray(-5, 2));
        }

        [Fact]
        public void CanIncreaseArray_SaturationGreaterThanLength_ThrowsArgumentOutOfRangeException()
        {
            var resizer = new LogarithmicArrayResizer<object>();
            Assert.Throws<ArgumentOutOfRangeException>("currentSaturation", () => resizer.CanIncreaseArray(2, 3));
        }

        [Theory]
        [InlineData(20, -1)]
        [InlineData(20, 19)]
        [InlineData(20, 5)]
        public void CanIncreaseArray_SaturationLessThanLength_False(int arrayLength, int currentSaturation)
        {
            var resizer = new LogarithmicArrayResizer<object>();
            Assert.False(resizer.CanIncreaseArray(arrayLength, currentSaturation));
        }

        [Theory]
        [InlineData(10, 10)]
        [InlineData(20, 20)]
        public void CanIncreaseArray_SaturationEqualsLength_True(int arrayLength, int currentSaturation)
        {
            var resizer = new LogarithmicArrayResizer<object>();
            Assert.True(resizer.CanIncreaseArray(arrayLength, currentSaturation));
        }

        [Fact]
        public void IncreaseArray_NullArray_ThrowsArgumentNullException()
        {
            var resizer = new LogarithmicArrayResizer<object>();
            Assert.Throws<ArgumentNullException>("sourceArray", () => resizer.IncreaseArray(null, 5));
        }

        [Theory]
        [InlineData(1, 1)]
        [InlineData(10, 7)]
        [InlineData(10, 10)]
        [InlineData(20, 20)]
        public void IncreaseArray_LengthCorrectAndDataCopiedCorrect(int arrayLength, int currentSaturation)
        {
            int[] array = new int[arrayLength];
            int[] expectedArray = new int[arrayLength * 2];
            for (int i = 0; i < currentSaturation; i++)
            {
                array[i] = i + 1;
                expectedArray[i] = i + 1;
            }

            var resizer = new LogarithmicArrayResizer<int>();
            var actualArray = resizer.IncreaseArray(array, currentSaturation);

            Assert.Equal(expectedArray, actualArray);
        }

        [Fact]
        public void DecreaseArray_NullArray_ThrowsArgumentNullException()
        {
            var resizer = new LogarithmicArrayResizer<object>();
            Assert.Throws<ArgumentNullException>("sourceArray", () => resizer.DecreaseArray(null, 5));
        }

        [Theory]
        [InlineData(20, 10)]
        [InlineData(30, 15)]
        [InlineData(20, 7)]
        [InlineData(15, 7)]
        public void DecreaseArray_LengthCorrectAndDataCopiedCorrect(int arrayLength, int currentSaturation)
        {
            int[] array = new int[arrayLength];
            int[] expectedArray = new int[arrayLength / 2];
            for (int i = 0; i < currentSaturation; i++)
            {
                array[i] = i + 1;
                expectedArray[i] = i + 1;
            }

            var resizer = new LogarithmicArrayResizer<int>();
            var actualArray = resizer.DecreaseArray(array, currentSaturation);

            Assert.Equal(expectedArray, actualArray);
        }

        [Theory]
        [InlineData(20, 11)]
        [InlineData(20, 19)]
        [InlineData(15, 8)]
        public void DecreaseArray_SaturationGreaterThanHalfLength_ThrowsInvalidOperationException(int arrayLength, int currentSaturation)
        {
            int[] array = new int[arrayLength];

            var resizer = new LogarithmicArrayResizer<int>();
            Assert.Throws<InvalidOperationException>(() => resizer.DecreaseArray(array, currentSaturation));
        }

        [Theory]
        [InlineData(10, 3)]
        public void DecreaseArray_LengthEqualsMinLength_ThrowsInvalidOperationException(int arrayLength, int currentSaturation)
        {
            int[] array = new int[arrayLength];

            var resizer = new LogarithmicArrayResizer<int>();
            Assert.Throws<InvalidOperationException>(() => resizer.DecreaseArray(array, currentSaturation));
        }
    }
}
