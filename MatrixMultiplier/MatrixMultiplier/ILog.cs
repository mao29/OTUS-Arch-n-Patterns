using System;
using System.Collections.Generic;
using System.Text;

namespace MatrixMultiplier
{
    public interface ILog
    {
        void Log(string message);

        IEnumerable<string> GetLogContent();
    }
}
