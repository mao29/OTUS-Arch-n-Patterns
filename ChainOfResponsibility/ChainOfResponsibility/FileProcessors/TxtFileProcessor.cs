using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Обработчик txt-файлов.
    /// </summary>
    public class TxtFileProcessor : BaseFileProcessor
    {
        /// <summary>
        /// Создать обработчик txt-файлов.
        /// </summary>
        /// <param name="logger">Логгер сообщений</param>
        public TxtFileProcessor(ILogger logger) : base(logger)
        { }

        /// <inheritdoc/>
        protected override bool CanHandle(string filePath)
        {
            return Path.GetExtension(filePath).Equals(".txt", StringComparison.InvariantCultureIgnoreCase);
        }

        /// <inheritdoc/>
        protected override void DoProcessFile(string filePath)
        {
            ReportProcessing($"Обработчик TXT получил файл {filePath}");
        }
    }
}
