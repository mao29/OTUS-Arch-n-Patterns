using System;
using System.Collections.Generic;
using System.Text;

namespace CommandParser
{
    /// <summary>
    /// Состояние парсера "команда не валидна".
    /// </summary>
    internal class InvalidCommandParserState : ICommandParserState
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
