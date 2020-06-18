using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Обработчик csv-файлов.
    /// </summary>
    public class CsvFileProcessor : BaseFileProcessor
    {
        /// <summary>
        /// Создать обработчик csv-файлов.
        /// </summary>
        /// <param name="logger">Логгер сообщений</param>
        public CsvFileProcessor(ILogger logger) : base(logger)
        { }

        /// <inheritdoc/>
        protected override bool CanHandle(string filePath)
        {
            return Path.GetExtension(filePath).Equals(".csv", StringComparison.InvariantCultureIgnoreCase);
        }

        /// <inheritdoc/>
        protected override void DoProcessFile(string filePath)
        {
            ReportProcessing($"Обработчик CSV получил файл {filePath}");
        }
    }
}
