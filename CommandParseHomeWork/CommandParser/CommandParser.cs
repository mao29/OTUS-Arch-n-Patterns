using System;
using System.Collections.Generic;
using System.Text;

namespace CommandParser
{
    /// <summary>
    /// Класс для парсинга команды.
    /// </summary>
    public class CommandParser : IStatefulCommandParser
    {
        /// <summary>
        /// Распарсенная команда.
        /// </summary>
        private Command _command;

        /// <summary>
        /// Текущее состояние парсера.
        /// </summary>
        private ICommandParserState _state;

        /// <summary>
        /// Создать парсер команды.
        /// </summary>
        public CommandParser()
        {
            _state = new FirstCommandNameCharacterCommandParserState(this);
        }

        /// <summary>
        /// Попробовать распарсить строку команды.
        /// </summary>
        /// <param name="commandString">Строка команды.</param>
        /// <param name="command">Распарсенная команда.</param>
        /// <returns>true, если команда валидна, иначе - false.</returns>
        public bool TryParseCommand(string commandString, out Command command)
        {
            command = null;
            if (string.IsNullOrEmpty(commandString))
            {
                return false;
            }
           
            foreach (char c in commandString)
            {
                var isValid = _state.ProcessChar(c);
                if (!isValid)
                {
                    return false;
                }
            }

            if (!_state.FinishProcessing())
            {
                return false;
            }

            command = _command;
            return true;
        }

        /// <inheritdoc/>
        void IStatefulCommandParser.SetState(ICommandParserState state)
        {
            _state = state;
        }

        /// <inheritdoc/>
        void IStatefulCommandParser.CreateCommand(string name)
        {
            _command = new Command(name);
        }

        /// <inheritdoc/>
        void IStatefulCommandParser.AddCommandParameter(string value)
        {
            _command.AddParameter(value);
        }

        /// <inheritdoc/>
        void IStatefulCommandParser.AddCommandKey(CommandKey key)
        {
            _command.AddKey(key);
        }
    }
}
