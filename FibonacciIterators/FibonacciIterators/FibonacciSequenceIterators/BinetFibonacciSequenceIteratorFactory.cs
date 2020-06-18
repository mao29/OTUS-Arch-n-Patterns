using System;
using System.Collections.Generic;
using System.Text;

namespace FibonacciIterators
{
    /// <summary>
    /// Фабрика итераторов по последовательности Фибоначчи, использующая вычислитель, работающий по формуле Бине.
    /// </summary>
    public class BinetFibonacciSequenceIteratorFactory : IFibonacciSequenceIteratorFactory
    {
        /// <inheritdoc/>
        public BackwardFibonacciSequenceIterator GetBackwardFibonacciSequenceIterator(int start, int end)
        {
            var calculator = new BinetFibonacciCalculator();
            return new BackwardFibonacciSequenceIterator(start, end, calculator);
        }

        /// <inheritdoc/>
        public ForwardFibonacciSequenceIterator GetForwardFibonacciSequenceIterator(int start, int end)
        {
            var calculator = new BinetFibonacciCalculator();
            return new ForwardFibonacciSequenceIterator(start, end, calculator);
        }
    }
}
