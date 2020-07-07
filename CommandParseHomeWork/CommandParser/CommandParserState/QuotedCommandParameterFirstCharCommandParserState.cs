using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CommandParser
{
    /// <summary>
    /// Состояние парсера "первый символ значения параметра команды в кавычках".
    /// </summary>
    internal class QuotedCommandParameterFirstCharCommandParserState : ICommandParserState
    {
        /// <summary>
        /// Валидные символы значения параметра команды в кавычках".
        /// </summary>
        private static readonly Regex validQuotedParameterRegex = new Regex("[A-Za-z0-9_]");

        /// <summary>
        /// Парсер.
        /// </summary>
        private readonly IStatefulCommandParser _parser;

        /// <summary>
        /// Создать состояние парсера "первый символ значения параметра команды в кавычках".
        /// </summary>
        /// <param name="parser">Парсер.</param>
        public QuotedCommandParameterFirstCharCommandParserState(IStatefulCommandParser parser)
        {
            _parser = parser;
        }

        public bool FinishProcessing()
        {
            _parser.SetState(new InvalidCommandParserState());
            return false;
        }

        public bool ProcessChar(char character)
        {
            if (validQuotedParameterRegex.IsMatch(character.ToString()))
            {                
                _parser.SetState(new QuotedCommandParameterCommandParserState(_parser, character));
                return true;
            }

            _parser.SetState(new InvalidCommandParserState());
            return false;
        }
    }
}
