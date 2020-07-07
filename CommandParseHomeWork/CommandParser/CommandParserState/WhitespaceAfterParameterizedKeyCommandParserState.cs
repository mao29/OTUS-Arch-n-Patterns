using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CommandParser
{
    /// <summary>
    /// Состояние парсера "пробел после ключа с обязательным параметром".
    /// </summary>
    internal class WhitespaceAfterParameterizedKeyCommandParserState : ICommandParserState
    {
        /// <summary>
        /// Парсер.
        /// </summary>
        private readonly IStatefulCommandParser _parser;

        /// <summary>
        /// Имя ключа.
        /// </summary>
        public string KeyName { get; }

        /// <summary>
        /// Создать состояние парсера "пробел после ключа с обязательным параметром".
        /// </summary>
        /// <param name="parser">Парсер.</param>
        /// <param name="keyName">Имя ключа.</param>
        public WhitespaceAfterParameterizedKeyCommandParserState(IStatefulCommandParser parser, string keyName)
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
            if (character == '_')
            {
                _parser.SetState(new AnyCharAfterParameterizedKeyCommandParserState(_parser, KeyName));
                return true;
            }

            _parser.SetState(new InvalidCommandParserState());
            return false;
        }
    }
}
