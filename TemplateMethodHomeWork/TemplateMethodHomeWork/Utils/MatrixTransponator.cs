using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethodHomeWork
{
    /// <summary>
    /// Класс для транспонирования матрицы.
    /// </summary>
    public class MatrixTransponator
    {
        /// <summary>
        /// Транспонировать матрицу.
        /// </summary>
        /// <param name="rowCount">Количество строк.</param>
        /// <param name="colCount">Количество колонок.</param>
        /// <param name="matrix">Матрица.</param>
        /// <returns>Транспонированная матрица.</returns>
        public int[][] TransponateMatrix(int rowCount, int colCount, int[][] matrix)
        {
            var transponatedMatrix = new int[colCount][];
            for (int i = 0; i < colCount; i++)
            {
                transponatedMatrix[i] = new int[rowCount];
                for (int j = 0; j < rowCount; j++)
                {
                    transponatedMatrix[i][j] = matrix[j][i];
                }
            }
            return transponatedMatrix;
        }
    }
}
