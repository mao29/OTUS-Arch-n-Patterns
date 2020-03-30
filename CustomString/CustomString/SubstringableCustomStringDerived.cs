using System;
using System.Collections.Generic;
using System.Text;

namespace CustomString
{
    /// <summary>
    /// Реализация <see cref="ISubstringableCustomString"/> с использованием наследования.
    /// </summary>
    public class SubstringableCustomStringDerived : CustomString, ISubstringableCustomString
    {
        /// <summary>
        /// Создать пустую строку.
        /// </summary>
        public SubstringableCustomStringDerived() : base(new char[0])
        {
        }

        /// <summary>
        /// Создать строку с одним символом.
        /// </summary>
        /// <param name="character">Единственный символ строки.</param>
        public SubstringableCustomStringDerived(char character) : base(new char[] { character })
        {
        }

        /// <summary>
        /// Создать строку с заданными символами.
        /// </summary>
        /// <param name="characters">Символы строки.</param>
        public SubstringableCustomStringDerived(char[] characters) : base(characters)
        {
        }

        /// <summary>
        /// Получить набор символов строки начиная с заданной позиции.
        /// </summary>
        /// <param name="start">Стартовая позиция.</param>
        /// <returns>Набор символов строки начиная с заданной позиции.</returns>
        public char[] GetSubstring(int start)
        {
            if (start < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(start), "Start index should be not less than zero.");
            }

            if (start >= _length)
            {
                throw new ArgumentOutOfRangeException(nameof(start), "Start index should be less than string length.");
            }

            var resultLength = _length - start;
            var resultArray = new char[resultLength];
            Array.Copy(_characters, start, resultArray, 0, resultLength);

            return resultArray;
        }

        /// <summary>
        /// Получить набор символов строки определенной длины начиная с заданной позиции.
        /// </summary>
        /// <param name="start">Стартовая позиция.</param>
        /// <param name="length">Требуемое количество символов.</param>
        /// <returns>Набор символов строки определенной длины начиная с заданной позиции.</returns>
        public char[] GetSubstring(int start, int length)
        {
            if (start < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(start), "Start index should be not less than zero.");
            }

            if (length <= 0)
            {
                throw new ArgumentOutOfRangeException(nameof(length), "Start index should be greater than zero.");
            }

            if (start >= _length)
            {
                throw new ArgumentOutOfRangeException(nameof(start), "Start index should be less than string length.");
            }

            if (start + length > _length)
            {
                throw new ArgumentOutOfRangeException("Start index plus length must be not greater than string length.");
            }

            var resultArray = new char[length];
            Array.Copy(_characters, start, resultArray, 0, length);

            return resultArray;
        }
    }
}
