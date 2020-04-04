using MatrixMultiplier;
using System;
using Xunit;

namespace MatrixMultiplierTests
{
    public class ThreadedMatrixMultiplierTests
    {
        [Fact]
        public void Constructor_IllegalThreadCount_ThrowsArgumentOutOfRangeException()
        {
            Assert.Throws<ArgumentOutOfRangeException>(() => new ThreadedMatrixMultiplier(-1, null));
        }

        [Theory]
        [InlineData(1, 5)]
        [InlineData(1, 20)]
        [InlineData(2, 5)]
        [InlineData(2, 20)]
        [InlineData(8, 5)]
        [InlineData(8, 20)]
        public void MultiplyMatrices_CalculatesCorrectly(int threadCount, int matrixSize)
        {
            var m1 = CreateTestMatrix(matrixSize, 1);
            var m2 = CreateTestMatrix(matrixSize, 2);

            var multiplier = new ThreadedMatrixMultiplier(threadCount, null);
            var mr = multiplier.MultiplyMatrices(matrixSize, m1, m2);

            var mExpected = CreateTestMatrix(matrixSize, matrixSize * 2);

            Assert.Equal(mExpected, mr);
        }

        /// <summary>
        /// Создать матрицу для тестирования с одинаковыми элементами.
        /// </summary>
        /// <param name="matrixSize">Размер матрицы.</param>
        /// <param name="value">Значение, которое записать во все ячейки.</param>
        /// <returns>Матрица заданного размера с одинаковыми значениями элементов.</returns>
        private int[][] CreateTestMatrix(int matrixSize, int value)
        {
            var matrixResult = new int[matrixSize][];
            for (int i = 0; i < matrixSize; i++)
            {
                matrixResult[i] = new int[matrixSize];
                for (var j = 0; j < matrixSize; j++)
                {
                    matrixResult[i][j] = value;
                }
            }
            return matrixResult;
        }

    }
}
