using System;
using System.Collections.Generic;
using System.Text;

namespace CommandHomeWork
{
    /// <summary>
    /// Операция транспонирования матрицы.
    /// </summary>
    public class TransponateMatrixCommand : ICommand
    {
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
        /// Создать команду для операции транспонирования матрицы.
        /// </summary>
        /// <param name="rowCount">Количество строк.</param>
        /// <param name="colCount">Количество колонок.</param>
        /// <param name="matrix">Матрица.</param>
        public TransponateMatrixCommand(int rowCount, int colCount, int[][] matrix)
        {
            this.rowCount = rowCount;
            this.colCount = colCount;
            this.matrix = matrix;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            transponatedMatrix = new int[colCount][];
            for (int i = 0; i < colCount; i++)
            {
                transponatedMatrix[i] = new int[rowCount];
                for (int j = 0; j < rowCount; j++)
                {
                    transponatedMatrix[i][j] = matrix[j][i];
                }
            }       
        }

        /// <inheritdoc/>
        public string[] GetResult()
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
