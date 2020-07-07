using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace CommandParser
{
    /// <summary>
    /// Состояние парсера команды "имя команды".
    /// </summary>
    internal class CommandNameCommandParserState : ICommandParserState
    {
        /// <summary>
        /// Валидные символы имени команды.
        /// </summary>
        private static readonly Regex validCommandNameRegex = new Regex("[A-Za-z]");

        /// <summary>
        /// Накопленные символы имени команды.
        /// </summary>
        private readonly StringBuilder _commandNameBuilder = new StringBuilder();     
        
        /// <summary>
        /// Парсер.
        /// </summary>
        private readonly IStatefulCommandParser _parser;

        /// <summary>
        /// Создать состояние парсера команды "имя команды".
        /// </summary>
        /// <param name="parser">Парсер.</param>
        public CommandNameCommandParserState(IStatefulCommandParser parser, char firstCharacter)
        {
            _parser = parser;
            _commandNameBuilder.Append(firstCharacter);
        }

        /// <inheritdoc/>
        public bool FinishProcessing()
        {            
            _parser.CreateCommand(_commandNameBuilder.ToString());
            _parser.SetState(new FinishedCommandParserState());
            return true;
        }

        /// <inheritdoc/>
        public bool ProcessChar(char character)
        {
            if (validCommandNameRegex.IsMatch(character.ToString()))
            {
                _commandNameBuilder.Append(character);
                return true;
            }

            if (character == '_')
            {
                _parser.CreateCommand(_commandNameBuilder.ToString());
                _parser.SetState(new AnyCharCommandParserState(_parser));
                return true;
            }

            _parser.SetState(new InvalidCommandParserState());
            return false;
        }
    }
}
