using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CommandParser
{
    /// <summary>
    /// Состояние парсера "первый символ имени команды".
    /// </summary>
    internal class FirstCommandNameCharacterCommandParserState : ICommandParserState
    {
        /// <summary>
        /// Валидные символы имени команды.
        /// </summary>
        private static readonly Regex validCommandNameRegex = new Regex("[A-Za-z]");

        /// <summary>
        /// Парсер.
        /// </summary>
        private readonly IStatefulCommandParser _parser;

        /// <summary>
        /// Создать состояние парсера "первый символ имени команды".
        /// </summary>
        /// <param name="parser">Парсер.</param>
        public FirstCommandNameCharacterCommandParserState(IStatefulCommandParser parser)
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
            if (validCommandNameRegex.IsMatch(character.ToString()))
            {
                _parser.SetState(new CommandNameCommandParserState(_parser, character));
                return true;
            }

            _parser.SetState(new InvalidCommandParserState());
            return false;
        }
    }
}
