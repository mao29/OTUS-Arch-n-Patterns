using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Обработчик json-файлов.
    /// </summary>
    public class JsonFileProcessor : BaseFileProcessor
    {
        /// <summary>
        /// Создать обработчик json-файлов.
        /// </summary>
        /// <param name="logger">Логгер сообщений.</param>
        public JsonFileProcessor(ILogger logger) : base(logger)
        { }

        /// <inheritdoc/>
        protected override bool CanHandle(string filePath)
        {
            return Path.GetExtension(filePath).Equals(".json", StringComparison.InvariantCultureIgnoreCase);
        }

        /// <inheritdoc/>
        protected override void DoProcessFile(string filePath)
        {
            ReportProcessing($"Обработчик JSON получил файл {filePath}");
        }
    }
}
