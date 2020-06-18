using System;
using System.Collections.Generic;
using System.Text;

namespace FibonacciIterators
{
    /// <summary>
    /// Фабрика итераторов по последовательности Фибоначчи, использующая вычислитель, вычисляющий с помощью рекурсии.
    /// </summary>
    public class RecursiveFibonacciSequenceIteratorFactory : IFibonacciSequenceIteratorFactory
    {
        /// <inheritdoc/>
        public BackwardFibonacciSequenceIterator GetBackwardFibonacciSequenceIterator(int start, int end)
        {
            var calculator = new RecursiveFibonacciCalculator();
            return new BackwardFibonacciSequenceIterator(start, end, calculator);
        }

        /// <inheritdoc/>
        public ForwardFibonacciSequenceIterator GetForwardFibonacciSequenceIterator(int start, int end)
        {
            var calculator = new RecursiveFibonacciCalculator();
            return new ForwardFibonacciSequenceIterator(start, end, calculator);
        }
    }
}
