using System;
using System.Diagnostics;
using System.IO;

namespace MatrixMultiplier
{
    class Program
    {

        static void Main(string[] args)
        {
            var inputStrings = File.ReadAllLines("in.txt");

            int matrixSize = int.Parse(inputStrings[0]);
            //matrixSize = 100;

            int[][] matrix1 = new int[matrixSize][];
            int[][] matrix2 = new int[matrixSize][];
            for (int i = 0; i < matrixSize; i++)
            {
                matrix1[i] = new int[matrixSize];
                matrix2[i] = new int[matrixSize];
                string[] numbers1 = inputStrings[i + 1].Split(' ');
                string[] numbers2 = inputStrings[i + matrixSize + 1].Split(' ');
                for (int j = 0; j < matrixSize; j++)
                {
                    matrix1[i][j] = int.Parse(numbers1[j]);
                    matrix2[i][j] = int.Parse(numbers2[j]);
                }
            }
            int threadCount = int.Parse(inputStrings[inputStrings.Length - 1]);         

            var watch = Stopwatch.StartNew();
            var result = new ThreadedMatrixMultiplier(threadCount).MultiplyMatrices(matrixSize, matrix1, matrix2);
            watch.Stop();

            using (var writer = new StreamWriter(File.Create("out.txt")))
            {
                writer.WriteLine($"Elapsed {watch.Elapsed.TotalSeconds}s");
                for (int i = 0; i < matrixSize; i++)
                {
                    for (int j = 0; j < matrixSize; j++)
                    {
                        writer.Write("{0} ", result[i][j]);
                    }
                    writer.WriteLine();
                }
            }

            Logger.Instance.Flush();
        }


    }
}
