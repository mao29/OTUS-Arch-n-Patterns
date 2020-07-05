using System;
using System.Collections.Generic;
using System.Text;

namespace FactoryHomeWork
{
    /// <summary>
    /// Фабрика конкретных фабрик писателей отсортированных данных в файл.
    /// </summary>
    public class SeparatedSortedDataWriterFactory
    {
        /// <summary>
        /// Получить конкретную фабрику писателей отсортированных данных в файл.
        /// </summary>
        /// <param name="separator">Разделитель.</param>
        /// <returns>Конкретная фабрика писателей отсортированных данных в файл.</returns>
        public ISortedDataWriter GetSortedDataWriter(Separator separator)
        {
            return separator switch
            {
                Separator.Tab => new TabSeparatedSortedDataWriter(),
                Separator.Space => new SpaceSeparatedSortedDataWriter(),
                Separator.NewLine => new NewLineSeparatedSortedDataWriter(),
                _ => throw new ArgumentException("Не существует класса для вывода сортированных данных с заданным разделителем."),
            };
        }
    }
}
