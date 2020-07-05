using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FactoryHomeWork
{
    /// <summary>
    /// Фабрика писателей отсортированных данных в файл с табуляцией в качестве разделителя.
    /// </summary>
    public class TabSeparatedSortedDataWriter : BaseSortedDataWriter
    {
        /// <inheritdoc/>
        protected override IDataWriter GetDataWriter(TextWriter writer)
        {
            return new TabSeparatedDataWriter(writer);
        }
    }
}
