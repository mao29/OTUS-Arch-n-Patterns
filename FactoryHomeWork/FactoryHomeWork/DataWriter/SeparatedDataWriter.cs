using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FactoryHomeWork
{
    /// <summary>
    /// Базовый класс для писателей данных в файл с разделителем.
    /// </summary>
    public abstract class SeparatedDataWriter : IDataWriter
    {
        /// <summary>
        /// Поток записи.
        /// </summary>
        private readonly TextWriter _writer;

        /// <summary>
        /// Используемый разделитель.
        /// </summary>
        public string Separator { get; }

        /// <summary>
        /// Создать писатель данных в файл с разделителем.
        /// </summary>
        /// <param name="writer">Поток записи.</param>
        /// <param name="separator">Разделитель.</param>
        public SeparatedDataWriter(TextWriter writer, string separator)
        {
            _writer = writer;
            Separator = separator;
        }

        /// <inheritdoc/>
        public void WriteData(string[] data)
        {
            if (data == null || data.Length == 0)
            {
                return;
            }

            _writer.Write(data[0]);

            int i = 1;
            while (i < data.Length)
            {
                _writer.Write(Separator);
                _writer.Write(data[i]);
                i++;
            }
        }
    }
}
