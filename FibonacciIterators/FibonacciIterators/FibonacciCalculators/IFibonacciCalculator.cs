using System;
using System.Collections.Generic;
using System.Text;

namespace FibonacciIterators
{
    /// <summary>
    /// Класс-вычислитель чисел Фибоначчи.
    /// </summary>
    public interface IFibonacciCalculator
    {
        /// <summary>
        /// Вычислить n-ое число Фибоначчи.
        /// </summary>
        /// <param name="n">Номер числа Фибоначчи.</param>
        /// <returns>n-ое число Фибоначчи.</returns>
        int CalculateNthNumber(int n);
    }
}
