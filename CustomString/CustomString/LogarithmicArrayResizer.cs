using System;
using System.Collections.Generic;
using System.Text;

namespace CustomString
{
    public class LogarithmicArrayResizer<T> : IArrayResizer<T>
    {
        /// <summary>
        /// Минимальный размер массива.
        /// </summary>
        public int MinSize { get; } = 10;

        /// <summary>
        /// Проверить, возможно ли уменьшение размера.
        /// </summary>
        /// <param name="arrayLength">Длина массива.</param>
        /// <param name="currentSaturation">Текущее наполнение массива.</param>
        /// <returns>true, если уменьшение возможно, false - иначе.</returns>
        public bool CanDecreaseArray(int arrayLength, int currentSaturation)
        {
            if (arrayLength < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayLength), "Array length should be greater than zero.");
            }

            if (currentSaturation > arrayLength)
            {
                throw new ArgumentOutOfRangeException(nameof(currentSaturation), "Current saturation should be not greater than array length.");
            }

            return arrayLength > MinSize && currentSaturation <= arrayLength / 2;
        }

        /// <summary>
        /// Проверить, возможно ли увеличение размера.
        /// </summary>
        /// <param name="arrayLength">Длина массива.</param>
        /// <param name="currentSaturation">Текущее наполнение массива.</param>
        /// <returns>true, если увеличение возможно, false - иначе.</returns>
        public bool CanIncreaseArray(int arrayLength, int currentSaturation)
        {
            if (arrayLength < 0)
            {
                throw new ArgumentOutOfRangeException(nameof(arrayLength), "Array length should be greater than zero.");
            }

            if (currentSaturation > arrayLength)
            {
                throw new ArgumentOutOfRangeException(nameof(currentSaturation), "Current saturation should be not greater than array length.");
            }

            return currentSaturation == arrayLength;
        }

        /// <summary>
        /// Уменьшить размер массива.
        /// </summary>
        /// <param name="sourceArray">Исходный массив.</param>
        /// <param name="currentSaturation">Текущее наполнение массива.</param>
        /// <returns>Новый массив уменьшенного размера.</returns>
        public T[] DecreaseArray(T[] sourceArray, int currentSaturation)
        {
            if (sourceArray == null)
            {
                throw new ArgumentNullException(nameof(sourceArray));
            }

            if (!CanDecreaseArray(sourceArray.Length, currentSaturation))
            {
                throw new InvalidOperationException("Can't decrease array with given length and current saturation.");
            }

            T[] decreasedArray = new T[sourceArray.Length / 2];
            Array.Copy(sourceArray, decreasedArray, currentSaturation);

            return decreasedArray;
        }

        /// <summary>
        /// Увеличить размер массива.
        /// </summary>
        /// <param name="sourceArray">Исходный массив.</param>
        /// <param name="currentSaturation">Текущее наполнение массива.</param>
        /// <returns>Новый массив увеличенного размера.</returns>
        public T[] IncreaseArray(T[] sourceArray, int currentSaturation)
        {
            if (sourceArray == null)
            {
                throw new ArgumentNullException(nameof(sourceArray));
            }

            T[] increasedArray = new T[sourceArray.Length * 2];
            Array.Copy(sourceArray, increasedArray, currentSaturation);

            return increasedArray;
        }
    }
}
