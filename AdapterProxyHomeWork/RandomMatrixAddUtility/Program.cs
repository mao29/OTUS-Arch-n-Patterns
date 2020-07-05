using MatrixAddAdapter;
using System;
using System.IO;

namespace RandomMatrixAddUtility
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 3 && args.Length != 4)
            {
                Console.WriteLine("Укажите путь к утилите сложения, имя файла для генерации входных данных, " +
                    "имя файла для вывода результата и (необязательно) имя файла для лога.");
                return;
            }
            ILogger logger = null;

            GenerateMatrices(args[1]);
            IMatrixAddAdapter addAdapter = new MatrixAddUtilityAdapter(args[0]);

            if (args.Length == 4)
            {
                logger = new FileLogger(args[3]);
                addAdapter = new LoggingMatrixAddAdapter(addAdapter, logger);
            }

            addAdapter.AddMatrixes(args[1], args[2]);

            if (logger is IDisposable disposableLogger)
            {
                disposableLogger.Dispose();
            }
        }

        /// <summary>
        /// Записать две случайно сгенерированных матрицы и их размерность в файл.
        /// </summary>
        /// <param name="file">Путь к файлу.</param>
        static void GenerateMatrices(string file)
        {
            var rand = new Random();
            int rowCount = rand.Next(9) + 1;
            int colCount = rand.Next(9) + 1;

            using (var writer = new StreamWriter(File.Create(file)))
            {
                writer.WriteLine($"{rowCount} {colCount}");
                WriteRandomMatrix(rand, rowCount, colCount, writer);
                WriteRandomMatrix(rand, rowCount, colCount, writer);
            }
        }

        /// <summary>
        /// Записать в поток случайно сгенерированную матрицу заданного размера.
        /// </summary>
        /// <param name="rand">Генератор случайных чисел.</param>
        /// <param name="rowCount">Количество строк матрицы.</param>
        /// <param name="colCount">Количество колонок матрицы.</param>
        /// <param name="writer">Потом для записи.</param>
        private static void WriteRandomMatrix(Random rand, int rowCount, int colCount, StreamWriter writer)
        {
            for (int i = 0; i < rowCount; i++)
            {
                for (int j = 0; j < colCount; j++)
                {
                    writer.Write(rand.Next(100));
                    writer.Write(" ");
                }

                writer.WriteLine();
            }
        }
    }
}
