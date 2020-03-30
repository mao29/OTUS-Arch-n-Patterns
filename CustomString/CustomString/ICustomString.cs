using System;
using System.Collections.Generic;
using System.Text;

namespace CustomString
{
    /// <summary>
    /// Пользовательский интерфейс для работы со строкой.
    /// </summary>
    public interface ICustomString
    {
        /// <summary>
        /// Получить содержимое строки в виде массива символов.
        /// </summary>
        /// <returns></returns>
        char[] GetString();

        /// <summary>
        /// Получить длину строки.
        /// </summary>
        /// <returns></returns>
        int GetLength();

        /// <summary>
        /// Очистить строку.
        /// </summary>
        void Clear();
    }
}
