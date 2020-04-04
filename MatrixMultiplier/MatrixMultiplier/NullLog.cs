using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MatrixMultiplier
{
    class NullLog : ILog
    {
        public IEnumerable<string> GetLogContent()
        {
            return Enumerable.Empty<string>();
        }

        public void Log(string message)
        {         
        }
    }
}
