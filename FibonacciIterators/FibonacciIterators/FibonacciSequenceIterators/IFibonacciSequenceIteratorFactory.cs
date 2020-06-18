using System;
using System.Collections.Generic;
using System.Text;

namespace FibonacciIterators
{
    /// <summary>
    /// Фабрика итераторов по последовательности Фибоначчи.
    /// </summary>
    interface IFibonacciSequenceIteratorFactory
    {
        /// <summary>
        /// Получить итератор по последовательности Фибоначчи в порядке возрастания.
        /// </summary>
        /// <param name="start">Стартовый элемент последовательности.</param>
        /// <param name="end">Конечный элемент последовательности.</param>
        /// <returns>Итератор по последовательности Фибоначчи в порядке возрастания.</returns>
        ForwardFibonacciSequenceIterator GetForwardFibonacciSequenceIterator(int start, int end);

        /// <summary>
        /// Получить итератор по последовательности Фибоначчи в порядке убывания.
        /// </summary>
        /// <param name="start">Стартовый элемент последовательности.</param>
        /// <param name="end">Конечный элемент последовательности.</param>
        /// <returns>Итератор по последовательности Фибоначчи в порядке убывания.</returns>
        BackwardFibonacciSequenceIterator GetBackwardFibonacciSequenceIterator(int start, int end);
    }
}
