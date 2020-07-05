using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace TemplateMethodHomeWork
{
    public  class Args
    {
        public MatrixOperation Operation { get; set; }

        public string SourceFilePath { get; set; }

        public string DestinationFilePath { get; set; }

        public Args(string[] args)
        {
             if (args.Length != 3)
            {
                throw new ArgumentException("Укажите операцию и имена файлов для обработки.");
            }

            string operationString = args[0];
            if (!Enum.TryParse<MatrixOperation>(operationString, out MatrixOperation operation))
            {
                throw new ArgumentException("Указана неизвестная операция.");
            }

            string sourceFilePath = args[1];
            if (!File.Exists(sourceFilePath))
            {
                throw new ArgumentException($"Файл {sourceFilePath} не найден.");
            }

            Operation = operation;
            SourceFilePath = sourceFilePath;
            DestinationFilePath = args[2];
        }
    }
}
