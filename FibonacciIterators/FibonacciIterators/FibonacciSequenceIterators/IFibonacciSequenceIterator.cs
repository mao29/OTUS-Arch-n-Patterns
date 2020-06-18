using System;
using System.Collections.Generic;
using System.Text;

namespace FibonacciIterators
{
    /// <summary>
    /// Итератор по последовательноти Фибоначчи.
    /// </summary>
    public interface IFibonacciSequenceIterator
    {
        /// <summary>
        /// Получить следующий элемент последовательности.
        /// </summary>
        /// <returns>Следующий элемент последовательности.</returns>
        int GetNext();

        /// <summary>
        /// Проверить, кончилась ли последовательность.
        /// </summary>
        /// <returns>true, если последовательность кончилась, иначе - false.</returns>
        bool HasMore();
    }
}
