using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FactoryHomeWork
{
    /// <summary>
    /// Писатель данных в файл с табуляцией в качестве разделителя.
    /// </summary>
    public class TabSeparatedDataWriter : SeparatedDataWriter
    {
        /// <summary>
        /// Создать писатель данных в файл с табуляцией в качестве разделителя.
        /// </summary>
        /// <param name="writer">Поток записи.</param>
        public TabSeparatedDataWriter(TextWriter writer) :
            base(writer, "\t")
        { }
    }
}
