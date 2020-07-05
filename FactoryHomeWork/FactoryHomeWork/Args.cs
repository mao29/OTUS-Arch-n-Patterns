using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace FactoryHomeWork
{
    internal class Args
    {
        public SortingMethod SortingMethod { get; set; }

        public Separator Separator { get; set; }

        public string SourceFilePath { get; set; }

        public string DestinationFilePath { get; set; }

        public Args(string[] args)
        {
            if (args.Length != 4)
            {
                throw new ArgumentException("Укажите метод сортировки, имена файлов для обработки и разделитель.");
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

            string separatorString = args[3];
            if (!Enum.TryParse(separatorString, out Separator separator))
            {
                throw new ArgumentException("Указан неверный разделитель.");
            }

            SortingMethod = sortingMethod;
            Separator = separator;
            SourceFilePath = sourceFilePath;
            DestinationFilePath = args[2];
        }
    }
}
