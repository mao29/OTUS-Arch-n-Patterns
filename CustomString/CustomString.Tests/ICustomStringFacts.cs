using System;
using Xunit;

namespace CustomString.Tests
{
    /// <summary>
    /// Базовый класс с тестами функциональности <see cref="ICustomString"/>.
    /// </summary>
    public abstract class ICustomStringFacts
    {
        /// <summary>
        /// Создать экземпляр пустой <see cref="ICustomString"/>.
        /// </summary>
        /// <returns>Экземпляр пустой <see cref="ICustomString"/>.</returns>
        protected abstract ICustomString GetCustomString();

        /// <summary>
        /// Создать экземпляр <see cref="ICustomString"/> с одним символом.
        /// </summary>
        /// <param name="character">Символ.</param>
        /// <returns>Экземпляр <see cref="ICustomString"/> с одним символом.</returns>
        protected abstract ICustomString GetCustomString(char character);

        /// <summary>
        /// Создать экземпляр <see cref="ICustomString"/> с заданными символами.
        /// </summary>
        /// <param name="characters">Символы.</param>
        /// <returns>Экземпляр <see cref="ICustomString"/> с заданными символами.</returns>
        protected abstract ICustomString GetCustomString(char[] characters);

        [Fact]
        public void Constructor_EmptyString_ZeroLength()
        {
            var str = GetCustomString();
            Assert.Equal(0, str.GetLength());
        }

        [Fact]
        public void Constructor_SingleCharString_LengthIs1()
        {
            var str = GetCustomString('a');
            Assert.Equal(1, str.GetLength());
        }

        [Fact]
        public void Constructor_SingleCharString_ResultSingleCharArray()
        {
            var str = GetCustomString('a');
            var actualChars = str.GetString();
            var expectedChars = new char[] { 'a' };
            Assert.Equal(expectedChars, actualChars);
        }

        [Fact]
        public void Constructor_EmptyArrayString_ZeroLength()
        {
            var sourceChars = new char[0];

            var str = GetCustomString(sourceChars);

            Assert.Equal(0, str.GetLength());
        }

        [Fact]
        public void Constructor_EmptyArrayString_ResultIsEmptyArray()
        {
            var sourceChars = new char[0];

            var str = GetCustomString(sourceChars);

            Assert.Equal(sourceChars, str.GetString());
        }

        [Fact]
        public void Constructor_NonEmptyArrayString_LengthCorrect()
        {
            var sourceChars = new char[] { 'H', 'e', 'l', 'l', 'o', '!' };

            var str = GetCustomString(sourceChars);

            Assert.Equal(6, str.GetLength());
        }

        [Fact]
        public void Constructor_NonEmptyArrayString_ResultArrayCorrect()
        {
            var sourceChars = new char[] { 'H', 'e', 'l', 'l', 'o', '!' };

            var str = GetCustomString(sourceChars);

            Assert.Equal(sourceChars, str.GetString());
        }

        [Fact]
        public void Constructor_NullPassed_ExceptionThrown()
        {
            Assert.Throws<ArgumentNullException>("characters", () => GetCustomString(null));
        }

        [Fact]
        public void Clear_EmptyString_ReturnsEmptyArray()
        {            
            var str = GetCustomString();

            str.Clear();

            Assert.Equal(new char[0], str.GetString());
        }

        [Fact]
        public void Clear_EmptyString_LengthBecomesZero()
        {
            var str = GetCustomString();

            str.Clear();

            Assert.Equal(0, str.GetLength());
        }

        [Fact]
        public void Clear_NonEmptyString_ReturnsEmptyArray()
        {
            var sourceChars = new char[] { 'H', 'e', 'l', 'l', 'o', '!' };

            var str = GetCustomString(sourceChars);

            str.Clear();

            Assert.Equal(new char[0], str.GetString());
        }

        [Fact]
        public void Clear_NonEmptyString_LengthBecomesZero()
        {
            var sourceChars = new char[] { 'H', 'e', 'l', 'l', 'o', '!' };

            var str = GetCustomString(sourceChars);

            str.Clear();

            Assert.Equal(0, str.GetLength());
        }
    }
}
