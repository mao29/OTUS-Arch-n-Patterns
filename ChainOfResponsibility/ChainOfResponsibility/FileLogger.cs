using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Логгер сообщений в файл.
    /// </summary>
    sealed class FileLogger : ILogger, IDisposable
    {
        private StreamWriter _streamWriter;

        public FileLogger(string destinationFilePath)
        {
            _streamWriter = new StreamWriter(destinationFilePath, false);
        }
       
        public void WriteMessage(string message)
        {
            _streamWriter.WriteLine(message);
        }

        public void Dispose()
        {
            _streamWriter.Dispose();
        }
    }
}
