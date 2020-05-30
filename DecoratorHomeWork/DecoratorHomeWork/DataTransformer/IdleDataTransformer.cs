using System;
using System.Collections.Generic;
using System.Text;

namespace DecoratorHomeWork
{
    /// <summary>
    /// Преобразователь данных, который никак не изменяет данные.
    /// </summary>
    public class IdleDataTransformer : IDataTransformer
    {
        /// <inheritdoc/>
        public string[] TransformData(string[] data)
        {
            return data;
        }
    }
}
