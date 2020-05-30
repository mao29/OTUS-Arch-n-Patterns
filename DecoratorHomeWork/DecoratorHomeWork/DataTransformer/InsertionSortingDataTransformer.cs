using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorHomeWork
{
    /// <summary>
    /// Преобразователь-декоратор, сортирующий данные простыми вставками.
    /// </summary>
    public class InsertionSortingDataTransformer : BaseSortingDataTransformer
    {
        /// <summary>
        /// Создать преобразователь-декоратор, сортирующий данные простыми вставками.
        /// </summary>
        /// <param name="innerTransformer">Оборачиваемый преобразователь данных.</param>
        public InsertionSortingDataTransformer(IDataTransformer innerTransformer) : base(innerTransformer)
        { }

        /// <inheritdoc />
        protected override string[] SortData(string[] data)
        {
            return InsertionSort(data);
        }

        /// <summary>
        /// Отсортировать данные простыми вставками.
        /// </summary>
        /// <param name="data">Данные.</param>
        /// <returns>Данные, отсортированные простыми вставками.</returns>
        private string[] InsertionSort(string[] data)
        {
            var sortedData = data;

            int i = 1;
            while (i < sortedData.Length)
            {
                int j = i;
                while (j > 0 && sortedData[j - 1].CompareTo(sortedData[j]) > 0)
                {
                    Swap(sortedData, j - 1, j);
                    j--;
                }
                i++;
            }

            return sortedData;
        }
    }
}
