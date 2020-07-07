using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CommandParser
{
    /// <summary>
    /// Состояние парсера "пробел".
    /// </summary>
    internal class WhitespaceCommandParserState : ICommandParserState
    {        
        /// <summary>
        /// Парсер.
        /// </summary>
        private readonly IStatefulCommandParser _parser;        

        /// <summary>
        /// Создать состояние парсера "пробел".
        /// </summary>
        /// <param name="parser">Парсер.</param>
        public WhitespaceCommandParserState(IStatefulCommandParser parser)
        {
            _parser = parser;            
        }

        /// <inheritdoc/>
        public bool FinishProcessing()
        {
            _parser.SetState(new FinishedCommandParserState());
            return true;
        }

        /// <inheritdoc/>
        public bool ProcessChar(char character)
        {
            if (character == '_')
            {
                _parser.SetState(new AnyCharCommandParserState(_parser));
                return true;
            }

            _parser.SetState(new InvalidCommandParserState());
            return false;          
        }
    }
}
