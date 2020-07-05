using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace RandomMatrixAddUtility
{
    class FileLogger : ILogger, IDisposable
    {
        private StreamWriter _writer;
        public FileLogger(string filePath)
        {
            _writer = new StreamWriter(filePath, true);
        }

        public void LogMessage(string message)
        {
            _writer.WriteLine(message);
        }

        public void Dispose()
        {
            _writer.Dispose();
        }
    }
}
