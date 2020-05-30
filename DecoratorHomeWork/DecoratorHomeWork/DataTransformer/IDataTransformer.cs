using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorHomeWork
{
    /// <summary>
    /// Интерфейс преобразователя данных.
    /// </summary>
    public interface IDataTransformer
    {
        /// <summary>
        /// Преобразовать данные.
        /// </summary>
        /// <param name="data">Данные.</param>
        /// <returns>Преобразованные данные.</returns>
        string[] TransformData(string[] data);
    }
}
