using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorHomeWork
{
    /// <summary>
    /// Преобразователь-декоратор, сортирующий передаваемые данные.
    /// </summary>
    public abstract class BaseSortingDataTransformer : IDataTransformer
    {
        /// <summary>
        /// Оборачиваемый преобразователь данных.
        /// </summary>
        protected IDataTransformer _innerTransformer;

        /// <summary>
        /// Создать преобразователь-декоратор, сортирующий передаваемые данные.
        /// </summary>
        /// <param name="innerTransformer">Оборачиваемый преобразователь данных.</param>
        public BaseSortingDataTransformer(IDataTransformer innerTransformer)
        {
            _innerTransformer = innerTransformer ?? throw new ArgumentNullException(nameof(innerTransformer));
        }

        /// <inheritdoc />
        public string[] TransformData(string[] data)
        {
            var transformedData = _innerTransformer.TransformData(data);

            if (transformedData != null)
            {
                transformedData = SortData(transformedData);
            }

            return transformedData;
        }

        /// <summary>
        /// Отсортировать данные.
        /// </summary>
        /// <param name="data">Данные.</param>
        /// <returns>Отсортированные данные.</returns>
        protected abstract string[] SortData(string[] data);

        /// <summary>
        /// Поменять элементы в массиве местами.
        /// </summary>
        /// <param name="data">Массив.</param>
        /// <param name="index1">Индекс первого элемента.</param>
        /// <param name="index2">Индекс второго элемента.</param>
        protected void Swap(string[] data, int index1, int index2)
        {
            var temp = data[index1];
            data[index1] = data[index2];
            data[index2] = temp;
        }
    }
}