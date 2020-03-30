using System;
using System.Collections.Generic;
using System.Text;

namespace CustomString
{
    /// <summary>
    /// Интерфейс классов-стратегий изменения размера массива.
    /// </summary>
    /// <typeparam name="T">Тип объектов массива.</typeparam>
    public interface IArrayResizer<T>
    {                
        /// <summary>
        /// Проверить, возможно ли уменьшение размера.
        /// </summary>
        /// <param name="arrayLength">Длина массива.</param>
        /// <param name="currentSaturation">Текущее наполнение массива.</param>
        /// <returns>true, если уменьшение возможно, false - иначе.</returns>
        bool CanDecreaseArray(int arrayLength, int currentSaturation);

        /// <summary>
        /// Проверить, возможно ли увеличение размера.
        /// </summary>
        /// <param name="arrayLength">Длина массива.</param>
        /// <param name="currentSaturation">Текущее наполнение массива.</param>
        /// <returns>true, если увеличение возможно, false - иначе.</returns>
        bool CanIncreaseArray(int arrayLength, int currentSaturation);

        /// <summary>
        /// Уменьшить размер массива.
        /// </summary>
        /// <param name="sourceArray">Исходный массив.</param>
        /// <param name="currentSaturation">Текущее наполнение массива.</param>
        /// <returns>Новый массив уменьшенного размера.</returns>
        T[] DecreaseArray(T[] sourceArray, int currentSaturation);

        /// <summary>
        /// Увеличить размер массива.
        /// </summary>
        /// <param name="sourceArray">Исходный массив.</param>
        /// <param name="currentSaturation">Текущее наполнение массива.</param>
        /// <returns>Новый массив увеличенного размера.</returns>
        T[] IncreaseArray(T[] sourceArray, int currentSaturation);
    }
}
