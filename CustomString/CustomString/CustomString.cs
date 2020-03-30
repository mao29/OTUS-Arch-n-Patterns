using System;
using System.Collections.Generic;
using System.Text;

namespace CustomString
{
    /// <summary>
    /// Пользовательская реализация строки.
    /// </summary>
    public class CustomString : ICustomString
    {
        /// <summary>
        /// Символы строки.
        /// </summary>
        protected char[] _characters;

        /// <summary>
        /// Длина строки.
        /// </summary>
        protected int _length;

        /// <summary>
        /// Создать пустую строку.
        /// </summary>
        public CustomString() : this(new char[0])
        {
        }

        /// <summary>
        /// Создать строку с одним символом.
        /// </summary>
        /// <param name="character">Единственный символ строки.</param>
        public CustomString(char character) : this(new char[] { character })
        {
        }

        /// <summary>
        /// Создать строку с заданными символами.
        /// </summary>
        /// <param name="characters">Символы строки.</param>
        public CustomString(char[] characters)
        {
            if (characters == null)
            {
                throw new ArgumentNullException(nameof(characters));
            }

            _length = characters.Length;
            _characters = new char[_length];
            Array.Copy(characters, _characters, _length);
        }

        /// <summary>
        /// Очистить строку.
        /// </summary>
        public void Clear()
        {
            _length = 0;
            _characters = new char[0];
        }

        /// <summary>
        /// Получить длину строки.
        /// </summary>
        /// <returns>Длина строки.</returns>
        public int GetLength()
        {
            return _length;
        }

        /// <summary>
        /// Получить символы строки.
        /// </summary>
        /// <returns>Символы строки.</returns>
        public char[] GetString()
        {
            char[] resultChar = new char[_length];
            Array.Copy(_characters, resultChar, _length);

            return resultChar;
        }
    }
}
