using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CommandParser
{
    /// <summary>
    /// Состояние парсера команды "значение параметра".
    /// </summary>
    internal class CommandParameterCommandParserState : ICommandParserState
    {
        /// <summary>
        /// Валидные символы значения параметра.
        /// </summary>
        private static readonly Regex validParameterRegex = new Regex("[A-Za-z0-9]");

        /// <summary>
        /// Накопленные символы значения параметра.
        /// </summary>
        private readonly StringBuilder _parameterBuilder = new StringBuilder();

        /// <summary>
        /// Парсер.
        /// </summary>
        private readonly IStatefulCommandParser _parser;

        /// <summary>
        /// Создать состояние парсера команды "значение параметра".
        /// </summary>
        /// <param name="parser">Парсер.</param>
        /// <param name="firstChar">Первый символ значения параметра команды.</param>
        public CommandParameterCommandParserState(IStatefulCommandParser parser, char firstChar)
        {
            _parser = parser;
            _parameterBuilder.Append(firstChar);
        }

        /// <inheritdoc/>
        public bool FinishProcessing()
        {
            _parser.AddCommandParameter(_parameterBuilder.ToString());
            _parser.SetState(new FinishedCommandParserState());
            return true;
        }

        /// <inheritdoc/>
        public bool ProcessChar(char character)
        {
            if (validParameterRegex.IsMatch(character.ToString()))
            {
                _parameterBuilder.Append(character);
                return true;
            }

            if (character == '_')
            {
                _parser.AddCommandParameter(_parameterBuilder.ToString());
                _parser.SetState(new AnyCharCommandParserState(_parser));
                return true;
            }

            _parser.SetState(new InvalidCommandParserState());
            return false;
        }
    }
}
