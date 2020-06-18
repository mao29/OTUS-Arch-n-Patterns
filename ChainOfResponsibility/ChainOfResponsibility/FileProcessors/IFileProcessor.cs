using System;
using System.Collections.Generic;
using System.Text;

namespace ChainOfResponsibility
{
    /// <summary>
    /// Интерфейс обработчика файла с возможностью выстраивания цепочки обработчиков.
    /// </summary>
    public interface IFileProcessor
    {
        /// <summary>
        /// Задать следующий обработчик цепочки обработчиков.
        /// </summary>
        /// <param name="fileProcessor">Следующий обработчик файла.</param>
        void SetNext(IFileProcessor fileProcessor);

        /// <summary>
        /// Обработать файл.
        /// </summary>
        /// <param name="filePath">Путь к файлу.</param>
        void ProcessFile(string filePath);      
    }
}
