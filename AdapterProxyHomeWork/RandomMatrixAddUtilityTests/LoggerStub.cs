using RandomMatrixAddUtility;
using System;
using System.Collections.Generic;
using System.Text;

namespace RandomMatrixAddUtilityTests
{
    /// <summary>
    /// Заглушка для логгера.
    /// </summary>
    class LoggerStub : ILogger
    {
        /// <summary>
        /// Логгер вызывался.
        /// </summary>
        public bool IsCalled { get; private set; } = false;

        /// <inheritdoc/>
        public void LogMessage(string message)
        {
            IsCalled = true;
        }
    }
}
