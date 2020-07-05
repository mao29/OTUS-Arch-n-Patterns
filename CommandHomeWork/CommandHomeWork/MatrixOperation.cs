using System;
using System.Collections.Generic;
using System.Text;

namespace CommandHomeWork
{
    /// <summary>
    /// Поддерживаемые операции над матрицами.
    /// </summary>
    public enum MatrixOperation
    {
        /// <summary>
        /// Транспонирование.
        /// </summary>
        Transponate,

        /// <summary>
        /// Вычисление определителя.
        /// </summary>
        Determinant,

        /// <summary>
        /// Сложение.
        /// </summary>
        Add
    }
}
