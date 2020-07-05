using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FactoryHomeWork
{
    /// <summary>
    /// Базовый класс для фабрики писателей отсортированных данных.
    /// </summary>
    public abstract class BaseSortedDataWriter : ISortedDataWriter
    {
        /// <summary>
        /// Получить писатель данных в файл.
        /// </summary>
        /// <param name="writer">Поток записи.</param>
        /// <returns>Писатель данных в файл.</returns>
        protected abstract IDataWriter GetDataWriter(TextWriter writer);

        /// <inheritdoc/>
        public void WriteBubbleSortedData(string[] data, TextWriter writer)
        {
            writer.WriteLine("Used bubble sort");
            var sorter = new BubbleDataSorter();

            WriteSortedData(data, sorter, writer);
        }

        /// <inheritdoc/>
        public void WriteInsertionSortedData(string[] data, TextWriter writer)
        {
            writer.WriteLine("Used insertion sort");            
            var sorter = new InsertionDataSorter();

            WriteSortedData(data, sorter, writer);
        }

        /// <inheritdoc/>
        public void WriteSelectionSortedData(string[] data, TextWriter writer)
        {
            writer.WriteLine("Used selection sort");            
            var sorter = new SelectionDataSorter();
            
            WriteSortedData(data, sorter, writer);
        }

        /// <summary>
        /// Записать отсортированные данные в файл.
        /// </summary>
        /// <param name="data">Исходные данные.</param>
        /// <param name="sorter">Сортирователь данных.</param>
        /// <param name="writer">Поток записи.</param>
        private void WriteSortedData(string[] data, IDataSorter sorter, TextWriter writer)
        {
            var sortedData = sorter.SortData(data);

            var dataWriter = GetDataWriter(writer);
            dataWriter.WriteData(sortedData);
        }
    }
}
