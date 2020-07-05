using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TemplateMethodHomeWork
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
        /// Размеры матрицы.
        /// </summary>
        private int rowCount, colCount;

        /// <summary>
        /// Матрица.
        /// </summary>
        private int[][] matrix;

        /// <summary>
        /// Транспонированная матрица.
        /// </summary>
        private int[][] transponatedMatrix;

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
        protected override void ReadData()
        {
            var inputStrings = File.ReadAllLines(_sourceFilePath);

            var dimensionsStr = inputStrings[0].Split(' ');

            rowCount = int.Parse(dimensionsStr[0]);
            colCount = int.Parse(dimensionsStr[1]);

            matrix = new int[rowCount][];            
            for (int i = 0; i < rowCount; i++)
            {
                matrix[i] = new int[colCount];                
                string[] numbers = inputStrings[i + 1].Split(' ');
                for (int j = 0; j < colCount; j++)
                {
                    matrix[i][j] = int.Parse(numbers[j]);
                }
            }
        }

        /// <inheritdoc/>
        protected override void ProcessData()
        {
            transponatedMatrix = new MatrixTransponator().TransponateMatrix(rowCount, colCount, matrix);
        }

        /// <inheritdoc/>
        protected override string[] TransformResultForWrite()
        {
            var result = new string[colCount];
            for (int i = 0; i < colCount; i++)
            {
                result[i] = string.Join(" ", transponatedMatrix[i]);
            }

            return result;
        }
    }
}
