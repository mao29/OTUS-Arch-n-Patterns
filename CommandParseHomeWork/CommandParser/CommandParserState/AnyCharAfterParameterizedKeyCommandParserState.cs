using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CommandParser
{
    /// <summary>
    /// Состояние парсера "любой символ после ключа с обязательным параметром".
    /// </summary>
    internal class AnyCharAfterParameterizedKeyCommandParserState : ICommandParserState
    {
        /// <summary>
        /// Валидные символы значения параметра ключа.
        /// </summary>
        private static readonly Regex validParameterRegex = new Regex("[A-Za-z0-9]");

        /// <summary>
        /// Парсер.
        /// </summary>
        private readonly IStatefulCommandParser _parser;

        /// <summary>
        /// Имя ключа.
        /// </summary>
        public string KeyName { get; }

        /// <summary>
        /// Создать состояние парсера "любой символ после ключа с обязательным параметром".
        /// </summary>
        /// <param name="parser">Парсер.</param>
        /// <param name="keyName">Имя ключа.</param>
        public AnyCharAfterParameterizedKeyCommandParserState(IStatefulCommandParser parser, string keyName)
        {
            _parser = parser;
            KeyName = keyName;
        }

        public bool FinishProcessing()
        {
            _parser.SetState(new InvalidCommandParserState());
            return false;
        }

        public bool ProcessChar(char character)
        {
            if (character == '_')
            {
                return true;
            }

            if (character == '"')
            {
                _parser.SetState(new QuotedKeyParameterFirstCharCommandParserState(_parser, KeyName));
                return true;
            }

            if (validParameterRegex.IsMatch(character.ToString()))
            {
                _parser.SetState(new KeyParameterCommandParserState(_parser, KeyName, character));
                return true;
            }

            _parser.SetState(new InvalidCommandParserState());
            return false;
        }
    }
}
