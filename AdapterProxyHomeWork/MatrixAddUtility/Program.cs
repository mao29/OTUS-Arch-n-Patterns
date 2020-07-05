using System;
using System.IO;

namespace MatrixAddUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Укажите два имени файлов.");
                return;
            }

            string sourceFile = args[0];
            if (!File.Exists(sourceFile))
            {
                Console.WriteLine($"Файл {sourceFile} не существует.");
                return;
            }

            var inputStrings = File.ReadAllLines(sourceFile);

            var dimensionsStr = inputStrings[0].Split(' ');

            int rowCount = int.Parse(dimensionsStr[0]);
            int colCount = int.Parse(dimensionsStr[1]);

            int[][] matrix1 = new int[rowCount][];
            int[][] matrix2 = new int[rowCount][];
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

            var result = AddMatrixes(rowCount, colCount, matrix1, matrix2);

            using (var writer = new StreamWriter(File.Create(args[1])))
            {
                for (int i = 0; i < rowCount; i++)
                {
                    for (int j = 0; j < colCount; j++)
                    {
                        writer.Write("{0} ", result[i][j]);
                    }
                    writer.WriteLine();
                }
            }
        }

        /// <summary>
        /// Сложить две матрицы.
        /// </summary>
        /// <param name="rowCount">Количество строк.</param>
        /// <param name="colCount">Количество столбцов.</param>
        /// <param name="matrix1">Первая матрица.</param>
        /// <param name="matrix2">Вторая матрица.</param>
        /// <returns>Результирующая матрица.</returns>
        public static int[][] AddMatrixes(int rowCount, int colCount, int[][] matrix1, int[][] matrix2)
        {
            var result = PrepareResultMatrix(rowCount, colCount);

            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    result[i][j] = matrix1[i][j] + matrix2[i][j];
                }
            }

            return result;
        }

        /// <summary>
        /// Метод для создания пустой матрицы заданного размера.
        /// </summary>
        /// <param name="rowCount">Количество строк.</param>
        /// <param name="colCount">Количество колонок.</param>
        /// <returns>Пустая матрица заданного размера.</returns>
        static int[][] PrepareResultMatrix(int rowCount, int colCount)
        {
            var matrixResult = new int[rowCount][];
            for (int i = 0; i < rowCount; i++)
            {
                matrixResult[i] = new int[colCount];
            }
            return matrixResult;
        }
    }
}
