using System;
using System.Collections.Generic;
using System.Text;

namespace CommandHomeWork
{
    /// <summary>
    /// Операция сложения матриц.
    /// </summary>
    public class AddMatrixCommand : ICommand
    {
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
        /// Создать команду для операции сложения матриц.
        /// </summary>
        /// <param name="rowCount">Количество строк.</param>
        /// <param name="colCount">Количество колонок.</param>
        /// <param name="matrix1">Первая матрица.</param>
        /// <param name="matrix2">Вторая матрица.</param>
        public AddMatrixCommand(int rowCount, int colCount, int[][] matrix1, int[][] matrix2)
        {
            this.rowCount = rowCount;
            this.colCount = colCount;
            this.matrix1 = matrix1;
            this.matrix2 = matrix2;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            resultMatrix = new int[rowCount][];
            for (int i = 0; i < rowCount; i++)
            {
                resultMatrix[i] = new int[colCount];
                for (int j = 0; j < colCount; j++)
                {
                    resultMatrix[i][j] = matrix1[i][j] + matrix2[i][j];
                }
            }            
        }

        /// <inheritdoc/>
        public string[] GetResult()
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
