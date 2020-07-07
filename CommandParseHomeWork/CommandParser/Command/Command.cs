using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CommandParser
{
    /// <summary>
    /// Команда.
    /// </summary>
    public class Command
    {
        /// <summary>
        /// Ключи команды.
        /// </summary>
        private readonly List<CommandKey> _keys = new List<CommandKey>();

        /// <summary>
        /// Параметры команды.
        /// </summary>
        private readonly List<string> _parameters = new List<string>();
        
        /// <summary>
        /// Наименование команды.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Ключи команды.
        /// </summary>
        public IReadOnlyCollection<CommandKey> Keys  => _keys.AsReadOnly();

        /// <summary>
        /// Параметры команды.
        /// </summary>
        public IReadOnlyCollection<string> Parameters => _parameters.AsReadOnly();

        /// <summary>
        /// Создать команду с заданным именем.
        /// </summary>
        /// <param name="name">Имя команды.</param>
        public Command(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Добавить ключ.
        /// </summary>
        /// <param name="key">Ключ.</param>
        public void AddKey(CommandKey key)
        {
            _keys.Add(key);
        }

        /// <summary>
        /// Добавить параметр.
        /// </summary>
        /// <param name="value">Параметр.</param>
        public void AddParameter(string value)
        {
            _parameters.Add(value);
        }

        /// <summary>
        /// Привести к строковому представлению.
        /// </summary>
        /// <returns>Строковое представление команды.</returns>
        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine($"Команда: {Name}");
           
            if (Keys.Any())
            {
                sb.AppendLine("Ключи:");
                foreach (var parameter in Keys)
                {
                    sb.AppendLine(parameter.ToString());
                }
            }

            if (Parameters.Any())
            {
                sb.AppendLine("Параметры:");
                foreach (var parameter in Parameters)
                {
                    sb.AppendLine(parameter.ToString());
                }
            }

            return sb.ToString();
        }
    }
}
