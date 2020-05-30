using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace DecoratorHomeWork
{
    internal class Args
    {
        public SortingMethod SortingMethod { get; set; }

        public string SourceFilePath { get; set; }

        public string DestinationFilePath { get; set; }

        public Args(string[] args)
        {
             if (args.Length != 3)
            {
                throw new ArgumentException("Укажите метод сортировки и имена файлов для обработки.");
            }

            string sortMethodString = args[0];
            if (!Enum.TryParse<SortingMethod>(sortMethodString, out SortingMethod sortingMethod))
            {
                throw new ArgumentException("Указан некорректный метод сортировки.");
            }

            string sourceFilePath = args[1];
            if (!File.Exists(sourceFilePath))
            {
                throw new ArgumentException($"Файл {sourceFilePath} не найден.");
            }

            SortingMethod = sortingMethod;
            SourceFilePath = sourceFilePath;
            DestinationFilePath = args[2];
        }
    }
}
