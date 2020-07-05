using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace CommandHomeWork
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
        protected override ICommand ReadDataAndCreateCommand()
        {
            var inputStrings = File.ReadAllLines(_sourceFilePath);

            var size = int.Parse(inputStrings[0]);

            var matrix = new int[size][];
            for (int i = 0; i < size; i++)
            {
                matrix[i] = new int[size];
                string[] numbers = inputStrings[i + 1].Split(' ');
                for (int j = 0; j < size; j++)
                {
                    matrix[i][j] = int.Parse(numbers[j]);
                }
            }

            return new CalculateDeterminantCommand(matrix);
        }
    }
}
