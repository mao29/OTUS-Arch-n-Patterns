using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace CustomString.Tests
{
    /// <summary>
    /// Базовый класс с тестами функциональности <see cref="ISubstringableCustomString"/>.
    /// </summary>
    public abstract class ISubstringableCustomStringFacts : ICustomStringFacts
    {
        /// <summary>
        /// Создать экземпляр пустой <see cref="ISubstringableCustomString"/>.
        /// </summary>
        /// <returns>Экземпляр пустой <see cref="ISubstringableCustomString"/>.</returns>
        protected abstract ISubstringableCustomString GetSubstringableCustomString();

        /// <summary>
        /// Создать экземпляр <see cref="ISubstringableCustomString"/> с одним символом.
        /// </summary>
        /// <param name="character">Символ.</param>
        /// <returns>Экземпляр <see cref="ISubstringableCustomString"/> с одним символом.</returns>
        protected abstract ISubstringableCustomString GetSubstringableCustomString(char character);

        /// <summary>
        /// Создать экземпляр <see cref="ISubstringableCustomString"/> с заданными символами.
        /// </summary>
        /// <param name="characters">Символы.</param>
        /// <returns>Экземпляр <see cref="ISubstringableCustomString"/> с заданными символами.</returns>
        protected abstract ISubstringableCustomString GetSubstringableCustomString(char[] characters);

        [Fact]
        public void GetSubstring_NegativeStartIndex_ThrowsArgumentOutOfRangeException()
        {
            var sourceChars = new char[] { 'H', 'e', 'l', 'l', 'o', '!' };

            var str = GetSubstringableCustomString(sourceChars);

            Assert.Throws<ArgumentOutOfRangeException>("start", () => str.GetSubstring(-1));
        }

        [Fact]
        public void GetSubstring_StartIndexMoreThanLength_ThrowsArgumentOutOfRangeException()
        {
            var sourceChars = new char[] { 'H', 'e', 'l', 'l', 'o', '!' };

            var str = GetSubstringableCustomString(sourceChars);

            Assert.Throws<ArgumentOutOfRangeException>("start", () => str.GetSubstring(10));
        }

        [Fact]
        public void GetSubstring_StartIndexZero_ReturnsFullArray()
        {
            var sourceChars = new char[] { 'H', 'e', 'l', 'l', 'o', '!' };
            var str = GetSubstringableCustomString(sourceChars);

            var actualChars = str.GetSubstring(0);

            Assert.Equal(sourceChars, actualChars);
        }

        [Fact]
        public void GetSubstring_StartIndexNonZero_ReturnsSlicedArray()
        {
            var sourceChars = new char[] { 'H', 'e', 'l', 'l', 'o', '!' };
            var str = GetSubstringableCustomString(sourceChars);

            var actualChars = str.GetSubstring(4);

            var expectedChars = new char[] { 'o', '!' };
            Assert.Equal(expectedChars, actualChars);
        }

        [Fact]
        public void GetSubstring_NegativeLength_ThrowsArgumentOutOfRangeException()
        {
            var sourceChars = new char[] { 'H', 'e', 'l', 'l', 'o', '!' };

            var str = GetSubstringableCustomString(sourceChars);

            Assert.Throws<ArgumentOutOfRangeException>("length", () => str.GetSubstring(1, -1));
        }

        [Fact]
        public void GetSubstring_StartPlusLengthMoreThanActualLength_ThrowsArgumentOutOfRangeException()
        {
            var sourceChars = new char[] { 'H', 'e', 'l', 'l', 'o', '!' };

            var str = GetSubstringableCustomString(sourceChars);

            Assert.Throws<ArgumentOutOfRangeException>(() => str.GetSubstring(1, 10));
        }

        [Fact]
        public void GetSubstring_TrimStart_ReturnsTail()
        {
            var sourceChars = new char[] { 'H', 'e', 'l', 'l', 'o', '!' };

            var str = GetSubstringableCustomString(sourceChars);

            var actualChars = str.GetSubstring(1, 5);

            var expectedChars = new char[] { 'e', 'l', 'l', 'o', '!' };
            Assert.Equal(expectedChars, actualChars);
        }

        [Fact]
        public void GetSubstring_TrimEnd_ReturnsHead()
        {
            var sourceChars = new char[] { 'H', 'e', 'l', 'l', 'o', '!' };

            var str = GetSubstringableCustomString(sourceChars);

            var actualChars = str.GetSubstring(0, 3);

            var expectedChars = new char[] { 'H', 'e', 'l' };
            Assert.Equal(expectedChars, actualChars);
        }

        [Fact]
        public void GetSubstring_ReturnsSubstring()
        {
            var sourceChars = new char[] { 'H', 'e', 'l', 'l', 'o', '!' };

            var str = GetSubstringableCustomString(sourceChars);

            var actualChars = str.GetSubstring(1, 3);

            var expectedChars = new char[] { 'e', 'l', 'l' };
            Assert.Equal(expectedChars, actualChars);
        }
    }
}
