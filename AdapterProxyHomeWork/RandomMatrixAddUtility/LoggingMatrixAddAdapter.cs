using MatrixAddAdapter;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomMatrixAddUtility
{
    /// <summary>
    /// Логирующий прокси над адаптером сложения матриц.
    /// </summary>
    public class LoggingMatrixAddAdapter : IMatrixAddAdapter
    {
        /// <summary>
        /// Адаптер сложения матриц.
        /// </summary>
        private IMatrixAddAdapter _adapter;

        /// <summary>
        /// Логгер сообщений о вызовах адаптера.
        /// </summary>
        private ILogger _logger;

        /// <summary>
        /// Создать логирующий прокси над адаптером сложения матриц.
        /// </summary>
        /// <param name="adapter">Адаптер сложения матриц.</param>
        /// <param name="logger">Логгер сообщений о вызовах адаптера.</param>
        public LoggingMatrixAddAdapter(IMatrixAddAdapter adapter, ILogger logger)
        {
            _adapter = adapter ?? throw new ArgumentNullException(nameof(adapter));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
        }

        /// <inheritdoc/>
        public void AddMatrixes(string sourceFile, string destinationFile)
        {
            _logger.LogMessage($"{DateTime.Now:yyyy-MM-dd hh:mm:ss}: MatrixAddAdapter called with arguments " +
                $"sourceFile: {sourceFile}, destinationFile: {destinationFile}");
            _adapter.AddMatrixes(sourceFile, destinationFile);
        }
    }
}
