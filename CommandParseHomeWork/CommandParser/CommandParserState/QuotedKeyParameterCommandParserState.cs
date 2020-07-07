using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CommandParser
{
    /// <summary>
    /// Состояние парсера "значение параметра ключа в кавычках".
    /// </summary>
    internal class QuotedKeyParameterCommandParserState : ICommandParserState
    {
        /// <summary>
        /// Валидные символы значения параметра ключа в кавычках.
        /// </summary>
        private static readonly Regex validQuotedParameterRegex = new Regex("[A-Za-z0-9_]");

        /// <summary>
        /// Накопленные символы значения параметра ключа в кавычках.
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
        /// Создать состояние парсера "значение параметра ключа в кавычках".
        /// </summary>
        /// <param name="parser">Парсер.</param>
        /// <param name="keyName">Имя ключа.</param>
        public QuotedKeyParameterCommandParserState(IStatefulCommandParser parser, string keyName, char firstChar)
        {
            _parser = parser;
            KeyName = keyName;
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
                _parser.AddCommandKey(new ParameterizedCommandKey(KeyName, _parameterBuilder.ToString()));
                _parser.SetState(new WhitespaceCommandParserState(_parser));
                return true;
            }

            _parser.SetState(new InvalidCommandParserState());
            return false;
        }
    }
}
