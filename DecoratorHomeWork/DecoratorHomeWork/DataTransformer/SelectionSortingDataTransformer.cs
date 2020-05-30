﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorHomeWork
{
    /// <summary>
    /// Преобразователь-декоратор, сортирующий данные простым выбором.
    /// </summary>
    public class SelectionSortingDataTransformer : BaseSortingDataTransformer
    {
        /// <summary>
        /// Создать преобразователь-декоратор, сортирующий данные простым выбором.
        /// </summary>
        /// <param name="innerTransformer">Оборачиваемый преобразователь данных.</param>
        public SelectionSortingDataTransformer(IDataTransformer innerTransformer) : base(innerTransformer)
        { }

        /// <inheritdoc />
        protected override string[] SortData(string[] data)
        {
            return SelectionSort(data);
        }

        /// <summary>
        /// Отсортировать данные простым выбором.
        /// </summary>
        /// <param name="data">Данные.</param>
        /// <returns>Данные, отсортированные простым выбором.</returns>
        private string[] SelectionSort(string[] data)
        {
            var sortedData = data;

            for (int i = 0; i < sortedData.Length - 1; i++)
            {
                int jMin = i;
                for (int j = i + 1; j < sortedData.Length; j++)
                {
                    if (sortedData[j].CompareTo(sortedData[jMin]) < 0)
                    {
                        jMin = j;
                    }
                }

                if (jMin != i)
                {
                    Swap(sortedData, i, jMin);
                }
            }

            return sortedData;
        }
    }
}
