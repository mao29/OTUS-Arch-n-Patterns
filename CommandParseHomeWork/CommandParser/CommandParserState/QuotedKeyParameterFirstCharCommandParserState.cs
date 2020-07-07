using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CommandParser
{
    /// <summary>
    /// Состояние парсера "первый символ значения параметра ключа в кавычках".
    /// </summary>
    internal class QuotedKeyParameterFirstCharCommandParserState : ICommandParserState
    {
        /// <summary>
        /// Валидные символы значения параметра ключа в кавычках.
        /// </summary>
        private static readonly Regex validQuotedParameterRegex = new Regex("[A-Za-z0-9_]");

        /// <summary>
        /// Парсер.
        /// </summary>
        private readonly IStatefulCommandParser _parser;

        /// <summary>
        /// Имя ключа.
        /// </summary>
        public string KeyName { get; }

        /// <summary>
        /// Создать состояние парсера "первый символ значения параметра ключа в кавычках".
        /// </summary>
        /// <param name="parser">Парсер.</param>
        /// <param name="keyName">Имя ключа.</param>
        public QuotedKeyParameterFirstCharCommandParserState(IStatefulCommandParser parser, string keyName)
        {
            _parser = parser;
            KeyName = keyName;
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
                _parser.SetState(new QuotedKeyParameterCommandParserState(_parser, KeyName, character));
                return true;
            }

            _parser.SetState(new InvalidCommandParserState());
            return false;
        }
    }
}
