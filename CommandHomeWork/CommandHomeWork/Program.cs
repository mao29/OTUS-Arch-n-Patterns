using System;

namespace CommandHomeWork
{
    public class Program
    {
        static void Main(string[] args)
        {
            try
            {
                var parsedArgs = new Args(args);

                var matrixProcessor = GetMatrixProcessor(parsedArgs.Operation, parsedArgs.SourceFilePath, parsedArgs.DestinationFilePath);
                matrixProcessor.DoProcessing();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        /// <summary>
        /// Получить обработчик операции.
        /// </summary>
        /// <param name="operation">Операция.</param>
        /// <param name="sourceFile">Путь к файлу с исходными данными.</param>
        /// <param name="destinationFile">Путь к файлу для печати результата.</param>
        /// <returns>Обработчик операции.</returns>
        public static MatrixProcessor GetMatrixProcessor(MatrixOperation operation, string sourceFile, string destinationFile)
        {
            return operation switch
            {
                MatrixOperation.Transponate => new TransponateMatrixProcessor(sourceFile, destinationFile),
                MatrixOperation.Determinant => new DeterminantMatrixProcessor(sourceFile, destinationFile),
                MatrixOperation.Add => new AddMatrixProcessor(sourceFile, destinationFile),
                _ => throw new ArgumentException("Не найдена операция."),
            };
        }
    }
}
