using System;
using System.Collections.Generic;
using System.Text;

namespace RandomMatrixAddUtility
{
    /// <summary>
    /// Пустая имплементация логгера.
    /// </summary>
    class NullLogger : ILogger
    {
        /// <inheritdoc/>
        public void LogMessage(string message)
        {            
        }
    }
}
