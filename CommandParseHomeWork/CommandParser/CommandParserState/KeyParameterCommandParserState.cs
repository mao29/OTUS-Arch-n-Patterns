using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CommandParser
{
    /// <summary>
    /// Состояние парсера "значение параметра ключа".
    /// </summary>
    internal class KeyParameterCommandParserState : ICommandParserState
    {
        /// <summary>
        /// Валидные символы значения параметра ключа.
        /// </summary>
        private static readonly Regex validParameterRegex = new Regex("[A-Za-z0-9]");

        /// <summary>
        /// Накопленные символы значения параметра ключа.
        /// </summary>
        private readonly StringBuilder _parameterBuilder = new StringBuilder();

        /// <summary>
        /// Парсер.
        /// </summary>
        private readonly IStatefulCommandParser _parser;

        /// <summary>
        /// Имя ключа.
        /// </summary>
        public string KeyName { get; }

        /// <summary>
        /// Создать состояние парсера "значение параметра ключа".
        /// </summary>
        /// <param name="parser">Парсер.</param>
        /// <param name="keyName">Имя ключа.</param>
        /// <param name="firstChar">Первый символ значения параметра ключа.</param>
        public KeyParameterCommandParserState(IStatefulCommandParser parser, string keyName, char firstChar)
        {
            _parser = parser;
            KeyName = keyName;
            _parameterBuilder.Append(firstChar);
        }

        /// <inheritdoc/>
        public bool FinishProcessing()
        {
            _parser.AddCommandKey(new ParameterizedCommandKey(KeyName, _parameterBuilder.ToString()));
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
                _parser.AddCommandKey(new ParameterizedCommandKey(KeyName, _parameterBuilder.ToString()));
                _parser.SetState(new AnyCharCommandParserState(_parser));
                return true;
            }

            _parser.SetState(new InvalidCommandParserState());
            return false;
        }
    }
}
