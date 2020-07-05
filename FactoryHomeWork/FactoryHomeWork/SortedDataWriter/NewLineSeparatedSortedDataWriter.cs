using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FactoryHomeWork
{
    /// <summary>
    /// Фабрика писателей отсортированных данных в файл с переносом строки в качестве разделителя.
    /// </summary>
    public class NewLineSeparatedSortedDataWriter : BaseSortedDataWriter
    {
        /// <inheritdoc/>
        protected override IDataWriter GetDataWriter(TextWriter writer)
        {
            return new NewLineSeparatedDataWriter(writer);
        }
    }
}
