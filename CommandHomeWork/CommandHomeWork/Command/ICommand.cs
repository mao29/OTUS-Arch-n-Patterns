using System;
using System.Collections.Generic;
using System.Text;

namespace CommandHomeWork
{
    /// <summary>
    /// Интерфейс команды для выполнения матричной операции.
    /// </summary>
    public interface ICommand
    {
        /// <summary>
        /// Выполнить операцию.
        /// </summary>
        void Execute();

        /// <summary>
        /// Получить результат операции для печати.
        /// </summary>
        /// <returns>Результат операции для печати.</returns>
        string[] GetResult();
    }
}
