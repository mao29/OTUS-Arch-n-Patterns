using System;
using System.Collections.Generic;
using System.Text;

namespace FibonacciIterators
{
    /// <summary>
    /// Итератор по последовательности Фибоначчи в порядке убывания.
    /// </summary>
    public class BackwardFibonacciSequenceIterator : IFibonacciSequenceIterator
    {
        /// <summary>
        /// Текущий номер числа Фибоначчи в последовательности.
        /// </summary>
        private int _current;

        /// <summary>
        /// Последний номер числа Фибоначчи в последовательности.
        /// </summary>
        private int _last;

        /// <summary>
        /// Класс-вычислитель чисел Фибоначчи.
        /// </summary>
        private IFibonacciCalculator _fibonacciCalculator;

        /// <summary>
        /// Создать итератор по последовательности Фибоначчи в порядке убывания.
        /// </summary>
        /// <param name="start">Стартовый номер числа Фибоначчи.</param>
        /// <param name="end">Конечный номер числа Фибоначчи.</param>
        /// <param name="fibonacciCalculator">Вычислитель чисел Фибоначчи.</param>
        /// <exception cref="ArgumentException"/>
        /// <exception cref="ArgumentNullException"/>
        public BackwardFibonacciSequenceIterator(int start, int end, IFibonacciCalculator fibonacciCalculator)
        {
            if (start < end)
            {
                throw new ArgumentException("Стартовый элемент последовательности должен быть не меньше конечного элемента.");
            }

            if (fibonacciCalculator == null)
            {
                throw new ArgumentNullException(nameof(fibonacciCalculator));
            }

            _current = start;
            _last = end;
            _fibonacciCalculator = fibonacciCalculator;
        }

        /// <inheritdoc/>
        public int GetNext()
        {
            if (!HasMore())
            {
                throw new InvalidOperationException("В последовательности больше нет элементов.");
            }

            _current--;
            return _fibonacciCalculator.CalculateNthNumber(_current + 1);
        }

        /// <inheritdoc/>
        public bool HasMore()
        {
            return _current >= _last;
        }
    }
}
