using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Обработчик xml-файлов.
    /// </summary>
    public class XmlFileProcessor : BaseFileProcessor
    {
        /// <summary>
        /// Создать обработчик xml-файлов.
        /// </summary>
        /// <param name="logger">Логгер сообщений</param>
        public XmlFileProcessor(ILogger logger) : base(logger)
        { }

        /// <inheritdoc/>
        protected override bool CanHandle(string filePath)
        {
            return Path.GetExtension(filePath).Equals(".xml", StringComparison.InvariantCultureIgnoreCase);
        }

        /// <inheritdoc/>
        protected override void DoProcessFile(string filePath)
        {
            ReportProcessing($"Обработчик XML получил файл {filePath}");
        }
    }
}
