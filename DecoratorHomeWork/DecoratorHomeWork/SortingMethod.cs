using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorHomeWork
{
    /// <summary>
    /// Поддерживаемые алгоритмы сортировки.
    /// </summary>
    public enum SortingMethod
    {
        /// <summary>
        /// Пузырьковая.
        /// </summary>
        Bubble,

        /// <summary>
        /// Простым выбором.
        /// </summary>
        Selection,

        /// <summary>
        /// Простыми вставками.
        /// </summary>
        Insertion
    }
}
