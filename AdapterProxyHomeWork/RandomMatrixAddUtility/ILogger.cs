using System;
using System.Collections.Generic;
using System.Text;

namespace RandomMatrixAddUtility
{
    /// <summary>
    /// Интерфейс для логирования сообщений.
    /// </summary>
    public interface ILogger
    {
        /// <summary>
        /// Записать сообщение в лог.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        void LogMessage(string message);
    }
}
