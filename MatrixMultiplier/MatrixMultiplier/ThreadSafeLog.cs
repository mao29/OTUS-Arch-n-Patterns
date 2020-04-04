using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Text;

namespace MatrixMultiplier
{
    /// <summary>
    /// Вспомогательный класс для логирования вычислений.
    /// Потокобезопасно добавляет сообщения в коллекцию и позволяет 
    /// получить все добавленные сообщения.
    /// 
    /// Класс неполноценный, т.к. не удаляет сообщения при извлечении,
    /// поэтому на больших размерах матриц запускать с осторожностью.
    /// </summary>
    class ThreadSafeLog : ILog
    {
        private ConcurrentQueue<string> _messages = new ConcurrentQueue<string>();

        public void Log(string message)
        {
            _messages.Enqueue(message);
        }

        public IEnumerable<string> GetLogContent()
        {
            return _messages.ToArray();
        }
    }
}
