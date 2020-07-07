using System;
using System.Collections.Generic;
using System.Text;

namespace CommandParser
{
    /// <summary>
    /// Ключ команды с параметром.
    /// </summary>
    public class ParameterizedCommandKey : CommandKey
    {
        /// <summary>
        /// Значение параметра.
        /// </summary>
        public string Parameter { get; protected set; }

        /// <summary>
        /// Создать ключ с параметром.
        /// </summary>
        /// <param name="name">Наименование ключа.</param>
        /// <param name="parameter">Значение параметра.</param>
        public ParameterizedCommandKey(string name, string parameter) : base(name)
        {
            Parameter = parameter;
        }

        /// <inheritdoc/>
        public override string ToString()
        {
            return $"{base.ToString()}, параметр: {Parameter}";
        }
    }
}
