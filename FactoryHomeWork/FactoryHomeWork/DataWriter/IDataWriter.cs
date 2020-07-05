using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryHomeWork
{
    /// <summary>
    /// Интерфейс писателя данных в файл.
    /// </summary>
    public interface IDataWriter
    {
        /// <summary>
        /// Записать данные в файл.
        /// </summary>
        /// <param name="data">Данные.</param>
        void WriteData(string[] data);
    }
}
