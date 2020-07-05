using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CommandHomeWork
{
    /// <summary>
    /// Обработчик операции сложения матрицы.
    /// </summary>
    public class AddMatrixProcessor : MatrixProcessor
    {
        /// <summary>
        /// Путь к файлу с исходными данными.
        /// </summary>
        protected readonly string _sourceFilePath;       

        /// <summary>
        /// Создать обработчик операции сложения матриц.
        /// </summary>
        /// <param name="sourceFilePath">Путь к файлу с исходными данными.</param>
        /// <param name="destinationFilePath">Путь к файлу для печати результата.</param>
        public AddMatrixProcessor(string sourceFilePath, string destinationFilePath)
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

            var matrix1 = new int[rowCount][];
            var matrix2 = new int[rowCount][];
            for (int i = 0; i < rowCount; i++)
            {
                matrix1[i] = new int[colCount];
                matrix2[i] = new int[colCount];
                string[] numbers1 = inputStrings[i + 1].Split(' ');
                string[] numbers2 = inputStrings[i + rowCount + 1].Split(' ');
                for (int j = 0; j < colCount; j++)
                {
                    matrix1[i][j] = int.Parse(numbers1[j]);
                    matrix2[i][j] = int.Parse(numbers2[j]);
                }
            }

            return new AddMatrixCommand(rowCount, colCount, matrix1, matrix2);
        }
    }
}
