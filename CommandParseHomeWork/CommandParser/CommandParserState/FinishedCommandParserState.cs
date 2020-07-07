using System;
using System.Collections.Generic;
using System.Text;

namespace CommandParser
{
    /// <summary>
    /// Состояние парсера "команда распарсена".
    /// </summary>
    internal class FinishedCommandParserState : ICommandParserState
    {
        /// <inheritdoc/>
        public bool FinishProcessing()
        {
            return false;
        }

        /// <inheritdoc/>
        public bool ProcessChar(char character)
        {
            return false;
        }
    }
}
