using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CommandParser
{
    /// <summary>
    /// Состояние парсера "любой символ после имени ключа".
    /// </summary>
    internal class AnyCharAfterKeyCommandParserState : ICommandParserState
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
        /// Наименование ключа.
        /// </summary>
        public string KeyName { get; }

        /// <summary>
        /// Создать состояние парсера "любой символ после имени ключа".
        /// </summary>
        /// <param name="parser">Парсер.</param>
        /// <param name="keyName">Имя ключа.</param>
        public AnyCharAfterKeyCommandParserState(IStatefulCommandParser parser, string keyName)
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
                return true;
            }

            if (character == '-')
            {
                _parser.AddCommandKey(new CommandKey(KeyName));
                _parser.SetState(new KeyNameCommandParserState(_parser));
                return true;
            }

            if (character == '"')
            {
                _parser.SetState(new QuotedKeyParameterFirstCharCommandParserState(_parser,KeyName));
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
