using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CommandHomeWork
{
    /// <summary>
    /// Базовый класс для обработчиков операции с матрицами.
    /// </summary>
    public abstract class MatrixProcessor
    {        
        /// <summary>
        /// Путь к файлу для печати результата операции.
        /// </summary>
        protected readonly string _destinationFilePath;

        /// <summary>
        /// Создать обработчик операции с матрицами.
        /// </summary>
        /// <param name="destinationFilePath">Путь к файлу для печати результата операции.</param>
        public MatrixProcessor(string destinationFilePath)
        {            
            _destinationFilePath = destinationFilePath;
        }

        /// <summary>
        /// Шаблонный метод осуществления операции.
        /// </summary>
        public void DoProcessing()
        {
            var command = ReadDataAndCreateCommand();
           
            command.Execute();
            
            var result = command.GetResult();
            WriteResult(result);
        }

        /// <summary>
        /// Вычитать исходные данные и создать команду для выполнения операции.
        /// </summary>
        protected abstract ICommand ReadDataAndCreateCommand();
      
        /// <summary>
        /// Вывести результаты операции в файл.
        /// </summary>
        /// <param name="result">Подготовленные для печати в файл результаты операции.</param>
        protected virtual void WriteResult(string[] result)
        {
            using (var writer = new StreamWriter(_destinationFilePath))
            {
                foreach (var item in result)
                {
                    writer.WriteLine(item);
                }
            }
        }
    }
}
