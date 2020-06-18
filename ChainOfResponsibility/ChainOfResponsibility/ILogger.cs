using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Интерфейс логгера сообщений.
    /// </summary>
    public interface ILogger
    {
        void WriteMessage(string message);
    }
}
