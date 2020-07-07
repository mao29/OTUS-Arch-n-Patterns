using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CommandParser
{
    /// <summary>
    /// Состояние парсера "значение параметра команды в кавычках".
    /// </summary>
    internal class QuotedCommandParameterCommandParserState : ICommandParserState
    {
        /// <summary>
        /// Валидные символы значения параметра команды в кавычках".
        /// </summary>
        private static readonly Regex validQuotedParameterRegex = new Regex("[A-Za-z0-9_]");

        /// <summary>
        /// Накопленные символы значения параметра команды.
        /// </summary>
        private readonly StringBuilder _parameterBuilder = new StringBuilder();

        /// <summary>
        /// Парсер.
        /// </summary>
        private readonly IStatefulCommandParser _parser;

        /// <summary>
        /// Создать состояние парсера "значение параметра команды в кавычках".
        /// </summary>
        /// <param name="parser">Парсер.</param>
        public QuotedCommandParameterCommandParserState(IStatefulCommandParser parser, char firstChar)
        {
            _parser = parser;
            _parameterBuilder.Append(firstChar);
        }

        /// <inheritdoc/>
        public bool FinishProcessing()
        {
            _parser.SetState(new InvalidCommandParserState());
            return false;
        }

        /// <inheritdoc/>
        public bool ProcessChar(char character)
        {
            if (validQuotedParameterRegex.IsMatch(character.ToString()))
            {
                _parameterBuilder.Append(character);
                return true;
            }

            if (character == '"')
            {
                _parser.AddCommandParameter(_parameterBuilder.ToString());
                _parser.SetState(new WhitespaceCommandParserState(_parser));
                return true;
            }

            _parser.SetState(new InvalidCommandParserState());
            return false;
        }
    }
}
