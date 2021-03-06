﻿using System;
using System.Collections.Generic;
using System.Text;

namespace CommandHomeWork
{
    /// <summary>
    /// Операция вычисления определителя матрицы.
    /// </summary>
    public class CalculateDeterminantCommand : ICommand
    {

        /// <summary>
        /// Матрица.
        /// </summary>
        private int[][] matrix;

        /// <summary>
        /// Определитель матрицы.
        /// </summary>
        private int determinant;

        /// <summary>
        /// Создать команду для операции вычисления определителя матрицы.
        /// </summary>
        /// <param name="matrix">Матрица.</param>
        public CalculateDeterminantCommand(int[][] matrix)
        {
            this.matrix = matrix;
        }

        /// <inheritdoc/>
        public void Execute()
        {
            determinant = CalculateDeterminant(matrix);
        }

        /// <summary>
        /// Вычислить определитель матрицы.
        /// </summary>
        /// <param name="matrix">Матрица.</param>
        /// <returns>Определитель матрицы.</returns>
        private int CalculateDeterminant(int[][] matrix)
        {
            if (matrix.Length == 1)
            {
                return matrix[0][0];
            }

            if (matrix.Length == 2)
            {
                return matrix[0][0] * matrix[1][1] - matrix[1][0] * matrix[0][1];
            }

            int result = 0;
            for (int i = 0; i < matrix.Length; i++)
            {
                result += (i % 2 == 1 ? 1 : -1) * matrix[1][i]
                    * CalculateDeterminant(CreateMatrixWithoutRowColumn(1, i, matrix));
            }
            return result;
        }

        /// <summary>
        /// Создать матрицу без заданной строки и колонки.
        /// </summary>
        /// <param name="rowNumber">Исключаемая строка.</param>
        /// <param name="columnNumber">Исключаемая колонка.</param>
        /// <param name="matrix">Матрица.</param>
        /// <returns>Матрица без заданной строки и колонки.</returns>
        private int[][] CreateMatrixWithoutRowColumn(int rowNumber, int columnNumber, int[][] matrix)
        {
            int[][] resultMatrix = new int[matrix.Length - 1][];
            for (int i = 0; i < matrix.Length - 1; i++)
            {
                resultMatrix[i] = new int[matrix.Length - 1];
                for (int j = 0; j < matrix.Length - 1; j++)
                {
                    int sourceRow = i < rowNumber ? i : i + 1;
                    int sourceColumn = j < columnNumber ? j : j + 1;
                    resultMatrix[i][j] = matrix[sourceRow][sourceColumn];
                }
            }

            return resultMatrix;
        }

        /// <inheritdoc/>
        public string[] GetResult()
        {
            return new[] { determinant.ToString() };
        }
    }
}
