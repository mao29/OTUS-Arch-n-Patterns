using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryHomeWork
{
    /// <summary>
    /// Интерфейс сортирователя данных.
    /// </summary>
    public interface IDataSorter
    {
        /// <summary>
        /// Отсортировать данные.
        /// </summary>
        /// <param name="data">Данные.</param>
        /// <returns>Отсортированные данные.</returns>
        string[] SortData(string[] data);
    }
}
