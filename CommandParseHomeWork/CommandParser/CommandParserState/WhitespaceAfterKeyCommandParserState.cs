using System;
using System.Collections.Generic;
using System.Text;

namespace CommandParser
{
    /// <summary>
    /// Состояние парсера "пробел после ключа команды".
    /// </summary>
    internal class WhitespaceAfterKeyCommandParserState : ICommandParserState
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
        /// Создать остояние парсера "пробел после ключа команды".
        /// </summary>
        /// <param name="parser">Парсер.</param>
        /// <param name="keyName">Имя ключа.</param>
        public WhitespaceAfterKeyCommandParserState(IStatefulCommandParser parser, string keyName)
        {
            _parser = parser;
            KeyName = keyName;
        }

        /// <inheritdoc/>
        public bool FinishProcessing()
        {
            _parser.AddCommandKey(new CommandKey(KeyName));
            _parser.SetState(new FinishedCommandParserState());
            return true;
        }

        /// <inheritdoc/>
        public bool ProcessChar(char character)
        {
            if (character == '_')
            {
                _parser.SetState(new AnyCharAfterKeyCommandParserState(_parser, KeyName));
                return true;
            }

            _parser.SetState(new InvalidCommandParserState());
            return false;
        }
    }
}
