using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FactoryHomeWork
{
    /// <summary>
    /// Писатель данных в файл с пробелом в качестве разделителя.
    /// </summary>
    public class SpaceSeparatedDataWriter : SeparatedDataWriter
    {
        /// <summary>
        /// Создать писатель данных в файл с пробелом в качестве разделителя.
        /// </summary>
        /// <param name="writer">Поток записи.</param>
        public SpaceSeparatedDataWriter(TextWriter writer) 
            : base(writer, " ")
        { }
    }
}
