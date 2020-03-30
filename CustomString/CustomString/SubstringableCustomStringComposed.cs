using System;
using System.Collections.Generic;
using System.Text;

namespace CustomString
{
    public class SubstringableCustomStringComposed : ISubstringableCustomString
    {
        private CustomString _string;

        /// <summary>
        /// Создать пустую строку.
        /// </summary>
        public SubstringableCustomStringComposed() : this(new char[0])
        {
        }

        /// <summary>
        /// Создать строку с одним символом.
        /// </summary>
        /// <param name="character">Единственный символ строки.</param>
        public SubstringableCustomStringComposed(char character) : this(new char[] { character })
        {
        }

        /// <summary>
        /// Создать строку с заданными символами.
        /// </summary>
        /// <param name="characters">Символы строки.</param>
        public SubstringableCustomStringComposed(char[] characters)
        {
            _string = new CustomString(characters);
        }

        public void Clear()
        {
            _string.Clear();
        }

        public int GetLength()
        {
            return _string.GetLength();
        }

        public char[] GetString()
        {
            return _string.GetString();
        }

        public char[] GetSubstring(int start)
        {
            if (start < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(start), "Start index should be not less than zero.");
            }

            int strLength = _string.GetLength();         

            if (start >= strLength)
            {
                throw new ArgumentOutOfRangeException(nameof(start), "Start index should be less than string length.");
            }

            var resultLength = strLength - start;
            var resultArray = new char[resultLength];
            var characters = _string.GetString();

            Array.Copy(characters, start, resultArray, 0, resultLength);

            return resultArray;
        }

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

            int strLength = _string.GetLength();

            if (start >= strLength)
            {
                throw new ArgumentOutOfRangeException(nameof(start), "Start index should be less than string length.");
            }

            if (start + length > strLength)
            {
                throw new ArgumentOutOfRangeException("Start index plus length must be not greater than string length.");
            }

            var resultArray = new char[length];
            var characters = _string.GetString();
            Array.Copy(characters, start, resultArray, 0, length);

            return resultArray;
        }
    }
}
