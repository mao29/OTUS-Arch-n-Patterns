using System;
using System.Collections.Generic;
using System.Text;

namespace CommandParser
{
    /// <summary>
    /// Состояние парсера "наименование ключа".
    /// </summary>
    internal class KeyNameCommandParserState : ICommandParserState
    {
        /// <summary>
        /// Парсер.
        /// </summary>
        private readonly IStatefulCommandParser _parser;

        /// <summary>
        /// Ключи с обязательным параметром.
        /// </summary>
        private readonly HashSet<char> requiredParameterKeys = new HashSet<char>() { 'a', 'r', 'p' };

        /// <summary>
        /// Ключи с возможным параметром.
        /// </summary>
        private readonly HashSet<char> allowedParameterKeys = new HashSet<char>() { 'n', 'm', 'l', 's' };

        /// <summary>
        /// Ключи без параметра.
        /// </summary>
        private readonly HashSet<char> noParameterKeys = new HashSet<char>() { 'c' };

        /// <summary>
        /// Создать состояние парсера "наименование ключа".
        /// </summary>
        /// <param name="parser">Парсер.</param>
        public KeyNameCommandParserState(IStatefulCommandParser parser)
        {
            _parser = parser;
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
            if (requiredParameterKeys.Contains(character))
            {
                _parser.SetState(new WhitespaceAfterParameterizedKeyCommandParserState(_parser, character.ToString()));
                return true;
            }

            if (allowedParameterKeys.Contains(character))
            {
                _parser.SetState(new WhitespaceAfterKeyCommandParserState(_parser, character.ToString()));
                return true;
            }

            if (noParameterKeys.Contains(character))
            {
                _parser.AddCommandKey(new CommandKey(character.ToString()));
                _parser.SetState(new WhitespaceCommandParserState(_parser));
                return true;
            }

            _parser.SetState(new InvalidCommandParserState());
            return false;
        }
    }
}
