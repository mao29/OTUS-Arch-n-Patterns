using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CommandHomeWork
{
    /// <summary>
    /// Операция транспонирования матрицы.
    /// </summary>
    public class TransponateMatrixProcessor : MatrixProcessor
    {
        /// <summary>
        /// Путь к файлу с исходными данными.
        /// </summary>
        protected readonly string _sourceFilePath;        

        /// <summary>
        /// Создать обработчик операции транспонирования матрицы.
        /// </summary>
        /// <param name="sourceFilePath">Путь к файлу с исходными данными.</param>
        /// <param name="destinationFilePath">Путь к файлу для печати результата.</param>
        public TransponateMatrixProcessor(string sourceFilePath, string destinationFilePath)
            : base(destinationFilePath)
        {
            _sourceFilePath = sourceFilePath;
        }

        /// <inheritdoc/>
        protected override ICommand ReadDataAndCreateCommand()
        {
            var inputStrings = File.ReadAllLines(_sourceFilePath);

            var dimensionsStr = inputStrings[0].Split(' ');

            var rowCount = int.Parse(dimensionsStr[0]);
            var colCount = int.Parse(dimensionsStr[1]);

            var matrix = new int[rowCount][];            
            for (int i = 0; i < rowCount; i++)
            {
                matrix[i] = new int[colCount];                
                string[] numbers = inputStrings[i + 1].Split(' ');
                for (int j = 0; j < colCount; j++)
                {
                    matrix[i][j] = int.Parse(numbers[j]);
                }
            }

            return new TransponateMatrixCommand(rowCount, colCount, matrix);
        }
    }
}
