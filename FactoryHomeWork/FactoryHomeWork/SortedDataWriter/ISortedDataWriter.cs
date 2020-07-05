using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FactoryHomeWork
{
    /// <summary>
    /// Интерфейс конкретной фабрики писателей отсортированных данных.
    /// </summary>
    public interface ISortedDataWriter
    {
        /// <summary>
        /// Записать данные, отсортированные пузырьковой сортировкой.
        /// </summary>
        /// <param name="data">Данные.</param>
        /// <param name="writer">Поток записи.</param>
        void WriteBubbleSortedData(string[] data, TextWriter writer);

        /// <summary>
        /// Записать данные, отсортированные сортировкой простыми вставками.
        /// </summary>
        /// <param name="data">Данные.</param>
        /// <param name="writer">Поток записи.</param>
        void WriteInsertionSortedData(string[] data, TextWriter writer);

        /// <summary>
        /// Записать данные, отсортированные сортировкой простым выбором.
        /// </summary>
        /// <param name="data">Данные.</param>
        /// <param name="writer">Поток записи.</param>
        void WriteSelectionSortedData(string[] data, TextWriter writer);
    }
}
