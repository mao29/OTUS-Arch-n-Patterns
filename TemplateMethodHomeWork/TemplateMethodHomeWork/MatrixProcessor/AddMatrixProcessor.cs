using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TemplateMethodHomeWork
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
        /// Размеры матриц.
        /// </summary>
        private int rowCount, colCount;

        /// <summary>
        /// Первая матрица.
        /// </summary>
        private int[][] matrix1;

        /// <summary>
        /// Вторая матрица.
        /// </summary>
        private int[][] matrix2;

        /// <summary>
        /// Результирующая матрица.
        /// </summary>
        private int[][] resultMatrix;

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
        protected override void ReadData()
        {
            var inputStrings = File.ReadAllLines(_sourceFilePath);

            var dimensionsStr = inputStrings[0].Split(' ');

            rowCount = int.Parse(dimensionsStr[0]);
            colCount = int.Parse(dimensionsStr[1]);

            matrix1 = new int[rowCount][];
            matrix2 = new int[rowCount][];
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
        }

        /// <inheritdoc/>
        protected override void ProcessData()
        {
            resultMatrix = new MatrixAdder().AddMatrices(rowCount, colCount, matrix1, matrix2);
        }

        /// <inheritdoc/>
        protected override string[] TransformResultForWrite()
        {
            var result = new string[rowCount];
            for (int i = 0; i < rowCount; i++)
            {
                result[i] = string.Join(" ", resultMatrix[i]);
            }

            return result;
        }
    }
}
