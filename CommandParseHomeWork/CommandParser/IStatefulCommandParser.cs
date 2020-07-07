using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

[assembly: InternalsVisibleTo("CommandParserTests")]
[assembly: InternalsVisibleTo("DynamicProxyGenAssembly2")]
namespace CommandParser
{
    /// <summary>
    /// Интерфейс парсера команды для использования объектами состояний.
    /// </summary>
    internal interface IStatefulCommandParser
    {
        /// <summary>
        /// Изменить состояние.
        /// </summary>
        /// <param name="state">Новое состояние.</param>
        void SetState(ICommandParserState state);

        /// <summary>
        /// Создать команду.
        /// </summary>
        /// <param name="name">Имя команды.</param>
        void CreateCommand(string name);

        /// <summary>
        /// Добавить параметр команды.
        /// </summary>
        /// <param name="value">Значение параметра.</param>
        void AddCommandParameter(string value);

        /// <summary>
        /// Добавить ключ.
        /// </summary>
        /// <param name="key">Ключ.</param>
        void AddCommandKey(CommandKey key);
    }
}
