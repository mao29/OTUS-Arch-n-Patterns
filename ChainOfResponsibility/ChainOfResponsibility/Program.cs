using System;
using System.IO;

namespace ChainOfResponsibility
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                Console.WriteLine("Необходимо указать путь к файлу со списком файлов для обработки и путь к файлу лога.");
                return;
            }

            using (var reader = new StreamReader(args[0]))
            using (var logger = new FileLogger(args[1]))
            {
                var processingChain = BuildProcessingChain(logger);

                var filePath = reader.ReadLine();
                while (filePath != null)
                {
                    processingChain.ProcessFile(filePath);

                    filePath = reader.ReadLine();
                }

                logger.WriteMessage("Обработка файлов завершена.");
            }
        }

        /// <summary>
        /// Построить цепочку обработчиков файлов.
        /// </summary>
        /// <param name="logger">Логгер.</param>
        /// <returns>Первый обработчик цепочки обработчиков.</returns>
        private static IFileProcessor BuildProcessingChain(FileLogger logger)
        {
            var txtProcessor = new TxtFileProcessor(logger);
            var csvProcessor = new CsvFileProcessor(logger);
            var xmlProcessor = new XmlFileProcessor(logger);
            var jsonProcessor = new JsonFileProcessor(logger);
            txtProcessor.SetNext(csvProcessor);
            csvProcessor.SetNext(xmlProcessor);
            xmlProcessor.SetNext(jsonProcessor);

            return txtProcessor;
        }
    }
}
