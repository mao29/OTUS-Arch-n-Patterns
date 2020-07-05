using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FactoryHomeWork
{
    /// <summary>
    /// Писатель данных в файл с переносом строки в качестве разделителя.
    /// </summary>
    public class NewLineSeparatedDataWriter : SeparatedDataWriter
    {
        /// <summary>
        /// Создать писатель данных в файл с переносом строки в качестве разделителя.
        /// </summary>
        /// <param name="writer">Поток записи.</param>
        public NewLineSeparatedDataWriter(TextWriter writer)
            : base(writer, Environment.NewLine)
        { }
    }
}
