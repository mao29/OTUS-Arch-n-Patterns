using System;
using System.Collections.Generic;
using System.Text;

namespace FibonacciIterators
{
    /// <summary>
    /// Класс-вычислитель чисел Фибоначчи по формуле Бине.
    /// </summary>
    public class BinetFibonacciCalculator : IFibonacciCalculator
    {
        /// <inheritdoc/>
        public int CalculateNthNumber(int n)
        {
            return Convert.ToInt32(Math.Pow((1 + Math.Sqrt(5)) / 2, n) / Math.Sqrt(5));
        }
    }
}
