using System;
using System.Collections.Generic;
using System.Text;

namespace CommandParser
{
    /// <summary>
    /// Интерфейс состояния парсера команд.
    /// </summary>
    internal interface ICommandParserState
    {
        /// <summary>
        /// Обработать очередной символ.
        /// </summary>
        /// <param name="character">Символ.</param>
        /// <returns>true, если символ успешно обработан, false - если команда невалидна.</returns>
        bool ProcessChar(char character);

        /// <summary>
        /// Завершить парсинг.
        /// </summary>
        /// <returns>true, если команда валидна, иначе - false.</returns>
        bool FinishProcessing();
    }
}
