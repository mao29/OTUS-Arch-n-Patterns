using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MatrixMultiplier
{
    /// <summary>
    /// Логгер-синглтон.
    /// </summary>
    public class Logger
    {
        /// <summary>
        /// Экземпляр логгера.
        /// </summary>
        private static Logger _instance;
        
        /// <summary>
        /// Объект для блокировки создания экземпляра логгера.
        /// </summary>
        private static object _creationLock = new object();
        
        /// <summary>
        /// Писатель сообщений в файл лога.
        /// </summary>
        private StreamWriter _writer;
        
        /// <summary>
        /// Объект для блокировки записи сообщения лога.
        /// </summary>
        private object _writeLock = new object();
       
        private Logger()
        {
            _writer = new StreamWriter("log.txt", false);    
        }

        /// <summary>
        /// Записать сообщение в лог.
        /// </summary>
        /// <param name="message">Текст сообщения.</param>
        public void LogMessage(string message)
        {
            lock (_writeLock)
            {
                _writer.WriteLine(message);
            }
        }

        /// <summary>
        /// Выполнить сброс всех сообщений в файловую систему.
        /// </summary>
        public void Flush()
        {
            _writer.Flush();
        }

        /// <summary>
        /// Экземпляр логгера.
        /// </summary>
        public static Logger Instance
        {
            get
            {
                var instance = _instance;
                if (instance == null)
                {
                    lock (_creationLock)
                    {
                        instance = _instance;
                        if (instance == null)
                        {
                            _instance = instance = new Logger();
                        }
                    }
                }
                return instance;
            }
        }
    }
}
