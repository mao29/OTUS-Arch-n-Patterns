using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CommandParser
{
    /// <summary>
    /// Состояние парсера "любой символ".
    /// </summary>
    internal class AnyCharCommandParserState : ICommandParserState
    {
        /// <summary>
        /// Валидные символы значения параметра.
        /// </summary>
        private static readonly Regex validParameterRegex = new Regex("[A-Za-z0-9]");

        /// <summary>
        /// Парсер.
        /// </summary>
        private readonly IStatefulCommandParser _parser;

        /// <summary>
        /// Создать состояние парсера "любой символ".
        /// </summary>
        /// <param name="parser">Парсер.</param>
        public AnyCharCommandParserState(IStatefulCommandParser parser)
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
                return true;
            }

            if (character == '-')
            {
                _parser.SetState(new KeyNameCommandParserState(_parser));
                return true;
            }

            if (character == '"')
            {
                _parser.SetState(new QuotedCommandParameterFirstCharCommandParserState(_parser));
                return true;
            }

            if (validParameterRegex.IsMatch(character.ToString()))
            {
                _parser.SetState(new CommandParameterCommandParserState(_parser, character));
                return true;
            }

            _parser.SetState(new InvalidCommandParserState());
            return false;
        }
    }
}
