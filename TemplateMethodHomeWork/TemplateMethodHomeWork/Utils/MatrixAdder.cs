using System;
using System.Collections.Generic;
using System.Text;

namespace TemplateMethodHomeWork
{
    /// <summary>
    /// Класс с методом сложения матриц.
    /// </summary>
    public class MatrixAdder
    {
        /// <summary>
        /// Сложить матрицы.
        /// </summary>
        /// <param name="rowCount">Количество строк в матрицах.</param>
        /// <param name="colCount">Количество колонок в матрицах.</param>
        /// <param name="matrix1">Первая матрица.</param>
        /// <param name="matrix2">Вторая матрица.</param>
        /// <returns>Результирующая матрица.</returns>
        public int[][] AddMatrices(int rowCount, int colCount, int[][] matrix1, int[][] matrix2)
        {
            var resultMatrix = new int[rowCount][];
            for (int i = 0; i < rowCount; i++)
            {
                resultMatrix[i] = new int[colCount];
                for (int j = 0; j < colCount; j++)
                {
                    resultMatrix[i][j] = matrix1[i][j] + matrix2[i][j];
                }
            }
            return resultMatrix;
        }
    }
}
