using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FactoryHomeWork
{
    /// <summary>
    /// Фабрика писателей отсортированных данных в файл с пробелом в качестве разделителя.
    /// </summary>
    public class SpaceSeparatedSortedDataWriter : BaseSortedDataWriter
    {
        /// <inheritdoc/>
        protected override IDataWriter GetDataWriter(TextWriter writer)
        {
            return new SpaceSeparatedDataWriter(writer);
        }
    }
}
