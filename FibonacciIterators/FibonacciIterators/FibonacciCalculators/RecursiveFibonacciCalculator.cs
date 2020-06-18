using System;
using System.Collections.Generic;
using System.Text;

namespace FibonacciIterators
{
    /// <summary>
    /// Класс-вычислитель чисел Фибоначчи с помощью рекурсии.
    /// </summary>
    public class RecursiveFibonacciCalculator : IFibonacciCalculator
    {
        /// <inheritdoc/>
        public int CalculateNthNumber(int n)
        {
            if (n == 1 || n == 2)
            {
                return 1;
            }

            return CalculateNthNumber(n - 1) + CalculateNthNumber(n - 2);
        }
    }
}
