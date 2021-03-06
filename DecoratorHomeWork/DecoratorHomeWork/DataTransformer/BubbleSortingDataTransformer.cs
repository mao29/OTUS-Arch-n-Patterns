﻿using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorHomeWork
{
    /// <summary>
    /// Преобразователь-декоратор, сортирующий данные пузырьковой сортировкой.
    /// </summary>
    public class BubbleSortingDataTransformer : BaseSortingDataTransformer
    {
        /// <summary>
        /// Создать преобразователь-декоратор, сортирующий данные пузырьковой сортировкой.
        /// </summary>
        /// <param name="innerTransformer">Оборачиваемый преобразователь данных.</param>
        public BubbleSortingDataTransformer(IDataTransformer innerTransformer) : base(innerTransformer)
        { }

        /// <inheritdoc />
        protected override string[] SortData(string[] data)
        {
            return BubbleSort(data);
        }

        /// <summary>
        /// Отсортировать данные пузырьковой сортировкой.
        /// </summary>
        /// <param name="data">Данные.</param>
        /// <returns>Данные, отсортированные пузырьковой сортировкой.</returns>
        private string[] BubbleSort(string[] data)
        {
            var sortedData = data;

            var n = data.Length;
            bool swapped;
            do
            {
                swapped = false;
                for (int i = 1; i < n; i++)
                {
                    if (data[i - 1].CompareTo(data[i]) > 0)
                    {
                        Swap(sortedData, i - 1, i);
                        swapped = true;
                    }
                }
            }
            while (swapped);

            return sortedData;
        }        
    }
}
