using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TemplateMethodHomeWork
{
    /// <summary>
    /// Обработчик операции вычисления определителя матрицы.
    /// </summary>
    public class DeterminantMatrixProcessor : MatrixProcessor
    {
        /// <summary>
        /// Путь к файлу с исходными данными.
        /// </summary>
        protected readonly string _sourceFilePath;

        /// <summary>
        /// Размер матрицы.
        /// </summary>
        private int size;


        /// <summary>
        /// Матрица.
        /// </summary>
        private int[][] matrix;

        /// <summary>
        /// Определитель матрицы.
        /// </summary>
        private int determinant;

        /// <summary>
        /// Создать обработчик операции вычисления определителя матрицы.
        /// </summary>
        /// <param name="sourceFilePath">Путь к файлу с исходными данными.</param>
        /// <param name="destinationFilePath">Путь к файлу для печати результата.</param>
        public DeterminantMatrixProcessor(string sourceFilePath, string destinationFilePath)
            : base(destinationFilePath)
        {
            _sourceFilePath = sourceFilePath;
        }

        /// <inheritdoc/>
        protected override void ReadData()
        {
            var inputStrings = File.ReadAllLines(_sourceFilePath);

            size = int.Parse(inputStrings[0]);

            matrix = new int[size][];
            for (int i = 0; i < size; i++)
            {
                matrix[i] = new int[size];
                string[] numbers = inputStrings[i + 1].Split(' ');
                for (int j = 0; j < size; j++)
                {
                    matrix[i][j] = int.Parse(numbers[j]);
                }
            }
        }

        /// <inheritdoc/>
        protected override void ProcessData()
        {
            determinant = new MatrixDeterminantCalculator().CalculateDeterminant(matrix);
        }

        /// <inheritdoc/>
        protected override string[] TransformResultForWrite()
        {
            return new[] { determinant.ToString() };
        }
    }
}
