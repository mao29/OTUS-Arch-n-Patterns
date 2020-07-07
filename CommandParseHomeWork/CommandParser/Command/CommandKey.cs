using System;
using System.Collections.Generic;
using System.Text;

namespace CommandParser
{
    /// <summary>
    /// Ключ команды.
    /// </summary>
    public class CommandKey
    {
        /// <summary>
        /// Наименование ключа.
        /// </summary>
        public string Name { get; protected set; }

        /// <summary>
        /// Создать ключ.
        /// </summary>
        /// <param name="name">Наименование ключа.</param>
        public CommandKey(string name)
        {
            Name = name;
        }

        /// <summary>
        /// Привести к строковому представлению.
        /// </summary>
        /// <returns>Строковое представление.</returns>
        public override string ToString()
        {
            return $"{Name}";
        }
    }
}
