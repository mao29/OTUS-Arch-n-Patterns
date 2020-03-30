using System;
using System.Collections.Generic;
using System.Text;

namespace CustomString
{
    /// <summary>
    /// 
    /// </summary>
    public interface ISubstringableCustomString : ICustomString
    {
        /// <summary>
        /// Получить набор символов строки начиная с заданной позиции.
        /// </summary>
        /// <param name="start">Стартовая позиция.</param>
        /// <returns>Набор символов строки начиная с заданной позиции.</returns>
        char[] GetSubstring(int start);

        /// <summary>
        /// Получить набор символов строки определенной длины начиная с заданной позиции.
        /// </summary>
        /// <param name="start">Стартовая позиция.</param>
        /// <param name="length">Требуемое количество символов.</param>
        /// <returns>Набор символов строки определенной длины начиная с заданной позиции.</returns>
        char[] GetSubstring(int start, int length);
    }
}
